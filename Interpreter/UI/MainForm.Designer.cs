namespace Interpreter.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.translateInputTextBox = new System.Windows.Forms.TextBox();
            this.translateOutputTextBox = new System.Windows.Forms.TextBox();
            this.translateButton = new System.Windows.Forms.Button();
            this.inputLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.outputLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.determineButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // translateInputTextBox
            // 
            this.translateInputTextBox.Location = new System.Drawing.Point(27, 50);
            this.translateInputTextBox.Multiline = true;
            this.translateInputTextBox.Name = "translateInputTextBox";
            this.translateInputTextBox.Size = new System.Drawing.Size(365, 223);
            this.translateInputTextBox.TabIndex = 0;
            // 
            // translateOutputTextBox
            // 
            this.translateOutputTextBox.Location = new System.Drawing.Point(398, 50);
            this.translateOutputTextBox.Multiline = true;
            this.translateOutputTextBox.Name = "translateOutputTextBox";
            this.translateOutputTextBox.Size = new System.Drawing.Size(365, 223);
            this.translateOutputTextBox.TabIndex = 1;
            // 
            // translateButton
            // 
            this.translateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.translateButton.Location = new System.Drawing.Point(525, 22);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(75, 23);
            this.translateButton.TabIndex = 2;
            this.translateButton.Text = "Translate";
            this.translateButton.UseVisualStyleBackColor = true;
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // inputLanguageComboBox
            // 
            this.inputLanguageComboBox.Location = new System.Drawing.Point(27, 23);
            this.inputLanguageComboBox.Name = "inputLanguageComboBox";
            this.inputLanguageComboBox.Size = new System.Drawing.Size(121, 21);
            this.inputLanguageComboBox.TabIndex = 3;
            // 
            // outputLanguageComboBox
            // 
            this.outputLanguageComboBox.Location = new System.Drawing.Point(398, 23);
            this.outputLanguageComboBox.Name = "outputLanguageComboBox";
            this.outputLanguageComboBox.Size = new System.Drawing.Size(121, 21);
            this.outputLanguageComboBox.TabIndex = 4;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(24, 277);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 13);
            this.messageLabel.TabIndex = 5;
            // 
            // determineButton
            // 
            this.determineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.determineButton.Location = new System.Drawing.Point(155, 22);
            this.determineButton.Name = "determineButton";
            this.determineButton.Size = new System.Drawing.Size(149, 23);
            this.determineButton.TabIndex = 6;
            this.determineButton.Text = "Determine the language";
            this.determineButton.UseVisualStyleBackColor = true;
            this.determineButton.Click += new System.EventHandler(this.determineButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 299);
            this.Controls.Add(this.determineButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.outputLanguageComboBox);
            this.Controls.Add(this.inputLanguageComboBox);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.translateOutputTextBox);
            this.Controls.Add(this.translateInputTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Translator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox translateInputTextBox;
        private System.Windows.Forms.TextBox translateOutputTextBox;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.ComboBox inputLanguageComboBox;
        private System.Windows.Forms.ComboBox outputLanguageComboBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button determineButton;
    }
}

