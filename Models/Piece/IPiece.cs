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
        Black,
        Null
    }
    public interface IPiece
    {
        public char Symbol { get; }
        public int Value { get; }
        public PieceColor Color { get; }
        public Coordinates Position { get; set; }
        public bool HasMoved { get; }

        public void UpdateStatus(Board board);
        public List<Coordinates> GetAvailableMoves();
        public Dictionary<Coordinates, PieceColor> GetAvailableAttack();
        public bool IsValidMove(Coordinates newPosition, Board board);
        public void Move(Coordinates newPosition, Board board);
        public bool IsTaking(Coordinates newPosition, Board board);
    }
}
