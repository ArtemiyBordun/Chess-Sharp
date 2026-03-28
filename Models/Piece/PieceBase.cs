using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Piece
{
    internal abstract class PieceBase : IPiece
    {
        public char Symbol { get; protected set; }
        public int Value { get; protected set; }
        public PieceColor Color { get; private set; }
        public Coordinates Position { get; set; }
        protected List<Coordinates> _availableMoves { get; set; }
        protected Dictionary<Coordinates, PieceColor> _availableAttack { get; set; }
        public bool HasMoved { get; protected set; }

        protected PieceBase(PieceColor color, Coordinates startPos)
        {
            Color = color;
            Position = startPos;
            _availableMoves = new List<Coordinates>();
            _availableAttack = new Dictionary<Coordinates, PieceColor>();
            HasMoved = false;
        }
        public void UpdateStatus(Board board)
        {
            UpdateAvailableMoves(board);
            UpdateAvailableAttack(board);
        }
        protected abstract void UpdateAvailableMoves(Board board);
        protected abstract void UpdateAvailableAttack(Board board);

        public List<Coordinates> GetAvailableMoves() => _availableMoves;
        public Dictionary<Coordinates, PieceColor> GetAvailableAttack() => _availableAttack;

        public virtual void Move(Coordinates newPosition, Board board)
        {
            board.Move(Position, newPosition, this);
            Position = newPosition;
            HasMoved = true;
        }
        public virtual bool IsTaking(Coordinates newPosition, Board board)
        {
            if (board.CheckPos(newPosition))
                return true;
            return false;
        }
        public virtual bool IsValidMove(Coordinates newPosition, Board board)
        {
            bool isInMoves = _availableMoves.Any(c => c.x == newPosition.x && c.y == newPosition.y);

            bool isInAttack = _availableAttack.Any(c => c.Value != Color && c.Key.x == newPosition.x && c.Key.y == newPosition.y);

            return isInMoves || isInAttack;
        }
    }
}
