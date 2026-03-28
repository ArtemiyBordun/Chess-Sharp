using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules
{
    public class MoveValidator
    {
        private Board _board;
        public GameStatus GameStatus { get; private set; }

        public MoveValidator(Board board) 
        {
            _board = board;
        }
        public void UpdateGameStatus()
        {
            GameStatus = Check.IsCheck(_board);
        }
    }
}
