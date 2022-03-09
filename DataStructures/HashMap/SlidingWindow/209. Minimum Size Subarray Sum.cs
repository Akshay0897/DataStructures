using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link - https://leetcode.com/problems/minimum-size-subarray-sum/

    public static class Minimum_Size_Subarray_Sum
    {
        public static int MinSubArrayLen(int target, int[] nums)
        {
            var ans = Int32.MaxValue;
            var left = 0;
            var right = 0;
            var sum = 0;

            while (right < nums.Length) 
            {
                sum += nums[right];

                while (sum >= target && left < nums.Length) 
                {
                    ans = Math.Min(ans, right - left + 1);
                    sum -= nums[left];
                    left++;
                }
                right++;
            }

            return ans == Int32.MaxValue ? 0 : ans;
        }
    }
}
