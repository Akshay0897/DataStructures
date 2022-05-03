using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap
{
    // Problem link: https://leetcode.com/problems/subarray-sums-divisible-by-k/

    public static class Subarray_Sums_Divisible_by_K
    {
        public static int SubarraysDivByK(int[] nums, int k)
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
                var remainder = sumTillNow % k;

                if (remainder < 0) 
                {
                    remainder += k;
                }

                if (!keyValuePairs.TryGetValue(remainder, out var value))
                {
                    keyValuePairs.Add(remainder, 1);
                }
                else
                {
                    totalSubArrs += value;
                    keyValuePairs[remainder] = value + 1;
                }
            }
            return totalSubArrs;
        }
    }
}
