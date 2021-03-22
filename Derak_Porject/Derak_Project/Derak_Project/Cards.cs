using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    public class Cards : List<Card>
    {
        public Card First()
        {
            return this[Count - 1];
        }

        public Card Extract(Card target)
        {
            Card temp = this[GetTargetIndex(target)];
            this.RemoveAt(GetTargetIndex(target));
            return temp;
        }

        public int GetTargetIndex(Card target)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (target == this[i])
                {
                    return i;
                }
            }
            throw new Exception("target not located");
        }


        ////retrieve all cards in container
        //public Cards ExtractAll()
        //{
        //    int length = this.Count;
        //    Cards temp = new Cards();
        //    for (int i = 0; i < length; i++)
        //    {
        //        temp.Add(this.Extract());
        //    }
        //    return new Cards();
        //}

        ////grab top card
        //public Card Extract()
        //{
        //    Card temp = this[this.Count - 1];
        //    this.RemoveAt(this.Count - 1);
        //    return temp;
        //}
        ////grab card at position
        //public Card Extract(int position)
        //{
        //    Card temp = this[position];
        //    this.RemoveAt(position);
        //    return temp;
        //}
    }
}
