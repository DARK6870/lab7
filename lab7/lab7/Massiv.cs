using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class Massiv
    {
        public int[] data { get; set; }
        public int Pr()
        {
            return data.Aggregate((x, y) => x * y);
        }

        public int Max()
        {
            return data.Max();
        }

        public int Even()
        {
            return data.Where(p => p % 2 == 0).Count();
        }

        public int Odd()
        {
            return data.Where(p => p % 2 == 1).Count();
        }

        public void DeleteElement(int x)
        {
            int[] newarr = data.Where(value => value != x).ToArray();
            data = newarr;
        }


        public void OrderAsk()
        {
            data.Order();
        }
        public void OrderDesk()
        {
            data.OrderDescending();
        }
    }
}
