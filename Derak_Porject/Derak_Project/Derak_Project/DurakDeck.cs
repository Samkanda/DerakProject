﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    class DurakDeck : Deck
    {
        public DurakDeck()
        {
            for (int suitVal = 1; suitVal < 5; suitVal++)
            {
                for (int rankVal = 6; rankVal < 14; rankVal++)
                {
                    this.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }
    }
}