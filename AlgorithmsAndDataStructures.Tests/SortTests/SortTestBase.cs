using Algorithms.Lib.Comparers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Lib.Tests.SortTests.Model;

namespace Algorithms.Lib.Tests.SortTests
{
    public abstract class SortTestBase<T>
    {
        public SortTestBase(SortMethod<T> sortMethodToTest)
        {
            this.SortMethod = sortMethodToTest;
        }

        public SortMethod<T> SortMethod { get; }


        public abstract TestDataArray<T> GetInputElementsInDescendingExpectedAsDescendingOrder();
        public abstract TestDataArray<T> GetInputElementsInDescendingExpectedAsAscendingOrder();
        public abstract TestDataArray<T> GetInputElementsInRandomOrderExpectedInAscendingOrder();
        public abstract TestDataArray<T> GetInputElementsInRandomOrderExpectedInDescendingOrder();


        protected void Test_Ascending_Order_When_All_Elements_Are_In_Reverse_Order()
        {
            var testData = GetInputElementsInDescendingExpectedAsAscendingOrder();
            this.SortMethod(testData.Input, true);

            Assert.IsTrue(new ArrayComparer<T>().AreArraySame(testData.Input, testData.Expected));
        }

        protected void Test_Descending_Order_When_All_Elements_Are_In_Reverse_Order()
        {
            var testData = GetInputElementsInDescendingExpectedAsDescendingOrder();
            SortMethod(testData.Input, false);
            Assert.IsTrue(new ArrayComparer<T>().AreArraySame(testData.Input, testData.Expected));
        }

        protected void Test_Ascending_Order_When_All_Elements_Are_In_Random_Order()
        {
            var testData = GetInputElementsInRandomOrderExpectedInAscendingOrder();
            SortMethod(testData.Input, true);
            Assert.IsTrue(new ArrayComparer<T>().AreArraySame(testData.Input, testData.Expected));
        }

        protected void Test_Descending_Order_When_All_Elements_Are_In_Random_Order()
        {
            var testData = GetInputElementsInRandomOrderExpectedInDescendingOrder();
            SortMethod(testData.Input, false);
            Assert.IsTrue(new ArrayComparer<T>().AreArraySame(testData.Input, testData.Expected));
        }
    }
}
