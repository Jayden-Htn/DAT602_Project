namespace GameApp
{
    partial class frmAdmin
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
            btnAddPlayer = new Button();
            btnDeletePlayer = new Button();
            lstPlayers = new ListBox();
            btnClose = new Button();
            btnEditPlayer = new Button();
            lstGames = new ListBox();
            btnEndGame = new Button();
            label2 = new Label();
            label3 = new Label();
            btnEndAllGames = new Button();
            SuspendLayout();
            // 
            // btnAddPlayer
            // 
            btnAddPlayer.Location = new Point(159, 395);
            btnAddPlayer.Name = "btnAddPlayer";
            btnAddPlayer.Size = new Size(112, 31);
            btnAddPlayer.TabIndex = 0;
            btnAddPlayer.Text = "Add Player";
            btnAddPlayer.UseVisualStyleBackColor = true;
            btnAddPlayer.Click += btnAddPlayer_Click;
            // 
            // btnDeletePlayer
            // 
            btnDeletePlayer.Location = new Point(159, 344);
            btnDeletePlayer.Name = "btnDeletePlayer";
            btnDeletePlayer.Size = new Size(112, 31);
            btnDeletePlayer.TabIndex = 1;
            btnDeletePlayer.Text = "Delete Player";
            btnDeletePlayer.UseVisualStyleBackColor = true;
            btnDeletePlayer.Click += btnDeletePlayer_Click;
            // 
            // lstPlayers
            // 
            lstPlayers.FormattingEnabled = true;
            lstPlayers.ItemHeight = 21;
            lstPlayers.Location = new Point(26, 69);
            lstPlayers.Name = "lstPlayers";
            lstPlayers.Size = new Size(273, 256);
            lstPlayers.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(512, 407);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(102, 31);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnEditPlayer
            // 
            btnEditPlayer.Location = new Point(26, 344);
            btnEditPlayer.Name = "btnEditPlayer";
            btnEditPlayer.Size = new Size(112, 31);
            btnEditPlayer.TabIndex = 5;
            btnEditPlayer.Text = "Edit Player";
            btnEditPlayer.UseVisualStyleBackColor = true;
            btnEditPlayer.Click += btnEditPlayer_Click;
            // 
            // lstGames
            // 
            lstGames.FormattingEnabled = true;
            lstGames.ItemHeight = 21;
            lstGames.Location = new Point(351, 69);
            lstGames.Name = "lstGames";
            lstGames.Size = new Size(273, 256);
            lstGames.TabIndex = 6;
            // 
            // btnEndGame
            // 
            btnEndGame.Location = new Point(351, 355);
            btnEndGame.Name = "btnEndGame";
            btnEndGame.Size = new Size(102, 31);
            btnEndGame.TabIndex = 7;
            btnEndGame.Text = "End Game";
            btnEndGame.UseVisualStyleBackColor = true;
            btnEndGame.Click += btnEndGame_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(94, 35);
            label2.Name = "label2";
            label2.Size = new Size(120, 21);
            label2.TabIndex = 8;
            label2.Text = "Online Players";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(427, 35);
            label3.Name = "label3";
            label3.Size = new Size(113, 21);
            label3.TabIndex = 9;
            label3.Text = "Active Games";
            // 
            // btnEndAllGames
            // 
            btnEndAllGames.Location = new Point(498, 355);
            btnEndAllGames.Name = "btnEndAllGames";
            btnEndAllGames.Size = new Size(126, 31);
            btnEndAllGames.TabIndex = 10;
            btnEndAllGames.Text = "End All Games";
            btnEndAllGames.UseVisualStyleBackColor = true;
            btnEndAllGames.Click += btnEndAllGames_Click;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEndAllGames);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnEndGame);
            Controls.Add(lstGames);
            Controls.Add(btnEditPlayer);
            Controls.Add(btnClose);
            Controls.Add(lstPlayers);
            Controls.Add(btnDeletePlayer);
            Controls.Add(btnAddPlayer);
            Name = "frmAdmin";
            Text = "Admin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddPlayer;
        private Button btnDeletePlayer;
        private ListBox lstPlayers;
        private Button btnClose;
        private Button btnEditPlayer;
        private ListBox lstGames;
        private Button btnEndGame;
        private Label label2;
        private Label label3;
        private Button btnEndAllGames;
    }
}