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
                            } catch (Exception e) { }
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
                            } catch (Exception e) { }
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
                            } catch (Exception e) { }
                        }
                    }
                }
                
            } 
            else
            {
                for (int i = this.Count - 1; i >= 0; i--)
                {
                    try
                    {
                        PlayCard(i);
                    } catch (Exception e)
                    {

                    }
                }
            }


            


            SendTurnEndEvent();
            // RUNS RECURSIVELY NOTHING BELOW THIS POINT
        }
    }
}
