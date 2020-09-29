using System;
using System.Collections.Generic;
using System.Linq;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new List<List<int>>();
            var l1 = new List<int> { 1, 2, 3, 4, 5, 9 };
            var l2 = new List<int> { 3, 5, 5, 6, -3, -5 };
            var l3 = new List<int> { -1, -2, 3, 7, 6, 10 };
            var l4 = new List<int> { 6, -2, 10, 7, -3, -5 };
            var l5 = new List<int> { 2, 2, -30, 7, 12, 83 };
            var l6 = new List<int> { -1, -3, -40, 7, -100, -40 };

            matrix.Add(l1);
            matrix.Add(l2);
            matrix.Add(l3);
            matrix.Add(l4);
            matrix.Add(l5);
            matrix.Add(l6);

            try
            {
                var matrixProcessor = new MatrixProcessor(matrix);
                var negativeNums = matrixProcessor.GetNegativeNumbersUnderDiagonal();
                OutputResult(negativeNums);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void OutputResult(List<int> negativeNums)
        {
            Console.WriteLine($"Negative numbers count: {negativeNums.Count()}");
            Console.WriteLine($"Sum: {negativeNums.Sum()}");
            Console.WriteLine($"Average: {negativeNums.Average()}");
        }
    }
}
