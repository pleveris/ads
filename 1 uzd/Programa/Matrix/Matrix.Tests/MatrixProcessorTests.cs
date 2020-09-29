using System;
using System.Collections.Generic;
using Xunit;

namespace Matrix.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetNegativeNumbersUnderDiagnol_1()
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

            var matrixProcessor = new MatrixProcessor(matrix);

            var negativeNums = matrixProcessor.GetNegativeNumbersUnderDiagonal();

            Assert.Equal(new List<int> { -10, -2 }, negativeNums);
        }

        [Fact]
        public void GetNegativeNumbersUnderDiagnol_2()
        {
            var matrix = new List<List<int>>();
            var l1 = new List<int> { 1, 2 };
            var l2 = new List<int> { 3, 5 };


            matrix.Add(l1);
            matrix.Add(l2);

            var matrixProcessor = new MatrixProcessor(matrix);

            var negativeNums = matrixProcessor.GetNegativeNumbersUnderDiagonal();

            Assert.Equal(new List<int> { }, negativeNums);
        }

        [Fact]
        public void GetNegativeNumbersUnderDiagnol_3()
        {
            var matrix = new List<List<int>>();
            var l1 = new List<int> { 1, 2 };
            var l2 = new List<int> { 3, -5 };


            matrix.Add(l1);
            matrix.Add(l2);

            var matrixProcessor = new MatrixProcessor(matrix);

            var negativeNums = matrixProcessor.GetNegativeNumbersUnderDiagonal();

            Assert.Equal(new List<int> { -5 }, negativeNums);
        }

        [Fact]
        public void GetNegativeNumbersUnderDiagnol_4()
        {
            var matrix = new List<List<int>>();

            var l1 = new List<int> { 1 };
            
            matrix.Add(l1);

            Assert.Throws<ArgumentException>(() => new MatrixProcessor(matrix));
        }

        [Fact]
        public void GetNegativeNumbersUnderDiagnol_5()
        {
            var matrix = new List<List<int>>();

            var l1 = new List<int> { 1, 3 };
            var l2 = new List<int> { 1, 3, 4 };

            matrix.Add(l1);
            matrix.Add(l2);

            Assert.Throws<ArgumentException>(() => new MatrixProcessor(matrix));
        }

        [Fact]
        public void GetNegativeNumbersUnderDiagnol_6()
        {
            var matrix = new List<List<int>>();
            var l1 = new List<int> {  1,   2,   3,  4,    5,   9 };
            var l2 = new List<int> {  3,   5,   5,  6,   -3,  -5 };
            var l3 = new List<int> { -1,  -2,   3,  7,    6,  10 };
            var l4 = new List<int> {  6,  -2,  10,  7,   -3,  -5 };
            var l5 = new List<int> {  2,   2, -30,  7,   12,  83 };
            var l6 = new List<int> { -1,  -3, -40,  7, -100, -40 };

            matrix.Add(l1);
            matrix.Add(l2);
            matrix.Add(l3);
            matrix.Add(l4);
            matrix.Add(l5);
            matrix.Add(l6);

            var matrixProcessor = new MatrixProcessor(matrix);

            var negativeNums = matrixProcessor.GetNegativeNumbersUnderDiagonal();

            Assert.Equal(new List<int> { -100, -40, -40, -30, -5, -5, -3, -3}, negativeNums);
        }
    }
}
