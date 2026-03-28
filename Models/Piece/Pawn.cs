using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models.Piece
{
    internal class Pawn : PieceBase
    {
        internal Pawn(PieceColor color, Coordinates startPos) : base(color, startPos)
        {
            Symbol = 'P';
            Value = 1;
        }

        protected override void UpdateAvailableMoves(Board board)
        {
            _availableMoves.Clear();
            if (!HasMoved)
            {
                if (Color == PieceColor.White)
                {
                    for (int x = Position.x + 1; x<= Position.x + 2; x++)
                    {
                        if (x < 0 || x>= Constants.LENGHT_BOARD || board.CheckPos(x, Position.y))
                            break;
                        if (!board.CheckPos(x, Position.y))
                            _availableMoves.Add(new Coordinates(x, Position.y));
                    }
                }
                else
                {
                    for (int x = Position.x - 1; x>= Position.x - 2; x--)
                    {
                        if (x < 0 || x>= Constants.LENGHT_BOARD || board.CheckPos(x, Position.y))
                            break;
                        if (!board.CheckPos(x, Position.y))
                            _availableMoves.Add(new Coordinates(x, Position.y));
                    }
                }
            }
            else
            {
                int x = Position.x;
                if (Color == PieceColor.White)
                    x += 1;     //Выбираем направление ходьбы пешки
                else
                    x -= 1;

                if (x >= 0 && x < Constants.LENGHT_BOARD && !board.CheckPos(x, Position.y))
                    _availableMoves.Add(new Coordinates(x, Position.y));
            }
        }

        protected override void UpdateAvailableAttack(Board board)
        {
            _availableAttack.Clear();
            int x = Position.x;
            if (Color == PieceColor.White)
                x += 1;
            else 
                x -= 1;
            int y = Position.y + 1;
            if (x >= 0 && x < Constants.LENGHT_BOARD) 
            {
                AddAvailableAttack(board, x, y);

                y = Position.y - 1;
                AddAvailableAttack(board, x, y);
            }
        }

        private void AddAvailableAttack(Board board, int x, int y)
        {
            if (x >= 0 && x < Constants.LENGHT_BOARD && y >= 0 && y < Constants.LENGHT_BOARD)
            {
                var coord = new Coordinates(x, y);
                var piece = board.GetPieceByCoordinates(x, y);
                PieceColor color = piece != null ? piece.Color : PieceColor.Null;
                _availableAttack.Add(coord, color);
            }
        }
    }
}
