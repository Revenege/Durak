namespace Teseter
{
    partial class frmHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelp));
            this.rtxtHelpInfo = new System.Windows.Forms.RichTextBox();
            this.btnExitAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxtHelpInfo
            // 
            this.rtxtHelpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtHelpInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtxtHelpInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtHelpInfo.EnableAutoDragDrop = true;
            this.rtxtHelpInfo.Location = new System.Drawing.Point(0, 0);
            this.rtxtHelpInfo.Name = "rtxtHelpInfo";
            this.rtxtHelpInfo.ReadOnly = true;
            this.rtxtHelpInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtHelpInfo.Size = new System.Drawing.Size(800, 400);
            this.rtxtHelpInfo.TabIndex = 1;
            this.rtxtHelpInfo.Text = resources.GetString("rtxtHelpInfo.Text");
            // 
            // btnExitAbout
            // 
            this.btnExitAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitAbout.Location = new System.Drawing.Point(700, 420);
            this.btnExitAbout.Name = "btnExitAbout";
            this.btnExitAbout.Size = new System.Drawing.Size(75, 20);
            this.btnExitAbout.TabIndex = 2;
            this.btnExitAbout.Text = "Exit";
            this.btnExitAbout.UseVisualStyleBackColor = true;
            this.btnExitAbout.Click += new System.EventHandler(this.btnExitAbout_Click);
            // 
            // frmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExitAbout);
            this.Controls.Add(this.rtxtHelpInfo);
            this.Name = "frmHelp";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtHelpInfo;
        private System.Windows.Forms.Button btnExitAbout;
    }
}