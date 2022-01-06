using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class MajorityElementIII
    {
        public static int FindInRotated(int n) 
        {
            var nums = n.ToString().ToCharArray().Select(elem => int.Parse(elem.ToString())).ToArray();
            Console.WriteLine(nums.Length);
            int i = nums.Length - 2;
            var stopLocation = -1;

            for (i = nums.Length - 2; i > 0; i--) 
            {
                if (nums[i - 1] < nums[i]) 
                {
                    stopLocation = i - 1;
                    break;
                }
            }

            if (i == 0) 
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

            
            
            // revers the rest of the array.


            return 0;
        } 
    }
}
