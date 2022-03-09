using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.MonotonicQueue
{
    // problem link: https://leetcode.com/problems/monotonic-array/

    public static class MonotonicArray
    {
        public static bool IsMonotonic(int[] nums)
        {
            var isDecreading = true;
            var isIncreasing = true;

            for (var i = 0; i < nums.Length - 1; i++) 
            {
                if (nums[i] > nums[i + 1])
                {
                    isIncreasing = false;

                } else if (nums[i] < nums[i+1]) 
                {
                    isDecreading = false;
                }       
            }

            return isDecreading || isIncreasing;
        }
    }
}
