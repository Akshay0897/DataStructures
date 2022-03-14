using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Two_pointer
{
    // problem link - https://leetcode.com/problems/sort-array-by-parity/

    public static class SortArrayByParityII
    {
        public static int[] SortArrayByParity(int[] nums)
        {
            var res = new int[nums.Length];
            int j = 0, k = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    res[j] = nums[i];
                    j += 2;
                }
                else
                {
                    res[k] = nums[i];
                    k += 2;
                }
            }
            return res;
        }
    }
}
