using System;
using System.Collections.Generic;
using System.Text;

namespace u_t6_data_1
{
    class Interpreter_IO
    {
        static public bool CheckFactCMD(string line)
        {
            while (true)
            {
                Console.Write($"Факт: '{line}' это правда? (Y/N): ");

                var key = Console.ReadKey().Key;
                Console.WriteLine();

                if (key == ConsoleKey.Y)
                    return true;
                else if (key == ConsoleKey.N)
                    return false;
            }
        }
    }
}
