///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            DurakComputer
///   Description:      Handles basic computer ai by iterating all playable moves
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
    /// DurakComputer class inherits DurakHand class
    /// </summary>
    public class DurakComputer : DurakHand
    {
        /// <summary>
        /// DurakComputer constructor
        /// </summary>
        public DurakComputer() : base()
        {
            Role = DurakRole.Extra;
           
        }

        /// <summary>
        /// TakeTurn() function handles computer moves (iterates all playable - basic ai)
        /// </summary>
        public override void TakeTurn()
        {
            SendTurnbeginEvent();

            for(int i = this.Count-1; i >= 0 ; i--)
            {
                try
                {
                    PlayCard(i);
                } 
                catch (Exception e)
                {

                }
            }

            SendTurnEndEvent();
            // RUNS RECURSIVELY NOTHING BELOW THIS POINT
        }
    }
}
