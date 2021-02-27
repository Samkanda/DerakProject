using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    class Card
    {
        /// <summary>
        /// enum for card's suit
        /// </summary>
        public readonly Suit suit;
        /// <summary>
        ///  enum for card's rank
        /// </summary>
        public readonly Rank rank;

        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="newSuit"></param>
        /// <param name="newRank"></param>
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public Card()
        {
        }

        /// <summary>
        /// to string override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }
    }
}
