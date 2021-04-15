///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            CardBox
///   Description:      Contains user controls for cardboxes to be rendered
///   Authors:          Shoaib Ali, Luke Richards, Navpreet Kanda, Mubashir Malik
///   Card Img Source:  http://acbl.mybigcommerce.com/52-playing-cards/  
///   Date:             April 14, 2021
///---------------------------------------------------------------------------------
///

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Derak_Project;

namespace CardBox1
{
    /// <summary>
    /// A control to use in a windows form application that displays playing card
    /// </summary>
    public partial class CardBox: UserControl
    {

        #region Fields and Properties
        /// <summary>
        /// Card Property: Sets/Gets the underlying Card object
        /// </summary>
        private Card myCard;
        public Card Card
        {
            set
            {
                myCard = value;
                pbMyPictureBox.Image = myCard.GetCardImage();
                UpdateCardImage();
            }
            get { return myCard; }
        }

        /// <summary>
        /// Suit Property: sets/gets the underlying Card object's Suit
        /// </summary>
        public Suit Suit
        {
            set
            {
                Card.suit = value;
                UpdateCardImage();
            }
            get { return Card.suit; }
        }

        /// <summary>
        /// Rank Property: sets/gets the underlying Card object's Rank
        /// </summary>
        public Rank Rank
        {
            set
            {
                Card.rank = value;
                UpdateCardImage();
            }
            get { return Card.rank; }
        }

        /// <summary>
        /// FaceUp Property: sets/gets the underlying Card object's FaceUp
        /// </summary>
        public bool FaceUp
        {
            set
            {
                if (myCard.FaceUp != value)
                {
                    myCard.FaceUp = value;
                    UpdateCardImage();
                    if (CardFlipped != null)
                        CardFlipped(this, new EventArgs());
                }

            
            }
            get { return Card.FaceUp; }
        }

        /// <summary>
        /// Orientation Property: sets/gets the underlying Card object's Orientation
        /// </summary>
        private Orientation myOrientation;
        public Orientation CardOrientation
        {
            set
            {
                if(myOrientation != value)
                {
                    myOrientation = value;
                    this.Size = new Size(Size.Height, Size.Width);
                    UpdateCardImage();
                }
            }
            get { return myOrientation; }
        }

        private void UpdateCardImage()
        {
            pbMyPictureBox.Image = myCard.GetCardImage();
            if (myOrientation == Orientation.Horizontal)
            {
                pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Consturctor
        /// </summary>
        public CardBox()
        {
            InitializeComponent();
            myOrientation = Orientation.Vertical;
            myCard = new Card();
        }

        /// <summary>
        /// Paramterized Constructor
        /// </summary>
        /// <param name="card"></param>
        /// <param name="orientation"></param>
        public CardBox(Card card, Orientation orientation = Orientation.Vertical)
        {
            InitializeComponent();
            myOrientation = orientation;
            myCard = card;
        }
        #endregion

        #region Events and Event Handlers

        /// <summary>
        /// Updates Image on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();  //Update card Image
        }

        public event EventHandler CardFlipped;

        new public event EventHandler Click;
        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(this, e); //Calls
        }

        #endregion

        #region Other Methods

        public override string ToString()
        {
            return myCard.ToString();
        }

        #endregion

        
    }
}
