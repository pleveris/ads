using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    public class MatrixProcessor
    {
        private List<List<int>> Matrix { get; set; }

        public MatrixProcessor(List<List<int>> matrix)
        {
            if (IsValidMatrix(matrix))
            {
                Matrix = matrix;
            }
            else
            {
                throw new ArgumentException("Invalid matrix (has to be n x n and n > 2)");
            }
        }

        public List<int> GetNegativeNumbersUnderDiagonal()
        {
            var negativeNums = new List<int>();

            for (int i = 1; i < Matrix.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var item = Matrix[i][Matrix.Count - 1 - j];

                    if (item < 0)
                    {
                        negativeNums.Add(item);
                    }
                }
            }

            negativeNums.Sort();

            return negativeNums;
        }

        private bool IsValidMatrix(List<List<int>> matrix)
        {
            var matrixCount = matrix.Count;

            if (matrixCount < 2)
            {
                return false;
            }

            foreach (var row in matrix)
            {
                if (row.Count != matrix.Count)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
