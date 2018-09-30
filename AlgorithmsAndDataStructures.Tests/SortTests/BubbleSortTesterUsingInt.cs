using Algorithms.Lib.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Lib.Tests.SortTests.Model;

namespace Algorithms.Lib.Tests.SortTests
{
    [TestClass]
    public class BubbleSortTesterUsingInt : SortTestBase<int>
    {
        public BubbleSortTesterUsingInt() : base(BubbleSort.Sort)
        {
        }

        [TestMethod]
        public new void Test_Ascending_Order_When_All_Elements_Are_In_Reverse_Order()
        {
            base.Test_Ascending_Order_When_All_Elements_Are_In_Reverse_Order();
        }

        [TestMethod]
        public new void Test_Descending_Order_When_All_Elements_Are_In_Reverse_Order()
        {
            base.Test_Descending_Order_When_All_Elements_Are_In_Reverse_Order();
        }

        [TestMethod]
        public new void Test_Ascending_Order_When_All_Elements_Are_In_Random_Order()
        {
            base.Test_Ascending_Order_When_All_Elements_Are_In_Random_Order();
        }

        [TestMethod]
        public new void Test_Descending_Order_When_All_Elements_Are_In_Random_Order()
        {
            base.Test_Descending_Order_When_All_Elements_Are_In_Random_Order();
        }


        public override TestDataArray<int> GetInputElementsInDescendingExpectedAsDescendingOrder()
        {
            return new TestDataArray<int>(
                new int[] { 5, 4, 3, 2, 1, 0 },
                new int[] { 5, 4, 3, 2, 1, 0 }
                );
        }

        public override TestDataArray<int> GetInputElementsInDescendingExpectedAsAscendingOrder()
        {
            return new TestDataArray<int>(new int[] { 5, 4, 3, 2, 1, 0 }, new int[] { 0, 1, 2, 3, 4, 5 });
        }

        public override TestDataArray<int> GetInputElementsInRandomOrderExpectedInAscendingOrder()
        {
            return new TestDataArray<int>(new int[] { 0, 2, 90, 24, 5, 10 }, new int[] { 0, 2, 5, 10, 24, 90 });
        }

        public override TestDataArray<int> GetInputElementsInRandomOrderExpectedInDescendingOrder()
        {
            return new TestDataArray<int>(new int[] { 0, 2, 90, 24, 5, 10 }, new int[] { 90, 24, 10, 5, 2, 0 });
        }
    }
}
