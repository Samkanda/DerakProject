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

        /// <summary>
        /// Auto-property field for suit trump
        /// </summary>
        /// <returns>
        /// The trump suit to be used
        /// </returns>
        private Suit myTrump;
        protected Suit Trump
        {
            get { return myTrump; }
        }

        /// <summary>
        /// Auto-property field for remaining draws count
        /// </summary>
        /// <returns>
        /// An integer representing the remaining draws
        /// </returns>
        private int remainingDraws;
        protected int RemainingDraws
        {
            get { return remainingDraws; }
        }

        /// <summary>
        /// Update info function to update game state information
        /// </summary>
        /// <param name="Field">Cards on field</param>
        /// <param name="trump">The trump card suit</param>
        /// <param name="remaining">The remaining draws</param>
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
            // Try playing a card at given index
            try
            {
                SendCardPlayed(this[index]);
                Extract(this[index]);
            }

            // If it isn't a valid play, exception is handled accordingly
            catch(Exception e)
            {
                throw e;
            }
            
        }

    }
}
