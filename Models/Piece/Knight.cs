using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Models.Piece
{
    internal class Knight : PieceBase
    {
        public Knight(PieceColor color, Coordinates startPos) : base(color, startPos)
        {
            Symbol = 'N';
            Value = 3;
        }
        protected override void UpdateAvailableMoves(Board board)
        {
            _availableMoves.Clear();

            if (CheckMove(board, Position.x + 2, Position.y + 1))
                _availableMoves.Add(new Coordinates(Position.x + 2, Position.y + 1));

            if (CheckMove(board, Position.x + 1, Position.y + 2))
                _availableMoves.Add(new Coordinates(Position.x + 1, Position.y + 2));

            if (CheckMove(board, Position.x - 1, Position.y + 2))
                _availableMoves.Add(new Coordinates(Position.x - 1, Position.y + 2));

            if (CheckMove(board, Position.x - 2, Position.y + 1))
                _availableMoves.Add(new Coordinates(Position.x - 2, Position.y + 1));

            if (CheckMove(board, Position.x + 2, Position.y - 1))
                _availableMoves.Add(new Coordinates(Position.x + 2, Position.y - 1));

            if (CheckMove(board, Position.x + 1, Position.y - 2))
                _availableMoves.Add(new Coordinates(Position.x + 1, Position.y - 2));

            if (CheckMove(board, Position.x - 1, Position.y - 2))
                _availableMoves.Add(new Coordinates(Position.x - 1, Position.y +- 2));

            if (CheckMove(board, Position.x - 2, Position.y - 1))
                _availableMoves.Add(new Coordinates(Position.x - 2, Position.y - 1));

        }
        protected override void UpdateAvailableAttack(Board board)
        {
            _availableAttack.Clear();

            // Направления: ↗, ↘, ↙, ↖, →, ←, ↑, ↓
            int[] dx = { 2, 1, -1, -2, 2, 1, -1, -2 };
            int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };
            for (int dir = 0; dir < dx.Length; dir++) 
            {
                var coord = new Coordinates(Position.x + dx[dir], Position.y + dy[dir]);

                //if (!CheckAttack(board, coord)) continue;

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
        private bool CheckMove(Board board, int x, int y)
        {
            if (board.CheckBound(x, y) && !board.CheckPos(x, y))
                return true;

            return false;
        }
    }
}
