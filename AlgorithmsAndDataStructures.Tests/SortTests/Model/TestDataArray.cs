using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Tests.SortTests.Model
{
    public class TestDataArray<T>
    {
        public TestDataArray(T[] input, T[] expected)
        {
            this.Input = input;
            this.Expected = expected;
        }

        public T[] Input { get; private set; }
        public T[] Expected { get; private set; }
    }
}
