namespace GameApp
{
    partial class frmGame
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
            btnExit = new Button();
            lstChat = new ListBox();
            lblHealthLabel = new Label();
            lblHealth = new Label();
            lblScoreLabel = new Label();
            lblScore = new Label();
            txtChat = new TextBox();
            btnChat = new Button();
            btnTest = new Button();
            lblTest = new Label();
            btnEatFruit = new Button();
            btnEatMeat = new Button();
            lblFruitLabel = new Label();
            lblMeatLabel = new Label();
            lblFruitCount = new Label();
            lblMeatCount = new Label();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(791, 388);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(117, 44);
            btnExit.TabIndex = 0;
            btnExit.Text = "Exit Game";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lstChat
            // 
            lstChat.FormattingEnabled = true;
            lstChat.ItemHeight = 21;
            lstChat.Location = new Point(649, 26);
            lstChat.Name = "lstChat";
            lstChat.Size = new Size(259, 298);
            lstChat.TabIndex = 1;
            // 
            // lblHealthLabel
            // 
            lblHealthLabel.AutoSize = true;
            lblHealthLabel.Location = new Point(630, 388);
            lblHealthLabel.Name = "lblHealthLabel";
            lblHealthLabel.Size = new Size(58, 21);
            lblHealthLabel.TabIndex = 2;
            lblHealthLabel.Text = "Health:";
            // 
            // lblHealth
            // 
            lblHealth.AutoSize = true;
            lblHealth.Location = new Point(702, 388);
            lblHealth.Name = "lblHealth";
            lblHealth.Size = new Size(37, 21);
            lblHealth.TabIndex = 3;
            lblHealth.Text = "100";
            // 
            // lblScoreLabel
            // 
            lblScoreLabel.AutoSize = true;
            lblScoreLabel.Location = new Point(636, 411);
            lblScoreLabel.Name = "lblScoreLabel";
            lblScoreLabel.Size = new Size(52, 21);
            lblScoreLabel.TabIndex = 4;
            lblScoreLabel.Text = "Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(702, 411);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(19, 21);
            lblScore.TabIndex = 5;
            lblScore.Text = "0";
            // 
            // txtChat
            // 
            txtChat.Location = new Point(649, 339);
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(184, 29);
            txtChat.TabIndex = 6;
            // 
            // btnChat
            // 
            btnChat.Location = new Point(839, 339);
            btnChat.Name = "btnChat";
            btnChat.Size = new Size(69, 31);
            btnChat.TabIndex = 7;
            btnChat.Text = "Send";
            btnChat.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(175, 64);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(183, 31);
            btnTest.TabIndex = 8;
            btnTest.Text = "Get map data";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // lblTest
            // 
            lblTest.AutoSize = true;
            lblTest.Location = new Point(209, 115);
            lblTest.Name = "lblTest";
            lblTest.Size = new Size(116, 21);
            lblTest.TabIndex = 9;
            lblTest.Text = "No data loaded";
            // 
            // btnEatFruit
            // 
            btnEatFruit.Location = new Point(186, 401);
            btnEatFruit.Name = "btnEatFruit";
            btnEatFruit.Size = new Size(102, 31);
            btnEatFruit.TabIndex = 10;
            btnEatFruit.Text = "Eat Fruit";
            btnEatFruit.UseVisualStyleBackColor = true;
            // 
            // btnEatMeat
            // 
            btnEatMeat.Location = new Point(469, 401);
            btnEatMeat.Name = "btnEatMeat";
            btnEatMeat.Size = new Size(102, 31);
            btnEatMeat.TabIndex = 11;
            btnEatMeat.Text = "Eat Meat";
            btnEatMeat.UseVisualStyleBackColor = true;
            // 
            // lblFruitLabel
            // 
            lblFruitLabel.AutoSize = true;
            lblFruitLabel.Location = new Point(34, 406);
            lblFruitLabel.Name = "lblFruitLabel";
            lblFruitLabel.Size = new Size(122, 21);
            lblFruitLabel.TabIndex = 12;
            lblFruitLabel.Text = "Number of fruit:";
            // 
            // lblMeatLabel
            // 
            lblMeatLabel.AutoSize = true;
            lblMeatLabel.Location = new Point(310, 406);
            lblMeatLabel.Name = "lblMeatLabel";
            lblMeatLabel.Size = new Size(128, 21);
            lblMeatLabel.TabIndex = 13;
            lblMeatLabel.Text = "Number of meat:";
            // 
            // lblFruitCount
            // 
            lblFruitCount.AutoSize = true;
            lblFruitCount.Location = new Point(161, 406);
            lblFruitCount.Name = "lblFruitCount";
            lblFruitCount.Size = new Size(19, 21);
            lblFruitCount.TabIndex = 14;
            lblFruitCount.Text = "0";
            // 
            // lblMeatCount
            // 
            lblMeatCount.AutoSize = true;
            lblMeatCount.Location = new Point(444, 406);
            lblMeatCount.Name = "lblMeatCount";
            lblMeatCount.Size = new Size(19, 21);
            lblMeatCount.TabIndex = 15;
            lblMeatCount.Text = "0";
            // 
            // frmGame
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 450);
            Controls.Add(lblMeatCount);
            Controls.Add(lblFruitCount);
            Controls.Add(lblMeatLabel);
            Controls.Add(lblFruitLabel);
            Controls.Add(btnEatMeat);
            Controls.Add(btnEatFruit);
            Controls.Add(lblTest);
            Controls.Add(btnTest);
            Controls.Add(btnChat);
            Controls.Add(txtChat);
            Controls.Add(lblScore);
            Controls.Add(lblScoreLabel);
            Controls.Add(lblHealth);
            Controls.Add(lblHealthLabel);
            Controls.Add(lstChat);
            Controls.Add(btnExit);
            Name = "frmGame";
            Text = "Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private ListBox lstChat;
        private Label lblHealthLabel;
        private Label lblHealth;
        private Label lblScoreLabel;
        private Label lblScore;
        private TextBox txtChat;
        private Button btnChat;
        private Button btnTest;
        private Label lblTest;
        private Button btnEatFruit;
        private Button btnEatMeat;
        private Label lblFruitLabel;
        private Label lblMeatLabel;
        private Label lblFruitCount;
        private Label lblMeatCount;
    }
}