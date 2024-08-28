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
            label1 = new Label();
            btnClose = new Button();
            btnListPlayers = new Button();
            SuspendLayout();
            // 
            // btnAddPlayer
            // 
            btnAddPlayer.Location = new Point(663, 69);
            btnAddPlayer.Name = "btnAddPlayer";
            btnAddPlayer.Size = new Size(102, 31);
            btnAddPlayer.TabIndex = 0;
            btnAddPlayer.Text = "Add Player";
            btnAddPlayer.UseVisualStyleBackColor = true;
            // 
            // btnDeletePlayer
            // 
            btnDeletePlayer.Location = new Point(663, 126);
            btnDeletePlayer.Name = "btnDeletePlayer";
            btnDeletePlayer.Size = new Size(102, 31);
            btnDeletePlayer.TabIndex = 1;
            btnDeletePlayer.Text = "Delete Player";
            btnDeletePlayer.UseVisualStyleBackColor = true;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 23);
            label1.Name = "label1";
            label1.Size = new Size(148, 21);
            label1.TabIndex = 3;
            label1.Text = "Admin Dashboard";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(663, 384);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(102, 31);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnListPlayers
            // 
            btnListPlayers.Location = new Point(321, 69);
            btnListPlayers.Name = "btnListPlayers";
            btnListPlayers.Size = new Size(102, 31);
            btnListPlayers.TabIndex = 5;
            btnListPlayers.Text = "List Players";
            btnListPlayers.UseVisualStyleBackColor = true;
            btnListPlayers.Click += btnListPlayers_Click;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnListPlayers);
            Controls.Add(btnClose);
            Controls.Add(label1);
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
        private Label label1;
        private Button btnClose;
        private Button btnListPlayers;
    }
}