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
            this.components = new System.ComponentModel.Container();
            CardGameProject.Card card2 = new CardGameProject.Card();
            this.lblTrumpTitle = new System.Windows.Forms.Label();
            this.lblDeckSizeTitle = new System.Windows.Forms.Label();
            this.lblDeckSize = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pnlPlayerHand = new System.Windows.Forms.Panel();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.txtCardPlayed = new System.Windows.Forms.TextBox();
            this.cbTrump = new CardBox.CardBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.lblPlayerHand = new System.Windows.Forms.Label();
            this.btnSkip = new System.Windows.Forms.Button();
            this.ttpGameHelp = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblTrumpTitle
            // 
            this.lblTrumpTitle.AutoSize = true;
            this.lblTrumpTitle.Location = new System.Drawing.Point(241, 41);
            this.lblTrumpTitle.Name = "lblTrumpTitle";
            this.lblTrumpTitle.Size = new System.Drawing.Size(49, 13);
            this.lblTrumpTitle.TabIndex = 5;
            this.lblTrumpTitle.Text = "TRUMP:";
            // 
            // lblDeckSizeTitle
            // 
            this.lblDeckSizeTitle.AutoSize = true;
            this.lblDeckSizeTitle.Location = new System.Drawing.Point(385, 41);
            this.lblDeckSizeTitle.Name = "lblDeckSizeTitle";
            this.lblDeckSizeTitle.Size = new System.Drawing.Size(111, 13);
            this.lblDeckSizeTitle.TabIndex = 6;
            this.lblDeckSizeTitle.Text = "CARDS REMAINING:";
            // 
            // lblDeckSize
            // 
            this.lblDeckSize.AutoSize = true;
            this.lblDeckSize.Location = new System.Drawing.Point(502, 41);
            this.lblDeckSize.Name = "lblDeckSize";
            this.lblDeckSize.Size = new System.Drawing.Size(52, 13);
            this.lblDeckSize.TabIndex = 7;
            this.lblDeckSize.Text = "OUTPUT";
            this.ttpGameHelp.SetToolTip(this.lblDeckSize, "Cards remaining in the deck.");
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(764, 412);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(24, 26);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "?";
            this.ttpGameHelp.SetToolTip(this.btnHelp, "Display how to play");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click_1);
            // 
            // pnlPlayerHand
            // 
            this.pnlPlayerHand.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlPlayerHand.Location = new System.Drawing.Point(310, 283);
            this.pnlPlayerHand.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPlayerHand.Name = "pnlPlayerHand";
            this.pnlPlayerHand.Size = new System.Drawing.Size(336, 137);
            this.pnlPlayerHand.TabIndex = 10;
            this.ttpGameHelp.SetToolTip(this.pnlPlayerHand, "Your hand. Click cards to play them");
            // 
            // pnlTable
            // 
            this.pnlTable.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTable.Location = new System.Drawing.Point(310, 141);
            this.pnlTable.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(336, 137);
            this.pnlTable.TabIndex = 11;
            this.ttpGameHelp.SetToolTip(this.pnlTable, "Cards currently in play");
            // 
            // txtCardPlayed
            // 
            this.txtCardPlayed.Location = new System.Drawing.Point(38, 141);
            this.txtCardPlayed.Margin = new System.Windows.Forms.Padding(2);
            this.txtCardPlayed.Multiline = true;
            this.txtCardPlayed.Name = "txtCardPlayed";
            this.txtCardPlayed.ReadOnly = true;
            this.txtCardPlayed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCardPlayed.Size = new System.Drawing.Size(182, 280);
            this.txtCardPlayed.TabIndex = 12;
            this.ttpGameHelp.SetToolTip(this.txtCardPlayed, "Displays all past game actions");
            // 
            // cbTrump
            // 
            this.cbTrump.Card = card2;
            this.cbTrump.isFaceUp = false;
            this.cbTrump.Location = new System.Drawing.Point(292, 11);
            this.cbTrump.Name = "cbTrump";
            this.cbTrump.Rank = CardGameProject.Rank.Ace;
            this.cbTrump.Size = new System.Drawing.Size(75, 100);
            this.cbTrump.Suit = CardGameProject.Suit.Club;
            this.cbTrump.TabIndex = 13;
            this.ttpGameHelp.SetToolTip(this.cbTrump, "The Trump Card");
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(245, 204);
            this.lblTable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(34, 13);
            this.lblTable.TabIndex = 14;
            this.lblTable.Text = "Table";
            // 
            // lblPlayerHand
            // 
            this.lblPlayerHand.AutoSize = true;
            this.lblPlayerHand.Location = new System.Drawing.Point(245, 342);
            this.lblPlayerHand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerHand.Name = "lblPlayerHand";
            this.lblPlayerHand.Size = new System.Drawing.Size(58, 13);
            this.lblPlayerHand.TabIndex = 15;
            this.lblPlayerHand.Text = "Your Hand";
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(651, 342);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 16;
            this.btnSkip.Text = "Skip Turn";
            this.ttpGameHelp.SetToolTip(this.btnSkip, "Click to skip your turn. ");
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // frmGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSkip);
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
            this.Name = "frmGameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
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
        private CardBox.CardBox cbTrump;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label lblPlayerHand;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.ToolTip ttpGameHelp;
    }
}