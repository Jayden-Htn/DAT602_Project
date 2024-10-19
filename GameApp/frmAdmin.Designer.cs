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
            btnListPlayers = new Button();
            listBox1 = new ListBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnAddPlayer
            // 
            btnAddPlayer.Location = new Point(159, 344);
            btnAddPlayer.Name = "btnAddPlayer";
            btnAddPlayer.Size = new Size(102, 31);
            btnAddPlayer.TabIndex = 0;
            btnAddPlayer.Text = "Add Player";
            btnAddPlayer.UseVisualStyleBackColor = true;
            // 
            // btnDeletePlayer
            // 
            btnDeletePlayer.Location = new Point(94, 395);
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
            btnListPlayers.Location = new Point(35, 344);
            btnListPlayers.Name = "btnListPlayers";
            btnListPlayers.Size = new Size(102, 31);
            btnListPlayers.TabIndex = 5;
            btnListPlayers.Text = "List Players";
            btnListPlayers.UseVisualStyleBackColor = true;
            btnListPlayers.Click += btnListPlayers_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Location = new Point(351, 69);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(273, 256);
            listBox1.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(472, 356);
            button1.Name = "button1";
            button1.Size = new Size(102, 31);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
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
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(btnListPlayers);
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
        private Button btnListPlayers;
        private ListBox listBox1;
        private Button button1;
        private Label label2;
        private Label label3;
    }
}