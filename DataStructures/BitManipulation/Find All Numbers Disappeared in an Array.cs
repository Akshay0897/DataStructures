using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BitManipulation
{
    public static class OneMissingOneDup
    {
        public static int[] FindDuplicate(int[] nums)
        {
            // first xor everything
            var xory = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                xory ^= nums[i];
            }

            for (int i = 1; i <= nums.Length; i++)
            {
                xory ^= i;
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

            for (int i = 1; i <= nums.Length; i++)
            {
                if ((i & rmsb) == 0)
                {
                    x ^= i;
                }
                else
                {
                    y ^= i;
                }
            }

            Console.WriteLine($"{x} {y}");
            return new int[] { x, y };
        }
    }
}
