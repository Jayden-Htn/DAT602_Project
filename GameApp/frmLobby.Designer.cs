﻿namespace GameApp
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
            btnStartGame = new Button();
            btnLogout = new Button();
            btnAccount = new Button();
            lblHeading2 = new Label();
            lblPlayer = new Label();
            dgvOnlinePlayers = new DataGridView();
            dgvGameInvites = new DataGridView();
            btnInvite = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOnlinePlayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGameInvites).BeginInit();
            SuspendLayout();
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeading.Location = new Point(29, 71);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(120, 21);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Online Players";
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(667, 210);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(102, 31);
            btnAdmin.TabIndex = 1;
            btnAdmin.Text = "Admin";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(431, 394);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(102, 31);
            btnStartGame.TabIndex = 2;
            btnStartGame.Text = "Start Game";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(667, 105);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(102, 31);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnAccount
            // 
            btnAccount.Location = new Point(667, 158);
            btnAccount.Name = "btnAccount";
            btnAccount.Size = new Size(102, 31);
            btnAccount.TabIndex = 4;
            btnAccount.Text = "Account";
            btnAccount.UseVisualStyleBackColor = true;
            btnAccount.Click += btnAccount_Click;
            // 
            // lblHeading2
            // 
            lblHeading2.AutoSize = true;
            lblHeading2.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeading2.Location = new Point(348, 71);
            lblHeading2.Name = "lblHeading2";
            lblHeading2.Size = new Size(109, 21);
            lblHeading2.TabIndex = 5;
            lblHeading2.Text = "Game Invites";
            // 
            // lblPlayer
            // 
            lblPlayer.AutoSize = true;
            lblPlayer.Location = new Point(29, 26);
            lblPlayer.Name = "lblPlayer";
            lblPlayer.Size = new Size(74, 21);
            lblPlayer.TabIndex = 6;
            lblPlayer.Text = "Welcome";
            // 
            // dgvOnlinePlayers
            // 
            dgvOnlinePlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOnlinePlayers.Location = new Point(29, 106);
            dgvOnlinePlayers.Name = "dgvOnlinePlayers";
            dgvOnlinePlayers.RowHeadersWidth = 56;
            dgvOnlinePlayers.Size = new Size(280, 269);
            dgvOnlinePlayers.TabIndex = 7;
            // 
            // dgvGameInvites
            // 
            dgvGameInvites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGameInvites.Location = new Point(348, 106);
            dgvGameInvites.Name = "dgvGameInvites";
            dgvGameInvites.RowHeadersWidth = 56;
            dgvGameInvites.Size = new Size(280, 269);
            dgvGameInvites.TabIndex = 8;
            // 
            // btnInvite
            // 
            btnInvite.Location = new Point(113, 394);
            btnInvite.Name = "btnInvite";
            btnInvite.Size = new Size(102, 31);
            btnInvite.TabIndex = 9;
            btnInvite.Text = "Invite";
            btnInvite.UseVisualStyleBackColor = true;
            btnInvite.Click += btnInvite_Click;
            // 
            // frmLobby
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnInvite);
            Controls.Add(dgvGameInvites);
            Controls.Add(dgvOnlinePlayers);
            Controls.Add(lblPlayer);
            Controls.Add(lblHeading2);
            Controls.Add(btnAccount);
            Controls.Add(btnLogout);
            Controls.Add(btnStartGame);
            Controls.Add(btnAdmin);
            Controls.Add(lblHeading);
            Name = "frmLobby";
            Text = "Lobby";
            ((System.ComponentModel.ISupportInitialize)dgvOnlinePlayers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGameInvites).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeading;
        private Button btnAdmin;
        private Button btnStartGame;
        private Button btnLogout;
        private Button btnAccount;
        private Label lblHeading2;
        private Label lblPlayer;
        private DataGridView dgvOnlinePlayers;
        private DataGridView dgvGameInvites;
        private Button btnInvite;
    }
}