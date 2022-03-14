using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap
{
    // problem link - https://leetcode.com/problems/find-all-lonely-numbers-in-the-array/

    public static class Find_All_Lonely_Numbers_in_the_Array
    {
        public static IList<int> FindLonely(int[] nums)
        {
            var lonelyList = new List<int>();

            // build frequancy char hashmap
            var frequancyMap = BuildFrequancy(nums);

            for (int i = 0; i < nums.Length; i++) 
            {
                if (!(frequancyMap.TryGetValue(nums[i], out var currentVal) && currentVal > 1 || frequancyMap.TryGetValue(nums[i] - 1, out var leftVal) || frequancyMap.TryGetValue(nums[i] + 1, out var rightVal))) 
                {
                    lonelyList.Add(nums[i]);
                }
            }


            foreach (var item in lonelyList)
            {
                Console.WriteLine(item);
            }

            return lonelyList;
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
