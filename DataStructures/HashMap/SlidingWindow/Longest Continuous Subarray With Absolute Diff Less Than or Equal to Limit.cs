using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link: https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/
    public static class Longest_Continuous_Subarray_With_Absolute_Diff_Less_Than_or_Equal_to_Limit
    {
        public static int LongestSubarray(int[] nums, int limit)
        {
            var min = int.MaxValue;
            var max = int.MinValue;
            var len = -1;
            var left = 0;
            var right = 0;

            while (left < nums.Length) 
            {
                min = Math.Min(min, nums[right]);
                max = Math.Max(max, nums[right]);

                while (Math.Abs(min - max) > limit) 
                {
                    left++;
                    min = Math.Min(min, nums[left]);
                    // max = Math.Max(max, nums[right]);
                }

                len = Math.Max(len, right - left + 1);
                right++;
            }
            return len;
        }
    }
}
