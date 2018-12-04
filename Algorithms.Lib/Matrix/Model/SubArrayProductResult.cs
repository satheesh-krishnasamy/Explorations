using System;
using System.Collections.Generic;

namespace Algorithms.Lib.Matrix.Model
{
    /// <summary>
    /// Class represents the result of the FindMaxSumOfContiguousSubArray method
    /// </summary>
    public class SubArrayProductResult
    {
        public SubArrayProductResult()
        {
            this.SubArrayIndexes = new List<Tuple<int, int>>();
        }
        /// <summary>
        /// Gets or sets the sum indicating all the sub-array have the same SUM.
        /// </summary>
        /// <value>
        /// The sum.
        /// </value>
        public long ProductSum { get; set; } = long.MinValue;

        /// <summary>
        /// Gets or sets the sub array indexes.
        /// </summary>
        /// <value>
        /// The sub array indexes.
        /// </value>
        public IList<Tuple<int, int>> SubArrayIndexes { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is SubArrayProductResult target)
            {
                var areEqual = this.ProductSum == target.ProductSum
                    && this.SubArrayIndexes.Count == target.SubArrayIndexes.Count;

                if (!areEqual)
                    return areEqual;

                var index = 0;
                foreach (var indexRange in this.SubArrayIndexes)
                {
                    if (target.SubArrayIndexes[index].Item1 == indexRange.Item1
                        && target.SubArrayIndexes[index].Item2 == indexRange.Item2)
                    {
                        index++;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            return base.Equals(obj);
        }
    }
}
