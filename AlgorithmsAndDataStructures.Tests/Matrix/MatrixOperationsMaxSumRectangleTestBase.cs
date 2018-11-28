using Algorithms.Lib.Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Lib.Tests.Matrix
{
    [TestClass]
    public class MatrixOperationsMaxSumRectangleTest
    {
        [TestMethod]
        public void GetMaxSumRectangle_should_return_max_sum_rectangle()
        {
            int[,] source = new int[,]
            {
                { 10, -1, -10},
                { 0, 10, 0},
                { 1, 20, 1},
                { 1, 21, 1}
            };

            var result = MatrixOperations.FindMaxSumRectangle(source);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Sum == 62);
            Assert.IsTrue(result.RowStartIndex == 0);
            Assert.IsTrue(result.RowEndIndex == 3);
            Assert.IsTrue(result.ColumnStartIndex == 0);
            Assert.IsTrue(result.ColumnEndIndex == 1);
        }

        [TestMethod]
        public void GetMaxSumRectangle_should_return_max_sum_rectangle_of_1X3()
        {
            int[,] source = new int[,]
            {
                { 10, -1, -10}
            };

            var result = MatrixOperations.FindMaxSumRectangle(source);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Sum == 10);
            Assert.IsTrue(result.RowStartIndex == 0);
            Assert.IsTrue(result.RowEndIndex == 0);
            Assert.IsTrue(result.ColumnStartIndex == 0);
            Assert.IsTrue(result.ColumnEndIndex == 0);
        }

        [TestMethod]
        public void GetMaxSumRectangle_should_return_Null_If_source_Matrix_Is_Empty()
        {
            int[,] source = new int[,]
            {
                { }
            };

            var result = MatrixOperations.FindMaxSumRectangle(source);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetMaxSumRectangle_should_return_max_sum_rectangle_In_Binary_Matrix_of_1X3()
        {
            int[,] source = new int[,]
            {
                { 1, 0 , 1}
            };

            var result = MatrixOperations.FindMaxSumRectangleWithContiguousElementsExcept(source, 0);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Sum == 1);
            Assert.IsTrue(result.RowStartIndex == 0);
            Assert.IsTrue(result.RowEndIndex == 0);
            Assert.IsTrue(result.ColumnStartIndex == 0);
            Assert.IsTrue(result.ColumnEndIndex == 0);
        }

        [TestMethod]
        public void GetMaxSumRectangle_should_return_max_sum_rectangle_In_Binary_Matrix_of_5X3()
        {
            int[,] source = new int[,]
            {
                { 1, 0 , 1},
                { 1, 1 , 1},
                { 1, 1 , 1},
                { 1, 1 , 1},
                { 1, 0 , 1}
            };

            var result = MatrixOperations.FindMaxSumRectangleWithContiguousElementsExcept(source, 0);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Sum == 9);
            Assert.IsTrue(result.RowStartIndex == 1);
            Assert.IsTrue(result.RowEndIndex == 3);
            Assert.IsTrue(result.ColumnStartIndex == 0);
            Assert.IsTrue(result.ColumnEndIndex == 2);
        }

        [TestMethod]
        public void GetMaxSumRectangle_should_return_Null_If_Binary_Matrix_Is_Empty()
        {
            int[,] source = new int[,]
            {
                { }
            };

            var result = MatrixOperations.FindMaxSumRectangleWithContiguousElementsExcept(source, 0);

            Assert.IsNull(result);
        }
    }
}
