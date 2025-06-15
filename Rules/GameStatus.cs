using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules
{
    public enum GameStatus
    {
        Move,
        CheckWhite,
        CheckBlack,
        Mate,
        Stalemate
    }
}
