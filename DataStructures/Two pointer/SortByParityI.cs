using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Two_pointer
{
    // problem link - https://leetcode.com/problems/sort-array-by-parity/

    public static class SortByParityI
    {
        public static int[] SortArrayByParity(int[] nums)
        {
            var j = 0;
            var i = 0;

            while (i < nums.Length)
            {
                if (nums[i] % 2 != 0)
                {
                    i++;
                }
                else
                {
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i++;
                    j++;
                }
            }

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }

            return nums;
        }
    }
}
