/*Programmer: Scott Jenkins
 *Date: 3/13/2020 
 *Purpose displays cards from the deck.
 * 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardGameProject;

namespace CardBox
{
    public partial class CardBox: UserControl
    {
        #region FIELDS AND PROPERTIES
        private Card myCard;
        public Card Card
        {
            set
            {
                myCard = value;
                UpdateCardImage();
            }

            get
            {
                return myCard;
            }
        }

        public Suit Suit
        {
            set
            {
                Card.suit = value;
                UpdateCardImage();
            }
            get { return myCard.suit; }
        }

        public Rank Rank
        {
            set
            {
                Card.rank = value;
                UpdateCardImage();
            }
            get { return myCard.rank; }
        }

        public bool isFaceUp
        {
            set
            {
                if (myCard.isFaceUp != value)
                {
                    myCard.isFaceUp = value;
                    UpdateCardImage();
                    if (CardFlipped != null)
                        CardFlipped(this, new EventArgs());
                    
                }
            }
            get
            {
                return myCard.isFaceUp;
            }
        }

        public override string ToString()
        {
            return Card.ToString();
        }

        #endregion
        /// <summary>
        /// an event handler for the load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }
        /// <summary>
        /// Constructor for the form object
        /// </summary>
        public CardBox()
        {
            InitializeComponent();
            Card = new Card();
        }

        /// <summary>
        /// Constructor for the form object when passed a card object 
        /// </summary>
        /// <param name="card"></param>
        public CardBox(Card card)
        {
            InitializeComponent();
            Card = card;
        }
        
        /// <summary>
        /// updates the image to be displayed
        /// </summary>
        public void UpdateCardImage()
        {
            pbMyPictureBox.Image = myCard.GetCardImage();
            System.Diagnostics.Debug.Write(myCard.shortForm.ToString());
        }

        //handler for when the card is flipped over
        public event EventHandler CardFlipped;

        /// <summary>
        /// Handler for the box being clicked
        /// </summary>
        new public event EventHandler Click;

        /// <summary>
        /// Handles a click event on the picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            if (Click !=null)
                Click(this, e);
        }
    }
}
