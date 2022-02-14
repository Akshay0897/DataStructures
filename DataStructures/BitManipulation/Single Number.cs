using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BitManipulation
{
    // problem link - https://leetcode.com/problems/single-number/

    public static class Single_Number
    {
        public static int FindSingle(int[] nums) 
        {
            var missing = nums[0];

            for (int i = 1; i < nums.Length; i++) 
            {
                missing ^= nums[i];
            }

            return missing;
        }
    }
}
