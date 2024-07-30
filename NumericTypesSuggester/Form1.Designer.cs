namespace NumericTypesSuggester
{
    partial class MainForm
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
            MinValueLabel = new Label();
            MaxValueLabel = new Label();
            MinValueTextBox = new TextBox();
            MaxValueTextBox = new TextBox();
            IntegralOnlyCheckBox = new CheckBox();
            MustBePreciseCheckBox = new CheckBox();
            ResultLabel = new Label();
            SuspendLayout();
            // 
            // MinValueLabel
            // 
            MinValueLabel.AutoSize = true;
            MinValueLabel.Font = new Font("Segoe UI", 20F);
            MinValueLabel.Location = new Point(33, 48);
            MinValueLabel.Name = "MinValueLabel";
            MinValueLabel.Size = new Size(139, 37);
            MinValueLabel.TabIndex = 0;
            MinValueLabel.Text = "Min value:";
            // 
            // MaxValueLabel
            // 
            MaxValueLabel.AutoSize = true;
            MaxValueLabel.Font = new Font("Segoe UI", 20F);
            MaxValueLabel.Location = new Point(33, 122);
            MaxValueLabel.Name = "MaxValueLabel";
            MaxValueLabel.Size = new Size(143, 37);
            MaxValueLabel.TabIndex = 1;
            MaxValueLabel.Text = "Max value:";
            // 
            // MinValueTextBox
            // 
            MinValueTextBox.Font = new Font("Segoe UI", 20F);
            MinValueTextBox.Location = new Point(188, 45);
            MinValueTextBox.Name = "MinValueTextBox";
            MinValueTextBox.Size = new Size(711, 43);
            MinValueTextBox.TabIndex = 2;
            // 
            // MaxValueTextBox
            // 
            MaxValueTextBox.Font = new Font("Segoe UI", 20F);
            MaxValueTextBox.Location = new Point(188, 119);
            MaxValueTextBox.Name = "MaxValueTextBox";
            MaxValueTextBox.Size = new Size(711, 43);
            MaxValueTextBox.TabIndex = 3;
            // 
            // IntegralOnlyCheckBox
            // 
            IntegralOnlyCheckBox.AutoSize = true;
            IntegralOnlyCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            IntegralOnlyCheckBox.Checked = true;
            IntegralOnlyCheckBox.CheckState = CheckState.Checked;
            IntegralOnlyCheckBox.Font = new Font("Segoe UI", 20F);
            IntegralOnlyCheckBox.Location = new Point(70, 208);
            IntegralOnlyCheckBox.Name = "IntegralOnlyCheckBox";
            IntegralOnlyCheckBox.Size = new Size(197, 41);
            IntegralOnlyCheckBox.TabIndex = 4;
            IntegralOnlyCheckBox.Text = "Integral only?";
            IntegralOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // MustBePreciseCheckBox
            // 
            MustBePreciseCheckBox.AutoSize = true;
            MustBePreciseCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            MustBePreciseCheckBox.Font = new Font("Segoe UI", 20F);
            MustBePreciseCheckBox.Location = new Point(33, 272);
            MustBePreciseCheckBox.Name = "MustBePreciseCheckBox";
            MustBePreciseCheckBox.Size = new Size(234, 41);
            MustBePreciseCheckBox.TabIndex = 5;
            MustBePreciseCheckBox.Text = "Must be precise?";
            MustBePreciseCheckBox.UseVisualStyleBackColor = true;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            ResultLabel.Location = new Point(33, 345);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(444, 37);
            ResultLabel.TabIndex = 6;
            ResultLabel.Text = "Suggested type: not enough data";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(957, 418);
            Controls.Add(ResultLabel);
            Controls.Add(MustBePreciseCheckBox);
            Controls.Add(IntegralOnlyCheckBox);
            Controls.Add(MaxValueTextBox);
            Controls.Add(MinValueTextBox);
            Controls.Add(MaxValueLabel);
            Controls.Add(MinValueLabel);
            Name = "MainForm";
            Text = "Numeric Types Suggester";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MinValueLabel;
        private Label MaxValueLabel;
        private TextBox MinValueTextBox;
        private TextBox MaxValueTextBox;
        private CheckBox IntegralOnlyCheckBox;
        private CheckBox MustBePreciseCheckBox;
        private Label ResultLabel;
    }
}
