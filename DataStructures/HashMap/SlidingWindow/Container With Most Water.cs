using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link: https://leetcode.com/problems/container-with-most-water/

    public static class Container_With_Most_Water
    {
        public static int MaxArea(int[] height) 
        {
            var max = 0;
            var p1 = 0;
            var p2 = height.Length - 1;

            while (p1 < p2)
            {
                var tempMax = (p2 - p1) * Math.Min(height[p2], height[p1]);
                max = Math.Max(tempMax, max);

                if (height[p1] < height[p2])
                {
                    p1 = p1 + 1;
                }
                else
                {
                    p2 = p2 - 1;
                }
            }
            return max;
        }
    }
}
