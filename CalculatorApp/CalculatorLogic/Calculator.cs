// <copyright file="Calculator.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace CalculatorLogic;

/// <summary>
/// Class with business logic for calculator.
/// </summary>
public class Calculator
{
    /// <summary>
    /// Indicates whether an operator has been entered.
    /// </summary>
    private bool hasOperator = false;

    /// <summary>
    /// Gets the current result.
    /// </summary>
    public double CurrentResult { get; private set; } = 0;

    /// <summary>
    /// Gets the current operator.
    /// </summary>
    public string CurrentOperator { get; private set; } = string.Empty;

    /// <summary>
    /// Enters a number and performs the calculation if the operator has already been entered.
    /// </summary>
    /// <param name="number">The number to enter.</param>
    /// <exception cref="DivideByZeroException">Throws when dividing by zero.</exception>
    public void EnterNumber(double number)
    {
        if (!this.hasOperator)
        {
            this.CurrentResult = number;
        }
        else
        {
            switch (this.CurrentOperator)
            {
                case "+": this.CurrentResult += number;
                    break;
                case "-":
                    this.CurrentResult -= number;
                    break;
                case "*":
                    this.CurrentResult *= number;
                    break;
                case "/":
                    if (number == 0)
                    {
                        throw new DivideByZeroException();
                    }

                    this.CurrentResult /= number;
                    break;
            }

            this.hasOperator = false;
        }
    }

    /// <summary>
    /// Enters an operator.
    /// </summary>
    /// <param name="currentOperator">The operator.</param>
    /// <exception cref="Exception">Thrown when an unknown operator is entered.</exception>
    public void EnterOperator(string currentOperator)
    {
        if (currentOperator == "+" || currentOperator == "-" ||
            currentOperator == "*" || currentOperator == "/")
        {
            this.CurrentOperator = currentOperator;
            this.hasOperator = true;
        }
        else
        {
            throw new Exception("Unknown operator");
        }
    }

    /// <summary>
    /// Resets to initial state.
    /// </summary>
    public void Reset()
    {
        this.CurrentResult = 0;
        this.CurrentOperator = string.Empty;
        this.hasOperator = false;
    }
}
