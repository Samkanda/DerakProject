///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            DurakHand
///   Description:      DurakHand class inherits hand class and handles cards in DurakHand
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
    /// DurakHand class inherits hand class
    /// </summary>
    public abstract class DurakHand : Hand
    {
        public const int MinimumHandSize = 6;

        /// <summary>
        /// DurakHand default constructor inherits base class constructor
        /// </summary>
        public DurakHand() : base()
        {

        }

        /// <summary>
        /// DurakRole function (getter/setter) for role
        /// </summary>
        /// <returns>
        /// The Durak player role
        /// </returns>
        private DurakRole myRole;
        public DurakRole Role
        {
            get { return myRole; }
            set
            {
                myRole = value;
            }
        }

        /// <summary>
        /// Auto-property for PlayingField 
        /// </summary>
        /// <returns>
        /// Returns battle array
        /// </returns>
        private List<DurakBattle> myPlayingField;
        protected List<DurakBattle> PlayingField
        {
            get { return myPlayingField; }
        }

        private Suit myTrump;
        protected Suit Trump
        {
            get { return myTrump; }
        }

        private int remainingDraws;
        protected int RemainingDraws
        {
            get { return remainingDraws; }
        }


        public void UpdateInfo(List<DurakBattle> Field, Suit trump, int remaining)
        {
            myPlayingField = Field;
            myTrump = trump;
            remainingDraws = remaining;
        }

        /// <summary>
        /// Function to draw cards
        /// </summary>
        /// <param name="drawPile">Array of cards (drawpile)</param>
        public void DrawToMinimum(Cards drawPile)
        {
            DrawTo(drawPile, MinimumHandSize);
        }

        /// <summary>
        /// Function to play card based on index
        /// </summary>
        /// <param name="index">Index of card play</param>
        protected void PlayCard(int index)
        {
            try
            {
                SendCardPlayed(this[index]);
                Extract(this[index]);
            } 
            catch(Exception e)
            {
                throw e;
            }
            
        }

    }
}
