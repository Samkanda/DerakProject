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
                playingField.Add(new DurakBattle(cardPlayed));
            }
            else if(players[pseudoCaret].Role == DurakRole.Extra)
            {
                Console.WriteLine(cardPlayed.ToString());
                playingField.Add(new DurakBattle(cardPlayed));
            } 
            else if (players[pseudoCaret].Role == DurakRole.Defender)
            {
                bool used = false;
                foreach (DurakBattle set in playingField)
                {
                    if(set.Defense == null && !used)
                    {

                        set.Defense = cardPlayed;
                        used = true;
                    }
                }
                if (!used)
                {
                    throw new InvalidPlayException("You cannot do that");
                }
            }
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
