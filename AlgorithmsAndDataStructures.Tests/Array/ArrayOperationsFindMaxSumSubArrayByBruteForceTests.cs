using Algorithms.Lib.Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Lib.Tests.Array
{
    [TestClass]
    public class ArrayOperationsTest4FindMaxSumSubArrayByBruteForceMethod
    {
        [TestMethod]
        public void FindMaxSumSubArrayByBruteForceMethodShould_Find_Max_Sum_Sub_Array_Exactly_Once()
        {
            var inputArray = new int[] { 100, 15, 20, -5, 0, 101 };
            var expectedSum = 231;
            var expectedSubArrayStartIndex = 0;
            var expectedSubArrayEndIndex = 5;

            var result = ArrayOperations.FindMaxSumSubArrayByBruteForceMethod(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == expectedSubArrayStartIndex);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == expectedSubArrayEndIndex);
            Assert.AreEqual(result.Sum, expectedSum);
        }

        [TestMethod]
        public void FindMaxSumSubArrayByBruteForceMethodShould_Find_Max_Sum_Sub_Arrays_more_than_once()
        {
            var inputArray = new int[] { 4, -1, -5, 4 };

            var expectedSum = 4;
            var expectedSubArrayStartIndex1 = 0;
            var expectedSubArrayEndIndex1 = 0;

            var expectedSubArrayStartIndex2 = 3;
            var expectedSubArrayEndIndex2 = 3;

            var result = ArrayOperations.FindMaxSumSubArrayByBruteForceMethod(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 2);

            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == expectedSubArrayStartIndex1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == expectedSubArrayEndIndex1);

            Assert.IsTrue(result.SubArrayIndexes[1].Item1 == expectedSubArrayStartIndex2);
            Assert.IsTrue(result.SubArrayIndexes[1].Item2 == expectedSubArrayEndIndex2);

            Assert.AreEqual(result.Sum, expectedSum);
        }


        [TestMethod]
        public void FindMaxSumSubArrayByBruteForceMethodShould_Return_SubArray_With_One_Element_That_Is_Max_Value()
        {
            var inputArray = new int[] { 1, 2, 3, 4, -100, 100 };

            var expectedSum = 100;
            var expectedSubArrayStartIndex1 = 5;
            var expectedSubArrayEndIndex1 = 5;

            var result = ArrayOperations.FindMaxSumSubArrayByBruteForceMethod(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);

            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == expectedSubArrayStartIndex1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == expectedSubArrayEndIndex1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == result.SubArrayIndexes[0].Item2);

            Assert.AreEqual(result.Sum, expectedSum);
        }


        [TestMethod]
        public void FindMaxSumSubArrayByBruteForceMethodShould_Return_When_Array_Size_Is_One()
        {
            var inputArray = new int[] { 100 };

            var expectedSum = 100;
            var expectedSubArrayStartIndex1 = 0;
            var expectedSubArrayEndIndex1 = 0;

            var result = ArrayOperations.FindMaxSumSubArrayByBruteForceMethod(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);

            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == expectedSubArrayStartIndex1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == expectedSubArrayEndIndex1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == result.SubArrayIndexes[0].Item2);

            Assert.AreEqual(result.Sum, expectedSum);
        }

        [TestMethod]
        public void FindMaxSumSubArrayByBruteForceMethodShould_Return_EMPTY_Result_When_Array_Size_Is_ZERO()
        {
            var inputArray = new int[] { };

            var expectedSum = long.MinValue;

            var result = ArrayOperations.FindMaxSumSubArrayByBruteForceMethod(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 0);
            Assert.AreEqual(result.Sum, expectedSum);
        }

        /// <summary>
        /// Finds the maximum sum sub array using Kadane's algorithm.
        /// Checks the result is whole array if whole array sum (22) is greater than sub array sum (16, 7).
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayByBruteForceMethodShould_Find_Whole_Array_AsResult_If_Whole_Array_sum_Greater_Than_Sub_Array_Sum()
        {
            int[] a = { 7, 5, 3, 1, -1, 5, 2 };
            var result = ArrayOperations.FindMaxSumSubArrayByBruteForceMethod(a);
            Assert.IsTrue(result.Sum == 22);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 0);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == a.Length - 1);
        }

        /// <summary>
        /// Finds the maximum sum sub array using Kadane's algorithm. 
        /// Checks whether the multiple sub arrays are returned with equal sum.
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayByBruteForceMethodShould_Find_Multiple_Sub_Array()
        {
            int[] a = { 7, 5, 3, 1, -1, -5, -10, 10, 6 };
            var result = ArrayOperations.FindMaxSumSubArrayByBruteForceMethod(a);
            Assert.IsTrue(result.Sum == 16);
            Assert.IsTrue(result.SubArrayIndexes.Count == 2);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 0);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == 3);
            Assert.IsTrue(result.SubArrayIndexes[1].Item1 == 7);
            Assert.IsTrue(result.SubArrayIndexes[1].Item2 == 8);
        }

    }
}