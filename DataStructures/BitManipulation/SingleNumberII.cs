using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BitManipulation
{
    // problem link - https://leetcode.com/problems/single-number-ii/

    public static class SingleNumberII
    {
        public static int[] SingleNumber(int[] nums)
        {
            // first xor everything
            var xory = 0;
            for (int i = 0; i < nums.Length; i++) 
            {
                xory ^= nums[i];
            }

            // find rmsbm
            var rmsb = xory & -xory;

            var x = 0;
            var y = 0;

            for (int i = 0; i < nums.Length; i++) 
            {
                if ((nums[i] & rmsb) == 0)
                {
                    x ^= nums[i];
                }
                else 
                {
                    y ^= nums[i];
                }
            }

            Console.WriteLine($"{x} {y}");
            return new int[] { x, y };
        }

        public static int MissingNumber(int[] nums)
        {
            // first xor everything
            var arrXor = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                arrXor ^= nums[i];
            }

            var xor = 0;    
            for (int i = 1; i <= nums.Length; i++) 
            {
                xor ^= i;
            }

            return arrXor ^ xor;
        }
    }
}
