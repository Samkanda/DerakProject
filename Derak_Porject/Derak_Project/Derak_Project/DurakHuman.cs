using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    class DurakHuman : DurakHand
    {
        private bool IsTurn = false;




        public DurakHuman() : base()
        {

        }

        public override void TakeTurn()
        {
            IsTurn = true;

        }

        public void EndTurn()
        {
            if (IsTurn)
            {
                SendTurnEndEvent();
            }
        }




    }
}
