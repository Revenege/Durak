namespace Main_Menu
{
    partial class frmGameWindow
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
            CardGameProject.Card card1 = new CardGameProject.Card();
            this.lblTrumpTitle = new System.Windows.Forms.Label();
            this.lblDeckSizeTitle = new System.Windows.Forms.Label();
            this.lblDeckSize = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pnlPlayerHand = new System.Windows.Forms.Panel();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.txtCardPlayed = new System.Windows.Forms.TextBox();
            this.cbTrump = new GameWindow.CardBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.lblPlayerHand = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTrumpTitle
            // 
            this.lblTrumpTitle.AutoSize = true;
            this.lblTrumpTitle.Location = new System.Drawing.Point(321, 50);
            this.lblTrumpTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrumpTitle.Name = "lblTrumpTitle";
            this.lblTrumpTitle.Size = new System.Drawing.Size(61, 17);
            this.lblTrumpTitle.TabIndex = 5;
            this.lblTrumpTitle.Text = "TRUMP:";
            // 
            // lblDeckSizeTitle
            // 
            this.lblDeckSizeTitle.AutoSize = true;
            this.lblDeckSizeTitle.Location = new System.Drawing.Point(513, 50);
            this.lblDeckSizeTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeckSizeTitle.Name = "lblDeckSizeTitle";
            this.lblDeckSizeTitle.Size = new System.Drawing.Size(139, 17);
            this.lblDeckSizeTitle.TabIndex = 6;
            this.lblDeckSizeTitle.Text = "CARDS REMAINING:";
            // 
            // lblDeckSize
            // 
            this.lblDeckSize.AutoSize = true;
            this.lblDeckSize.Location = new System.Drawing.Point(669, 50);
            this.lblDeckSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeckSize.Name = "lblDeckSize";
            this.lblDeckSize.Size = new System.Drawing.Size(66, 17);
            this.lblDeckSize.TabIndex = 7;
            this.lblDeckSize.Text = "OUTPUT";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(1019, 507);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 32);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click_1);
            // 
            // pnlPlayerHand
            // 
            this.pnlPlayerHand.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlPlayerHand.Location = new System.Drawing.Point(413, 348);
            this.pnlPlayerHand.Name = "pnlPlayerHand";
            this.pnlPlayerHand.Size = new System.Drawing.Size(448, 169);
            this.pnlPlayerHand.TabIndex = 10;
            // 
            // pnlTable
            // 
            this.pnlTable.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTable.Location = new System.Drawing.Point(413, 173);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(448, 169);
            this.pnlTable.TabIndex = 11;
            // 
            // txtCardPlayed
            // 
            this.txtCardPlayed.Location = new System.Drawing.Point(50, 173);
            this.txtCardPlayed.Multiline = true;
            this.txtCardPlayed.Name = "txtCardPlayed";
            this.txtCardPlayed.ReadOnly = true;
            this.txtCardPlayed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCardPlayed.Size = new System.Drawing.Size(242, 344);
            this.txtCardPlayed.TabIndex = 12;
            // 
            // cbTrump
            // 
            this.cbTrump.Card = card1;
            this.cbTrump.isFaceUp = false;
            this.cbTrump.Location = new System.Drawing.Point(390, 13);
            this.cbTrump.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTrump.Name = "cbTrump";
            this.cbTrump.Rank = CardGameProject.Rank.Ace;
            this.cbTrump.Size = new System.Drawing.Size(100, 123);
            this.cbTrump.Suit = CardGameProject.Suit.Club;
            this.cbTrump.TabIndex = 13;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(327, 251);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(44, 17);
            this.lblTable.TabIndex = 14;
            this.lblTable.Text = "Table";
            // 
            // lblPlayerHand
            // 
            this.lblPlayerHand.AutoSize = true;
            this.lblPlayerHand.Location = new System.Drawing.Point(327, 421);
            this.lblPlayerHand.Name = "lblPlayerHand";
            this.lblPlayerHand.Size = new System.Drawing.Size(76, 17);
            this.lblPlayerHand.TabIndex = 15;
            this.lblPlayerHand.Text = "Your Hand";
            // 
            // frmGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblPlayerHand);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.cbTrump);
            this.Controls.Add(this.txtCardPlayed);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlPlayerHand);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblDeckSize);
            this.Controls.Add(this.lblDeckSizeTitle);
            this.Controls.Add(this.lblTrumpTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGameWindow";
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.frmGameWindow_Load);
            this.Shown += new System.EventHandler(this.frmGameWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTrumpTitle;
        private System.Windows.Forms.Label lblDeckSizeTitle;
        private System.Windows.Forms.Label lblDeckSize;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Panel pnlPlayerHand;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.TextBox txtCardPlayed;
        private GameWindow.CardBox cbTrump;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label lblPlayerHand;
    }
}