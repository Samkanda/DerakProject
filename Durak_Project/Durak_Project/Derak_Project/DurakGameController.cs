///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            DurakGameController
///   Description:      Handles gameplay elements
///   Authors:          Shoaib Ali, Luke Richards, Navpreet Kanda, Mubashir Malik
///   Date:             April 15, 2021
///---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    /// <summary>
    /// DurakGameController class, handles gameplay elements
    /// </summary>
    public class DurakGameController
    {
        #region Properties and fields

        private DurakDeck deck;

        /// <summary>
        /// auto property for getting number of cards
        /// </summary>
        public int CardsRemaining { get { return deck.Count; } }

        private Cards DiscardPile;

        /// <summary>
        /// auto property for getting number of cards
        /// </summary>
        public int CardsDiscarded { get { return DiscardPile.Count; } }

        private List<DurakBattle> playingField;

        /// <summary>
        /// Auto-property for DurakBattle PlayingField
        /// </summary>
        /// <returns>
        /// Returns list of DurakBattle instance (playingfield)
        /// </returns>
        public IList<DurakBattle> PlayingField { get { return playingField.AsReadOnly(); } }

        private List<DurakHand> players;


        /// <summary>
        /// Auto-property for DurakHand Players
        /// </summary>
        /// <returns>
        /// Returns list object of DurakHand instances (players)
        /// </returns>
        public IList<DurakHand> Players { get { return players.AsReadOnly(); } }


        private List<DurakHand> lastOut;

        /// <summary>
        /// Auto-property for DurakHand Players
        /// </summary>
        /// <returns>
        /// Returns list object of DurakHand instances (players)
        /// </returns>
        public IList<DurakHand> LastOut { get { return lastOut.AsReadOnly(); } }

        

        private bool perevodnoy = true;

        private bool cardFreeze = false;

        private DurakHand attacker;

        /// <summary>
        /// Auto-property for DurakHand Attacker
        /// </summary>
        /// <returns>
        /// Returns the attacker instance of DurakHand
        /// </returns> 
        public DurakHand Attacker { get { return attacker; } }

        private DurakHand defender;

        /// <summary>
        /// Auto-property for DurakHand Defender
        /// </summary>
        /// <returns>
        /// Returns the defender instance of DurakHand
        /// </returns>
        public DurakHand Defender { get { return defender; } }

        private DurakHand activePlayer;

        /// <summary>
        /// Auto-property for DurakHand Active player
        /// </summary>
        /// <returns>
        /// Returns the active player instance of DurakHand
        /// </returns>
        public DurakHand ActivePlayer { get { return activePlayer; } }

        private Card talon;

        public event EventHandler GameEndEvent;

        private string log = "";

        /// <summary>
        /// Auto-property for logs
        /// </summary>
        /// <returns>
        /// Returns a log as string
        /// </returns>
        public string Log { get { return log; } }

        /// <summary>
        /// Auto-property to retrieve a talon
        /// </summary>
        /// <returns>
        /// Returns the talon
        /// </returns>
        public Card Talon
        {
            get { return talon; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor of DurakGameConstroller()
        /// </summary>
        public DurakGameController(bool passing = true, int minimumCardValue =6)
        {
            //attach event handlers
            Hand.TurnEndEvent += delegate (object obj, EventArgs e) { this.EndOfTurn(); };
            Hand.CardPlayed += delegate (object obj, Card cardPlayed) { this.playCard(cardPlayed); };

            //set intial values
            perevodnoy = passing;
            DiscardPile = new Cards();
            deck = new DurakDeck(minimumCardValue);
            deck.Shuffle();
            talon = deck[0];
            playingField = new List<DurakBattle>();
            players = new List<DurakHand>();
        }
        #endregion

        #region methods
        /// <summary>
        /// Function to add a new player, and assign a DurakHand
        /// </summary>
        /// <param name="playerNew">Assign hand to new player</param>
        public void AddNewPlayer(DurakHand playerNew)
        {
            //send info about game to player
            playerNew.UpdateInfo(playingField, talon.suit, deck.Count);
            //deal them cards
            playerNew.DrawToMinimum(deck);
            //sort their cards
            playerNew.Sort();
            //add them to the list
            players.Add(playerNew);
        }

        /// <summary>
        /// Function to play a card based on card object instance
        /// </summary>
        /// <param name="cardPlayed">Card object instance</param>
        private void playCard(Card cardPlayed)
        {
            //if further card plays are forbidden this turn
            if (cardFreeze)
            {
                throw new InvalidPlayException("You cannot play anymore cards this turn");
            }
            //if the player is attacker
            if(activePlayer.Role == DurakRole.Attacker || activePlayer.Role == DurakRole.Extra)
            {
                // used is only there to remember whether the card did pass a check
                bool used = false;
                
                //check whether its possible for another attack to be played at all
                if (playingField.Count < 6 && defender.Count > 0)
                {
                    //if theres no prior attacks the attacker can play whatever card they want
                    if(playingField.Count == 0)
                    {
                        //add, log , remember that it worked
                        playingField.Add(new DurakBattle(cardPlayed));
                        log += Environment.NewLine + " attacked with " + cardPlayed.ToString();
                        used = true;
                    } 
                    else
                    {//if there are prior attacks the attack must match one fo the cards in the field
                        //bool representing whether that rank is in the field already
                        bool rankAvailable = false;
                        //loop through every card checking for a matching rank
                        foreach(DurakBattle front in playingField)
                        {
                            if(front.Attack.rank == cardPlayed.rank)
                            {
                                rankAvailable = true;
                            }
                            if(front.Defense != null && front.Defense.rank == cardPlayed.rank)
                            {
                                rankAvailable = true;
                            }
                        }
                        //if there was a matching rank then play the card
                        if (rankAvailable)
                        {
                            //add, log , remember that it worked
                            playingField.Add(new DurakBattle(cardPlayed));
                            log += Environment.NewLine + " attacked with " + cardPlayed.ToString();
                            used = true;
                        }
                    }
                }
                //if it wasnt used throw custom exception, should always be handled
                if (!used)
                {
                    throw new InvalidPlayException("You cannot do that");
                }
            }
            else if (activePlayer.Role == DurakRole.Defender)
            {
                //for remembering if the card passes the attack, if perevodnoy is false check will always fail, disabling it
                bool perevodnoySuccess = perevodnoy;

                // if not disabled check to see if it will pass
                if (perevodnoy)
                {
                    for (int i = 0; i < playingField.Count; i++)
                    {
                        if (playingField[i].Defense != null || cardPlayed.rank != playingField[i].Attack.rank)
                        {
                            perevodnoySuccess = false;
                        }
                    }
                    if(perevodnoySuccess)
                    {
                        perevodnoySuccess = Next(ActivePlayer).Count >= playingField.Count + 1;
                    }
                }
                //if it passes
                if (perevodnoySuccess)
                {
                    //add it to field as attacker
                    playingField.Add(new DurakBattle(cardPlayed));
                    log += Environment.NewLine + " passed the attack with " + cardPlayed.ToString();

                    //switch players
                    activePlayer = Previous(ActivePlayer);
                    SwitchRoles();
                    activePlayer = Next(ActivePlayer);
                    //disallow further plays this turn
                    cardFreeze = true;
                    
                } 
                else
                {// if it didnt pass
                    //current index
                    int currentIndex;

                    //loop through all playingfield
                    for (currentIndex = 0; currentIndex < playingField.Count; currentIndex++)
                    {
                        //find the first one with no defense, see break
                        if (playingField[currentIndex].Defense == null)
                        {
                            //if card matches suit of attacker
                            if (cardPlayed.suit == playingField[currentIndex].Attack.suit)
                            {
                                //if its stronger than the attacker
                                if ((int)cardPlayed.rank > (int)playingField[currentIndex].Attack.rank)
                                {
                                    //add card
                                    playingField[currentIndex].Defense = cardPlayed;
                                    log += Environment.NewLine + " defended with " + cardPlayed.ToString();
                                } else
                                {
                                    // throw error as response
                                    throw new InvalidPlayException("You cannot do that, not higher");
                                }
                            }// then if its trump but not the same suit as attacker it wins
                            else if (cardPlayed.suit == talon.suit)
                            {
                                //play the card
                                playingField[currentIndex].Defense = cardPlayed;
                                log += Environment.NewLine + " defended with " + cardPlayed.ToString();
                            } else
                            {
                                //other wise wrong suit
                                throw new InvalidPlayException("You cannot do that, wrong suit");
                            }
                            //break because the battle we wanted was found
                            break;
                        }
                    }// if tried to play a defense when there is no attack
                    if (currentIndex >= playingField.Count)
                    {
                        throw new InvalidPlayException("You cannot do that");
                    }
                }
            }
        }

        /// <summary>
        /// Function to end the active turn event
        /// </summary>
        private void EndOfTurn()
        {
            //if there was a card freeze turn it off
            cardFreeze = false;

            //keeps track of whether the active player lost a round
            bool loser = false;

            //if they are defender
            if(activePlayer == defender)
            {
                //if theres any unanswered attacks
                foreach(DurakBattle bout in playingField)
                {
                    if(bout.Defense == null)
                    {
                        loser = true;
                    } 
                }
                if (loser)
                {
                    //pick up all cards in field
                    foreach (DurakBattle bout in playingField)
                    {
                        activePlayer.AddRange(bout.Retrieve());
                    }
                    //log then start new round
                    playingField.Clear();
                    log += Environment.NewLine + Environment.NewLine + activePlayer.Name + " has ended their turn and has lost the round";
                    Deal(); 
                    CalculateRoles();
                }
            }
            else if (activePlayer == attacker)
            {
                //default to true
                loser = true;
                //set to false if any of the attacks are unanswered
                foreach (DurakBattle bout in playingField)
                {
                    if (bout.Defense == null)
                    {
                        loser = false;
                    }
                }
                if (loser)
                {
                    //if they are the loser move all to discard
                    foreach (DurakBattle bout in playingField)
                    {
                        DiscardPile.AddRange(bout.Retrieve());
                    }

                    //log then start new round
                    playingField.Clear();
                    log += Environment.NewLine + Environment.NewLine + activePlayer.Name + " has ended their turn and has lost the round";
                    Deal();
                    CalculateRoles();
                }
            }
            //if the game is continueing
            if(players.Count > 1)
            {
                NewTurn();
            } 
            else
            {
                //otherwise end the game
                GameEndEvent(this, new EventArgs());
            }
        }

        /// <summary>
        /// Denote the next player (For if player is removed from game)
        /// </summary>
        /// <param name="startPlayer">DurakHand card object list</param>
        /// <returns>The player based on location in array</returns>
        public DurakHand Next(DurakHand startPlayer)
        {
            //find player sent
            if(players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (startPlayer == players[i])
                    {
                        //grab player after in the list
                        if (i + 1 == players.Count)
                        {
                            //if at end of list grab start of list
                            return players[0];
                        } else
                        {
                            return players[i + 1];
                        }
                    }
                }
                //throw an error if its not found
                throw new ArgumentOutOfRangeException("", "hand is not in game");
            }
            return null;
        }

        /// <summary>
        /// Denote the previous player (For if player is removed from game)
        /// </summary>
        /// <param name="startPlayer">DurakHand card object list</param>
        /// <returns>The player based on index in array</returns>
        public DurakHand Previous(DurakHand startPlayer)
        {
            //find player sent
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (startPlayer == players[i])
                    {
                        //grab player after in the list
                        if (i - 1 < 0)
                        {
                            // if at beginning grab the end
                            return players[players.Count - 1];
                        } else
                        {
                            return players[i - 1];
                        }
                    }
                }
                //cant find target in the list
                throw new ArgumentOutOfRangeException("", "hand is not in game");
            }
            return null;
        }

        /// <summary>
        /// Function to check the role of active player based on players in array and if they are/arent the 'Extra' role
        /// </summary>
        private void CalculateRoles()
        {
            //double check that all players have drawn if they can
            Deal();
            //keep track of who went out
            lastOut = new List<DurakHand>();

            //remove all extras who went out this turn
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Count == 0 && players[i].Role == DurakRole.Extra)
                {
                    lastOut.Add(players[i]);
                    players.RemoveAt(i);
                }
            }
            //move the active player if attacker/defender are going out
            //if the active player leaves the game next/previous will throw unhandled exceptions
            //this block stops that
            if (attacker != null && defender != null)
            {
               
                if(activePlayer == attacker)
                {
                    // if attacker then move it back so theres no issue
                    //also if the defender goes out the attacker has to attack again on the next person
                    if (attacker.Count < 1 || defender.Count < 1)
                    {
                        activePlayer = Previous(activePlayer);
                    }
                } else
                {
                    //if the defender goes out
                    if ( defender.Count < 1)
                    {
                        //set activeplayer back 1
                        activePlayer = Previous(activePlayer);
                        //if the attacker is also going out set it back one more
                        if (attacker.Count < 1)
                        {
                            activePlayer = Previous(activePlayer);
                        }
                    }
                }
            }
            
            //remove attacker/defender if neccesary
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Count == 0 && players[i].Role != DurakRole.Extra)
                {
                    lastOut.Add(players[i]);
                    players.RemoveAt(i);
                }
            }
            //log anyone leaving the game
            if(lastOut.Count > 0)
            {
                log += Environment.NewLine + Environment.NewLine;
                foreach (DurakHand nonFool in lastOut)
                {
                    log += Environment.NewLine + nonFool.Name + " has left the game due to not having any cards";
                }
            }
            
            
            //calc new attacker/defender
            SwitchRoles();
        }

        /// <summary>
        /// Function to switch the active players role (attacker or defender)
        /// </summary>
        private void SwitchRoles()
        {
            //set everyones roles to extra
            foreach (DurakHand player in players)
            {
                player.Role = DurakRole.Extra;
            }
            //attacker is next player
            attacker = Next(activePlayer);
            attacker.Role = DurakRole.Attacker;
            //defender is next next player
            defender = Next(Next(activePlayer));
            defender.Role = DurakRole.Defender;
            //log it to sidebar
            log += Environment.NewLine + Environment.NewLine + Attacker.Name + " is the attacker and " + defender.Name + " is the defender";
        }

        /// <summary>
        /// Function to denote new turn event (log to program as well)
        /// </summary>
        private void NewTurn()
        {
            //activeplayer is now next player
            activePlayer = Next(activePlayer);
            //display new player
            log += Environment.NewLine + Environment.NewLine + activePlayer.Role + " | " + activePlayer.Name + Environment.NewLine +
                "=============================";
            //sort their hand
            activePlayer.Sort();
            //update their info
            activePlayer.UpdateInfo(playingField, talon.suit, deck.Count);
            //call their turn function
            activePlayer.TakeTurn();
        }

        /// <summary>
        /// Function to deal cards to players in array
        /// </summary>
        public void Deal()
        {
            //force all players to draw to minimum starting with active player
            DurakHand target = activePlayer;
            for (int i = 0; i < players.Count; i++)
            {
                target.DrawToMinimum(deck);
                target = Next(target);
            }
        }

        /// <summary>
        /// Function to start the game (accounts for multiple players, and not enough players as well)
        /// </summary>
        public void StartGame()
        {
            //display players
            foreach (DurakHand player in players)
            {
                Console.WriteLine(player.ToString());
            }
            //last check for players
            if(players.Count < 2)
            {
                throw new Exception("Not Enough Players");
            }

            //initial active player set
            activePlayer = players[0];

            //randomize who goes first
            Random rnd = new Random();
            for(int i = rnd.Next(players.Count);i > 0; i--)
            {
                activePlayer = Next(activePlayer);
            }
            //calculate startng roles
            CalculateRoles();
            //start first turn
            NewTurn();
        }
        #endregion
    }
}
