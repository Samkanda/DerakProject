///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            Card
///   Description:      Handles different card states
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
    public class DurakComputer : DurakHand
    {

        public DurakComputer() : base()
        {
            Role = DurakRole.Extra;
           
        }

        
        public override void TakeTurn()
        {
            SendTurnbeginEvent();

            for(int i = this.Count-1; i >= 0 ; i--)
            {
                try
                {
                    PlayCard(i);
                    //break;
                } 
                catch (Exception e)
                {

                }
            }


            
            SendTurnEndEvent();
            // RUNS RECURSIVELY NOTHING BELOW THIS POINT
        }
    }
}
