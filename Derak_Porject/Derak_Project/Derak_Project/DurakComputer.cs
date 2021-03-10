using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    class DurakComputer : DurakHand
    {

        public DurakComputer()
        {

        }

        public override void TakeTurn()
        {
            //TurnEndHandler();
            SendTurnEndEvent();
        }
    }
}
