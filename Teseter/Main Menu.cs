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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int deckSize = 0;
            int playerCount = 0;
            String playerName = "";

            //ensure the player has selected a palyer count
            if (cbxPlayers.SelectedIndex != -1)
            {
                //check which decksize they picked. 
                if (rbtn20.Checked)
                {
                    deckSize = 20;
                }
                else if(rbtn36.Checked)
                {
                    deckSize = 36;
                }
                else if (rbtn52.Checked)
                {
                    deckSize = 52;
                }

                Int32.TryParse(cbxPlayers.SelectedItem.ToString(),out playerCount);

                //ensure they entered a name of non-zero length
                if (txtName.Text.Length > 0)
                {

                    //Creates an array of players. Can be between 2 and 7
                    Player[] players;

                    List<Player> playerList = new List<Player>();
                    //set the players name to their input
                    playerName = txtName.Text;
                    playerList.Add(new Player(playerName));
                    //loop over the remaining players and set there names to be AI and a number
                    for (int i=0; i < playerCount-1; i++)
                    {
                        playerList.Add(new Player("AI " + (i+1)));
                    }
                    //Sets each player in the arary. 
                    players = playerList.ToArray();

                    //Close the main menu, and open the game window
                    this.Hide();
                    var gameWindow = new frmGameWindow(players, deckSize);
                    //binding closing the game window to also close the main menu
                    gameWindow.Closed += (s, args) => this.Close();
                    gameWindow.Show();

                }
            }
        }
    }
}
