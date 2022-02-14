using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    // problem link - https://leetcode.com/problems/find-the-duplicate-number/

    public static class Find_the_Duplicate_Number
    {
        public static int Find(int[] nums) 
        {
            int maxNum = -1;
            var arrSum = 0;
            for (int i = 0; i < nums.Length; i++) 
            {
                if (nums[i] > maxNum) 
                {
                    maxNum = nums[i];
                }

                arrSum+= nums[i];
            }

            // get sum
            var sumTillN = (maxNum * (maxNum + 1)) / 2;

            return arrSum - sumTillN;
        }
    }
}
