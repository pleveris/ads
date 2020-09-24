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
            var l1 = new List<int> { 1, 2, 3, 4 };
            var l2 = new List<int> { 3, 5, 5, 6 };
            var l3 = new List<int> { -1, -2, 3, 7 };
            var l4 = new List<int> { -1, -2, -10, 7 };

            matrix.Add(l1);
            matrix.Add(l2);
            matrix.Add(l3);
            matrix.Add(l4);

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

        public static List<int> GetNegativeNumbers(List<List<int>> matrix)
        {
            var negativeNums = new List<int>();

            for (int i = 1; i < matrix.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var item = matrix[i][matrix.Count - 1 - j];

                    if (item < 0)
                    {
                        negativeNums.Add(item);
                    }
                }
            }

            return negativeNums;
        }

        private static void OutputResult(List<int> negativeNums)
        {
            Console.Write("Negative numbers under matrix diagonal: ");
            foreach (var num in negativeNums)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine($"\nSum: {negativeNums.Sum()}");
            Console.WriteLine($"Average: {negativeNums.Average()}");
        }

    }
}
