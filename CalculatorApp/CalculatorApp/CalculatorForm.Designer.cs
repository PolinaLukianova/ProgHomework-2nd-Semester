namespace CalculatorApp;

partial class CalculatorForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
        textBox = new TextBox();
        tableLayoutPanel = new TableLayoutPanel();
        plus = new Button();
        equal = new Button();
        button0 = new Button();
        clear = new Button();
        minus = new Button();
        button3 = new Button();
        button2 = new Button();
        button1 = new Button();
        multiply = new Button();
        button6 = new Button();
        button5 = new Button();
        button4 = new Button();
        divide = new Button();
        button9 = new Button();
        button7 = new Button();
        button8 = new Button();
        tableLayoutPanel.SuspendLayout();
        SuspendLayout();
        // 
        // textBox
        // 
        textBox.BackColor = SystemColors.ControlLightLight;
        textBox.Dock = DockStyle.Top;
        textBox.Font = new Font("Segoe UI", 35F);
        textBox.Location = new Point(0, 0);
        textBox.Name = "textBox";
        textBox.ReadOnly = true;
        textBox.Size = new Size(332, 85);
        textBox.TabIndex = 0;
        textBox.TextAlign = HorizontalAlignment.Right;
        // 
        // tableLayoutPanel
        // 
        tableLayoutPanel.ColumnCount = 4;
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel.Controls.Add(plus, 3, 3);
        tableLayoutPanel.Controls.Add(equal, 2, 3);
        tableLayoutPanel.Controls.Add(button0, 1, 3);
        tableLayoutPanel.Controls.Add(clear, 0, 3);
        tableLayoutPanel.Controls.Add(minus, 3, 2);
        tableLayoutPanel.Controls.Add(button3, 2, 2);
        tableLayoutPanel.Controls.Add(button2, 1, 2);
        tableLayoutPanel.Controls.Add(button1, 0, 2);
        tableLayoutPanel.Controls.Add(multiply, 3, 1);
        tableLayoutPanel.Controls.Add(button6, 2, 1);
        tableLayoutPanel.Controls.Add(button5, 1, 1);
        tableLayoutPanel.Controls.Add(button4, 0, 1);
        tableLayoutPanel.Controls.Add(divide, 3, 0);
        tableLayoutPanel.Controls.Add(button9, 2, 0);
        tableLayoutPanel.Controls.Add(button7, 0, 0);
        tableLayoutPanel.Controls.Add(button8, 1, 0);
        tableLayoutPanel.Dock = DockStyle.Fill;
        tableLayoutPanel.Location = new Point(0, 85);
        tableLayoutPanel.Name = "tableLayoutPanel";
        tableLayoutPanel.RowCount = 4;
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel.Size = new Size(332, 348);
        tableLayoutPanel.TabIndex = 1;
        // 
        // plus
        // 
        plus.Dock = DockStyle.Fill;
        plus.Font = new Font("Segoe UI", 15F);
        plus.Location = new Point(252, 264);
        plus.Name = "plus";
        plus.Size = new Size(77, 81);
        plus.TabIndex = 15;
        plus.Text = "+";
        plus.UseVisualStyleBackColor = true;
        // 
        // equal
        // 
        equal.Dock = DockStyle.Fill;
        equal.Font = new Font("Segoe UI", 15F);
        equal.Location = new Point(169, 264);
        equal.Name = "equal";
        equal.Size = new Size(77, 81);
        equal.TabIndex = 14;
        equal.Text = "=";
        equal.UseVisualStyleBackColor = true;
        // 
        // button0
        // 
        button0.Dock = DockStyle.Fill;
        button0.Font = new Font("Segoe UI", 15F);
        button0.Location = new Point(86, 264);
        button0.Name = "button0";
        button0.Size = new Size(77, 81);
        button0.TabIndex = 13;
        button0.Text = "0";
        button0.UseVisualStyleBackColor = true;
        // 
        // clear
        // 
        clear.Dock = DockStyle.Fill;
        clear.Font = new Font("Segoe UI", 15F);
        clear.Location = new Point(3, 264);
        clear.Name = "clear";
        clear.Size = new Size(77, 81);
        clear.TabIndex = 12;
        clear.Text = "C";
        clear.UseVisualStyleBackColor = true;
        // 
        // minus
        // 
        minus.Dock = DockStyle.Fill;
        minus.Font = new Font("Segoe UI", 15F);
        minus.Location = new Point(252, 177);
        minus.Name = "minus";
        minus.Size = new Size(77, 81);
        minus.TabIndex = 11;
        minus.Text = "-";
        minus.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Dock = DockStyle.Fill;
        button3.Font = new Font("Segoe UI", 15F);
        button3.Location = new Point(169, 177);
        button3.Name = "button3";
        button3.Size = new Size(77, 81);
        button3.TabIndex = 10;
        button3.Text = "3";
        button3.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.Dock = DockStyle.Fill;
        button2.Font = new Font("Segoe UI", 15F);
        button2.Location = new Point(86, 177);
        button2.Name = "button2";
        button2.Size = new Size(77, 81);
        button2.TabIndex = 9;
        button2.Text = "2";
        button2.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        button1.Dock = DockStyle.Fill;
        button1.Font = new Font("Segoe UI", 15F);
        button1.Location = new Point(3, 177);
        button1.Name = "button1";
        button1.Size = new Size(77, 81);
        button1.TabIndex = 8;
        button1.Text = "1";
        button1.UseVisualStyleBackColor = true;
        // 
        // multiply
        // 
        multiply.Dock = DockStyle.Fill;
        multiply.Font = new Font("Segoe UI", 15F);
        multiply.Location = new Point(252, 90);
        multiply.Name = "multiply";
        multiply.Size = new Size(77, 81);
        multiply.TabIndex = 7;
        multiply.Text = "*";
        multiply.UseVisualStyleBackColor = true;
        // 
        // button6
        // 
        button6.Dock = DockStyle.Fill;
        button6.Font = new Font("Segoe UI", 15F);
        button6.Location = new Point(169, 90);
        button6.Name = "button6";
        button6.Size = new Size(77, 81);
        button6.TabIndex = 6;
        button6.Text = "6";
        button6.UseVisualStyleBackColor = true;
        // 
        // button5
        // 
        button5.Dock = DockStyle.Fill;
        button5.Font = new Font("Segoe UI", 15F);
        button5.Location = new Point(86, 90);
        button5.Name = "button5";
        button5.Size = new Size(77, 81);
        button5.TabIndex = 5;
        button5.Text = "5";
        button5.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.Dock = DockStyle.Fill;
        button4.Font = new Font("Segoe UI", 15F);
        button4.Location = new Point(3, 90);
        button4.Name = "button4";
        button4.Size = new Size(77, 81);
        button4.TabIndex = 4;
        button4.Text = "4";
        button4.UseVisualStyleBackColor = true;
        // 
        // divide
        // 
        divide.Dock = DockStyle.Fill;
        divide.Font = new Font("Segoe UI", 15F);
        divide.Location = new Point(252, 3);
        divide.Name = "divide";
        divide.Size = new Size(77, 81);
        divide.TabIndex = 3;
        divide.Text = "/";
        divide.UseVisualStyleBackColor = true;
        // 
        // button9
        // 
        button9.Dock = DockStyle.Fill;
        button9.Font = new Font("Segoe UI", 15F);
        button9.Location = new Point(169, 3);
        button9.Name = "button9";
        button9.Size = new Size(77, 81);
        button9.TabIndex = 2;
        button9.Text = "9";
        button9.UseVisualStyleBackColor = true;
        // 
        // button7
        // 
        button7.Dock = DockStyle.Fill;
        button7.Font = new Font("Segoe UI", 15F);
        button7.Location = new Point(3, 3);
        button7.Name = "button7";
        button7.Size = new Size(77, 81);
        button7.TabIndex = 0;
        button7.Text = "7";
        button7.UseVisualStyleBackColor = true;
        // 
        // button8
        // 
        button8.Dock = DockStyle.Fill;
        button8.Font = new Font("Segoe UI", 15F);
        button8.Location = new Point(86, 3);
        button8.Name = "button8";
        button8.Size = new Size(77, 81);
        button8.TabIndex = 1;
        button8.Text = "8";
        button8.UseVisualStyleBackColor = true;
        // 
        // CalculatorForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        ClientSize = new Size(332, 433);
        Controls.Add(tableLayoutPanel);
        Controls.Add(textBox);
        ForeColor = SystemColors.ActiveCaptionText;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(220, 320);
        Name = "CalculatorForm";
        Text = "Calculator";
        tableLayoutPanel.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox textBox;
    private TableLayoutPanel tableLayoutPanel;
    private Button plus;
    private Button equal;
    private Button button0;
    private Button clear;
    private Button minus;
    private Button button3;
    private Button button2;
    private Button button1;
    private Button multiply;
    private Button button6;
    private Button button5;
    private Button button4;
    private Button divide;
    private Button button9;
    private Button button7;
    private Button button8;
}
