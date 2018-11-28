using System;
using System.Collections.Generic;

namespace Algorithms.Lib.Matrix.Model
{
    /// <summary>
    /// Class represents the result of the FindMaxSumOfContiguousSubArray method
    /// </summary>
    public class SubArraySumResult
    {
        public SubArraySumResult()
        {
            this.SubArrayIndexes = new List<Tuple<int, int>>();
        }
        /// <summary>
        /// Gets or sets the sum indicating all the sub-array have the same SUM.
        /// </summary>
        /// <value>
        /// The sum.
        /// </value>
        public long Sum { get; set; } = long.MinValue;

        /// <summary>
        /// Gets or sets the sub array indexes.
        /// </summary>
        /// <value>
        /// The sub array indexes.
        /// </value>
        public IList<Tuple<int, int>> SubArrayIndexes { get; set; }
    }
}
