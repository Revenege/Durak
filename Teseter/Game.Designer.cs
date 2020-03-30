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
            this.SuspendLayout();
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(38, 38);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(100, 20);
            this.txtTest.TabIndex = 0;
            // 
            // lblTempOutput
            // 
            this.lblTempOutput.AutoSize = true;
            this.lblTempOutput.Location = new System.Drawing.Point(35, 89);
            this.lblTempOutput.Name = "lblTempOutput";
            this.lblTempOutput.Size = new System.Drawing.Size(52, 13);
            this.lblTempOutput.TabIndex = 1;
            this.lblTempOutput.Text = "OUTPUT";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(144, 36);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblCardPlayed
            // 
            this.lblCardPlayed.AutoSize = true;
            this.lblCardPlayed.Location = new System.Drawing.Point(263, 89);
            this.lblCardPlayed.Name = "lblCardPlayed";
            this.lblCardPlayed.Size = new System.Drawing.Size(52, 13);
            this.lblCardPlayed.TabIndex = 3;
            this.lblCardPlayed.Text = "OUTPUT";
            // 
            // lblTrump
            // 
            this.lblTrump.AutoSize = true;
            this.lblTrump.Location = new System.Drawing.Point(296, 41);
            this.lblTrump.Name = "lblTrump";
            this.lblTrump.Size = new System.Drawing.Size(52, 13);
            this.lblTrump.TabIndex = 4;
            this.lblTrump.Text = "OUTPUT";
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
            // 
            // frmGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDeckSize);
            this.Controls.Add(this.lblDeckSizeTitle);
            this.Controls.Add(this.lblTrumpTitle);
            this.Controls.Add(this.lblTrump);
            this.Controls.Add(this.lblCardPlayed);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTempOutput);
            this.Controls.Add(this.txtTest);
            this.Name = "frmGameWindow";
            this.Text = "Durak";
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
    }
}