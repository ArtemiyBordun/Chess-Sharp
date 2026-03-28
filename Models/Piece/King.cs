using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Models.Piece
{
    internal class King : PieceBase
    {
        public King(PieceColor color, Coordinates startPos) : base(color, startPos)
        {
            Symbol = 'K';
            Value = 100;
        }
        protected override void UpdateAvailableMoves(Board board)
        {
            _availableMoves.Clear();

            // Направления: ↗, ↘, ↙, ↖, →, ←, ↑, ↓
            int[] dx = { 1, 1, -1, -1, 1, -1, 0, 0 };
            int[] dy = { 1, -1, 1, -1, 0, 0, 1, -1 };

            for (int dir = 0; dir < dx.Length; dir++)
            {
                int x = Position.x;
                int y = Position.y;

                x += dx[dir];
                y += dy[dir];

                if (!board.CheckBound(x, y)) break;

                var coord = new Coordinates(x, y);
                var piece = board.GetPieceByCoordinates(coord);
                if (piece == null && board.CheckAttackedSquare(coord, Color))
                {
                    _availableMoves.Add(coord);
                }
            }
        }


        protected override void UpdateAvailableAttack(Board board)
        {
            _availableAttack.Clear();

            // Направления: ↗, ↘, ↙, ↖, →, ←, ↑, ↓
            int[] dx = { 1, 1, -1, -1, 1, -1, 0, 0 };
            int[] dy = { 1, -1, 1, -1, 0, 0, 1, -1 };

            for (int dir = 0; dir < dx.Length; dir++)
            {
                int x = Position.x;
                int y = Position.y;

                x += dx[dir];
                y += dy[dir];

                var coord = new Coordinates(x, y);

                if (!board.CheckBound(coord.x, coord.y)) continue;

                var piece = board.GetPieceByCoordinates(coord);
                if (piece == null)
                {
                    _availableAttack.Add(coord, PieceColor.Null);
                }
                else
                {
                    _availableAttack.Add(coord, piece.Color);
                }
            }
        }
    }
}
