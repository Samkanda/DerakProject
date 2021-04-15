///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            DurakHuman
///   Description:      DurakHuman inherits DurakHand and handles player related gameplay elements for hand
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
    /// DurakHuman inherits DurakHand and handles player related gameplay elements for hand
    /// </summary>
    public class DurakHuman : DurakHand
    {
        private bool IsTurn = false;

        /// <summary>
        /// DurakHuman default constructor inherits base constructor from DurakHand
        /// </summary>
        public DurakHuman() : base()
        {
            Role = DurakRole.Defender;
        }

        /// <summary>
        /// Function to handle players take turn
        /// </summary>
        public override void TakeTurn()
        {
            IsTurn = true;
            SendTurnbeginEvent();
        }

        /// <summary>
        /// Function to handle end turn event for human player
        /// </summary>
        public void EndTurn()
        {
            if (IsTurn)
            {
                IsTurn = false;
                SendTurnEndEvent();
            }
        }

        /// <summary>
        /// Function to play card as DurakHuman
        /// </summary>
        /// <param name="target">Index of card for human to play</param>
        public void PlayerPlayCard(Card target)
        {
            if (IsTurn)
            {
                PlayCard(GetTargetIndex(target));
            }
        }
    }
}
