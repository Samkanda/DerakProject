﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    abstract class DurakHand : Hand
    {
        public const int MinimumHandSize = 6;

        private DurakRole myRole;
        public DurakRole Role
        {
            get { return Role; }
            set
            {
                myRole = value;
            }
        }
        //USE THIS FOR VALIDATION AND AI
        private List<DurakBattle> myPlayingField;
        protected List<DurakBattle> PlayingField
        {
            get { return myPlayingField; }
        }

        public void UpdateInfo(List<DurakBattle> Field)
        {
            myPlayingField = Field;
        }

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
