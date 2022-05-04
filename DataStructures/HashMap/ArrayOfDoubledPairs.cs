using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap
{
    // problem link: https://leetcode.com/problems/array-of-doubled-pairs/
    public static class ArrayOfDoubledPairs
    {
        public static bool IsGoodArray(int[] arr) 
        {
            // first build the frequancy map to get the total frequancy of particular number
            var frequancyMap = BuildFrequancy(arr);
            Array.Sort(arr, (a, b) => Math.Abs(a) - Math.Abs(b));
            foreach (var key in arr)
            {
                if (frequancyMap.TryGetValue(key, out var val) && val == 0)
                {
                    continue;
                }

                if (!frequancyMap.TryGetValue(key * 2, out var doubleVal) || doubleVal == 0) 
                {
                    return false;
                }
                
                if (frequancyMap[key] > 0) 
                {
                    frequancyMap[key] = frequancyMap[key] - 1;
                }
                if (frequancyMap[key * 2] > 0)
                {
                    frequancyMap[key * 2] = frequancyMap[key * 2] - 1;
                }
            }
            return true;
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
