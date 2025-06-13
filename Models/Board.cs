using Models.Piece;
using Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Board
    {
        private IPiece[,] _board;
        private const int _lenght = Constants.LENGHT_BOARD;
        public Board() 
        {
            _board = new IPiece[_lenght, _lenght];
            InitializationBoard();
        }
        public IPiece[,] GetBoard => _board;
        private void InitializationBoard()
        {
            for (int i = 0; i < _lenght; i++)
            {
                if (i > Constants.FIRST_POSITION_WHITE_PAWN && i < Constants.FIRST_POSITION_BLACK_PAWN)
                    continue;   //пропускаем пустые поля
                for (int j = 0; j < _lenght; j++)
                {
                    if (i == Constants.FIRST_POSITION_WHITE_PAWN)      //заполняем белыми пешками
                        _board[i, j] = new Pawn(PieceColor.White, new Coordinates(i, j));
                    else if (i == Constants.FIRST_POSITION_BLACK_PAWN) //заполняем черными пешками
                        _board[i, j] = new Pawn(PieceColor.Black, new Coordinates(i, j));
                }
            }
            _board[2, 1] = new Pawn(PieceColor.Black, new Coordinates(2, 1));
        }
    }
}
