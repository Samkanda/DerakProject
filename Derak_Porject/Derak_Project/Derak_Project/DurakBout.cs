using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    class DurakBout
    {
        Card Attack;
        Card Defense;


        public DurakBout()
        {

        }

        public static void resolve(DurakBout[] DurakRound)
        {
            foreach (DurakBout bout in DurakRound)
            {
                Console.WriteLine("hello");
            }
        }

        // a dangerous but simple strategy objects when assigned are add checks to the setter to help ensure no one tries to pass bad info 
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
        }



    }
}
