using System;

namespace PerfectSquares
{
    public class PerfectSquaresClass
    {
        public PerfectSquaresClass() { }

        public static int nextPerfectSquare(double squaredNumber)
        {
            double squareRoot = 0;
            squareRoot = Math.Sqrt(squaredNumber);
            int x = (int) Math.Floor(squareRoot);
            if (Math.Abs((x * x) - squaredNumber) < .001)
                return x+1;
            else return -1;

        }
    }
}
