using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link - https://leetcode.com/problems/max-consecutive-ones/
    public static class Max_Consecutive_Ones
    {
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            var maxConsucutiveOnes = 0;
            var begin = 0;
            var end = 0;

            while (end < nums.Length)
            {
                while (end < nums.Length && nums[end] == 1) 
                {
                    end++;
                }

                Console.WriteLine($"end begin {end} {begin}");
                maxConsucutiveOnes = Math.Max(maxConsucutiveOnes, end - begin);
                // reset the begin
                end++;
                begin = end;
            }
            return maxConsucutiveOnes;
        }
    }
}
