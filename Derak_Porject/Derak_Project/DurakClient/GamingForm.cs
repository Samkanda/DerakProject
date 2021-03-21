﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Derak_Project;
using DurakClient;
using CardBox1;

namespace DurakClient
{
    public partial class GamingForm : Form
    {
        DurakGameController players = new DurakGameController();
        /// <summary>
        /// Constructor for frmMainForm
        /// </summary>

        public GamingForm()
        {
            InitializeComponent();

            players.Add(new DurakComputer());
            players.Add(new DurakComputer());
            players.Add(new DurakComputer());
            players.Add(new DurakHuman());

            Hand.TurnBeginEvent += delegate (object obj, EventArgs e) { Turn_Begin(obj, e); };

            //pbDeck = new CardBox(new Card());
            players.StartGame();
        }

        #region FIELDS AND PROPERTIES

        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        private const int POP = 25;

        /// <summary>
        /// The regular size of a CardBox control
        /// </summary>
        static private Size regularSize = new Size(65, 107);

        /// <summary>
        /// When a CardBox is clicked, move to the opposite panel.
        /// </summary>
        void CardBox_Click(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                // if the card is in the home panel...
                if (aCardBox.Parent == pnlCardHome)
                {
                    try
                    {
                        //TODO make dynamic
                        (players[3] as DurakHuman).PlayerPlayCard(aCardBox.Card);
                        // Remove the card from the home panel
                        // Add the control to the play panel
                        pnlCardHome.Controls.Remove(aCardBox);
                        pnlCardDefend.Controls.Add(aCardBox);
                        RealignCards(pnlCardHome);
                        RealignCards(pnlCardDefend);
                    } 
                    catch
                    {

                    }
                    
                }

            }

        }
        /// <summary>
        /// Initializes the card dealer/deck on form Load.
        /// </summary>
        private void frmMainForm_Load(object sender, EventArgs e)
        {
            // Set the deck image to a card back image
            //pbDeck.Image = (new PlayingCard()).GetCardImage();
          
        }

        /// <summary>
        /// Closes the current form.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        ///  CardBox controls grow in size when the mouse is over it.
        /// </summary>
        void CardBox_MouseEnter(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                // Enlarge the card for visual effect
                aCardBox.Size = new Size(regularSize.Width + POP, regularSize.Height + POP);
                // move the card to the top edge of the panel.
                aCardBox.Top = 0;
            }


        }


        /// <summary>
        /// CardBox control shrinks to regular size when the mouse leaves.
        /// </summary>
        void CardBox_MouseLeave(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                // resize the card back to regular size
                aCardBox.Size = new Size(regularSize.Width, regularSize.Height);
                // move the card to the top edge of the panel.
                aCardBox.Top = POP;
            }


        }

        /// <summary>
        /// Repositions the cards in a panel so that they are evenly distributed in the area available.
        /// </summary>
        /// <param name="panelHand"></param>
        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;
                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;
                // An offset for the remaining cards
                int offset = 0;
                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;
                    // Determine width of all the cards/controls 
                    int allCardsWidth = (myCount - 1) * offset + cardWidth;
                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardsWidth) / 2;
                }
                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.
                // Align the "first" card (which is the last control in the collection)

                panelHand.Controls[myCount - 1].Top = 0;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n");
                panelHand.Controls[myCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = 0;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;
                }

            }
        }
        #endregion

        private void pbDeck_Click_1(object sender, EventArgs e)
        {
            

        }

        void UpdateUI(Cards sada)
        {
            pnlCardDefend.Controls.Clear();
            pnlCardAttack.Controls.Clear();
            pnlCardHome.Controls.Clear();
            foreach (Card ss in sada)
            {
                CardBox aCardBox = new CardBox(ss);
                pnlCardHome.Controls.Add(aCardBox);
                aCardBox.Click += CardBox_Click;
                // wire CardBox_MouseEnter for the "POP" visual effect
                aCardBox.MouseEnter += CardBox_MouseEnter;
                // wire CardBox_MouseLeave for the regular visual effect
                aCardBox.MouseLeave += CardBox_MouseLeave;
            }
            foreach(DurakBattle front in players.PlayingField)
            {
                CardBox aCardBoxA = new CardBox(front.Attack);
                pnlCardAttack.Controls.Add(aCardBoxA);
                if(front.Defense != null)
                {
                    CardBox aCardBoxD = new CardBox(front.Defense);
                    pnlCardDefend.Controls.Add(aCardBoxD);
                }
                
            }
            //pnlCardHome.Controls.Add(new CardBox());
            Console.WriteLine("test");
            RealignCards(pnlCardHome);
            RealignCards(pnlCardAttack);
            RealignCards(pnlCardDefend);
        }

        private void Turn_Begin(object sender, EventArgs e)
        {
            //cool way to check if the current player is a human
            if(sender as DurakHuman != null)
            {
                UpdateUI(players[3]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DurakBattle set in players.PlayingField)
            {
                Console.WriteLine(set.ToString());
            }
            (players[3] as DurakHuman).EndTurn();
        }
    }
}
    
