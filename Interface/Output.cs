using Models;
using Models.Piece;
using System.Xml.Serialization;

namespace ConsoleUI
{
    public static class Output
    {
        public static void WriteBoard(IPiece[,] board, IPiece selectPiece = null)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Coordinates> moves = null;
            List<Coordinates> attacked = null;
            if (selectPiece != null)
            {
                moves = selectPiece.AvailableMoves;
                attacked = selectPiece.AvailableAttack;
            }

            Console.WriteLine("   A  B  C  D  E  F  G  H ");

            for (int i = 7; i >= 0; i--)
            {
                Console.Write($"{i + 1} ");

                for (int j = 0; j < 8; j++)
                {
                    bool isWhiteSquare = (i + j) % 2 == 0;

                    Console.BackgroundColor = isWhiteSquare ? ConsoleColor.Gray : ConsoleColor.DarkGreen;

                    var piece = board[i, j];
                    if (moves != null && moves.Any(c => c.x == i && c.y == j))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" · ");
                    }
                    else if (piece == null)
                    {
                        Console.Write("   "); // пустая клетка
                    }
                    else
                    {
                        if (attacked != null && attacked.Any(c => c.x == i && c.y == j))
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Цвет фигуры
                        }
                        else
                        {
                            Console.ForegroundColor = piece.Color == PieceColor.White
                                ? ConsoleColor.White
                                : ConsoleColor.Black;
                        }

                        Console.Write($" {piece.Symbol} ");
                    }

                    Console.ResetColor();
                }

                Console.WriteLine($"{i + 1} ");
            }

            Console.WriteLine("   A  B  C  D  E  F  G  H ");
        }

        public static void WriteSelectPiece()
        {
            Console.WriteLine("Выберите фигуру, которой хотите походить. Для этого введите её координаты в формате - A1 или E4");
        }

        public static void WriteSelectMove()
        {
            Console.WriteLine("Выберите куда походить. Для этого введите координаты в формате - A1 или E4");
        }

        public static void WriteColor(string color)
        {
            Console.WriteLine($"Сейчас ход {color}");
        }
        public static void WriteError(string error)
        {
            Console.WriteLine($"Ошибка: {error}");
        } 
        public static void ClearConsole()
        {
            Console.Clear();
        }
    }
}
