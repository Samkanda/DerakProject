///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            DurakBattle
///   Description:      Handles bout logic (attack and defence)
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
    /// DurakBattle class handles bout logic (attack and defence)
    /// </summary>
    public class DurakBattle
    {
        /// <summary>
        /// Attack function
        /// </summary>
        /// <returns>
        /// Card object that is attacking
        /// </returns>
        private Card myAttack;
        public Card Attack
        {
            get { return myAttack; }
        }

        /// <summary>
        /// Defence function
        /// </summary>
        /// <returns>
        /// Card object that is defending
        /// </returns>
        private Card myDefense;
        public Card Defense
        {
            get { return myDefense; }
            set
            {
                myDefense = value;
            }
        }

        /// <summary>
        /// Cards retrieve function
        /// </summary>
        /// <returns>
        /// List of card objects (cards) pertaining to bout
        /// </returns>
        public Cards Retrieve()
        {
            Cards temp = new Cards { myAttack };
            if(myDefense != null)
            {
                temp.Add(myDefense);
            }
            return temp;
        }

        /// <summary>
        /// Paramaterized constructor for DurakBattle class
        /// </summary>
        /// <param name="attack">Card object</param>
        public DurakBattle(Card attack)
        {
            myAttack = attack;
        }

        /// <summary>
        /// Overridden default ToString() to show bout details
        /// </summary>
        /// <returns>
        /// Bout details as string
        /// </returns>
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
