using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    //public delegate void TurnEndEvent_Handler();
    //public delegate void CardPlayed_Handler(Card playedCard);

    public abstract class Hand : Cards
    {


        public static event EventHandler TurnEndEvent;
        public static event EventHandler TurnBeginEvent;
        public static event EventHandler<Card> CardPlayed;

        public abstract void TakeTurn();

        protected void SendTurnEndEvent()
        {
            TurnEndEvent(this, new EventArgs());
        }

        protected void SendTurnbeginEvent()
        {
            TurnBeginEvent(this, new EventArgs());
        }

        protected void SendCardPlayed(Card playedCard)
        {
            CardPlayed(this, playedCard);
        }

        public void DrawTo(Cards drawPile, int handSize)
        {
            for (int i = this.Count; i < handSize; i++)
            {
                this.Add(drawPile.Extract());// unhandled exception if drawpile empty 
            }
            
        }

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
