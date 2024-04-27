namespace KeyboardTrainer
{
    partial class LogInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            KeyPreview = true;
            label1 = new Label();
            label2 = new Label();
            NameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            button1 = new Button();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(279, 77);
            label1.Name = "label1";
            label1.Size = new Size(55, 28);
            label1.TabIndex = 0;
            label1.Text = "Имя:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(279, 139);
            label2.Name = "label2";
            label2.Size = new Size(85, 28);
            label2.TabIndex = 1;
            label2.Text = "Пароль:";
            // 
            // NameTextBox
            // 
            NameTextBox.Font = new Font("Segoe UI", 15F);
            NameTextBox.Location = new Point(279, 108);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(216, 34);
            NameTextBox.TabIndex = 2;
            NameTextBox.TextChanged += textBox1_TextChanged_1;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Font = new Font("Segoe UI", 15F);
            PasswordTextBox.Location = new Point(279, 170);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(216, 34);
            PasswordTextBox.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(340, 210);
            button1.Name = "button1";
            button1.Size = new Size(83, 40);
            button1.TabIndex = 4;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Font = new Font("Segoe UI", 13F);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(234, 276);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 25);
            errorLabel.TabIndex = 5;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(errorLabel);
            Controls.Add(button1);
            Controls.Add(PasswordTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LogInForm";
            Text = "LogInForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox NameTextBox;
        private TextBox PasswordTextBox;
        private Button button1;
        private Label errorLabel;
    }
}