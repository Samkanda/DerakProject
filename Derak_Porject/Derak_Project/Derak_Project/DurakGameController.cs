using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    class DurakGameController : List<Hand>
    {
        private int caret = 0;
        public static int ultra = 0;
        

        public DurakGameController() : base()
        {

        }

        public void PassTurn()
        {
            
            //caret++;
            
            Console.WriteLine(ultra+" / "+caret);
            ultra++;
            if (caret >= this.Count)
            {
                caret = 0;
            }
            this[caret++].TakeTurn();// NOTE: stack overflow exception?

        }






    }
}
