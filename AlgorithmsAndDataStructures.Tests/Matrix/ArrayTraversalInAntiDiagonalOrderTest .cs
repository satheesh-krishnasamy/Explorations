using Algorithms.Lib.Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Tests.Matrix
{
    /// <summary>
    /// Test class to test the array traversal method - Traverse by anti-diagonal order
    /// </summary>
    [TestClass]
    public class ArrayTraversalInAtiDiagonalOrderTest
    {
        [TestMethod]
        public void TestAntiDiagonalTraversalWithMatrix_4_X_4()
        {
            int[,] inputArray = new int[,] {
                    {10, 20, 30, 40},
                    {40, 50, 60, 70},
                    {80, 90, 100, 110},
                    {120, 130, 140, 150}
                };

            IList<int[]> expectedResult = new List<int[]> {
                new int[]{ 10 },
                new int[]{ 20, 40 },
                new int[]{ 30, 50, 80},
                new int[]{ 40, 60, 90, 120},
                new int[]{ 70, 100, 130},
                new int[]{ 110, 140},
                new int[]{ 150}
            };

            ArrayAntiDiagonalOrderTestMethod(inputArray, expectedResult);


        }

        private void ArrayAntiDiagonalOrderTestMethod(int[,] inputArray, IList<int[]> expectedResult)
        {
            var actualResult = ArrayTraversals.TraverseArrayInAntiDiagonalOrder(inputArray);

            Assert.AreEqual(actualResult.Count, expectedResult.Count);

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.IsTrue(MatrixComparer.AreSame(expectedResult[i], actualResult[i]));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestAntiDiagonalTraversalWithMatrix_2_X_5()
        {
            int[,] inputArray = new int[,] {
                    {10, 20},
                    {40, 50},
                    {80, 90},
                    {120, 130},
                    {19, 20 }
                };

            IList<int[]> expectedResult = new List<int[]> {
                new int[]{ 10 },
                new int[]{ 20, 40 },
                new int[]{ 50, 80},
                new int[]{ 90, 120},
                new int[]{ 130, 19},
                new int[]{ 20}
            };

            ArrayAntiDiagonalOrderTestMethod(inputArray, expectedResult);
        }

        [TestMethod]
        public void TestAntiDiagonalTraversalWithMatrix_1_X_1()
        {
            int[,] inputArray = new int[,] {
                    {10}
                };

            IList<int[]> expectedResult = new List<int[]>
                {
                new int[] { 10 }
                };

            ArrayAntiDiagonalOrderTestMethod(inputArray, expectedResult);
        }

        [TestMethod]
        public void TestAntiDiagonalTraversalWithMatrix_0_X_0()
        {
            int[,] inputArray = new int[,] {
                };

            IList<int[]> expectedResult = new List<int[]>
            {
            };

            ArrayAntiDiagonalOrderTestMethod(inputArray, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestAntiDiagonalTraversalWithMatrix_5_X_1()
        {
            int[,] inputArray = new int[,] {
                { 1 },{5 },{6 },{7 },{10 }
                };

            IList<int[]> expectedResult = new List<int[]>
            {
                new int[] { 1 },
                new int[] {5 },
                new int[] {6 }, new int[] {7 },
                new int[] {10 }
            };

            ArrayAntiDiagonalOrderTestMethod(inputArray, expectedResult);
        }
    }
}
