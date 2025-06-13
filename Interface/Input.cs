using Models;
using Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Input
    {
        public static Coordinates GetCoordinatesWithConsole()
        {
            string? line = Console.ReadLine();
            if (line == null || line.Length != 2 || !Constants.CORRECT_COORDINATES_CHAR.Contains(line[0]) ||
                !Constants.CORRECT_COORDINATES_NUM.Contains(line[1]))
            {
                Output.WriteError("Введенная координата неправильная, попробуйте ещё раз");
                return null;
            }
            int y = Convert.ToInt32(line[0]) - 65;  //записываем букву в виде числа (А = 65)
            int x = Convert.ToInt32(line[1]) - 48 - 1;  //записываем букву цифру виде числа (0 = 48) + индексация с 0
            var coord = new Coordinates(x, y);
            return coord;
        }
    }
}
