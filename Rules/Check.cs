using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules
{
    public static class Check
    {


        public static GameStatus IsCheck(Board board)
        {
            return GameStatus.Move;
        }
    }
}
