using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO REMOVE
using System.Windows.Forms;

namespace Derak_Project
{
    public class DurakGameController
    {
        //TODO: switch to private? possibly take out of controller
        public DurakDeck deck;

        private List<DurakBattle> playingField;
        public IList<DurakBattle> PlayingField { get { return playingField.AsReadOnly(); } }

        private List<DurakHand> players;
        public IList<DurakHand> Players { get { return players.AsReadOnly(); } }

        public Cards DiscardPile;

        private DurakHand attacker;
        public DurakHand Attacker { get { return attacker; } }

        private DurakHand defender;
        public DurakHand Defender { get { return defender; } }

        private DurakHand activePlayer;
        public DurakHand ActivePlayer { get { return activePlayer; } }

        private Card talon;

        private string log = "";
        public string Log { get { return log; } }


        public Card Talon
        {
            get { return talon; }
        }

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

        public void AddNewPlayer(DurakHand playerNew)
        {
            playerNew.UpdateInfo(playingField);
            playerNew.DrawToMinimum(deck);
            players.Add(playerNew);
        }

        private void playCard(Card cardPlayed)
        {

            if(activePlayer.Role == DurakRole.Attacker)
            {
                bool used = false;
                if (playingField.Count < 6 && defender.Count > 0)
                {
                    if(playingField.Count == 0)
                    {
                        playingField.Add(new DurakBattle(cardPlayed));
                        log += Environment.NewLine +" attacked with " + cardPlayed.ToString();
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
                            log += Environment.NewLine +" attacked with " + cardPlayed.ToString();
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
                int currentIndex;
                for(currentIndex = 0; currentIndex < playingField.Count; currentIndex++)
                {
                    if(playingField[currentIndex].Defense == null)
                    {
                        if (cardPlayed.suit == playingField[currentIndex].Attack.suit)
                        {
                            if((int)cardPlayed.rank > (int)playingField[currentIndex].Attack.rank)
                            {
                                playingField[currentIndex].Defense = cardPlayed;
                                log += Environment.NewLine +" defended with " + cardPlayed.ToString();
                            } else
                            {
                                throw new InvalidPlayException("You cannot do that, not higher");
                            }
                        }
                        else if (cardPlayed.suit == talon.suit)
                        {
                            playingField[currentIndex].Defense = cardPlayed;
                            log += Environment.NewLine +" defended with " + cardPlayed.ToString();
                        }
                        else
                        {
                            throw new InvalidPlayException("You cannot do that, wrong suit");
                        }
                        break;
                    }
                }
                if(currentIndex >= playingField.Count)
                {
                    throw new InvalidPlayException("You cannot do that");
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

        private void EndOfTurn()
        {
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
                if(players.Count == 0)
                {
                    MessageBox.Show("TIE");
                } 
                else
                {
                    MessageBox.Show(players[0].Name+" is the durak");
                }
            }
        }

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
            attacker = Next(activePlayer);
            attacker.Role = DurakRole.Attacker;
            defender = Next(Next(activePlayer));
            defender.Role = DurakRole.Defender;
            log += Environment.NewLine + Environment.NewLine + Attacker.Name + " is the attacker and " + defender.Name + " is the defender";
        }


        private void NewTurn()
        {
            activePlayer = Next(activePlayer);
            log += Environment.NewLine + Environment.NewLine + activePlayer.Role + " | " + activePlayer.Name + Environment.NewLine +
                "=============================";

            
            activePlayer.UpdateInfo(playingField);
            activePlayer.TakeTurn();
        }

        public void Deal()
        {
            foreach (DurakHand player in players)
            {
                player.DrawToMinimum(deck);
                //Console.WriteLine(player.ToString());
            }
        }

        public void StartGame()
        {
            //deck.Shuffle();
            //Deal();
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
