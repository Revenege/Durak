namespace Teseter
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.rtxtAboutInfo = new System.Windows.Forms.RichTextBox();
            this.btnExitAbout = new System.Windows.Forms.Button();
            this.ttpExit = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // rtxtAboutInfo
            // 
            this.rtxtAboutInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtAboutInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtxtAboutInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtAboutInfo.EnableAutoDragDrop = true;
            this.rtxtAboutInfo.Location = new System.Drawing.Point(0, 0);
            this.rtxtAboutInfo.Name = "rtxtAboutInfo";
            this.rtxtAboutInfo.ReadOnly = true;
            this.rtxtAboutInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtxtAboutInfo.Size = new System.Drawing.Size(800, 400);
            this.rtxtAboutInfo.TabIndex = 0;
            this.rtxtAboutInfo.Text = resources.GetString("rtxtAboutInfo.Text");
            // 
            // btnExitAbout
            // 
            this.btnExitAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitAbout.Location = new System.Drawing.Point(700, 420);
            this.btnExitAbout.Name = "btnExitAbout";
            this.btnExitAbout.Size = new System.Drawing.Size(75, 20);
            this.btnExitAbout.TabIndex = 1;
            this.btnExitAbout.Text = "Exit";
            this.ttpExit.SetToolTip(this.btnExitAbout, "Close this window and return to the menu");
            this.btnExitAbout.UseVisualStyleBackColor = true;
            this.btnExitAbout.Click += new System.EventHandler(this.btnExitAbout_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExitAbout);
            this.Controls.Add(this.rtxtAboutInfo);
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtAboutInfo;
        private System.Windows.Forms.Button btnExitAbout;
        private System.Windows.Forms.ToolTip ttpExit;
    }
}