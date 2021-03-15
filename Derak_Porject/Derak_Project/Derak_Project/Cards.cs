using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    class Cards : List<Card>
    {
        //retrieve all cards in container
        public Cards ExtractAll()
        {
            int length = this.Count;
            Cards temp = new Cards();
            for (int i = 0; i < length; i++)
            {
                temp.Add(this.Extract());

            }
            return new Cards();
        }

        //grab first card in list that matches given card
        public Cards ExtractAll(Card matching)
        {
            return new Cards();
        }

        //grab top card
        public Card Extract()
        {
            Card temp = this[this.Count - 1];
            this.RemoveAt(this.Count - 1);
            return temp;
        }
        //grab card at position
        public Card Extract(int position)
        {
            Card temp = this[position];
            this.RemoveAt(position);
            return temp;
        }
        //grab first card in list that matches given card
        public Card Extract(Card matching)
        {
            return new Card();
        }
    }
}
