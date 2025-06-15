using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Coordinates
    {
        public int x;
        public int y;
        public bool IsFree;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
            IsFree = true;
        }
    }
}
