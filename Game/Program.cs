/*
 * the following program represnets the interface for the game Durak. 
 * date: 2020-01-23
 * Since: 2020-02-10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardGameProject;

namespace GameClient
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Menu.frmMainMenu());
        }
    }
}
