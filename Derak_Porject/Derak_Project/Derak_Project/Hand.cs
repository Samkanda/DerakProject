///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            Hand
///   Description:      Hand class inherits cards class
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
    /// Hand class inherits cards class
    /// </summary>
    public abstract class Hand : Cards
    {
        protected string name;

        /// <summary>
        /// Auto-property for name (get/set)
        /// </summary>
        /// <returns>
        /// The name field
        /// </returns>
        public string Name { get { return name; } set { name = value; } }
        public static event EventHandler TurnEndEvent;
        public static event EventHandler TurnBeginEvent;
        public static event EventHandler<Card> CardPlayed;

        /// <summary>
        /// Default constructor for hand class
        /// </summary>
        public Hand()
        {
            name = this.GetHashCode().ToString();
        }

        public abstract void TakeTurn();

        /// <summary>
        /// Function to denote the end turn event
        /// </summary>
        protected void SendTurnEndEvent()
        {
            TurnEndEvent(this, new EventArgs());
        }

        /// <summary>
        /// Function to denote the start of turn event
        /// </summary>
        protected void SendTurnbeginEvent()
        {
            TurnBeginEvent(this, new EventArgs());
        }

        /// <summary>
        /// Function to send card played
        /// </summary>
        /// <param name="playedCard">Card object</param>
        protected void SendCardPlayed(Card playedCard)
        {
            CardPlayed(this, playedCard);
        }

        /// <summary>
        /// Function to draw cards to hand
        /// </summary>
        /// <param name="drawPile">Cards array</param>
        /// <param name="handSize">Integer hand-size</param>
        public void DrawTo(Cards drawPile, int handSize)
        {
            if(drawPile.Count < handSize-this.Count)
            {
                this.AddRange(drawPile);
                drawPile.Clear();
            } 
            else
            {
                for (int i = this.Count; i < handSize; i++)
                {
                    this.Add(drawPile.Extract(drawPile.First()));// unhandled exception if drawpile empty 
                }
            }
        }

        /// <summary>
        /// Function override base ToString() method
        /// </summary>
        /// <returns>
        /// Formatted hand information as string
        /// </returns>
        public override string ToString()
        {
            string output = "\n =====Hand=====";
            for (int i = 0; i < this.Count; i++)
            {
                output += "\n[" + (i + 1) + "] " + this[i].ToString();
            }
            return output;
        }
    }
}
