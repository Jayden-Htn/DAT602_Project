namespace GameApp
{
    partial class frmLobby
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
            lblHeading = new Label();
            btnAdmin = new Button();
            btnGame = new Button();
            SuspendLayout();
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeading.Location = new Point(52, 35);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(57, 21);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Lobby";
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(199, 91);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(102, 31);
            btnAdmin.TabIndex = 1;
            btnAdmin.Text = "Admin";
            btnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnGame
            // 
            btnGame.Location = new Point(52, 91);
            btnGame.Name = "btnGame";
            btnGame.Size = new Size(102, 31);
            btnGame.TabIndex = 2;
            btnGame.Text = "Start Game";
            btnGame.UseVisualStyleBackColor = true;
            // 
            // frmLobby
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGame);
            Controls.Add(btnAdmin);
            Controls.Add(lblHeading);
            Name = "frmLobby";
            Text = "Lobby";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeading;
        private Button btnAdmin;
        private Button btnGame;
    }
}