///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            Cards
///   Description:      Cards class handles list of card objects (specific cards)
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
    /// Cards class which is list of card, inherits generic list class
    /// </summary>
    public class Cards : List<Card>
    {
        /// <summary>
        /// Function retrieves first card
        /// </summary>
        /// <returns>
        /// First card obj in list
        /// </returns>
        public Card First()
        {
            return this[Count - 1];
        }

        /// <summary>
        /// Function takes card out from list
        /// </summary>
        /// <param name="target">Card object</param>
        /// <returns>
        /// Returns extracted card object
        /// </returns>
        public Card Extract(Card target)
        {
            Card temp = this[GetTargetIndex(target)];
            this.RemoveAt(GetTargetIndex(target));
            return temp;
        }

        /// <summary>
        /// Function gets card index based on card object
        /// </summary>
        /// <param name="target">Card object</param>
        /// <returns>
        /// Returns card index as an integer
        /// </returns>
        public int GetTargetIndex(Card target)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (target == this[i])
                {
                    return i;
                }
            }
            throw new Exception("target not located");
        }
    }
}
