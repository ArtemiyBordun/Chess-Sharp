using ConsoleUI;
using Models;
using Models.Piece;

namespace Core
{
    public class GameManager
    {
        private PieceColor _currentColor;
        private IPiece[,] _board;

        public GameManager() 
        {
            _currentColor = PieceColor.White;
            _board = new Board().GetBoard;
        }

        public void StartGame()
        {
            Output.WriteColor("белых");
            while (true)
            {
                Output.WriteBoard(_board);
                UpdatePieces();

                var piece = SelectPieceMove();
                Move(piece);

                Output.ClearConsole();
                ChangeColor();
            }
        }
        private void UpdatePieces()
        {
            foreach (var piece in _board) 
            {
                if (piece == null) continue;
                piece.GetAvailableMoves(_board);
                piece.GetAvailableAttack(_board);
            }
        }

        private void ChangeColor()
        {
            if (_currentColor == PieceColor.White)
            {
                _currentColor = PieceColor.Black;
                Output.WriteColor("черных");
            }
            else
            {
                _currentColor = PieceColor.White;
                Output.WriteColor("белых");
            }
        }

        private IPiece SelectPieceMove()
        {
            while (true)
            {
                Output.WriteSelectPiece();
                var coord = Input.GetCoordinatesWithConsole();

                if (coord == null) continue;

                var piece = _board[coord.x, coord.y];
                if (piece == null || piece.Color != _currentColor)
                    Output.WriteError("Фигурой нельзя ходить");
                else
                {
                    if (piece.AvailableMoves.Count == 0 && piece.AvailableAttack.Count == 0)
                        Output.WriteError("Фигурой нельзя ходить");
                    else
                    {
                        Output.ClearConsole();
                        Output.WriteBoard(_board, piece);
                        return piece;
                    }
                }
            }
        }

        private void Move(IPiece piece)
        {
            while (true)
            {
                Output.WriteSelectMove();
                var coord = Input.GetCoordinatesWithConsole();
                if (coord == null) continue;

                var moves = piece.AvailableMoves;
                var attacked = piece.AvailableAttack;

                if ((moves.Count != 0 && moves.Any(c => c.x == coord.x && c.y == coord.y)) ||
                    (attacked.Count != 0 && attacked.Any(c => c.x == coord.x && c.y == coord.y)))
                {
                    piece.Move(coord, _board);
                    return;
                }
            }
        }
    }
}
