using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    abstract class DurakHand : Hand
    {
        public const int MinimumHandSize = 6;

        public void DrawToMinimum(Cards drawPile)
        {
            DrawTo(drawPile, MinimumHandSize);
        }

        protected void PlayCard(int index)
        {
            SendCardPlayed(this.Extract(index));
        }

    }
}
