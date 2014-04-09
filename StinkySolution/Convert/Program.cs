using System;

namespace Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            var days = int.Parse(args[0]);
            var right = int.Parse(args[1]);

            var result = (byte)(((days >> (right % 7)) | (days << (7 - (right % 7)))) & 127);

            Console.WriteLine("The result of conversion is: {0}", result);
        }
    }
}
