///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            DurakComputer
///   Description:      Handles basic computer ai by iterating all playable moves
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
    /// DurakComputer class inherits DurakHand class
    /// </summary>
    public class DurakComputer : DurakHand
    {
        private const int goodCardThreshold = 11;



        /// <summary>
        /// DurakComputer constructor
        /// </summary>
        public DurakComputer() : base()
        {
            Role = DurakRole.Extra;
           
        }

        /// <summary>
        /// TakeTurn() function handles computer moves (iterates all playable - basic ai)
        /// </summary>
        public override void TakeTurn()
        {
            SendTurnbeginEvent();
            this.Sort();
            int startingHandSize = this.Count;

            if (Role == DurakRole.Defender)
            {
                bool passable = true;
                bool surrender = true;
                bool test;

                foreach(DurakBattle front in PlayingField)
                {
                    if(front.Defense != null){passable = false;}
                    test = false;
                    foreach(Card cardInHand in this)
                    {
                        if(cardInHand.rank == front.Attack.rank) { test = true; }
                    }
                    if (!test) { surrender = false; }
                }
                if(RemainingDraws > 0)
                {
                    test = true;
                    foreach (DurakBattle front in PlayingField)
                    {
                        if(front.Attack.suit != Trump) { test = false; }
                    }
                    if (test) { surrender = true; }
                } 
                else
                {
                    surrender = false;
                }
                if (passable)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (this[i].rank == PlayingField[0].Attack.rank)
                        {
                            try
                            {
                                PlayCard(i);
                            } catch (InvalidPlayException e) { }
                        }
                    }
                }
                if (!surrender)
                {
                    foreach (DurakBattle front in PlayingField)
                    {
                        if (front.Defense == null)
                        {
                            int target = 0;
                            for (int i = 0; i < Count; i++)
                            {
                                if (front.Attack.suit == this[i].suit && front.Attack.rank < this[i].rank)
                                {
                                    if (this[target].suit != this[i].suit || this[i].rank < this[target].rank)
                                    {
                                        target = i;
                                    }
                                }
                            }
                            try
                            {
                                PlayCard(target);
                            } catch (InvalidPlayException e) { }
                        }
                        if (front.Defense == null && front.Attack.suit != Trump)
                        {
                            int target = 0;
                            for (int i = 0; i < Count; i++)
                            {
                                if (Trump == this[i].suit)
                                {
                                    if (this[target].suit != Trump || this[i].rank < this[target].rank)
                                    {
                                        target = i;
                                    }
                                }
                            }
                            try
                            {
                                PlayCard(target);
                            } catch (InvalidPlayException e) { }
                        }
                    }
                }
                
            } 
            else
            {
                bool escalation = false;
                int noDrawThreshold = 0;

                foreach(DurakBattle front in PlayingField)
                {
                    if(front.Defense != null) { escalation = true; }
                }
                if (Role == DurakRole.Extra)
                {
                    noDrawThreshold = PlayingField.Count;
                }


                if (RemainingDraws > noDrawThreshold)
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        try
                        {
                            if (this[i].suit != Trump && (int)this[i].rank < goodCardThreshold)
                            {
                                PlayCard(i);
                                i--;
                            }
                        } catch (InvalidPlayException e) { }
                    }
                }
                else if (Role==DurakRole.Extra || escalation)
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        try
                        {
                            PlayCard(i);
                            i--;
                        } catch (InvalidPlayException e) { }
                    }
                }
                else
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        try
                        {
                            PlayCard(i);
                            i--;
                        } catch (InvalidPlayException e) { }
                    }
                }
            }
            if(this.Count >= startingHandSize)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    try
                    {
                        PlayCard(i);
                        break;
                    } catch (InvalidPlayException e) { }
                }
            }
            SendTurnEndEvent();
            // RUNS RECURSIVELY NOTHING BELOW THIS POINT
        }
    }
}
