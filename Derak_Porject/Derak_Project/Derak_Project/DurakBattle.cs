using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    public class DurakBattle
    {
        private Card myAttack;
        public Card Attack
        {
            get { return myAttack; }
        }
        private Card myDefense;
        public Card Defense
        {
            get { return myDefense; }
            set
            {
                myDefense = value;
            }
        }

        public Cards Retrieve()
        {
            Cards temp = new Cards { myAttack };
            if(myDefense != null)
            {
                temp.Add(myDefense);
            }
            return temp;
        }

        public DurakBattle(Card attack)
        {
            myAttack = attack;
        }

        //public static void resolve(DurakBattle[] DurakRound)
        //{
        //    foreach (DurakBattle bout in DurakRound)
        //    {
        //        Console.WriteLine("hello");
        //    }
        //}

        public override string ToString()
        {
            if(Defense != null)
            {
                return Attack.ToString() + " >>>> " + Defense.ToString();
            } 
            else
            {
                return Attack.ToString() + " >>>> ";
            }
            
        }





    }
}
