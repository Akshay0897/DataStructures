using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.MonotonicQueue
{
    public static class Trapping_Rain_Water
    {
        public static int Trap(int[] height)
        {
            var totalWater = 0;
            var leftMaxArr = new int[height.Length];
            var waterTrapped = new int[height.Length];
            leftMaxArr[0] = height[0];

            var rightMaxArr = new int[height.Length];
            rightMaxArr[height.Length - 1] = height[height.Length - 1];


            for (var i = 1; i < height.Length; i++) 
            {
                leftMaxArr[i] = Math.Max(leftMaxArr[i-1], height[i]);
            }

            for (var i = height.Length - 2; i >= 0; i--)
            {
                rightMaxArr[i] = Math.Max(rightMaxArr[i + 1], height[i]);
            }

            for (var i = 0; i < height.Length; i++)
            {
                waterTrapped[i] = Math.Min(leftMaxArr[i], rightMaxArr[i]) - height[i];
            }

            for (var i = 0; i < height.Length; i++)
            {
               totalWater += waterTrapped[i];
            }

            return totalWater;
        }
    }
}
