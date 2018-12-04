using Algorithms.Lib.Matrix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Matrix
{
    public class ArrayOperations
    {
        /// <summary>
        /// Finds the maximum sum sub array using kadanes algorithm.
        /// </summary>
        /// <param name="a">input array.</param>
        /// <returns>Returns sub array [start index, end index] having maximum sum</returns>
        public static SubArraySumResult FindMaxSumSubArrayByKadanesAlgorithm(int[] a)
        {
            var result = new SubArraySumResult()
            {
                Sum = 0
            };

            long maxSumEndingHere = 0;

            int startIndex = -1,
                endIndex = -1;

            if (a.Length > 0)
            {
                result.Sum = a[0];
                startIndex = 0;
                endIndex = 0;
                maxSumEndingHere = a[0];

                result.SubArrayIndexes.Add(new Tuple<int, int>(startIndex, endIndex));
            }

            for (int i = 1; i < a.Length; i++)
            {
                var maxSumEndingHereTemp = maxSumEndingHere + a[i];

                if (maxSumEndingHereTemp > a[i])
                {
                    maxSumEndingHere = maxSumEndingHereTemp;
                    endIndex = i;
                }
                else // a[i] >= maxSumEndingHereTemp
                {
                    maxSumEndingHere = a[i];
                    startIndex = i;
                    endIndex = i;
                }

                if (maxSumEndingHere > result.Sum)
                {
                    result.Sum = maxSumEndingHere;
                    result.SubArrayIndexes.Clear();
                    result.SubArrayIndexes.Add(new Tuple<int, int>(startIndex, endIndex));
                }
                else if (maxSumEndingHere == result.Sum)
                {
                    result.SubArrayIndexes.Add(new Tuple<int, int>(startIndex, endIndex));
                }
            }

            return result;
        }


        /// <summary>
        /// Finds the maximum sum sub array using kadanes algorithm.
        /// </summary>
        /// <param name="a">input array.</param>
        /// <returns>Returns sub array [start index, end index] having maximum sum</returns>
        public static SubArraySumResult FindMaxSumSubArrayByKadanesAlgorithmCustom(int[] a, int endElement)
        {
            var result = new SubArraySumResult()
            {
                Sum = 0
            };

            long maxSumEndingHere = 0;

            int startIndex = -1,
                endIndex = -1;

            if (a.Length > 0)
            {
                result.Sum = a[0];
                startIndex = 0;
                endIndex = 0;
                maxSumEndingHere = a[0];

                result.SubArrayIndexes.Add(new Tuple<int, int>(startIndex, endIndex));
            }

            for (int i = 1; i < a.Length; i++)
            {
                var maxSumEndingHereTemp = maxSumEndingHere + a[i];

                if (maxSumEndingHereTemp > a[i])
                {
                    maxSumEndingHere = maxSumEndingHereTemp;
                    endIndex = i;
                }
                else // a[i] >= maxSumEndingHereTemp
                {
                    maxSumEndingHere = a[i];
                    startIndex = i;
                    endIndex = i;
                }

                if (maxSumEndingHere > result.Sum)
                {
                    result.Sum = maxSumEndingHere;
                    result.SubArrayIndexes.Clear();
                    result.SubArrayIndexes.Add(new Tuple<int, int>(startIndex, endIndex));
                }
                else if (maxSumEndingHere == result.Sum)
                {
                    result.SubArrayIndexes.Add(new Tuple<int, int>(startIndex, endIndex));
                }

                if (a[i] == endElement)
                {
                    maxSumEndingHere = 0;
                    startIndex = endIndex = i + 1;
                }
            }

            return result;
        }

        /// <summary>
        /// Finds the maximum sum sub array by brute force method.
        /// </summary>
        /// <param name="a">input array.</param>
        /// <returns>Returns sub array [start index, end index] having maximum sum</returns>
        public static SubArraySumResult FindMaxSumSubArrayByBruteForceMethod(int[] a)
        {
            SubArraySumResult result = new SubArraySumResult();

            int lastSubArrayStartIndex = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i; j < a.Length; j++)
                {
                    var currSubArraySum = GetSum(a, i, j);
                    if (currSubArraySum > result.Sum)
                    {
                        result.Sum = currSubArraySum;
                        result.SubArrayIndexes.Clear();
                        result.SubArrayIndexes.Add(new Tuple<int, int>(i, j));
                        lastSubArrayStartIndex = i;
                    }
                    else if (currSubArraySum == result.Sum && lastSubArrayStartIndex != i)
                    {
                        /* Reason for the check => (lastSubArrayStartIndex != i):
                         * If the current subarray with max-sum includes 
                         * the previously added subarray
                         * then do not add the subarray as max-sum subarray
                         * Example: 0-3 = 10 and 0-5 = 10 then
                         * do no consider the second sub-array ranging 0-5 as max-sum subarray.
                         */
                        result.SubArrayIndexes.Add(new Tuple<int, int>(i, j));
                        lastSubArrayStartIndex = i;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Finds the maximum product sub array by brute force method.
        /// </summary>
        /// <param name="a">input array.</param>
        /// <returns>Returns sub array [start index, end index] having maximum product</returns>
        public static SubArrayProductResult FindMaxProductSubArrayByBruteForceMethod(int[] a)
        {
            if (a == null || a.Length == 0)
                return null;

            SubArrayProductResult result = new SubArrayProductResult();

            int lastSubArrayStartIndex = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i; j < a.Length; j++)
                {
                    var currSubArraySum = GetProduct(a, i, j);
                    if (currSubArraySum > result.ProductSum)
                    {
                        result.ProductSum = currSubArraySum;
                        result.SubArrayIndexes.Clear();
                        result.SubArrayIndexes.Add(new Tuple<int, int>(i, j));
                        lastSubArrayStartIndex = i;
                    }
                    else if (currSubArraySum == result.ProductSum /*&& lastSubArrayStartIndex != i*/)
                    {
                        /* Reason for the check => (lastSubArrayStartIndex != i):
                         * If the current subarray with max-sum includes 
                         * the previously added subarray
                         * then do not add the subarray as max-sum subarray
                         * Example: 0-3 = 10 and 0-5 = 10 then
                         * do no consider the second sub-array ranging 0-5 as max-sum subarray.
                         */
                        result.SubArrayIndexes.Add(new Tuple<int, int>(i, j));
                        lastSubArrayStartIndex = i;
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// Finds Majority element in the given array using Boyer Moore Voting algorithm.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">array</param>
        /// <returns>
        /// Majority element
        /// </returns>
        public static MajorityElementResult<T> FindMajorityElementByBoyerMooreAlgorithm<T>(T[] a)
        {
            MajorityElementResult<T> result = new MajorityElementResult<T>();

            if (a.Length > 0)
            {
                result.Count = 1;
                result.MajorityElement = a[0];
            }

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == null)
                    continue;

                if (a[i].Equals(result.MajorityElement))
                {
                    result.Count++;
                }
                else
                {
                    result.Count--;
                }

                if (result.Count == 0)
                {
                    result.MajorityElement = a[i];
                    result.Count = 1;
                }
            }

            if (result.Count > 0)
            {
                result.Count = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == null)
                        continue;

                    if (a[i].Equals(result.MajorityElement))
                    {
                        result.Count++;
                    }
                }

                if (result.Count > Math.Floor(a.Length / 2.0))
                {
                    return result;
                }
            }

            return null;
        }


        /// <summary>
        /// Finds Majority element in the given array using brute force method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">array</param>
        /// <returns>
        /// Majority element
        /// </returns>
        public static MajorityElementResult<T> FindMajorityElementByBruteForceMethod<T>(T[] a)
        {
            MajorityElementResult<T> result = new MajorityElementResult<T>();

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == null)
                    continue;

                var tempCount = 0;
                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] == null)
                        continue;

                    if (a[i].Equals(a[j]))
                    {
                        tempCount++;
                    }
                }

                if (tempCount > result.Count)
                {
                    result.Count = tempCount;
                    result.MajorityElement = a[i];
                }
            }

            if (result.Count > Math.Floor(a.Length / 2.0))
            {
                return result;
            }

            return null;
        }

        private static long GetSum(int[] array, int startIndex, int endIndex)
        {
            long sum = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        private static long GetProduct(int[] array, int startIndex, int endIndex)
        {
            long sum = 1;
            for (int i = startIndex; i <= endIndex; i++)
            {
                // Once the current element is ZERO then product of upcoming elements becomes ZERO.
                if (array[i] == 0)
                {
                    return 0;
                }

                sum *= array[i];
            }
            return sum;
        }
    }
}
