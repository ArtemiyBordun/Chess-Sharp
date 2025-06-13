using Rules;
using System;
using System.Collections.Generic;
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
        }

        public override List<Coordinates> GetAvailableMoves(IPiece[,] board)
        {
            AvailableMoves.Clear();
            if (!HasMoved)
            {
                if (Color == PieceColor.White)
                {
                    for (int x = Position.x + 1; x<= Position.x + 2; x++)
                    {
                        if (x < 0 || x>= Constants.LENGHT_BOARD || board[x, Position.y] != null)
                            break;
                        if (board[x, Position.y] == null)
                            AvailableMoves.Add(new Coordinates(x, Position.y));
                    }
                }
                else
                {
                    for (int x = Position.x - 1; x>= Position.x - 2; x--)
                    {
                        if (x < 0 || x>= Constants.LENGHT_BOARD || board[x, Position.y] != null)
                            break;
                        if (board[x, Position.y] == null)
                            AvailableMoves.Add(new Coordinates(x, Position.y));
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

                if (x >= 0 && x < Constants.LENGHT_BOARD && board[x, Position.y] == null)
                    AvailableMoves.Add(new Coordinates(x, Position.y));
            }
            return AvailableMoves;
        }

        public override List<Coordinates> GetAvailableAttack(IPiece[,] board)
        {
            AvailableAttack.Clear();
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

            return AvailableAttack;
        }

        private void AddAvailableAttack(IPiece[,] board, int x, int y)
        {
            if (y >= 0 && y < Constants.LENGHT_BOARD)
                if (board[x, y] != null && board[x, y].Color != Color)
                    AvailableAttack.Add(new Coordinates(x, y));
        }

        public override bool IsValidMove(Coordinates newPosition, IPiece[,] board)
        {
            throw new NotImplementedException();
        }
    }
}
