using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap
{
    public static class Find_Original_Array_From_Doubled_Array
    {
        // problem link: https://leetcode.com/problems/find-original-array-from-doubled-array/

        public static int[] IsGoodArray(int[] arr)
        {
            // first build the frequancy map to get the total frequancy of particular number
            var frequancyMap = BuildFrequancy(arr);
            Array.Sort(arr, (a, b) => Math.Abs(a) - Math.Abs(b));
            var list = new List<int>();

            if (arr.Length % 2 != 0)
            {
                return new int[] { };
            }

            foreach (var key in arr)
            {
                if (frequancyMap.TryGetValue(key, out var val) && val == 0)
                {
                    continue;
                }

                // Console.WriteLine(key);
                if (!frequancyMap.TryGetValue(key * 2, out var doubleVal) || doubleVal == 0)
                {
                    return new int[] { };
                }

                list.Add(key);
                if (frequancyMap[key] > 0)
                {
                    frequancyMap[key] = frequancyMap[key] - 1;
                }
                if (frequancyMap[key * 2] > 0)
                {
                    frequancyMap[key * 2] = frequancyMap[key * 2] - 1;
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            return list.ToArray();
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
