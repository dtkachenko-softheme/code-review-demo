using System;

namespace SolveQuadraticEquation
{
    class QuadraticEquationSolver
    {
        private double _a;
        private double _b;
        private double _c;

        private Result _result;

        public void ReadCommandlineArguments(string[] args)
        {
            _a = double.Parse(args[0]);
            _b = double.Parse(args[1]);
            _c = double.Parse(args[2]);
        }

        public void Solve()
        {
            _result = new Result();
            var sqrtpart = _b * _b - 4 * _a * _c;
            if (sqrtpart > 0)
            {
                _result.X1 = (-_b + Math.Sqrt(sqrtpart)) / (2 * _a);
                _result.X2 = (-_b - Math.Sqrt(sqrtpart)) / (2 * _a);
                
            }
            else if (sqrtpart < 0)
            {
                sqrtpart = -sqrtpart;
                _result.X1 = _result.X2 = -_b / (2 * _a);
                _result.Img = Math.Sqrt(sqrtpart) / (2 * _a);
                _result.IsImaginary = true;
            }
            else
            {
                _result.X1 = _result.X2 = (-_b + Math.Sqrt(sqrtpart)) / (2 * _a);
            }
        }

        public void Print()
        {
            if (_result.IsImaginary)
            {
                Console.WriteLine("Imaginary Solutions: {0,8:f4} + {1,8:f4} i or {2,8:f4} + {3,8:f4} i", _result.X1, _result.Img, _result.X2, _result.Img);
            }
            else
            {
                Console.WriteLine("Real Solutions: {0,8:f4} or  {1,8:f4}", _result.X1, _result.X2);
            }
        }

        private class Result
        {
            public double X1 { get; set; }
            public double X2 { get; set; }
            public double Img { get; set; }

            public bool IsImaginary { get; set; }
        }
    }
}
