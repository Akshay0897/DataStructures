using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    // check if element occures more than n/3 times in an array. 

    public static class MajorityElement2
    {
        public static IList<int> GetMajorityElement(int[] nums)
        {
            var maybeMajorityElement1 = nums[0];
            var cnt1 = 1;

            var maybeMajorityElement2 = nums[0];
            var cnt2 = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == maybeMajorityElement1)
                {
                    cnt1++;
                }
                else if (nums[i] == maybeMajorityElement2)
                {
                    cnt2++;
                }
                else 
                {
                    if (cnt1 == 0)
                    {
                        maybeMajorityElement1 = nums[i];
                        cnt1 = 1;
                    }
                    else if (cnt2 == 0)
                    {
                        maybeMajorityElement2 = nums[i];
                        cnt2 = 1;
                    }
                    else 
                    {
                        cnt1--;
                        cnt2--;
                    }
                }
            }

            Console.WriteLine($"Potential candidate for majority is {maybeMajorityElement1} {maybeMajorityElement2}");

            var resultList = new List<int> {}; 

            var totalCnt1 = 0;
            var totalCnt2 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == maybeMajorityElement1)
                {
                    totalCnt1++;
                }

                if (nums[i] == maybeMajorityElement2)
                {
                    totalCnt2++;
                }
            }

            Console.WriteLine($"Potential candidate for majority is {totalCnt1} {totalCnt2}");

            if (totalCnt1 > nums.Length / 3) 
            {
                resultList.Add(maybeMajorityElement1);
            }

            if (maybeMajorityElement1 != maybeMajorityElement2 && totalCnt2 > nums.Length / 3)
            {
                resultList.Add(maybeMajorityElement2);
            }

           

            return resultList;
        }
    }
}
