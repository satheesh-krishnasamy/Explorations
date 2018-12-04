using Algorithms.Lib.Matrix;
using Algorithms.Lib.Matrix.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Tests.Array
{
    [TestClass]
    public class ArrayOperationsFindMaxProductSubArrayByBruteForceMethodTests
    {
        [TestMethod]
        public void FindMaxProductSubArrayByBruteForceMethod_should_find_Max_Product_SubArray()
        {
            var inputToTest = new int[] { 2, 3, -2, 4 };
            var expectedResult = new SubArrayProductResult() { ProductSum = 6 };
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(0, 1));

            var result = ArrayOperations.FindMaxProductSubArrayByBruteForceMethod(inputToTest);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void FindMaxProductSubArrayByBruteForceMethod_should_find_Max_Product_SubArray_In_a_Array_having_Zero()
        {
            var inputToTest = new int[] { -1, 0, -5, 0 };
            var expectedResult = new SubArrayProductResult() { ProductSum = 0 };
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(0, 1));
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(0, 2));
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(0, 3));
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(1, 1));
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(1, 2));
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(1, 3));
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(2, 3));
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(3, 3));

            var result = ArrayOperations.FindMaxProductSubArrayByBruteForceMethod(inputToTest);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void FindMaxProductSubArrayByBruteForceMethod_should_find_Max_Product_SubArray_In_a_Array_having_2_Elements()
        {
            var inputToTest = new int[] { 1, -5 };
            var expectedResult = new SubArrayProductResult() { ProductSum = 1 };
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(0, 0));

            var result = ArrayOperations.FindMaxProductSubArrayByBruteForceMethod(inputToTest);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedResult);
        }


        [TestMethod]
        public void FindMaxProductSubArrayByBruteForceMethod_should_find_Max_Product_SubArray_In_a_Array_having_many_Elements()
        {
            var inputToTest = new int[] { 0, 0, -2, 0, 1, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, -3, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 2, -3, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, -3, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 0, -3, 0, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -2, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -3, 0, 0, -1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, -3, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -2, 0, 0, -2, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 3, 0, 0, 0, 0, 1, 0, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, -3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -2, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 2, 0, 0, 0, 0, 0, -1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, -2, 0, -1, 0, 0, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, -3, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0 };
            var expectedResult = new SubArrayProductResult() { ProductSum = 6 };
            expectedResult.SubArrayIndexes.Add(new Tuple<int, int>(227, 228));

            var result = ArrayOperations.FindMaxProductSubArrayByBruteForceMethod(inputToTest);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void FindMaxProductSubArrayByBruteForceMethod_should_return_null_when_a_Array_of_0X0()
        {
            var inputToTest = new int[] { };

            var result = ArrayOperations.FindMaxProductSubArrayByBruteForceMethod(inputToTest);

            Assert.IsNull(result);
        }
    }
}
