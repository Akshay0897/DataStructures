using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.ChainingTechnique
{
    public static class PatitionArr
    {
        public static int GetDisjointIndex(int[] nums) 
        {
            var leftMax = nums[0];
            var greater = nums[0];
            var ans = 0;

            for (var i = 0; i < nums.Length; i++) 
            {
                if (nums[i] > greater)
                {
                    greater = nums[i];
                }
                else if (nums[i] < leftMax) 
                {
                    leftMax = greater;
                    ans = i;
                }
            }

            return ans + 1;
        }
    }
}
