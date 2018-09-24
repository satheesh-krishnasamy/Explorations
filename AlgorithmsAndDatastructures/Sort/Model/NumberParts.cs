using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsAndDatastructures.Sort.Model
{
    internal class NumberParts
    {
        public bool IsNegative { get; set; }
        public string WholeNumPart { get; set; }
        public string FractionalPart { get; set; }

        /// <summary>
        /// Parses the number string.
        /// </summary>
        /// <param name="numberStringInput">The number string input.</param>
        /// <returns>NumberParts instance</returns>
        /// <remarks>
        /// This method does not do any validation. 
        /// Expects proper number string.
        /// Example format: [+|-]([0-9])([.[0-9]])
        /// </remarks>
        public static NumberParts ParseNumberString(string numberStringInput)
        {
            NumberParts n = new NumberParts();

            string tempWholeNum = "";
            bool leadingZeros = true;
            int indexOfDOT = -1;

            foreach (var c in numberStringInput)
            {
                indexOfDOT++;
                /*if (c == '-')
                    tempWholeNum += c;
                else 
                */
                if (c == '.')
                {
                    break;// do not process the fractional part
                }
                else
                {
                    if (c == '-')
                    {
                        n.IsNegative = true;
                    }
                    else if (leadingZeros && c != '0' && c != '+')
                    {
                        tempWholeNum += c;
                        leadingZeros = false;
                    }
                    else if (!leadingZeros)
                    {
                        if (c != '+')// ignore leading (+) symbol in positive number
                            tempWholeNum += c;
                    }
                }
            }

            // ignore the dot character and go over the (.)
            n.FractionalPart = string.Empty;
            for (int indexOfCharNextToDOT = indexOfDOT + 1; indexOfCharNextToDOT< numberStringInput.Length; indexOfCharNextToDOT++)
            {
                n.FractionalPart += numberStringInput[indexOfCharNextToDOT];
            }

            //// dot presents in the number and not as a last char
            //if (indexOfCharNextToDOT < numberStringInput.Length)
            //{
            //    n.FractionalPart = numberStringInput.Substring(indexOfCharNextToDOT, numberStringInput.Length - indexOfCharNextToDOT);
            //}

            if (tempWholeNum == "-" || tempWholeNum == "")
                tempWholeNum = "0";

            n.WholeNumPart = tempWholeNum;
            return n;
        }
    }
}
