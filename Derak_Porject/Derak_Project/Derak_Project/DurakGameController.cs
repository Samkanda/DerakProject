using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    class DurakGameController : List<Hand>
    {
        private int caret = 0;
        public static int ultra = 0;
        //TODO: switch to private? possibly take out of controller
        private DurakDeck deck;

        public DurakGameController() : base()
        {
            //TODO might be a better way to write this
            Hand.TurnEndEvent += delegate () { this.NewTurn(); };

            deck = new DurakDeck();
        }

        public void NewTurn()
        {
            ultra++;
            if (caret >= this.Count)
            {
                caret = 0;
            }
            Console.WriteLine(ultra + " / " + caret);
            this[caret++].TakeTurn();// NOTE: stack overflow exception?

        }

        public void Deal()
        {
            foreach (DurakHand player in this)
            {
                player.DrawToMinimum(deck);
                Console.WriteLine(player.ToString());
            }
        }

        public void StartGame()
        {
            deck.Shuffle();
            Deal();

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
