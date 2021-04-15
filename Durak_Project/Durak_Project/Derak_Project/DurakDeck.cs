///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            DurakDeck
///   Description:      Populates DurakDeck with Deck obj (inherits cards - list of card objs)
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
    /// DurakDeck class inherits Deck class, populates DurakDeck with Deck obj (inherits cards - list of card objs)
    /// </summary>
    public class DurakDeck : Deck
    {
        /// <summary>
        /// Default constructor for DurakDeck, which populates via iteration of suits and ranks per card
        /// </summary>
        public DurakDeck(int minimumRank = 6)
        {
            // Iterate per suits
            for (int suitVal = 1; suitVal < 5; suitVal++)
            {
                // Iterate per rank, and then instantiate new card object
                for (int rankVal = minimumRank; rankVal < 15; rankVal++)
                {
                    this.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }
    }
}
