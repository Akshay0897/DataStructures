using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class MajorityElementIII
    {
        /*
        - What this problem wants is finding the next permutation of n
        - Steps to find the next permuation: 
        find largest index k such that inp[k] < inp[k+1];
            if k == -1: return -1
            else:
                look for largest index l such that inp[l] > inp[k]
                swap the two index
                reverse from k+1 to n.length
        */

        public static int FindGreater(int n) 
        {
            var nums = n.ToString().ToCharArray().Select(elem => int.Parse(elem.ToString())).ToArray();
            int i = nums.Length - 2;
            var stopLocation = -1;

            for (i = nums.Length - 2; i >= 0; i--) 
            {
                if (nums[i + 1] <= nums[i])
                {
                    continue;
                }
                else 
                {
                    stopLocation = i;
                    break;
                }
            }
            Console.WriteLine($"stop location is {stopLocation}");

            if (i == -1) 
            {
                return -1;
            }

            var swapPos = -1;
            for (int j = nums.Length - 1; j > i; j--) 
            {
                if (nums[j] > nums[stopLocation]) 
                {
                    swapPos = j;
                    break;
                }
            }

            Console.WriteLine($"{stopLocation} {swapPos}");
            
            // swap the num.
            var temp = nums[swapPos];
            nums[swapPos] = nums[stopLocation];
            nums[stopLocation] = temp;

            Console.WriteLine("After swapping");

            foreach (var item in nums)
            {
                Console.Write(item);
            }

            Console.WriteLine("reversing now");

            // revers the rest of the array.
            ReversePartOfAnArr(nums, i + 1, nums.Length - 1);

            foreach (var item in nums) 
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine(string.Join("", nums));

            return int.TryParse(string.Join("", nums), out int result) ? result: -1;
        }

        private static void ReversePartOfAnArr(int[] nums, int start, int end) 
        {
            while (start < end) 
            {
                // swap the num.
                var temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;

                start++;
                end--;
            }
        }
    }
}
