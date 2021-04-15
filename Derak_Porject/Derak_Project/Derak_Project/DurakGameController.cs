///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            DurakGameController
///   Description:      Handles gameplay elements
///   Authors:          Shoaib Ali, Luke Richards, Navpreet Kanda, Mubashir Malik
///   Date:             April 14, 2021
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
        //TODO: switch to private? possibly take out of controller
        public DurakDeck deck;

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

        public Cards DiscardPile;

        private const bool perevodnoy = true;

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

        public static event EventHandler GameEndEvent;

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

        /// <summary>
        /// Default constructor of DurakGameConstroller()
        /// </summary>
        public DurakGameController()
        {
            Hand.TurnEndEvent += delegate (object obj, EventArgs e) { this.EndOfTurn(); };
            Hand.CardPlayed += delegate (object obj, Card cardPlayed) { this.playCard(cardPlayed); };

            DiscardPile = new Cards();
            deck = new DurakDeck();
            deck.Shuffle();
            talon = deck[0];
            playingField = new List<DurakBattle>();
            players = new List<DurakHand>();
        }

        /// <summary>
        /// Function to add a new player, and assign a DurakHand
        /// </summary>
        /// <param name="playerNew">Assign hand to new player</param>
        public void AddNewPlayer(DurakHand playerNew)
        {
            playerNew.UpdateInfo(playingField, talon.suit);
            playerNew.DrawToMinimum(deck);
            players.Add(playerNew);
        }

        /// <summary>
        /// Function to play a card based on card object instance
        /// </summary>
        /// <param name="cardPlayed">Card object instance</param>
        private void playCard(Card cardPlayed)
        {
            if (cardFreeze)
            {
                throw new InvalidPlayException("You cannot play anymore cards this turn");
            }
            if(activePlayer.Role == DurakRole.Attacker)
            {
                bool used = false;
                if (playingField.Count < 6 && defender.Count > 0)
                {
                    if(playingField.Count == 0)
                    {
                        playingField.Add(new DurakBattle(cardPlayed));
                        log += Environment.NewLine + " attacked with " + cardPlayed.ToString();
                        used = true;
                    } 
                    else
                    {
                        bool rankAvailable = false;
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
                        if (rankAvailable)
                        {
                            playingField.Add(new DurakBattle(cardPlayed));
                            log += Environment.NewLine + " attacked with " + cardPlayed.ToString();
                            used = true;
                        }
                    }
                }
                if (!used)
                {
                    throw new InvalidPlayException("You cannot do that");
                }
            }
            else if (activePlayer.Role == DurakRole.Defender)
            {
                bool perevodnoySuccess = perevodnoy;
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
                if (perevodnoySuccess)
                {
                    //throw new InvalidPlayException("THIS WOULD PASS << PH");
                    playingField.Add(new DurakBattle(cardPlayed));
                    log += Environment.NewLine + " passed the attack with " + cardPlayed.ToString();
                    activePlayer = Previous(ActivePlayer);
                    SwitchRoles();
                    activePlayer = Next(ActivePlayer);
                    cardFreeze = true;
                    
                } 
                else
                {
                    int currentIndex;
                    for (currentIndex = 0; currentIndex < playingField.Count; currentIndex++)
                    {
                        if (playingField[currentIndex].Defense == null)
                        {
                            if (cardPlayed.suit == playingField[currentIndex].Attack.suit)
                            {
                                if ((int)cardPlayed.rank > (int)playingField[currentIndex].Attack.rank)
                                {
                                    playingField[currentIndex].Defense = cardPlayed;
                                    log += Environment.NewLine + " defended with " + cardPlayed.ToString();
                                } else
                                {
                                    throw new InvalidPlayException("You cannot do that, not higher");
                                }
                            } else if (cardPlayed.suit == talon.suit)
                            {
                                playingField[currentIndex].Defense = cardPlayed;
                                log += Environment.NewLine + " defended with " + cardPlayed.ToString();
                            } else
                            {
                                throw new InvalidPlayException("You cannot do that, wrong suit");
                            }
                            break;
                        }
                    }
                    if (currentIndex >= playingField.Count)
                    {
                        throw new InvalidPlayException("You cannot do that");
                    }
                }
            }
            else if (activePlayer.Role == DurakRole.Extra)
            {
                //TODO same as attack function move to its own thing?
                bool used = false;
                if (playingField.Count < 6 && defender.Count > 0)
                {
                    if (playingField.Count == 0)
                    {
                        playingField.Add(new DurakBattle(cardPlayed));
                        log += Environment.NewLine + " attacked with " + cardPlayed.ToString();
                        used = true;
                    } else
                    {
                        bool rankAvailable = false;
                        foreach (DurakBattle front in playingField)
                        {
                            if (front.Attack.rank == cardPlayed.rank)
                            {
                                rankAvailable = true;
                            }
                            if (front.Defense != null && front.Defense.rank == cardPlayed.rank)
                            {
                                rankAvailable = true;
                            }
                        }
                        if (rankAvailable)
                        {
                            playingField.Add(new DurakBattle(cardPlayed));
                            log += Environment.NewLine + " attacked with " + cardPlayed.ToString();
                            used = true;
                        }
                    }
                }
                if (!used)
                {
                    throw new InvalidPlayException("You cannot do that");
                }
            }
        }

        /// <summary>
        /// Function to end the active turn event
        /// </summary>
        private void EndOfTurn()
        {
            cardFreeze = false;

            bool loser = false;
            if(activePlayer == defender)
            {
                foreach(DurakBattle bout in playingField)
                {
                    if(bout.Defense == null)
                    {
                        loser = true;
                    } 
                }
                if (loser)
                {
                    foreach (DurakBattle bout in playingField)
                    {
                        activePlayer.AddRange(bout.Retrieve());
                    }
                    playingField.Clear();
                    log += Environment.NewLine + Environment.NewLine + activePlayer.Name + " has ended their turn and has lost the round";
                    Deal(); 
                    CalculateRoles();
                }
            }
            else if (activePlayer == attacker)
            {
                loser = true;
                foreach (DurakBattle bout in playingField)
                {
                    if (bout.Defense == null)
                    {
                        loser = false;
                    }
                }
                if (loser)
                {
                    foreach (DurakBattle bout in playingField)
                    {
                        DiscardPile.AddRange(bout.Retrieve());
                    }
                    playingField.Clear();
                    log += Environment.NewLine + Environment.NewLine + activePlayer.Name + " has ended their turn and has lost the round";
                    Deal();
                    CalculateRoles();
                }
            }

            if(players.Count > 1)
            {
                NewTurn();
            } 
            else
            {
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
            if(players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (startPlayer == players[i])
                    {
                        if (i + 1 == players.Count)
                        {
                            return players[0];
                        } else
                        {
                            return players[i + 1];
                        }
                    }
                }
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
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (startPlayer == players[i])
                    {
                        if (i - 1 < 0)
                        {
                            return players[players.Count - 1];
                        } else
                        {
                            return players[i - 1];
                        }
                    }
                }
                throw new ArgumentOutOfRangeException("", "hand is not in game");
            }
            return null;
        }

        /// <summary>
        /// Function to check the role of active player based on players in array and if they are/arent the 'Extra' role
        /// </summary>
        private void CalculateRoles()
        {
            Deal();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Count == 0 && players[i].Role == DurakRole.Extra)
                {
                    players.RemoveAt(i);
                }
            }
            if(attacker != null && defender != null)
            {
                if (attacker.Count < 1 || defender.Count < 1)
                {
                    activePlayer = Previous(activePlayer);
                }
            }
            

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Count == 0 && players[i].Role != DurakRole.Extra)
                {
                    players.RemoveAt(i);
                }
            }

            foreach (DurakHand player in players)
            {
                player.Role = DurakRole.Extra;
            }
            SwitchRoles();
        }

        /// <summary>
        /// Function to switch the active players role (attacker or defender)
        /// </summary>
        private void SwitchRoles()
        {
            attacker = Next(activePlayer);
            attacker.Role = DurakRole.Attacker;
            defender = Next(Next(activePlayer));
            defender.Role = DurakRole.Defender;
            log += Environment.NewLine + Environment.NewLine + Attacker.Name + " is the attacker and " + defender.Name + " is the defender";
        }

        /// <summary>
        /// Function to denote new turn event (log to program as well)
        /// </summary>
        private void NewTurn()
        {
            activePlayer = Next(activePlayer);
            log += Environment.NewLine + Environment.NewLine + activePlayer.Role + " | " + activePlayer.Name + Environment.NewLine +
                "=============================";

            
            activePlayer.UpdateInfo(playingField, talon.suit);
            activePlayer.TakeTurn();
        }

        /// <summary>
        /// Function to deal cards to players in array
        /// </summary>
        public void Deal()
        {
            foreach (DurakHand player in players)
            {
                player.DrawToMinimum(deck);
            }
        }

        /// <summary>
        /// Function to start the game (accounts for multiple players, and not enough players as well)
        /// </summary>
        public void StartGame()
        {
            foreach (DurakHand player in players)
            {
                Console.WriteLine(player.ToString());
            }
            if(players.Count < 2)
            {
                throw new Exception("Not Enough Players");
            }
            activePlayer = players[players.Count-1];

            CalculateRoles();
            NewTurn();
        }
    }
}
