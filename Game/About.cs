using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teseter
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the current fomr.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitAbout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
