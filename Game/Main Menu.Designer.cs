namespace Main_Menu
{
    partial class frmMainMenu
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
            this.rbtn20 = new System.Windows.Forms.RadioButton();
            this.rbtn36 = new System.Windows.Forms.RadioButton();
            this.rbtn52 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxPlayers = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.ttpHelp = new System.Windows.Forms.ToolTip(this.components);
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtn20
            // 
            this.rbtn20.AutoSize = true;
            this.rbtn20.Location = new System.Drawing.Point(6, 19);
            this.rbtn20.Name = "rbtn20";
            this.rbtn20.Size = new System.Drawing.Size(67, 17);
            this.rbtn20.TabIndex = 0;
            this.rbtn20.Text = "20 Cards";
            this.rbtn20.UseVisualStyleBackColor = true;
            // 
            // rbtn36
            // 
            this.rbtn36.AutoSize = true;
            this.rbtn36.Checked = true;
            this.rbtn36.Location = new System.Drawing.Point(97, 19);
            this.rbtn36.Name = "rbtn36";
            this.rbtn36.Size = new System.Drawing.Size(67, 17);
            this.rbtn36.TabIndex = 1;
            this.rbtn36.TabStop = true;
            this.rbtn36.Text = "36 Cards";
            this.rbtn36.UseVisualStyleBackColor = true;
            // 
            // rbtn52
            // 
            this.rbtn52.AutoSize = true;
            this.rbtn52.Location = new System.Drawing.Point(188, 19);
            this.rbtn52.Name = "rbtn52";
            this.rbtn52.Size = new System.Drawing.Size(67, 17);
            this.rbtn52.TabIndex = 2;
            this.rbtn52.Text = "52 Cards";
            this.rbtn52.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn20);
            this.groupBox1.Controls.Add(this.rbtn36);
            this.groupBox1.Controls.Add(this.rbtn52);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 57);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deck Size";
            this.ttpHelp.SetToolTip(this.groupBox1, "Select the size of the deck you would like to play with");
            // 
            // cbxPlayers
            // 
            this.cbxPlayers.FormattingEnabled = true;
            this.cbxPlayers.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cbxPlayers.Location = new System.Drawing.Point(56, 105);
            this.cbxPlayers.Name = "cbxPlayers";
            this.cbxPlayers.Size = new System.Drawing.Size(57, 21);
            this.cbxPlayers.TabIndex = 7;
            this.cbxPlayers.Text = "2";
            this.ttpHelp.SetToolTip(this.cbxPlayers, "Select the amount of players in the game");
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 146);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.ttpHelp.SetToolTip(this.btnStart, "Starts the game of Durak with current settings");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(9, 107);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(41, 13);
            this.lblPlayers.TabIndex = 9;
            this.lblPlayers.Text = "Players";
            this.ttpHelp.SetToolTip(this.lblPlayers, "Select the amount of players in the game");
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(119, 107);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(67, 13);
            this.lblPlayerName.TabIndex = 10;
            this.lblPlayerName.Text = "Player Name";
            this.ttpHelp.SetToolTip(this.lblPlayerName, "Enter your name!");
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(193, 105);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 11;
            this.txtName.Text = "Player";
            this.ttpHelp.SetToolTip(this.txtName, "Enter your name!");
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(245, 146);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(22, 23);
            this.btnHelp.TabIndex = 12;
            this.btnHelp.Text = "?";
            this.ttpHelp.SetToolTip(this.btnHelp, "Displays how to play Durak");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(218, 10);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 13;
            this.btnAbout.Text = "About";
            this.ttpHelp.SetToolTip(this.btnAbout, "Tell you who made this!");
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // frmMainMenu
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 181);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbxPlayers);
            this.Controls.Add(this.btnStart);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn20;
        private System.Windows.Forms.RadioButton rbtn36;
        private System.Windows.Forms.RadioButton rbtn52;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxPlayers;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ToolTip ttpHelp;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnAbout;
    }
}

