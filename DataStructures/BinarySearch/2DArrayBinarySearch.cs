using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinarySearch
{
    public static class _2DArrayBinarySearch
    {
        public static bool FindElement(int[][] matrix, int num) 
        {
            // use binary search since we know that matrix is fucking sorted
            var row = 0;
            var col = matrix[0].Length - 1;

            if (matrix == null || matrix.Length < 1 || matrix[0].Length < 1)
            {
                return false;
            }

            while (col >= 0 && row <= matrix.Length - 1)
            {
                if (matrix[row][col] == num)
                {
                    Console.WriteLine($"Found at {row} {col}");
                    return true;
                }
                else if (matrix[row][col] > num)
                {
                    col--;
                }
                else if (num > matrix[row][col])
                {
                    row++;
                }
            }
            return false;
        }
    }
}
