using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // this is sorting plus sliding window

    public static class Frequency_of_the_Most_Frequent_Element
    {
        public static int MaxFrequency(int[] nums, int k)
        {
            var maxFreq = int.MinValue;
            var left = 0;
            var right = 0;
            double totalSum = 0;

            // first sort it baby
            Array.Sort(nums);

            while (right < nums.Length) 
            {
                totalSum += nums[right];
                // then we use sliding window
                while (nums[right] * (right - left + 1) > totalSum + k)
                {
                    totalSum -= nums[left];
                    left++;
                }
                maxFreq = Math.Max(maxFreq, (right - left + 1));
                right++;
            }
            return maxFreq;
        }
    }
}
