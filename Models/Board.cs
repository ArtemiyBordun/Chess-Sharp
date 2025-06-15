using Models.Piece;
using System;
using System.Collections.Generic;
using System.Data;
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
            _board[0, 0] = new Rook(PieceColor.White, new Coordinates(0, 0));   //расставляем ладьи
            _board[0, 7] = new Rook(PieceColor.White, new Coordinates(0, 7));
            _board[7, 0] = new Rook(PieceColor.Black, new Coordinates(7, 0));
            _board[7, 7] = new Rook(PieceColor.Black, new Coordinates(7, 7));

            _board[0, 1] = new Knight(PieceColor.White, new Coordinates(0, 1)); //расставляем коней
            _board[0, 6] = new Knight(PieceColor.White, new Coordinates(0, 6));
            _board[7, 1] = new Knight(PieceColor.Black, new Coordinates(7, 1));
            _board[7, 6] = new Knight(PieceColor.Black, new Coordinates(7, 6));

            _board[0, 2] = new Bishop(PieceColor.White, new Coordinates(0, 2)); //расставляем слонов
            _board[0, 5] = new Bishop(PieceColor.White, new Coordinates(0, 5));
            _board[7, 2] = new Bishop(PieceColor.Black, new Coordinates(7, 2));
            _board[7, 5] = new Bishop(PieceColor.Black, new Coordinates(7, 5));

            _board[0, 3] = new Queen(PieceColor.White, new Coordinates(0, 3));  //расставляем ферзей
            _board[7, 3] = new Queen(PieceColor.Black, new Coordinates(7, 3));

            _board[0, 4] = new King(PieceColor.White, new Coordinates(0, 4));   //расставляем королей
            _board[7, 4] = new King(PieceColor.Black, new Coordinates(7, 4));

            _board[3, 3] = new King(PieceColor.Black, new Coordinates(3, 3));   //
        }
        public IPiece[,] GetPieces => _board;

        public void UpdateBoard()
        {
            foreach (var piece in _board)
            {
                if (piece == null) continue;
                piece.UpdateStatus(this);
            }
        }

        public IPiece? GetPieceByCoordinates(Coordinates coordinates)
        {
            return GetPieceByCoordinates(coordinates.x, coordinates.y);
        }
        public IPiece? GetPieceByCoordinates(int x, int y)
        {
            return _board[x, y];
        }
        public bool CheckPos(Coordinates pos)
        {
            return CheckPos(pos.x, pos.y);
        }
        public bool CheckPos(int x, int y)
        {
            return _board[x, y] != null;
        }
        public bool CheckBound(int x, int y)
        {
            return x >= 0 && x < Constants.LENGHT_BOARD &&
                   y >= 0 && y < Constants.LENGHT_BOARD;
        }
        public PieceColor GetColorByCoordinates(Coordinates pos)
        {
            if (_board[pos.x, pos.y] == null)
                return PieceColor.Null;
            var color = _board[pos.x, pos.y].Color;
            return color;
        }
        public void Move(Coordinates current, Coordinates newPosition, IPiece piece)
        {
            _board[current.x, current.y] = null;
            _board[newPosition.x, newPosition.y] = piece;
        }
        public bool CheckAttackedSquare(Coordinates pos, PieceColor color)
        {
            foreach (var piece in _board)
            {
                if (piece == null || piece.Color != color) continue;
                foreach (var coord in piece.GetAvailableMoves())
                {
                    if (coord == pos) 
                        return true;
                }
            }

            return false;
        }
    }
}
