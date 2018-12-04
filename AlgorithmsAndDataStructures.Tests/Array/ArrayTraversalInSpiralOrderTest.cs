using Algorithms.Lib.Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Tests.Array
{
    /// <summary>
    /// Test class to test the array traversal method - Traverse in Spiral order
    /// </summary>
    [TestClass]
    public class ArrayTraversalInSpiralOrderTest
    {
        [TestMethod]
        public void TestSpiralTraversalWithMatrix_4_X_4()
        {
            int[,] inputArray = new int[,] {
                    {10, 20, 30, 40},
                    {40, 50, 60, 70},
                    {80, 90, 100, 110},
                    {120, 130, 140, 150}
                };

            int[] expectedResult = new int[] { 10, 20, 30, 40,
                70, 110, 150,
                140, 130, 120,
                80, 40,
                50, 60,
                100, 90
            };

            var actualResult = ArrayTraversals.TraverseArrayInSpiralOrder(inputArray);

            Assert.IsTrue(MatrixComparer.AreSame(expectedResult, actualResult));
        }

        [TestMethod]
        public void TestSpiralTraversalWithMatrix_2_X_5()
        {
            int[,] inputArray = new int[,] {
                    {10, 20},
                    {40, 50},
                    {80, 90},
                    {120, 130},
                    {19, 20 }
                };

            int[] expectedResult = new int[] { 10,20,
                50, 90, 130, 20,
                19,
                120, 80, 40
            };

            var actualResult = ArrayTraversals.TraverseArrayInSpiralOrder(inputArray);

            Assert.IsTrue(MatrixComparer.AreSame(expectedResult, actualResult));
        }

        [TestMethod]
        public void TestSpiralTraversalWithMatrix_4_X_5()
        {
            int[,] inputArray = new int[,] {
                    {10, 20, 30, 40, 50},
                    {40, 50, 10, 20, 30},
                    {80, 90, 40, 30, 20},
                    {120, 130, 100, 90, 80}
                };

            int[] expectedResult = new int[] {
                10,20, 30, 40, 50,
                30, 20, 80,
                90, 100, 130, 120,
                80, 40,
                50, 10, 20,
                30, 40, 90
            };

            var actualResult = ArrayTraversals.TraverseArrayInSpiralOrder(inputArray);

            Assert.IsTrue(MatrixComparer.AreSame(expectedResult, actualResult));
        }


        [TestMethod]
        public void TestSpiralTraversalWithMatrix_1_X_1()
        {
            int[,] inputArray = new int[,] {
                    {10}
                };

            int[] expectedResult = new int[] { 10 };

            var actualResult = ArrayTraversals.TraverseArrayInSpiralOrder(inputArray);

            Assert.IsTrue(MatrixComparer.AreSame(expectedResult, actualResult));
        }

        [TestMethod]
        public void TestSpiralTraversalWithMatrix_0_X_0()
        {
            int[,] inputArray = new int[,] {
                };

            int[] expectedResult = new int[] { };

            var actualResult = ArrayTraversals.TraverseArrayInSpiralOrder(inputArray);

            Assert.IsTrue(MatrixComparer.AreSame(expectedResult, actualResult));
        }

        [TestMethod]
        public void TestSpiralTraversalWithMatrix_5_X_1()
        {
            int[,] inputArray = new int[,] {
                { 1 },{5 },{6 },{7 },{10 }
                };

            int[] expectedResult = new int[] { 1, 5, 6, 7, 10 };

            var actualResult = ArrayTraversals.TraverseArrayInSpiralOrder(inputArray);

            Assert.IsTrue(MatrixComparer.AreSame(expectedResult, actualResult));
        }
    }
}
