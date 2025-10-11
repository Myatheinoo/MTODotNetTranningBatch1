namespace MTODotNetTrainingBatch1.WinFormsApp1
{
    partial class FrmLogin
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
            BtnClick = new Button();
            BtnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            textUsername = new TextBox();
            textPassword = new TextBox();
            SuspendLayout();
            // 
            // BtnClick
            // 
            BtnClick.BackColor = Color.FromArgb(46, 125, 50);
            BtnClick.FlatStyle = FlatStyle.Flat;
            BtnClick.Font = new Font("Segoe UI", 12F);
            BtnClick.ForeColor = Color.White;
            BtnClick.Location = new Point(389, 235);
            BtnClick.Name = "BtnClick";
            BtnClick.Size = new Size(112, 55);
            BtnClick.TabIndex = 0;
            BtnClick.Text = "Login";
            BtnClick.UseVisualStyleBackColor = false;
            BtnClick.Click += BtnLogin_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.BackColor = Color.FromArgb(55, 71, 79);
            BtnCancel.FlatStyle = FlatStyle.Flat;
            BtnCancel.Font = new Font("Segoe UI", 12F);
            BtnCancel.ForeColor = Color.White;
            BtnCancel.Location = new Point(228, 235);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(112, 55);
            BtnCancel.TabIndex = 1;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = false;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(27, 28);
            label1.Name = "label1";
            label1.Size = new Size(132, 32);
            label1.TabIndex = 2;
            label1.Text = "User Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(27, 138);
            label2.Name = "label2";
            label2.Size = new Size(111, 32);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // textUsername
            // 
            textUsername.Font = new Font("Segoe UI", 12F);
            textUsername.Location = new Point(27, 63);
            textUsername.Name = "textUsername";
            textUsername.Size = new Size(503, 39);
            textUsername.TabIndex = 4;
            textUsername.KeyDown += textUsername_KeyDown;
            // 
            // textPassword
            // 
            textPassword.Font = new Font("Segoe UI", 12F);
            textPassword.Location = new Point(27, 173);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(503, 39);
            textPassword.TabIndex = 5;
            textPassword.UseSystemPasswordChar = true;
            textPassword.KeyDown += textPassword_KeyDown;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 361);
            Controls.Add(textPassword);
            Controls.Add(textUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnCancel);
            Controls.Add(BtnClick);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnClick;
        private Button BtnCancel;
        private Label label1;
        private Label label2;
        private TextBox textUsername;
        private TextBox textPassword;
    }
}
