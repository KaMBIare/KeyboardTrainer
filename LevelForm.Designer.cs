namespace KeyboardTrainer
{
    partial class LevelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelForm));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 193);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 245);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Thistle;
            label1.Font = new Font("Segoe UI", 24F);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(443, 80);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(105, 45);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.lineBG;
            pictureBox2.Location = new Point(-38, 65);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1034, 74);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(592, 20);
            label3.Name = "label3";
            label3.Size = new Size(73, 28);
            label3.TabIndex = 5;
            label3.Text = "Время:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(671, 20);
            label4.Name = "label4";
            label4.Size = new Size(60, 28);
            label4.TabIndex = 6;
            label4.Text = "00:00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(118, 20);
            label5.Name = "label5";
            label5.Size = new Size(61, 28);
            label5.TabIndex = 8;
            label5.Text = "100%";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(12, 20);
            label6.Name = "label6";
            label6.Size = new Size(100, 28);
            label6.TabIndex = 7;
            label6.Text = "Точность:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(719, 162);
            label7.Name = "label7";
            label7.Size = new Size(69, 28);
            label7.TabIndex = 9;
            label7.Text = "Выйти";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15F);
            label8.Location = new Point(427, 20);
            label8.Name = "label8";
            label8.Size = new Size(39, 28);
            label8.TabIndex = 12;
            label8.Text = "0%";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F);
            label9.Location = new Point(321, 20);
            label9.Name = "label9";
            label9.Size = new Size(102, 28);
            label9.TabIndex = 11;
            label9.Text = "Прогресс:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Thistle;
            label10.Font = new Font("Segoe UI", 40F);
            label10.Location = new Point(376, 65);
            label10.Name = "label10";
            label10.Size = new Size(61, 72);
            label10.TabIndex = 13;
            label10.Text = "п";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Thistle;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 24F);
            textBox1.ForeColor = SystemColors.ControlDarkDark;
            textBox1.Location = new Point(12, 80);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.RightToLeft = RightToLeft.Yes;
            textBox1.Size = new Size(346, 43);
            textBox1.TabIndex = 14;
            textBox1.TabStop = false;
            textBox1.Text = "Text";
            textBox1.UseWaitCursor = true;
            // 
            // LevelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            KeyPreview = true;
            Name = "LevelForm";
            Text = "LevelForm";
            Load += LevelForm_Load;
            KeyDown += KeyDownLevel;
            KeyUp += KeyUpLevel;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox1;
    }
}