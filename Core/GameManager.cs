using ConsoleUI;
using Models;
using Models.Piece;
using Rules;
using System.Net.NetworkInformation;

namespace Core
{
    public class GameManager
    {
        private PieceColor _currentColor;
        private Board _board;
        private MoveValidator _status;
        private List<Player> _players;

        public GameManager() 
        {
            _currentColor = PieceColor.White;
            _board = new Board();
            _status = new MoveValidator(_board);

            _players = new List<Player>();
            _players.Add(new Player(PieceColor.White));
            _players.Add(new Player(PieceColor.Black));
        }

        public void StartGame()
        {
            var gameStatus = GameStatus.Move;
            Output.WriteColor("белых");
            while (true)
            {
                Output.WriteBoard(_board);
                Output.WriteScore(_players[0].GetScore, _players[1].GetScore);
                _board.UpdateBoard();
                _status.UpdateGameStatus();
                gameStatus = _status.GameStatus;
                if (gameStatus != GameStatus.Move)
                {
                    if (gameStatus == GameStatus.CheckWhite)
                        Console.WriteLine("Шах белым!");
                    if (gameStatus == GameStatus.CheckBlack)
                        Console.WriteLine("Шах черным!");
                }

                var piece = SelectPieceMove();
                Move(piece);

                Output.ClearConsole();
                ChangeColor();
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

                var piece = _board.GetPieceByCoordinates(coord);
                if (piece == null ||
                    piece.Color != _currentColor ||
                    (piece.GetAvailableMoves().Count == 0 && !piece.GetAvailableAttack().Any(p => p.Value != piece.Color)))
                {
                    Output.WriteError("Фигурой нельзя ходить");
                }
                else
                {
                    Output.ClearConsole();
                    Output.WriteBoard(_board, piece);
                    return piece;
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

                if (piece.IsValidMove(coord, _board))
                {
                    bool taking = piece.IsTaking(coord, _board);
                    if (taking)
                    {
                        var player = _players.Where(x => x.GetColor == _currentColor).First();
                        player.UpdateValue(_board.GetPieceByCoordinates(coord));
                    }

                    piece.Move(coord, _board);
                    return;
                }
            }
        }
    }
}
