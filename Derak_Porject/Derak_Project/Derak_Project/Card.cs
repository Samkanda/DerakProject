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
using System.Drawing;

namespace Derak_Project
{
    /// <summary>
    /// The card class, handles different card states
    /// </summary>
    public class Card : IComparable
    {
        /// <summary>
        /// Function to change cards suit
        /// </summary>
        /// <returns>
        /// The cards suit
        /// </returns>
        protected Suit mySuit;
        public Suit suit
        {
            get { return mySuit; }
            set { mySuit = value; }
        }

        /// <summary>
        /// Function to change cards rank
        /// </summary>
        /// <returns>
        /// The cards rank
        /// </returns>
        protected Rank myRank;
        public Rank rank
        {
            get { return myRank; }
            set { myRank = value; }
        }

        /// <summary>
        /// Function to change cards face state
        /// </summary>
        /// <returns>
        /// The boolean state of the cards face
        /// </returns>
        protected bool faceUp = true;
        public bool FaceUp
        {
            get { return faceUp; }
            set { faceUp = value; }
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="newSuit">Initializes card with suit</param>
        /// <param name="newRank">Initializes card with rank</param>
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Card()
        {
        }

        /// <summary>
        /// Function to retrieve card image from resource manager
        /// </summary>
        /// <returns>
        /// The card image -> (pertaining to file)
        /// </returns>
        public Image GetCardImage()
        {
            string imageName;
            Image cardImage;
            if (!faceUp)
            {
                imageName = "blue_back";
            } else
            {
                imageName = myRank.ToString() + "_" + mySuit.ToString();
            }
            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;
            return cardImage;
        }

        public virtual int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Unable to compare a Card to a null object");
            }
            Card compareCard = obj as Card;
            if (compareCard != null)
            {
                int thisSort = (int)this.rank * 10 + (int)this.mySuit;
                int compareCardSort = (int)compareCard.rank * 10 + (int)compareCard.mySuit;
                return (thisSort.CompareTo(compareCardSort));
            } else
            {
                throw new ArgumentException("Object being compared cannot be converted to a Card");
            }
        }

        //public static bool operator ==(PlayingCard left, PlayingCard right)
        //{
        //    return left.CardValue == right.CardValue;
        //}

        //public static bool operator !=(PlayingCard left, PlayingCard right)
        //{
        //    return (left.CardValue != right.CardValue);
        //}

        //public static bool operator <(PlayingCard left, PlayingCard right)
        //{
        //    return (left.CardValue < right.CardValue);
        //}

        //public static bool operator >(PlayingCard left, PlayingCard right)
        //{
        //    return (left.CardValue > right.CardValue);
        //}

        //public static bool operator <=(PlayingCard left, PlayingCard right)
        //{
        //    return (left.CardValue <= right.CardValue);
        //}

        //public static bool operator >=(PlayingCard left, PlayingCard right)
        //{
        //    return (left.CardValue >= right.CardValue);
        //}

        /// <summary>
        /// ToString() Function Override
        /// </summary>
        /// <returns>
        /// Rank and suit of card
        /// </returns>
        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }
    }
}
