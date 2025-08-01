namespace Lab_12
{
    partial class PlotForm
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
            lbl_leftBoundary = new Label();
            lbl_rightBoundary = new Label();
            leftBoundary = new TextBox();
            rightBoundary = new TextBox();
            label3 = new Label();
            epsilon = new TextBox();
            SolveTheEquation_btn = new Button();
            label4 = new Label();
            solution = new TextBox();
            label5 = new Label();
            iterations = new TextBox();
            button2 = new Button();
            SolveMethod = new ComboBox();
            lbl_SolveMethod = new Label();
            panel1 = new Panel();
            Equation = new ComboBox();
            label1 = new Label();
            LBL = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_leftBoundary
            // 
            lbl_leftBoundary.AutoSize = true;
            lbl_leftBoundary.Location = new Point(16, 132);
            lbl_leftBoundary.Name = "lbl_leftBoundary";
            lbl_leftBoundary.Size = new Size(171, 20);
            lbl_leftBoundary.TabIndex = 0;
            lbl_leftBoundary.Text = "Левая граница отрезка";
            // 
            // lbl_rightBoundary
            // 
            lbl_rightBoundary.AutoSize = true;
            lbl_rightBoundary.Location = new Point(11, 185);
            lbl_rightBoundary.Name = "lbl_rightBoundary";
            lbl_rightBoundary.Size = new Size(181, 20);
            lbl_rightBoundary.TabIndex = 1;
            lbl_rightBoundary.Text = "Правая граница отрезка";
            // 
            // leftBoundary
            // 
            leftBoundary.Location = new Point(11, 155);
            leftBoundary.Name = "leftBoundary";
            leftBoundary.Size = new Size(181, 27);
            leftBoundary.TabIndex = 2;
            leftBoundary.TextChanged += leftBoundary_TextChanged;
            // 
            // rightBoundary
            // 
            rightBoundary.Location = new Point(11, 208);
            rightBoundary.Name = "rightBoundary";
            rightBoundary.Size = new Size(181, 27);
            rightBoundary.TabIndex = 3;
            rightBoundary.TextChanged += rightBoundary_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 238);
            label3.Name = "label3";
            label3.Size = new Size(170, 20);
            label3.TabIndex = 4;
            label3.Text = "Погрешность решения";
            // 
            // epsilon
            // 
            epsilon.Location = new Point(11, 261);
            epsilon.Name = "epsilon";
            epsilon.Size = new Size(181, 27);
            epsilon.TabIndex = 5;
            epsilon.Text = "0.1e-6";
            epsilon.TextChanged += epsilon_TextChanged;
            // 
            // SolveTheEquation_btn
            // 
            SolveTheEquation_btn.Location = new Point(11, 294);
            SolveTheEquation_btn.Name = "SolveTheEquation_btn";
            SolveTheEquation_btn.Size = new Size(181, 29);
            SolveTheEquation_btn.TabIndex = 6;
            SolveTheEquation_btn.Text = "Решить уравнение";
            SolveTheEquation_btn.UseVisualStyleBackColor = true;
            SolveTheEquation_btn.Click += SolveTheEquation_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 339);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 7;
            label4.Text = "Решение";
            // 
            // solution
            // 
            solution.Location = new Point(11, 362);
            solution.Name = "solution";
            solution.ReadOnly = true;
            solution.Size = new Size(181, 27);
            solution.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 392);
            label5.Name = "label5";
            label5.Size = new Size(161, 20);
            label5.TabIndex = 9;
            label5.Text = "Количество итераций";
            // 
            // iterations
            // 
            iterations.Location = new Point(11, 415);
            iterations.Name = "iterations";
            iterations.ReadOnly = true;
            iterations.Size = new Size(181, 27);
            iterations.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(11, 448);
            button2.Name = "button2";
            button2.Size = new Size(181, 29);
            button2.TabIndex = 11;
            button2.Text = "Построить график";
            button2.UseVisualStyleBackColor = true;
            // 
            // SolveMethod
            // 
            SolveMethod.DropDownWidth = 500;
            SolveMethod.FormattingEnabled = true;
            SolveMethod.Location = new Point(11, 33);
            SolveMethod.Name = "SolveMethod";
            SolveMethod.Size = new Size(181, 28);
            SolveMethod.Sorted = true;
            SolveMethod.TabIndex = 12;
            SolveMethod.Text = "Выберите метод";
            SolveMethod.SelectedIndexChanged += SolveMethod_SelectedIndexChanged;
            // 
            // lbl_SolveMethod
            // 
            lbl_SolveMethod.AutoSize = true;
            lbl_SolveMethod.Location = new Point(41, 10);
            lbl_SolveMethod.Name = "lbl_SolveMethod";
            lbl_SolveMethod.Size = new Size(120, 20);
            lbl_SolveMethod.TabIndex = 13;
            lbl_SolveMethod.Text = "Метод решения";
            // 
            // panel1
            // 
            panel1.Controls.Add(Equation);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(lbl_SolveMethod);
            panel1.Controls.Add(lbl_leftBoundary);
            panel1.Controls.Add(SolveMethod);
            panel1.Controls.Add(lbl_rightBoundary);
            panel1.Controls.Add(leftBoundary);
            panel1.Controls.Add(iterations);
            panel1.Controls.Add(rightBoundary);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(solution);
            panel1.Controls.Add(epsilon);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(SolveTheEquation_btn);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(205, 483);
            panel1.TabIndex = 14;
            // 
            // Equation
            // 
            Equation.FormattingEnabled = true;
            Equation.Location = new Point(11, 87);
            Equation.Name = "Equation";
            Equation.Size = new Size(181, 28);
            Equation.TabIndex = 15;
            Equation.Text = "Выберите уравнение";
            Equation.SelectedIndexChanged += Equation_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 64);
            label1.Name = "label1";
            label1.Size = new Size(181, 20);
            label1.TabIndex = 14;
            label1.Text = "Уравнение для решения";
            // 
            // LBL
            // 
            LBL.AutoSize = true;
            LBL.Location = new Point(250, 48);
            LBL.Name = "LBL";
            LBL.Size = new Size(50, 20);
            LBL.TabIndex = 15;
            LBL.Text = "label2";
            // 
            // PlotForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 501);
            Controls.Add(LBL);
            Controls.Add(panel1);
            Name = "PlotForm";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_leftBoundary;
        private Label lbl_rightBoundary;
        private TextBox leftBoundary;
        private TextBox rightBoundary;
        private Label label3;
        private TextBox epsilon;
        private Button SolveTheEquation_btn;
        private Label label4;
        private TextBox solution;
        private Label label5;
        private TextBox iterations;
        private Button button2;
        private ComboBox SolveMethod;
        private Label lbl_SolveMethod;
        private Panel panel1;
        private ComboBox Equation;
        private Label label1;
        private Label LBL;
    }
}
