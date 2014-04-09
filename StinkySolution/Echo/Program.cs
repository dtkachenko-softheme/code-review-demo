using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stinky
{
    class EchoProgram
    {
        static void Main(string[] args)
        {
            var MY_LINE_CONSTRUCTOR = new StringBuilder();

            foreach (var arg in args) MY_LINE_CONSTRUCTOR.AppendFormat("{0} ", arg);

            Console.WriteLine(MY_LINE_CONSTRUCTOR.ToString());
        }
    }
}
