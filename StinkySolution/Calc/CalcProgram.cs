using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calc
{
    class CalcProgram
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("usage: [x] [+|-|*|/] [y]");
                return;
            }

            var x = Convert.ToInt32(args[0]);
            var y = Convert.ToInt32(args[2]);
            var operation = args[1];

            try
            {
                Console.WriteLine(Calculate(x, y, operation));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }

        static int Calculate(int x, int y, string operation)
        {
            switch (operation.Trim())
            {
                case "+":
                    return x + y;
                case "-":
                    return x - y;
                case "*":
                    return x * y;
                case "/":
                    if (y == 0)
                    {
                        throw new Exception("Invalid arguments");
                    }
                    return x / y;
                default:
                    throw new Exception("Invalid arguments");
            }
        }
    }
}
