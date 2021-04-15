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

            // Handle if computer role is defending
            if (Role == DurakRole.Defender)
            {
                bool passable = true;
                bool surrender = true;
                bool test;

                // Iterate through cards that are on the playing field
                // Iterate through cards that are able to be drawn
                foreach(DurakBattle front in PlayingField)
                {
                    // If your defence isnt null, you arent able to pass turn
                    if(front.Defense != null){passable = false;}
                    test = false;

                    // Checking if rank in hand is the same as rank on attack
                    foreach(Card cardInHand in this)
                    {
                        if(cardInHand.rank == front.Attack.rank) { test = true; }
                    }

                    // Result test yields no surrender 
                    if (!test) { surrender = false; }
                }

                // If remaining draws are greater than 0..
                if (RemainingDraws > 0)
                {
                    test = true;

                    // Iterate through cards that are on the playing field
                    foreach (DurakBattle front in PlayingField)
                    {
                        // If attack suit isnt the trump
                        if(front.Attack.suit != Trump) { test = false; }
                    }

                    // If test returns true, surrender play
                    if (test) { surrender = true; }
                }

                // Otherwise, make the surrender play false
                else
                {
                    surrender = false;
                }

                // If the play is passable (if the player can pass turn)
                if (passable)
                {
                    // Iterate through count
                    for (int i = 0; i < Count; i++)
                    {
                        // If the currently selected rank is the same as the attack rank on field
                        if (this[i].rank == PlayingField[0].Attack.rank)
                        {
                            // Try playing the card
                            try
                            {
                                PlayCard(i);
                            } 

                            // Otherwise, catch the InvalidPlayException
                            catch (InvalidPlayException e) { }
                        }
                    }
                }

                // If the move isnt a surrender
                if (!surrender)
                {
                    // Iterate through cards that are on the playing field
                    foreach (DurakBattle front in PlayingField)
                    {
                        // If the defence returns as null
                        if (front.Defense == null)
                        {
                            int target = 0;

                            // Iterate over computer count
                            for (int i = 0; i < Count; i++)
                            {
                                // Basically checking if attack is a valid attack
                                if (front.Attack.suit == this[i].suit && front.Attack.rank < this[i].rank)
                                {
                                    // Then assign target to be used as the played card
                                    if (this[target].suit != this[i].suit || this[i].rank < this[target].rank)
                                    {
                                        target = i;
                                    }
                                }
                            }

                            // Try playing the card returned to target
                            try
                            {
                                PlayCard(target);
                            }

                            // Catch an InvalidPlayException if the play is invalid
                            catch (InvalidPlayException e) { }
                        }

                        // If computer isnt defending and the attack suit doesnt match the trump
                        if (front.Defense == null && front.Attack.suit != Trump)
                        {
                            int target = 0;

                            // Iterate over computer count
                            for (int i = 0; i < Count; i++)
                            {
                                // If the trump is of same suit
                                if (Trump == this[i].suit)
                                {
                                    // And further varify that suit isnt trump OR the rank played is less, assign target
                                    if (this[target].suit != Trump || this[i].rank < this[target].rank)
                                    {
                                        target = i;
                                    }
                                }
                            }

                            // Try playing the card returned to target
                            try
                            {
                                PlayCard(target);
                            } 
                            
                            // Catch InvalidPlayException is play is not valid
                            catch (InvalidPlayException e) { }
                        }
                    }
                }

            }// If role isn't defender...
            else
            {
                //for checking whether its the first attack
                bool escalation = false;
                //point at which it doesnt want to draw
                int noDrawThreshold = 0;

                //if there is a defending card its not the first attack
                foreach(DurakBattle front in PlayingField)
                {
                    if(front.Defense != null) { escalation = true; }
                }
                //raise threshold if you are a supporting attacker
                if (Role == DurakRole.Extra)
                {
                    noDrawThreshold = PlayingField.Count;
                }
                //if its an escalation or extra which is defacto an escalatuion
                if (escalation || RemainingDraws < noDrawThreshold)
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        try
                        {
                            PlayCard(i);
                            i--;
                        } catch (InvalidPlayException e) { }
                    }
                }// if it assumes its not end game
                else
                {
                    //for each card if its a bad card play it
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
            }
            //if the ai didnt play a card at this point try everything to play atleast one
            if (this.Count >= startingHandSize)
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
