using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinarySearch
{
    // problem link - https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/
    public static class KthSmallestInSortedMatrix
    {
        // how to reduce the search space
        public static int FindSmallest(int[][] nums, int k) 
        {
            var low = 0;
            var high = nums[nums.Length - 1][nums[0].Length - 1];

            while (low < high)
            {
                var mid = low + (high - low) / 2;

                // Trick here in using binary search is that we need to able to find the base condition on which we can search in searchspace and reduce it
                // here we are using this CountPairs function to decide where to move in the Search Space, likewise there could be anything
                if (CountLessThanMid(nums, mid) < k)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            return low;
        }

        private static int CountLessThanMid(int[][] matrix, int target)
        {
            int n = matrix.Length, i = n - 1, j = 0, cnt = 0;
            while (i >= 0 && j < n)
            {
                if (matrix[i][j] > target)
                {
                    i--;
                }
                else
                {
                    cnt += i + 1;
                    j++;
                }
            }

            return cnt;
        }
    }
}
