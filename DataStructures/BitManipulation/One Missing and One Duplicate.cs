using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BitManipulation
{
    public static class FindAllMissing
    {
        // problem link: https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
        // note: this could be easily solve by just using hashset but the thing was to use only o(1) space, good inplace replacement trick.

        public static int[] FindDuplicates(int[] nums)
        {
            IList<int> result = new List<int>();

            for (int i = 0; i < nums.Length; i++) 
            {
                var index = Math.Abs(nums[i]) - 1;
                if (nums[index] > 0)
                {
                    nums[index] = -nums[index];
                }
                else 
                {
                    result.Add(index + 1);
                }
            }

            foreach (var item in result) 
            {
                Console.WriteLine(item);
            }

            return result.ToArray();    
        }
    }
}
