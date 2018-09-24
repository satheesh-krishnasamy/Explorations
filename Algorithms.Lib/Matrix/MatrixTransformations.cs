using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Matrix
{
    public class MatrixTransformations
    {
        public static void Transform90DegreeInPlace(ref int[,] input)
        {
            const int FIRST_DIMENSION = 0;
            const int SECOND_DIMENSION = 1;

            var rowsCount = input.GetLength(FIRST_DIMENSION);
            var colsCount = input.GetLength(SECOND_DIMENSION);

            // this method works only on the matrix having same number or rows and columns
            if (input.GetLength(0) != input.GetLength(1))
                throw new Exception("Not supported");

            for (int currentElementCount = rowsCount; currentElementCount > 0; currentElementCount--)
            {
                TransformInternal(ref input, currentElementCount);
            }
        }

        private static void TransformInternal(ref int[,] matrix, int elementCountToTransform)
        {
            // rows and columns count are same
            var totalRowsInWholeMatrix = matrix.GetLength(0);
            var totalColsInWholeMatrix = matrix.GetLength(1);


            var rowIndex = 0;//totalRowsInWholeMatrix - elementCountToTransform;
            var currentSubMatrixTargetColumnIndex = elementCountToTransform - 1; // 2 X 2 => 2 , 3 X 3 => 3

            // Transform the target column in the submatrix with target row
            for (int col = 0, row = currentSubMatrixTargetColumnIndex; currentSubMatrixTargetColumnIndex != col; col++, row--)
            {
                var element = matrix[rowIndex, col];
                matrix[rowIndex, col] = matrix[row, currentSubMatrixTargetColumnIndex];
                matrix[row, currentSubMatrixTargetColumnIndex] = element;
            }

            // Re-order the target column
            for (int rowSource = rowIndex, rowTarget = currentSubMatrixTargetColumnIndex;
                rowSource < rowTarget;
                rowSource++, rowTarget--)
            {
                var element = matrix[rowTarget, currentSubMatrixTargetColumnIndex];
                matrix[rowTarget, currentSubMatrixTargetColumnIndex] = matrix[rowSource, currentSubMatrixTargetColumnIndex];
                matrix[rowSource, currentSubMatrixTargetColumnIndex] = element;
            }

            // Re-order all the rows in the submatrix
            for (int c = 0; c < currentSubMatrixTargetColumnIndex; c++)
            {
                int r = 0;
                var temp = matrix[r, c];
                for (; r < currentSubMatrixTargetColumnIndex; r++)
                {
                    matrix[r, c] = matrix[r + 1, c];
                }

                matrix[r, c] = temp;
            }

        }
    }
}
