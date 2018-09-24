using Algorithms.Lib.Common.Model;
using Algorithms.Lib.Sort.Model;
using System.Collections.Generic;

namespace Algorithms.Lib.Sort
{
    public class SortNumberUtil
    {
        public void SelectionSortAsNumbers(string[] numberStrings, bool sortAsc)
        {
            IList<NumberParts> numbers = GetNumberPartsCollection(numberStrings);

            // Apply the selection sort
            SelectionSortNumberStringsWithoutCasting(ref numbers, ref numberStrings, sortAsc);
        }

        public void SelectionSort(ref double[] inputCollection, bool isAsc)
        {
            for (int i = 0; i < inputCollection.Length; i++)
            {
                var indexOfSmallestOrGreatestNumber = i;
                for (int j = i + 1; j < inputCollection.Length; j++)
                {
                    if (inputCollection[indexOfSmallestOrGreatestNumber] < inputCollection[j])
                    {
                        if (!isAsc)
                        {
                            indexOfSmallestOrGreatestNumber = j;
                        }
                    }
                    else
                    {
                        if (isAsc)
                        {
                            indexOfSmallestOrGreatestNumber = j;
                        }
                    }
                }

                var tempValue = inputCollection[i];
                inputCollection[i] = inputCollection[indexOfSmallestOrGreatestNumber];
                inputCollection[indexOfSmallestOrGreatestNumber] = tempValue;
            }
        }

        private IList<NumberParts> GetNumberPartsCollection(string[] numberStrings)
        {
            IList<NumberParts> numbers = new List<NumberParts>();

            // Split the number parts (symbol, whole number, fractional part)
            for (int i = 0; i < numberStrings.Length; i++)
            {
                numbers.Add(NumberParts.ParseNumberString(numberStrings[i]));
            }

            return numbers;
        }

        /// <summary>
        /// Sorts number strings without type casting
        /// </summary>
        /// <param name="numberParts">Array of objects of type NumberParts</param>
        /// <param name="strNumbers">Input number string array</param>
        /// <param name="asc">true: if ascending order, false: descending order.</param>
        /// <remarks>
        /// This method works on the following factors.
        /// Facts:
        ///  1. Any number string that start with - is negative number.
        ///  2. Any number string that does not or does have the + is positive number.
        ///  3. The number can have the optional fractional part (part after dot character).
        ///  4. Any whole number (part before the dot) with less number of digits (e.g. 9)
        ///  is less than other whole number that has more number of digits (123).
        ///  5. Adding the ZEROs (0) in-front of the whole number does not affect its value.
        ///  6. Adding the ZEROs (0) at the trail of the whole number affects its value; so dont do that.
        ///  7. Adding the ZEROs (0) at the trail of the fractional part does NOT affect the value of the fractional part.
        ///  8. A negative number having lesser value in whole number part (-1) is greater than the other 
        ///  negative number with greater value in whole number part (-1000). i.e. -1 > -1000 though 1 less than 1000.
        /// </remarks>
        private static void SelectionSortNumberStringsWithoutCasting(ref IList<NumberParts> numberParts, ref string[] strNumbers, bool asc)
        {
            for (int i = 0; i < numberParts.Count; i++)
            {
                var indexOfNumInterchange = i;
                for (int j = i + 1; j < numberParts.Count; j++)
                {
                    // selection sort
                    if (IsGreater(numberParts[indexOfNumInterchange], numberParts[j]))
                    {
                        if (asc)
                        {
                            indexOfNumInterchange = j;
                        }
                    }
                    else
                    {
                        if (!asc)
                        {
                            indexOfNumInterchange = j;
                        }
                    }
                }


                // interchange the i th smallest/greatest number
                var smallerNumber = numberParts[indexOfNumInterchange];
                numberParts[indexOfNumInterchange] = numberParts[i];
                numberParts[i] = smallerNumber;

                // interchange the actual strings
                var smallerNum = strNumbers[indexOfNumInterchange];
                strNumbers[indexOfNumInterchange] = strNumbers[i];
                strNumbers[i] = smallerNum;
            }
        }

        private static bool IsGreater(NumberParts num1, NumberParts num2)
        {
            if (num1.IsNegative && !num2.IsNegative)
                return false;
            if (num1.IsNegative && num2.IsNegative)
            {
                // -100 , -1
                var compareWholeNumResult = CompareNumberStringByValue(num1.WholeNumPart, num2.WholeNumPart, true);

                if (compareWholeNumResult == ComparisonResult.FirstIsGreaterThenSecond)
                {
                    //negative big numbers are actually small
                    return false;
                }
                else if (compareWholeNumResult == ComparisonResult.FirstIsLessThanSecond)
                {
                    //negative smaller numbers are actually big
                    return true;
                }
                else if (compareWholeNumResult == ComparisonResult.BothAreEqual)
                {
                    //-1.1, -1.0
                    var compareResult = CompareNumberStringByValue(num1.FractionalPart, num2.FractionalPart, false);
                    if (compareResult == ComparisonResult.FirstIsGreaterThenSecond)
                    {
                        return false;
                    }
                    else // <=  ComparisonResult.FirstIsLessThanSecond || ComparisonResult.BothAreEqual
                    {
                        return true;
                    }

                }

            }
            else if (!num1.IsNegative && !num2.IsNegative)
            {
                var compareResult = CompareNumberStringByValue(num1.WholeNumPart, num2.WholeNumPart, true);

                if (compareResult == ComparisonResult.FirstIsGreaterThenSecond)
                {
                    return true;
                }
                else if (compareResult == ComparisonResult.FirstIsLessThanSecond)
                {
                    return false;
                }
                else if (compareResult == ComparisonResult.BothAreEqual)
                {
                    var compareFractionalPartResult = CompareNumberStringByValue(num1.FractionalPart, num2.FractionalPart, false);
                    if (compareFractionalPartResult == ComparisonResult.FirstIsGreaterThenSecond)
                        return true;
                    else // <=
                        return false;

                }
            }

            // num1 is positive and num2 is negative
            return true;
        }

        private static ComparisonResult CompareNumberStringByValue(string numStr1, string numStrZero2, bool isWholeNumber)
        {
            // 9, 999
            if (numStr1.Length < numStrZero2.Length)
            {
                if (isWholeNumber)
                {
                    numStr1 = string.Concat(new string('0', numStrZero2.Length - numStr1.Length), numStr1);
                }
                else
                {
                    numStr1 = string.Concat(numStr1, new string('0', numStrZero2.Length - numStr1.Length));
                }
            }// 999, 9
            else if (numStr1.Length > numStrZero2.Length)
            {
                if (isWholeNumber)
                {
                    numStrZero2 = string.Concat(new string('0', numStr1.Length - numStrZero2.Length), numStrZero2);
                }
                else
                {
                    numStrZero2 = string.Concat(numStrZero2, new string('0', numStr1.Length - numStrZero2.Length));
                }
            }

            /* compare each character (ASCII or UNICODE)
             * 48 - 57 = 0 - 9
             * 46 = DOT (.)
             * 43 = +
             * 45 = -
             * 65-90 = A-Z
             * 97 - 122 = a-z
             * */
            for (int i = 0; i < numStr1.Length; i++)
            {
                if (numStr1[i] > numStrZero2[i])
                    return ComparisonResult.FirstIsGreaterThenSecond;
                else if (numStr1[i] < numStrZero2[i])
                    return ComparisonResult.FirstIsLessThanSecond;
            }

            return ComparisonResult.BothAreEqual;
        }


    }
}
