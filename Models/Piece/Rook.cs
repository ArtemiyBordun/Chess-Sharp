using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Models.Piece
{
    internal class Rook : PieceBase
    {
        public Rook(PieceColor color, Coordinates startPos) : base(color, startPos)
        {
            Symbol = 'R';
            Value = 5;
        }
        protected override void UpdateAvailableMoves(Board board)
        {
            _availableMoves.Clear();

            // Направления: →, ←, ↑, ↓
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            for (int dir = 0; dir < 4; dir++)
            {
                int x = Position.x;
                int y = Position.y;

                while (true)
                {
                    x += dx[dir];
                    y += dy[dir];

                    if (!board.CheckBound(x, y)) break;

                    var piece = board.GetPieceByCoordinates(new Coordinates(x, y));
                    if (piece == null)
                    {
                        _availableMoves.Add(new Coordinates(x, y));
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }


        protected override void UpdateAvailableAttack(Board board)
        {
            _availableAttack.Clear();

            // Направления: →, ←, ↑, ↓
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            for (int dir = 0; dir < 4; dir++)
            {
                int x = Position.x;
                int y = Position.y;

                while (true)
                {
                    x += dx[dir];
                    y += dy[dir];

                    if (!board.CheckBound(x, y)) break;

                    var piece = board.GetPieceByCoordinates(new Coordinates(x, y));
                    if (piece == null)
                    {
                        _availableAttack.Add(new Coordinates(x, y), PieceColor.Null);
                    }
                    else
                    {
                        _availableAttack.Add(new Coordinates(x, y), piece.Color);
                        break;
                    }
                }
            }
        }
    }
}
