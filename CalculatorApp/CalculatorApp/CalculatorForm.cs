// <copyright file="Calculator.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace CalculatorApp;

using CalculatorLogic;

/// <summary>
/// Represents the main form of the calculator app.
/// </summary>
public partial class CalculatorForm : Form
{
    private readonly Calculator calculator = new();
    private bool waitingOperand = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorForm"/> class.
    /// </summary>
    public CalculatorForm()
    {
        this.InitializeComponent();

        foreach (Control ctrl in this.tableLayoutPanel.Controls)
        {
            if (ctrl is Button button)
            {
                button.Click += this.ButtonClick;
            }
        }
    }

    private void ButtonClick(object? sender, EventArgs e)
    {
        var button = (Button)sender!;
        var text = button.Text;

        if (char.IsDigit(text[0]))
        {
            if (this.waitingOperand)
            {
                this.textBox.Text = string.Empty;
                this.waitingOperand = false;
            }

            this.textBox.Text += text;
        }
        else if (text == "C")
        {
            this.calculator.Reset();
            this.textBox.Text = string.Empty;
            this.waitingOperand = false;
        }
        else if (text == "=")
        {
            if (double.TryParse(this.textBox.Text, out double number))
            {
                this.calculator.EnterNumber(number);
                this.textBox.Text = this.calculator.CurrentResult.ToString();
                this.waitingOperand = true;
            }
        }
        else
        {
            if (double.TryParse(this.textBox.Text, out double number))
            {
                this.calculator.EnterNumber(number);
                this.calculator.EnterOperator(text);
                this.textBox.Text = this.calculator.CurrentResult.ToString();
                this.waitingOperand = true;
            }
        }
    }
}
