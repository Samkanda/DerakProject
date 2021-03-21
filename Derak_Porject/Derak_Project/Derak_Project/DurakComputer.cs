using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    public class DurakComputer : DurakHand
    {

        public DurakComputer()
        {
            Role = DurakRole.Extra;
        }

        
        public override void TakeTurn()
        {
            SendTurnbeginEvent();
            PlayCard(0);
            SendTurnEndEvent();
            // RUNS RECURSIVELY NOTHING BELOW THIS POINT
        }
    }
}
