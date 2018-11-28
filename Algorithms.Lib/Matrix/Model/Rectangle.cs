using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Matrix.Model
{
    public class Rectangle
    {
        public long Sum { get; set; }
        public int ColumnStartIndex { get; set; }
        public int ColumnEndIndex { get; set; }
        public int RowEndIndex { get; set; }
        public int RowStartIndex { get; set; }
    }
}
