namespace SolveQuadraticEquation
{
    class QuadraticEquationProgram
    {
        static void Main(string[] args)
        {
            var solver = new QuadraticEquationSolver();
            solver.ReadCommandlineArguments(args);
            solver.Solve();
            solver.Print();
        }
    }
}
