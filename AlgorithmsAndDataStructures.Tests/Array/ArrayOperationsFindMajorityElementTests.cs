using Algorithms.Lib.Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Tests.Array
{
    [TestClass]
    public class ArrayOperationsFindMajorityElementByBoyerMooreAlgorithmTests
    {
        #region FindMajorityElementByBoyerMooreAlgorithmTest
        [TestMethod]
        public void FindMajorityElementByBoyerMooreAlgorithm_Should_Return_Majority_Element()
        {
            int[] a = new int[] { 1, 1, 3, 2, 1 };
            var result = ArrayOperations.FindMajorityElementByBoyerMooreAlgorithm(a);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result.MajorityElement == 1);
        }

        [TestMethod]
        public void FindMajorityElementByBoyerMooreAlgorithm_Should_Return_Null_if_no_majority_element_found_when_array_length_is_even()
        {
            int[] a = new int[] { 1, 1, 3, 2, 1, 4 };
            var result = ArrayOperations.FindMajorityElementByBoyerMooreAlgorithm(a);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindMajorityElementByBoyerMooreAlgorithm_Should_Return_Null_if_no_majority_element_found_when_array_length_is_odd()
        {
            int[] a = new int[] { 1, 1, 3, 2, 1, 4, 5 };
            var result = ArrayOperations.FindMajorityElementByBoyerMooreAlgorithm(a);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindMajorityElementByBoyerMooreAlgorithm_Should_Return_MajorityElement_if_Array_size_is_one()
        {
            int[] a = new int[] { 5 };
            var result = ArrayOperations.FindMajorityElementByBoyerMooreAlgorithm(a);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result.MajorityElement == 5);
        }

        [TestMethod]
        public void FindMajorityElementByBoyerMooreAlgorithm_Should_Return_Null_if_Array_size_is_Zero()
        {
            int[] a = new int[] { };
            var result = ArrayOperations.FindMajorityElementByBoyerMooreAlgorithm(a);

            Assert.IsNull(result);
        }

        #endregion FindMajorityElementByBoyerMooreAlgorithmTest

        #region FindMajorityElementByBruteForceMethodTest
        [TestMethod]
        public void FindMajorityElementByBruteForceMethod_Should_Return_Majority_Element()
        {
            int[] a = new int[] { 1, 1, 3, 2, 1 };
            var result = ArrayOperations.FindMajorityElementByBoyerMooreAlgorithm(a);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result.MajorityElement == 1);
        }

        [TestMethod]
        public void FindMajorityElementByBruteForceMethod_Should_Return_Null_if_no_majority_element_found_when_array_length_is_even()
        {
            int[] a = new int[] { 1, 1, 3, 2, 1, 4 };
            var result = ArrayOperations.FindMajorityElementByBruteForceMethod(a);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindMajorityElementByBruteForceMethod_Should_Return_Null_if_no_majority_element_found_when_array_length_is_odd()
        {
            int[] a = new int[] { 1, 1, 3, 2, 1, 4, 5 };
            var result = ArrayOperations.FindMajorityElementByBruteForceMethod(a);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindMajorityElementByBruteForceMethod_Should_Return_MajorityElement_if_Array_size_is_one()
        {
            int[] a = new int[] { 5 };
            var result = ArrayOperations.FindMajorityElementByBruteForceMethod(a);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result.MajorityElement == 5);
        }

        [TestMethod]
        public void FindMajorityElementByBruteForceMethod_Should_Return_Null_if_Array_size_is_Zero()
        {
            int[] a = new int[] {  };
            var result = ArrayOperations.FindMajorityElementByBruteForceMethod(a);

            Assert.IsNull(result);
        }
        #endregion FindMajorityElementByBruteForceMethodTest

    }
}
