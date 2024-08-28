namespace GameApp
{
    partial class frmLogin
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
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnSubmit = new Button();
            lblTitle1 = new Label();
            lblTitle2 = new Label();
            lblHeading = new Label();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(123, 170);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(81, 21);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(224, 170);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(135, 29);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(131, 225);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(76, 21);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(224, 222);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(135, 29);
            txtPassword.TabIndex = 2;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(180, 286);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(101, 29);
            btnSubmit.TabIndex = 3;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new Font("Cooper Black", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle1.ForeColor = Color.FromArgb(255, 128, 0);
            lblTitle1.Location = new Point(152, 19);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(187, 42);
            lblTitle1.TabIndex = 5;
            lblTitle1.Text = "Survivor";
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new Font("Cooper Black", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle2.ForeColor = Color.Green;
            lblTitle2.Location = new Point(179, 59);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(133, 42);
            lblTitle2.TabIndex = 6;
            lblTitle2.Text = "Island";
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeading.Location = new Point(184, 122);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(122, 21);
            lblHeading.TabIndex = 10;
            lblHeading.Text = "Login/Register";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 382);
            Controls.Add(lblHeading);
            Controls.Add(lblTitle2);
            Controls.Add(lblTitle1);
            Controls.Add(btnSubmit);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Name = "frmLogin";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnSubmit;
        private Label lblTitle1;
        private Label lblTitle2;
        private Label lblHeading;
    }
}
