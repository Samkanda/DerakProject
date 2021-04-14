/////---------------------------------------------------------------------------------
/////   Namespace:        Derak_Project
/////   Class:            Card
/////   Description:      Handles different card states
/////   Authors:          Shoaib Ali, Luke Richards, Navpreet Kanda, Mubashir Malik
/////   Date:             April 14, 2021
/////---------------------------------------------------------------------------------

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System;
//using System.Drawing;
//namespace Derak_Project
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class PlayingCard : ICloneable, IComparable
//    {
//        #region Fields and Properties

//        protected Suit mySuit;
//        public Suit Suit
//        {
//            get { return mySuit; } // return the suit
//            set { mySuit = value; }
//        }

//        protected Rank myRank;
//        public Rank Rank
//        {
//            get { return myRank; } // retrun the suit
//            set { myRank = value; }
//        }

//        protected int myValue;
//        public int CardValue
//        {
//            get { return myValue; }
//            set { myValue = value; }
//        }

//        protected int? altValue = null;
//        public int? AlternateValue
//        {
//            get { return altValue; }
//            set { altValue = value; }
//        }

//        protected bool faceUp = false;
//        public bool FaceUp
//        {
//            get { return faceUp; }
//            set { faceUp = value; }
//        }
//        #endregion

//        #region Constructor
//        public PlayingCard(Rank rank = Rank.Ace, Suit suit = Suit.Heart)
//        {
//            this.myRank = rank;
//            this.mySuit = suit;
//            this.myValue = (int)rank;
//        }
//        #endregion

//        #region Public Methods

//        public virtual int CompareTo(object obj)
//        {
//            if (obj == null)
//            {
//                throw new ArgumentNullException("Unable to compare a Card to a null object");
//            }
//            PlayingCard compareCard = obj as PlayingCard;
//            if (compareCard != null)
//            {
//                int thisSort = this.myValue * 10 + (int)this.mySuit;
//                int compareCardSort = compareCard.myValue * 10 + (int)compareCard.mySuit;
//                return (thisSort.CompareTo(compareCardSort));
//            }
//            else
//            {
//                throw new ArgumentException("Object being compared cannot be converted to a Card");
//            }
//        }

//        public object Clone()
//        {
//            return this.MemberwiseClone();
//        }

//        public override bool Equals(object obj)
//        {
//            return (this.CardValue == ((PlayingCard)obj).CardValue);
//        }

//        public override int GetHashCode()
//        {
//            return this.myValue * 100 + (int)this.mySuit * 10 + ((this.faceUp) ? 1 : 0);
//        }

//        public Image GetCardImage()
//        {
//            string imageName;
//            Image cardImage;
//            if (!faceUp)
//            {
//                imageName = "Back";
//            }
//            else
//            {
//                imageName = mySuit.ToString() + "_" + myRank.ToString();
//            }
//            cardImage = Derak_Project.Properties.Resources.ResourceManager.GetObject(imageName) as Image;
//            return cardImage;
//        }

//        public string DebugString()
//        {
//            string cardState = (string)(myRank.ToString() + " of " + mySuit.ToString()).PadLeft(20);
//            cardState += (string)((FaceUp) ? "(Face Up)" : "(Face Down)").PadLeft(12);
//            cardState += " Value: " + myValue.ToString().PadLeft(2);
//            cardState += ((altValue != null) ? "/" + altValue.ToString() : "");
//            return cardState;
//        }
//        #endregion

//        #region Relational Operator
        
//        #endregion
//    }
//}
