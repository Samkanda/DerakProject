using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    public class DurakGameController : List<DurakHand>
    {
        private int caret = 0;
        public static int ultra = 0;
        //TODO: switch to private? possibly take out of controller
        private DurakDeck deck;
        public List<DurakBattle> PlayingField;

        public DurakGameController() : base()
        {
            //TODO might be a better way to write this
            Hand.TurnEndEvent += delegate (object obj, EventArgs e) { this.NewTurn(); };
            Hand.CardPlayed += delegate (object obj, Card cardPlayed) { this.playCard(cardPlayed); };

            deck = new DurakDeck();
            PlayingField = new List<DurakBattle>();

        }

        private void playCard(Card cardPlayed)
        {
            int pseudoCaret = caret - 1;
            if(pseudoCaret < 0)
            {
                pseudoCaret = this.Count - 1;
            }

            if(this[pseudoCaret].Role == DurakRole.Attacker)
            {
                PlayingField.Add(new DurakBattle(cardPlayed));
            }
            else if(this[pseudoCaret].Role == DurakRole.Extra)
            {
                Console.WriteLine(cardPlayed.ToString());
                PlayingField.Add(new DurakBattle(cardPlayed));
            } 
            else if (this[pseudoCaret].Role == DurakRole.Defender)
            {
                bool used = false;
                foreach (DurakBattle set in PlayingField)
                {
                    if(set.Defense == null && !used)
                    {
                        set.Defense = cardPlayed;
                        used = true;
                    }
                }
            }



        }



        private void NewTurn()
        {
            ultra++;
            if (caret >= this.Count)
            {
                caret = 0;
            }
            Console.WriteLine(ultra + " / " + caret);

            this[caret].UpdateInfo(PlayingField);
            this[caret++].TakeTurn();
        }

        public void Deal()
        {
            foreach (DurakHand player in this)
            {
                player.DrawToMinimum(deck);
                //Console.WriteLine(player.ToString());
            }
        }

        public void StartGame()
        {
            deck.Shuffle();
            Deal();
            foreach (DurakHand player in this)
            {
                Console.WriteLine(player.ToString());
            }
            NewTurn();
        }

        //TODO get rid of this garbage. store ints that refer to positions in the list obv
        // OR make an enum and store roles in the hand objects. THIS REQUIRES THINKING. need to figure how how the roles progress and implement that
        // a dangerous but simple strategy objects when assigned are add checks to the setter to help ensure no one tries to pass bad info 
        /*
        private static Hand defender;
        public static Hand Defender
        {
            get { return defender; }
            set
            {
                defender = value;
            }
        }
        private static Hand attacker;
        public static Hand Attacker
        {
            get { return attacker; }
            set
            {
                attacker = value;
            }
        }//*/




    }
}
