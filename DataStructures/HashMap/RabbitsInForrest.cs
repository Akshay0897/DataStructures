using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap
{
    // problem link: https://leetcode.com/problems/rabbits-in-forest/

    public static class RabbitsInForrest
    {
        public static int TotalRabbit(int[] arr) 
        {
            var totalRabbit = 0.0;
            var frequancyMap = BuildFrequancy(arr);
            foreach (var frequancy in frequancyMap) 
            {
                var totalGroup = Math.Ceiling((double)frequancy.Value / (frequancy.Key+1));
                var groupSize = frequancy.Key + 1;
                totalRabbit += totalGroup * groupSize;
            }

            return (int)totalRabbit;
        }

        private static Dictionary<int, int> BuildFrequancy(int[] nums)
        {
            var charFrequancyMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!charFrequancyMap.ContainsKey(nums[i]))
                {
                    charFrequancyMap.Add(nums[i], 1);
                }
                else
                {
                    charFrequancyMap[nums[i]]++;
                }
            }
            return charFrequancyMap;
        }
    }
}