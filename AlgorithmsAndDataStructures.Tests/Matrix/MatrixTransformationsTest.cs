using Algorithms.Lib.Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithms.Lib.Tests.Matrix
{
    [TestClass]
    public class MatrixTransformationsTest
    {
        [TestMethod]
        public void Test_Matrix_Transformation_with_5X5_Matrix()
        {
            // prepare the input/test data
            int[,] source = new int[,] {
                    {10, 20, 30, 40, 5},
                    {20, 30, 40, 50, 7},
                    {20, 30, 40, 50, 8},
                    {20, 30, 40, 50, 0},
                    {100, 200, 300, 400, 500}
                };

            // define the expected result
            var expected = new int[,]{
                {100, 20, 20, 20, 10},
                {200,30,30,30,20},
                {300,40,40,40,30},
                {400,50,50,50,40},
                {500,0,8,7,5}};

            // do the test
            MatrixTransformations.Transform90DegreeInPlace(source);

            // validate/verify the output of the method with the expected output
            Assert.IsTrue(MatrixComparer.AreSame(source, expected));
        }

        [TestMethod]
        public void Test_Matrix_Transformation_with_4X4_Matrix()
        {
            // prepare the input/test data
            int[,] testData = new int[,] {
                    {10, 20, 30, 40},
                    {40, 50, 60, 70},
                    {80, 90, 100, 110},
                    {120, 130, 140, 150}
                };

            // define the expected result
            var expected = new int[,]{
                {120, 80, 40, 10},
                {130, 90, 50, 20},
                {140, 100, 60, 30},
                {150, 110, 70, 40}
                };

            // do the test
            MatrixTransformations.Transform90DegreeInPlace(testData);

            // validate/verify the output of the method with the expected output
            Assert.IsTrue(MatrixComparer.AreSame(testData, expected));
        }

        [TestMethod]
        public void Test_Matrix_Transformation_with_4X4_string_Matrix()
        {
            // prepare the input/test data
            string[,] testData = new string[,] {
                    {"10", "20", "30", "40"},
                    {"40", "50", "60", "70"},
                    {"80", "90", "100", "110"},
                    {"120", "130", "140", "150"}
                };

            // define the expected result
            var expected = new string[,]{
                    {"120", "80", "40", "10"},
                    {"130", "90", "50", "20"},
                    {"140", "100", "60", "30"},
                    {"150", "110", "70", "40"}
                };

            // do the test
            MatrixTransformations.Transform90DegreeInPlace(testData);

            // validate/verify the output of the method with the expected output
            Assert.IsTrue(MatrixComparer.AreSame(testData, expected));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Test_Matrix_Transformation_Should_Throw_Exception_On_Rows_And_Columns_Count_Is_Unequal()
        {
            // prepare the input/test data
            int[,] testData = new int[,] {
                    {10, 20, 30},
                    {40, 50, 60},
                    {80, 90, 100},
                    {120, 130, 140},
                    {120, 130, 140}
                };

            // define the expected result
            var expected = new int[,]{
                {120, 80, 40, 10},
                {130, 90, 50, 20},
                {140, 100, 60, 30},
                {150, 110, 70, 40}
                };

            // do the test
            MatrixTransformations.Transform90DegreeInPlace(testData);
        }
    }
}
