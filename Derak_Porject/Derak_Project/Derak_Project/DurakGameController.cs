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
        private int caret = -1;
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

            if(players[caret].Role == DurakRole.Attacker)
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
            else if (players[caret].Role == DurakRole.Defender)
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
            else if (players[caret].Role == DurakRole.Extra)
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

            //this is currently implemented elsewhere
            //players[caret].Extract(cardPlayed);


        }

        private void EndOfTurn()
        {
            bool loser = false;
            if(players[caret] == defender)
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
                        players[caret].AddRange(bout.Retrieve());
                    }
                    playingField.Clear();
                    MessageBox.Show(players[caret].Role + " " + players[caret].Name + " has lost");
                    CalculateRoles();
                    Deal();
                    DropPlayers();
                }
            }
            else if (players[caret] == attacker)
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
                    MessageBox.Show(players[caret].Role + " " + players[caret].Name + " has lost");
                    CalculateRoles();
                    Deal();
                    DropPlayers();
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

        private void DropPlayers()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if(players[i].Count == 0)
                {
                    players.RemoveAt(i);
                }
            }
        }


        //TODO make work for 4 players? I think it works
        private void CalculateRoles()
        {
            foreach(DurakHand player in players)
            {
                player.Role = DurakRole.Extra;
            }
            if(caret +1 >= players.Count)
            {
                attacker = players[0];
                attacker.Role = DurakRole.Attacker;
                defender = players[1];
                defender.Role = DurakRole.Defender;
            } 
            else
            {
                attacker = players[caret+1];
                attacker.Role = DurakRole.Attacker;
                if (caret + 2 >= players.Count)
                {
                    defender = players[0];
                    defender.Role = DurakRole.Defender;
                } else
                {
                    defender = players[caret + 2];
                    defender.Role = DurakRole.Defender;
                }
            }


        }


        private void NewTurn()
        {
            caret++;
            if (caret >= players.Count)
            {
                caret = 0;
            }
            //players[caret].DrawToMinimum(deck);
            log += Environment.NewLine + Environment.NewLine + players[caret].Role + " | " + players[caret].Name + Environment.NewLine +
                "=============================";
            players[caret].UpdateInfo(playingField);
            players[caret].TakeTurn();
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
            CalculateRoles();


            NewTurn();
        }
    }
}
