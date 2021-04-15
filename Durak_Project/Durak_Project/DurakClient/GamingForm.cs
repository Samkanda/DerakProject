///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            GamingForm
///   Description:      Main gaming form contains UI
///   Authors:          Shoaib Ali, Luke Richards, Navpreet Kanda, Mubashir Malik
///   Card Img Source:  http://acbl.mybigcommerce.com/52-playing-cards/  
///   Date:             April 14, 2021
///---------------------------------------------------------------------------------

using System;
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
        DurakGameController players;
        DurakHuman currentHumanPlayer;

        /// <summary>
        /// Constructor for frmMainForm
        /// </summary>
        public GamingForm(int humans = 1, int computers = 1, bool perevodnoy = true, int minimumCardValue = 6)
        {
            InitializeComponent();
            DurakHand player;
            players = new DurakGameController(perevodnoy, minimumCardValue);

            // For human players add them to game controller
            for (int i = 0; i < humans; i++)
            {
                player = new DurakHuman();
                players.AddNewPlayer(player);
                player.Name = "Player "+(i+1);
            }

            // For computer players add them to game controller
            for (int i = 0; i < computers; i++)
            {
                player = new DurakComputer();
                players.AddNewPlayer(player);
                player.Name = "Computer "+(i+1);
            }
            // set up event handlers
            players.GameEndEvent += delegate (object obj, EventArgs e) { GameEnd(obj as DurakGameController); };
            Hand.TurnBeginEvent += delegate (object obj, EventArgs e) { Turn_Begin(obj, e); };
            //set value
            pbDeck.Card = players.Talon;
            //start game
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
        #endregion
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
                        currentHumanPlayer.PlayerPlayCard(aCardBox.Card);
                        // Remove the card from the home panel
                        // Add the control to the play panel
                        pnlCardHome.Controls.Remove(aCardBox);
                        RealignCards(pnlCardHome);
                        if(currentHumanPlayer == players.Attacker || currentHumanPlayer.Role == DurakRole.Extra)
                        {
                            pnlCardAttack.Controls.Add(aCardBox);
                        }
                        else if (currentHumanPlayer == players.Defender)
                        {
                            pnlCardDefend.Controls.Add(aCardBox);
                            
                        }
                        // realign cards
                        RealignBattles(pnlCardAttack, pnlCardDefend);
                    } 
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
        ///// <summary>
        /////  CardBox controls grow in size when the mouse is over it.
        ///// </summary>
        //void CardBox_MouseEnter(object sender, EventArgs e)
        //{
        //    // Convert sender to a CardBox
        //    CardBox aCardBox = sender as CardBox;
        //    MessageBox.Show(".");
        //    // If the conversion worked
        //    if (aCardBox != null)
        //    {
        //        // Enlarge the card for visual effect
        //        aCardBox.Size = new Size(regularSize.Width + POP, regularSize.Height + POP);
        //        // move the card to the top edge of the panel.
        //        aCardBox.Top = 0;
        //    }
        //}

        ///// <summary>
        ///// CardBox control shrinks to regular size when the mouse leaves.
        ///// </summary>
        //void CardBox_MouseLeave(object sender, EventArgs e)
        //{
        //    // Convert sender to a CardBox
        //    CardBox aCardBox = sender as CardBox;

        //    // If the conversion worked
        //    if (aCardBox != null)
        //    {
        //        // resize the card back to regular size
        //        aCardBox.Size = new Size(regularSize.Width, regularSize.Height);
        //        // move the card to the top edge of the panel.
        //        aCardBox.Top = POP;
        //    }


        //}

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

        /// <summary>
        /// Function to realign the cards so that the bout displays correctly (whether attacking or defending)
        /// </summary>
        /// <param name="panelAttack"></param>
        /// <param name="panelDefend"></param>
        private void RealignBattles(Panel panelAttack, Panel panelDefend)
        {
            int myCount = panelAttack.Controls.Count;
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = panelAttack.Controls[0].Width;
                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = 10;
                // An offset for the remaining cards
                int offset = 0;
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelAttack.Width - cardWidth) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;
                    // Determine width of all the cards/controls 
                    int allCardsWidth = (myCount - 1) * offset + cardWidth;
                }
                panelAttack.Controls[0].Top = 0;
                //System.Diagnostics.Debug.Write(panelAttack.Controls[myCount - 1].Top.ToString() + "\n");
                panelAttack.Controls[0].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = 1; index < myCount; index++)
                {
                    // Align the current card
                    panelAttack.Controls[index].Top = 0;
                    panelAttack.Controls[index].Left = panelAttack.Controls[index-1].Left + offset;
                }
                if(panelDefend.Controls.Count > 0)
                {
                    panelDefend.Controls[0].Top = 0;
                    panelDefend.Controls[0].Left = startPoint;
                    for (int index = 1; index < panelDefend.Controls.Count; index++)
                    {
                        // Align the current card
                        panelDefend.Controls[index].Top = 0;
                        panelDefend.Controls[index].Left = panelDefend.Controls[index - 1].Left + offset;
                    }
                }
            }
        }


        void GameEnd(DurakGameController game)
        {
            if(game.Players.Count < 1)
            {
                string outMessage = game.Players[0].Name;
                for (int i = 1; i < game.Players.Count; i++)
                {
                    outMessage += "and" + game.Players[i].Name;
                }
                MessageBox.Show(outMessage + " have tied for losing and are the fools");
            } 
            else
            {
                MessageBox.Show( game.Players[0].Name + " has lost the game and is the fool");
            }
            this.Close();
        }

        void UpdateUI(Cards info)
        {
            pnlCardDefend.Controls.Clear();
            pnlCardAttack.Controls.Clear();
            pnlCardHome.Controls.Clear();
            foreach (Card ss in info)
            {
                CardBox aCardBox = new CardBox(ss);
                pnlCardHome.Controls.Add(aCardBox);
                aCardBox.Click += CardBox_Click;
                //// wire CardBox_MouseEnter for the "POP" visual effect
                //aCardBox.MouseEnter += CardBox_MouseEnter;
                //// wire CardBox_MouseLeave for the regular visual effect
                //aCardBox.MouseLeave += CardBox_MouseLeave;
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
            // pnlCardHome.Controls.Add(new CardBox());
            // Console.WriteLine("test");
            RealignCards(pnlCardHome);
            RealignBattles(pnlCardAttack, pnlCardDefend);

            txtOpponent.Text = "";
            foreach(DurakHand player in players.Players)
            {
                if(player != currentHumanPlayer)
                {
                    txtOpponent.Text += "["+player.Name + "] : " + player.Count + " cards"+ Environment.NewLine;
                }
            }
            txtOpponent.Height = TextRenderer.MeasureText(txtOpponent.Text, txtOpponent.Font).Height;

            //TODO CHANGE
            txtDeck.Text = "Deck : " + players.CardsRemaining;
            txtDiscard.Text = "Discard : " + players.CardsDiscarded;
            txtLog.Text = players.Log;
            txtLog.Focus();
            txtLog.ScrollToCaret();
            pnlCardHome.Focus();
            //txtLog.AppendText("");

        }

        private void Turn_Begin(object sender, EventArgs e)
        {
            //cool way to check if the current player is a human
            currentHumanPlayer = sender as DurakHuman;
            if (currentHumanPlayer != null)
            {
                UpdateUI(currentHumanPlayer);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DurakBattle set in players.PlayingField)
            {
                Console.WriteLine(set.ToString());
            }
            currentHumanPlayer.EndTurn();
        }

    }
}
    
