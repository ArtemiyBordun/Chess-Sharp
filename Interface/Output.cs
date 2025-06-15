using Models;
using Models.Piece;
using System.Drawing;
using System.Xml.Serialization;

namespace ConsoleUI
{
    public static class Output
    {
        public static void WriteBoard(Board board, IPiece selectPiece = null)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Coordinates> moves = null;
            Dictionary<Coordinates, PieceColor> attacked = null;
            if (selectPiece != null)
            {
                moves = selectPiece.GetAvailableMoves();
                attacked = selectPiece.GetAvailableAttack();
            }

            Console.WriteLine("   A  B  C  D  E  F  G  H ");

            for (int i = 7; i >= 0; i--)
            {
                Console.Write($"{i + 1} ");

                for (int j = 0; j < 8; j++)
                {
                    bool isWhiteSquare = (i + j) % 2 == 1;

                    Console.BackgroundColor = isWhiteSquare ? ConsoleColor.Gray : ConsoleColor.DarkGreen;

                    var piece = board.GetPieceByCoordinates(i, j);
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
                        if (attacked != null && attacked.Any(c => c.Value == piece.Color && c.Key.x == i && c.Key.y == j))
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // цвет фигуры под атакой
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

                Console.WriteLine($" {i + 1} ");
            }

            Console.WriteLine("   A  B  C  D  E  F  G  H ");
        }

        public static void WriteSelectPiece()
        {
            Console.WriteLine("Выберите фигуру, которой хотите походить. " +
                "Для этого введите её координаты в формате - A1 или e4");
        }
        public static void WriteScore(int scoreWhite, int scoreBlack)
        {
            Console.WriteLine("Счёт фигур:\n Белые:\t\tЧерные:");
            Console.WriteLine($"    {scoreWhite}\t\t   {scoreBlack}");
        }
        public static void WriteSelectMove()
        {
            Console.WriteLine("Выберите куда походить. Для этого введите координаты в формате - A1 или e4\nДля выбора другой фигура нажмите Backspace");
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
