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
            this.txtTest = new System.Windows.Forms.TextBox();
            this.lblTempOutput = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblCardPlayed = new System.Windows.Forms.Label();
            this.lblTrump = new System.Windows.Forms.Label();
            this.lblTrumpTitle = new System.Windows.Forms.Label();
            this.lblDeckSizeTitle = new System.Windows.Forms.Label();
            this.lblDeckSize = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pnlPlayerHand = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(51, 47);
            this.txtTest.Margin = new System.Windows.Forms.Padding(4);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(132, 22);
            this.txtTest.TabIndex = 0;
            // 
            // lblTempOutput
            // 
            this.lblTempOutput.AutoSize = true;
            this.lblTempOutput.Location = new System.Drawing.Point(47, 110);
            this.lblTempOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempOutput.Name = "lblTempOutput";
            this.lblTempOutput.Size = new System.Drawing.Size(66, 17);
            this.lblTempOutput.TabIndex = 1;
            this.lblTempOutput.Text = "OUTPUT";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(192, 44);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 28);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblCardPlayed
            // 
            this.lblCardPlayed.AutoSize = true;
            this.lblCardPlayed.Location = new System.Drawing.Point(351, 110);
            this.lblCardPlayed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCardPlayed.Name = "lblCardPlayed";
            this.lblCardPlayed.Size = new System.Drawing.Size(66, 17);
            this.lblCardPlayed.TabIndex = 3;
            this.lblCardPlayed.Text = "OUTPUT";
            // 
            // lblTrump
            // 
            this.lblTrump.AutoSize = true;
            this.lblTrump.Location = new System.Drawing.Point(395, 50);
            this.lblTrump.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrump.Name = "lblTrump";
            this.lblTrump.Size = new System.Drawing.Size(66, 17);
            this.lblTrump.TabIndex = 4;
            this.lblTrump.Text = "OUTPUT";
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
            this.pnlPlayerHand.Location = new System.Drawing.Point(354, 261);
            this.pnlPlayerHand.Name = "pnlPlayerHand";
            this.pnlPlayerHand.Size = new System.Drawing.Size(448, 169);
            this.pnlPlayerHand.TabIndex = 10;
            // 
            // frmGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pnlPlayerHand);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblDeckSize);
            this.Controls.Add(this.lblDeckSizeTitle);
            this.Controls.Add(this.lblTrumpTitle);
            this.Controls.Add(this.lblTrump);
            this.Controls.Add(this.lblCardPlayed);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTempOutput);
            this.Controls.Add(this.txtTest);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGameWindow";
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.frmGameWindow_Load);
            this.Shown += new System.EventHandler(this.frmGameWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.Label lblTempOutput;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblCardPlayed;
        private System.Windows.Forms.Label lblTrump;
        private System.Windows.Forms.Label lblTrumpTitle;
        private System.Windows.Forms.Label lblDeckSizeTitle;
        private System.Windows.Forms.Label lblDeckSize;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Panel pnlPlayerHand;
    }
}