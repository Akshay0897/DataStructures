using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class PartitioningArray
    {
        public static void Partition(int[] nums, int pivot) 
        {
            var j = 0;
            var i = 0;

            while(i < nums.Length)
            {
                if (nums[i] > pivot)
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
        }

        public static void Partition01s(int[] nums)
        {
            var j = 0;
            var i = 0;

            while (i < nums.Length)
            {
                if (nums[i] == 1)
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
        }

        public static void Partition012s(int[] nums)
        {
            var j = 0;
            var i = 0;
            var k = nums.Length - 1;

            while (i <= k)
            {
                if (nums[i] == 1)
                {
                    i++;
                }
                else if(nums[i] == 0)
                {
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i++;
                    j++;
                }
                else
                {
                    var temp = nums[i];
                    nums[i] = nums[k];
                    nums[k] = temp;
                    k--;
                }
            }

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }

        public static void PartitionByParity(int[] nums)
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
        }
    }
}
