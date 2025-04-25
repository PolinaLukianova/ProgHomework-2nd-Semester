// <copyright file="Calculator.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace CalculatorLogic.Tests;

public class CalculatorLogicTests
{
    private Calculator calc;

    [SetUp]
    public void Setup()
    {
        this.calc = new Calculator();
    }

    [Test]
    public void EnterNumber_CurrentResultShouldAssignEnterNumber()
    {
        this.calc.EnterNumber(5);
        Assert.That(this.calc.CurrentResult, Is.EqualTo(5));
    }

    [Test]
    public void EnterOperator_CurrentOperatorShouldAssignEnterOperator()
    {
        this.calc.EnterOperator("+");
        Assert.That(this.calc.CurrentOperator, Is.EqualTo("+"));
    }

    [Test]
    public void EnterExpressionAdd_ShouldReturnValueOfExpression()
    {
        this.calc.EnterNumber(5);
        this.calc.EnterOperator("+");
        this.calc.EnterNumber(7);
        Assert.That(this.calc.CurrentResult, Is.EqualTo(12));
    }

    [Test]
    public void EnterExpressionSubtract_ShouldReturnValueOfExpression()
    {
        this.calc.EnterNumber(10);
        this.calc.EnterOperator("-");
        this.calc.EnterNumber(7);
        Assert.That(this.calc.CurrentResult, Is.EqualTo(3));
    }

    [Test]
    public void EnterExpressionMult_ShouldReturnValueOfExpression()
    {
        this.calc.EnterNumber(5);
        this.calc.EnterOperator("*");
        this.calc.EnterNumber(3);
        Assert.That(this.calc.CurrentResult, Is.EqualTo(15));
    }

    [Test]
    public void EnterExpressionDiv_ShouldReturnValueOfExpression()
    {
        this.calc.EnterNumber(15);
        this.calc.EnterOperator("/");
        this.calc.EnterNumber(3);
        Assert.That(this.calc.CurrentResult, Is.EqualTo(5));
    }

    [Test]
    public void EnterSomeExpressions_ShouldReturnValueOfExpressions()
    {
        this.calc.EnterNumber(15);
        this.calc.EnterOperator("/");
        this.calc.EnterNumber(3);
        this.calc.EnterOperator("+");
        this.calc.EnterNumber(20);
        this.calc.EnterOperator("-");
        this.calc.EnterNumber(5);
        this.calc.EnterOperator("*");
        this.calc.EnterNumber(2);
        Assert.That(this.calc.CurrentResult, Is.EqualTo(40));
    }

    [Test]
    public void DivOnZero_ShouldThrowException()
    {
        this.calc.EnterNumber(15);
        this.calc.EnterOperator("/");
        Assert.Throws<DivideByZeroException>(() => this.calc.EnterNumber(0));
    }

    [Test]
    public void UnknownOperator_ShouldThrowException()
    {
        this.calc.EnterNumber(15);
        Assert.Throws<Exception>(() => this.calc.EnterOperator("&"), "Unknown operator.");
    }

    [Test]
    public void Reset_ShouldResetAssignedValue()
    {
        this.calc.EnterNumber(5);
        this.calc.EnterOperator("*");
        this.calc.EnterNumber(3);
        this.calc.Reset();
        Assert.Multiple(() =>
        {
            Assert.That(this.calc.CurrentResult, Is.EqualTo(0));
            Assert.That(this.calc.CurrentOperator, Is.EqualTo(string.Empty));
        });
    }
}
