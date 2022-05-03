using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinarySearch
{
    // problem link: https://leetcode.com/problems/k-th-smallest-prime-fraction/

    public static class K_th_Smallest_Prime_Fraction
    {
        public static int SmallestDistancePair(int[] nums, int k)
        {
            // first sort the array in ascending order
            int length = nums.Length;
            Array.Sort(nums);

            // Minimum absolute difference
            int low = 0;
            var high = nums[length - 1] - nums[0];

            while (low < high)
            {
                var mid = low + (high - low) / 2;

                // Trick here in using binary search is that we need to able to find the base condition on which we can search in searchspace and reduce it
                // here we are using this CountPairs function to decide where to move in the Search Space, likewise there could be anything
                if (CountPairs(nums, mid) < k)
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

        // this function counts the total number of pairs which has distance less that the mid
        private static int CountPairs(int[] nums, int mid)
        {
            var totalPairsLessThanMid = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var j = i;

                // traverse till we reach the point where it vioiltes the condition of min distance  
                while (j < nums.Length && Math.Abs(nums[j] - nums[i]) <= mid)
                {
                    j++;
                }

                // add it to the total cnt 
                totalPairsLessThanMid += j - i - 1;
            }
            return totalPairsLessThanMid;
        }
    }
}