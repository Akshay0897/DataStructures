using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinarySearch
{
    // problem link - https://leetcode.com/problems/subarray-sum-equals-k/
    // We are using prefix sum approach in this problem we could also use sliding window approach to solve it in O(1)

    public static class Subarray_Sum_Equals_K
    {
        public static int SubarraySum(int[] nums, int goal)
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>
            {
                { 0, 1 }
            };

            var totalSubArrs = 0;
            var sumTillNow = 0;

            for (int i = 0; i < nums.Length; i++) 
            {
                sumTillNow += nums[i];
                if (keyValuePairs.ContainsKey(sumTillNow - goal))
                {
                    keyValuePairs.TryGetValue(sumTillNow - goal, out var val);
                    totalSubArrs += val;
                }

                if (!keyValuePairs.TryGetValue(sumTillNow, out var value))
                {
                    keyValuePairs.Add(sumTillNow, 1);
                }
                else 
                {
                    keyValuePairs[sumTillNow] = value + 1;
                }
            }
            return totalSubArrs;
        }
    }
}