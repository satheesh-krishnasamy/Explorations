using Algorithms.Lib.Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Lib.Tests.Array
{
    [TestClass]
    public class ArrayFindMaxSumSubArrayTests
    {
        [TestMethod]
        public void FindMaxSumOfContiguousSubArray_Should_Find_Max_Sum_Sub_Array_Exactly_Once()
        {
            var inputArray = new int[] { 100, 15, 20, -5, 0, 101 };
            var expectedSum = 135;
            var expectedSubArrayStartIndex = 0;
            var expectedSubArrayEndIndex = 2;

            var result = SubArray.FindMaxSumOfContiguousSubArray(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == expectedSubArrayStartIndex);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == expectedSubArrayEndIndex);
            Assert.AreEqual(result.Sum, expectedSum);
        }

        [TestMethod]
        public void FindMaxSumOfContiguousSubArray_Should_Find_Max_Sum_Sub_Arrays_more_than_once()
        {
            var inputArray = new int[] { -4, 0, -5, 0 };

            var expectedSum = 0;
            var expectedSubArrayStartIndex1 = 1;
            var expectedSubArrayEndIndex1 = 1;

            var expectedSubArrayStartIndex2 = 3;
            var expectedSubArrayEndIndex2 = 3;

            var result = SubArray.FindMaxSumOfContiguousSubArray(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 2);

            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == expectedSubArrayStartIndex1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == expectedSubArrayEndIndex1);

            Assert.IsTrue(result.SubArrayIndexes[1].Item1 == expectedSubArrayStartIndex2);
            Assert.IsTrue(result.SubArrayIndexes[1].Item2 == expectedSubArrayEndIndex2);

            Assert.AreEqual(result.Sum, expectedSum);
        }


        [TestMethod]
        public void FindMaxSumOfContiguousSubArray_Should_Return_SubArray_With_One_Element_That_Is_Max_Value()
        {
            var inputArray = new int[] { 1, 2, 3, 4, -100, 100 };

            var expectedSum = 100;
            var expectedSubArrayStartIndex1 = 5;
            var expectedSubArrayEndIndex1 = 5;

            var result = SubArray.FindMaxSumOfContiguousSubArray(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);

            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == expectedSubArrayStartIndex1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == expectedSubArrayEndIndex1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == result.SubArrayIndexes[0].Item2);

            Assert.AreEqual(result.Sum, expectedSum);
        }


        [TestMethod]
        public void FindMaxSumOfContiguousSubArray_Should_Return_When_Array_Size_Is_One()
        {
            var inputArray = new int[] { 100 };

            var expectedSum = 100;
            var expectedSubArrayStartIndex1 = 0;
            var expectedSubArrayEndIndex1 = 0;

            var result = SubArray.FindMaxSumOfContiguousSubArray(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 1);

            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == expectedSubArrayStartIndex1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item2 == expectedSubArrayEndIndex1);
            Assert.IsTrue(result.SubArrayIndexes[0].Item1 == result.SubArrayIndexes[0].Item2);

            Assert.AreEqual(result.Sum, expectedSum);
        }

        [TestMethod]
        public void FindMaxSumOfContiguousSubArray_Should_Return_EMPTY_Result_When_Array_Size_Is_ZERO()
        {
            var inputArray = new int[] { };

            var expectedSum = 0;

            var result = SubArray.FindMaxSumOfContiguousSubArray(inputArray);
            Assert.IsTrue(result.SubArrayIndexes.Count == 0);
            Assert.AreEqual(result.Sum, expectedSum);
        }

    }
}