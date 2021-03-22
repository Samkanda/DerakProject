using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    public class DurakGameController
    {
        private int caret = 0;
        //TODO: switch to private? possibly take out of controller
        private DurakDeck deck;

        private List<DurakBattle> playingField;
        public IList<DurakBattle> PlayingField { get { return playingField.AsReadOnly(); } }

        public List<DurakHand> players;
        public IList<DurakHand> Players { get { return players.AsReadOnly(); } }

        private DurakHand attacker;
        public DurakHand Attacker { get { return attacker; } }

        private DurakHand defender;
        public DurakHand Defender { get { return defender; } }

        private Card talon;

        public Card Talon
        {
            get { return talon; }
        }

        public DurakGameController()
        {
            Hand.TurnEndEvent += delegate (object obj, EventArgs e) { this.NewTurn(); };
            Hand.CardPlayed += delegate (object obj, Card cardPlayed) { this.playCard(cardPlayed); };

            deck = new DurakDeck();
            deck.Shuffle();
            talon = deck[deck.Count - 1];
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
            int pseudoCaret = caret - 1;
            if(pseudoCaret < 0)
            {
                pseudoCaret = players.Count - 1;
            }

            if(players[pseudoCaret].Role == DurakRole.Attacker)
            {
                bool used = false;
                if (playingField.Count < 6 && defender.Count > 0)
                {
                    if(playingField.Count == 0)
                    {
                        playingField.Add(new DurakBattle(cardPlayed));
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
                            used = true;
                        }
                    }
                }
                if (!used)
                {
                    throw new InvalidPlayException("You cannot do that");
                }
            }
            else if (players[pseudoCaret].Role == DurakRole.Defender)
            {
                int currentIndex;
                for(currentIndex = 0; currentIndex < playingField.Count; currentIndex++)
                {
                    if(playingField[currentIndex].Defense == null)
                    {
                        if (cardPlayed.suit == playingField[currentIndex].Attack.suit || cardPlayed.suit == talon.suit)
                        {
                            if((int)cardPlayed.rank > (int)playingField[currentIndex].Attack.rank)
                            {
                                playingField[currentIndex].Defense = cardPlayed;
                            } else
                            {
                                throw new InvalidPlayException("You cannot do that, not higher");
                            }
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
            //else if (players[pseudoCaret].Role == DurakRole.Extra)
            //{
            //    Console.WriteLine(cardPlayed.ToString());
            //    playingField.Add(new DurakBattle(cardPlayed));
            //}
            else
            {
                throw new NotImplementedException("role not implemented");
            }

            //this is currently implemented elsewhere
            //players[pseudoCaret].Extract(cardPlayed);


        }


        private void NewTurn()
        {
            if (caret >= players.Count)
            {
                caret = 0;
            }
            //players[caret].DrawToMinimum(deck);
            players[caret].UpdateInfo(playingField);
            players[caret++].TakeTurn();
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
            attacker = players[0];
            attacker.Role = DurakRole.Attacker;
            defender = players[1];
            defender.Role = DurakRole.Defender;


            NewTurn();
        }
    }
}
