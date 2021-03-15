using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    class DurakBattle
    {
        private Card myAttack;
        Card Attack
        {
            get { return myAttack; }
        }
        private Card myDefense;
        Card Defense
        {
            get { return myDefense; }
            set
            {
                myDefense = value;
            }
        }

        private bool DefenderVictory;



        public DurakBattle(Card attack)
        {
            myAttack = attack;
        }

        public static void resolve(DurakBattle[] DurakRound)
        {
            foreach (DurakBattle bout in DurakRound)
            {
                Console.WriteLine("hello");
            }
        }

        



    }
}
