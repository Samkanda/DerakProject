///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            Card
///   Description:      Handles different card states
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
    public class Deck : Cards
    {
        public Deck()
        {
            /* I want this back
            for (int suitVal = 1; suitVal < 5; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    this.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }*/
        }


        /// <summary>
        /// randomizes order of deck
        /// </summary>
        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[this.Count];
            Random sourceGen = new Random();
            for (int i = 0; i < this.Count; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(this.Count);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(this[sourceCard]);
            }
            this.Clear();
            this.AddRange(newDeck);
        }
    }
}
