using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClient;

namespace Main_Menu
{
    public partial class frmGameWindow : Form
    {
        //strictly for inheritance, default constructor 
        private frmGameWindow()
        {
            InitializeComponent();
        }
        //obtains the premade game object, begin the game
        public frmGameWindow(Durak game)
        {
            InitializeComponent();
        }
    }
}
