using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    // doing this using moore's voting algorithm this one is very famous one
    // we can also do this using building frequancy counter etc. but we already know that so using this algo for now.

    public static class MajorityElement
    {
        public static int GetMajorityElement(int[] nums) 
        {
            var maybeMajorityElement = nums[0];
            var cnt = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (cnt == 0) { maybeMajorityElement = nums[i]; }
                if (nums[i] == maybeMajorityElement)
                {
                    cnt++;
                }
                else 
                {
                    cnt--;
                }
            }

            Console.WriteLine($"Potential candidate for majority is {maybeMajorityElement}");

            var totalCnt = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == maybeMajorityElement) 
                {
                    totalCnt++;
                }
            }

            if (totalCnt > Math.Floor((double)nums.Length / 2)) {
                Console.WriteLine($"Majority element occurs {totalCnt} times in array.");
            }

            return maybeMajorityElement;
        }
    }
}
