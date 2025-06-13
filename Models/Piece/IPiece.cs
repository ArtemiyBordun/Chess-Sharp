using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Piece
{
    public enum PieceColor
    {
        White,
        Black
    }
    public interface IPiece
    {
        public char Symbol { get; }
        public PieceColor Color { get; }
        public Coordinates Position { get; set; }
        public bool HasMoved { get; }
        public List<Coordinates> AvailableMoves { get; set; }
        public List<Coordinates> AvailableAttack { get; set; }

        public List<Coordinates> GetAvailableMoves(IPiece[,] board);
        public List<Coordinates> GetAvailableAttack(IPiece[,] board);
        public bool IsValidMove(Coordinates newPosition, IPiece[,] board);
        public void Move(Coordinates newPosition, IPiece[,] board);
    }
}
