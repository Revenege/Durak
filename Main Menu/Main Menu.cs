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

            if (cbxPlayers.SelectedIndex != -1)
            {
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

                if (txtName.Text.Length > 0)
                {

                    Durak newGame = new Durak(deckSize);

                    //Creates an array of players. Can be between 2 and 7
                    Player[] players;

                    List<Player> playerList = new List<Player>();
                    playerName = txtName.Text;
                    playerList.Add(new Player(playerName));
                    for (int i=0; i < playerCount-1; i++)
                    {
                        playerList.Add(new Player("AI " + i));
                    }
                    //Sets each player in the arary. 
                    players = playerList.ToArray();

                    //Setting the players. Must be done before starting the game.
                    newGame.SetPlayers(players);
                    //Close the main menu, and open the game window
                    this.Hide();
                    var gameWindow = new frmGameWindow();
                    gameWindow.Closed += (s, args) => this.Close();
                    gameWindow.Show();

                }
            }
        }
    }
}
