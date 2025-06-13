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
        public PieceColor Color { get; private set; }
        public Coordinates Position { get; set; }
        public List<Coordinates> AvailableMoves { get; set; }
        public List<Coordinates> AvailableAttack { get; set; }
        public bool HasMoved { get; protected set; }

        protected PieceBase(PieceColor color, Coordinates startPos)
        {
            Color = color;
            Position = startPos;
            AvailableMoves = new List<Coordinates>();
            AvailableAttack = new List<Coordinates>();
            HasMoved = false;
        }

        public abstract List<Coordinates> GetAvailableMoves(IPiece[,] board);
        public abstract List<Coordinates> GetAvailableAttack(IPiece[,] board);
        public abstract bool IsValidMove(Coordinates newPosition, IPiece[,] board);

        public virtual void Move(Coordinates newPosition, IPiece[,] board)
        {
            board[Position.x, Position.y] = null;
            board[newPosition.x, newPosition.y] = this;
            Position = newPosition;
            HasMoved = true;
        }
    }
}
