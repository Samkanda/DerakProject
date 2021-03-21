using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Derak_Project
{
    public class Card
    {
        protected Suit mySuit;
        public Suit suit
        {
            get { return mySuit; } // return the suit
            set { mySuit = value; }
        }

        protected Rank myRank;
        public Rank rank
        {
            get { return myRank; } // retrun the suit
            set { myRank = value; }
        }

        /*/// <summary>
        /// enum for card's suit
        /// </summary>
        public readonly Suit suit;
        /// <summary>
        ///  enum for card's rank
        /// </summary>
        public readonly Rank rank;//*/

        protected bool faceUp = true;
        public bool FaceUp
        {
            get { return faceUp; }
            set { faceUp = value; }
        }

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
