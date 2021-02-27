using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    abstract class Hand : Cards
    {
        public abstract void TakeTurn();

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
