using Algorithms.Lib.Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Lib.Tests.Matrix
{

    /// <summary>
    /// Test cases for testing the FindMaxSumSubArrayUsingKadanesAlgorithm method
    /// </summary>
    [TestClass]
    public class ArrayOperationsTest4FindMaxSumSubArrayUsingKadanesAlgorithm
    {
        /// <summary>
        /// Finds the maximum sum sub array using Kadane's algorithm should find maximum sum sub array.
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_MaxSumSubArray()
        {
            int[] a = { -2, -3, 4, -1, -2, 1, 5, -3 };
            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(a);
            Assert.IsTrue(result.Sum == 7);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 2);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == 6);
        }

        [TestMethod]
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_MaxSumSubArray2()
        {
            var inputArray = new int[] { 100, 15, 20, -5, 0, 101 };
            var expectedSum = 231;
            var expectedSubArrayStartIndex = 0;
            var expectedSubArrayEndIndex = 5;

            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == expectedSubArrayStartIndex);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == expectedSubArrayEndIndex);
            Assert.AreEqual(result.Sum, expectedSum);
        }

        /// <summary>
        /// Finds the maximum sum sub array using Kadane's algorithm should find maximum sum sub array in a single element array.
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_MaxSumSubArray_In_A_SingleElementArray()
        {
            int[] a = { -2 };
            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(a);
            Assert.IsTrue(result.Sum == a[0]);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 0);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == 0);
        }


        /// <summary>
        /// Finds the maximum sum sub array using Kadane's algorithm should find maximum sum sub array in an array with negative elements sorted desc.
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_MaxSumSubArray_In_An_Array_With_Negative_elements_Sorted_Desc()
        {
            int[] a = { -2, -4, -5, -7 };
            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(a);
            Assert.IsTrue(result.Sum == a[0]);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 0);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == 0);
        }

        /// <summary>
        /// Finds the maximum sum sub array using Kadane's algorithm should find maximum sum sub array in an array with negative elements sorted asc.
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_MaxSumSubArray_In_An_Array_With_Negative_elements_Sorted_Asc()
        {
            int[] a = { -7, -5, -3, -1 };
            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(a);
            Assert.IsTrue(result.Sum == a[3]);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 3);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == 3);
        }


        /// <summary>
        /// Finds the maximum sum sub array using Kadane's algorithm should find maximum sum sub array in an array with positive elements sorted desc.
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_MaxSumSubArray_In_An_Array_With_Positive_elements_Sorted_Desc()
        {
            int[] a = { 2, 4, 5, 7 };
            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(a);
            Assert.IsTrue(result.Sum == 18);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 0);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == a.Length - 1);
        }

        /// <summary>
        /// Finds the maximum sum sub array using Kadane's algorithm should find maximum sum sub array in an array with positive elements sorted asc.
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_MaxSumSubArray_In_An_Array_With_Positive_elements_Sorted_Asc()
        {
            int[] a = { 7, 5, 3, 1 };
            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(a);
            Assert.IsTrue(result.Sum == 16);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 0);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == a.Length - 1);
        }

        /// <summary>
        /// Finds the maximum sum sub array using Kadane's algorithm should find maximum sum sub array in an array with mixed elements1.
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_MaxSumSubArray_In_An_Array_With_Mixed_Elements1()
        {
            int[] a = { 7, 5, 3, 1, -1 };
            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(a);
            Assert.IsTrue(result.Sum == 16);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 0);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == 3);
        }

        /// <summary>
        /// Finds the maximum sum sub array using kadaneKs algorithm.
        /// Use case: sub array sum (16) is greater than whole array sum (7).
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_MaxSumSubArray_If_subArray_sum_Greater_Than_Whole_Array_Sum()
        {
            int[] a = { 7, 5, 3, 1, -16, 5, 2 };
            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(a);
            Assert.IsTrue(result.Sum == 16);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 0);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == 3);
        }

        /// <summary>
        /// Finds the maximum sum sub array using Kadane's algorithm.
        /// Checks the result is whole array if whole array sum (22) is greater than sub array sum (16, 7).
        /// </summary>
        [TestMethod]
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_Whole_Array_AsResult_If_Whole_Array_sum_Greater_Than_Sub_Array_Sum()
        {
            int[] a = { 7, 5, 3, 1, -1, 5, 2 };
            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(a);
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
        public void FindMaxSumSubArrayUsingKadanesAlgorithm_Should_Find_Multiple_Sub_Array()
        {
            int[] a = { 7, 5, 3, 1, -1, -5, -10, 10, 6 };
            var result = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(a);
            Assert.IsTrue(result.Sum == 16);
            Assert.IsTrue(result.SubArrayIndexes.Count == 2);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == 0);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == 3);
            Assert.IsTrue(result.SubArrayIndexes[1].Item1 == 7);
            Assert.IsTrue(result.SubArrayIndexes[1].Item2 == 8);
        }

    }
}
