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
        public static Coordinates? GetCoordinatesWithConsole()
        {
            string? line = Console.ReadLine();
            if (line == null || line.Length != 2 || 
                (!Constants.CORRECT_COORDINATES_CHAR_UPPER.Contains(line[0]) &&
                !Constants.CORRECT_COORDINATES_CHAR_LOWER.Contains(line[0])) || 
                !Constants.CORRECT_COORDINATES_NUM.Contains(line[1]))
            {
                Output.WriteError("Введенная координата неправильная, попробуйте ещё раз");
                return null;
            }
            int x, y = 0;
            if (Constants.CORRECT_COORDINATES_CHAR_UPPER.Contains(line[0]))
                y = Convert.ToInt32(line[0]) - 65;  //записываем заглавную букву в виде числа (А = 65 по ASCII) 
            else if (Constants.CORRECT_COORDINATES_CHAR_LOWER.Contains(line[0]))
                y = Convert.ToInt32(line[0]) - 97;  //записываем строчную букву в виде числа (a = 97)

            x = Convert.ToInt32(line[1]) - 48 - 1;  //записываем букву цифру виде числа (0 = 48) + индексация с 0
            var coord = new Coordinates(x, y);
            return coord;
        }
    }
}
