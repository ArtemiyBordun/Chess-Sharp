using Models.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    internal class Player
    {
        private PieceColor _color;
        private int _score;
        internal Player(PieceColor color) 
        {
            _color = color;
            _score = 0;
        }
        internal PieceColor GetColor => _color;
        internal int GetScore => _score;
        internal void UpdateValue(IPiece piece)
        {
            _score += piece.Value;
        }
    }
}
