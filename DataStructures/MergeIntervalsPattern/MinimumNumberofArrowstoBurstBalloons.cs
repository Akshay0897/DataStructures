using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.MergeIntervalsPattern
{
    // problem link - https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/

    public static class MinimumNumberofArrowstoBurstBalloons
    {
        public static int GetTotalArrows(int[][] points) 
        {
            // sort it by ascending order of strating point
            Array.Sort(points, (p, q) => p[0].CompareTo(q[0]));

            Display2DArr(points);

            var result = new List<int[]> { };

            // add the first one by default
            result.Add(points[0]);

            for (int i = 1; i < points.Length; i++)
            {
                // get the previous one
                var prevInterval = result[result.Count - 1];
                var nextInterval = points[i];

                if (prevInterval[1] >= nextInterval[0])
                {
                    // then we can merge
                    prevInterval[1] = Math.Min(prevInterval[1], nextInterval[1]);
                }
                else
                {
                    result.Add(points[i]);
                }
            }

            // print
            Display2DArr(result.ToArray());    
            
            return result.Count;
        }

        private static void Display2DArr(int[][] intervals)
        {
            foreach (var interval in intervals)
            {
                Console.WriteLine($"{interval[0]},{interval[1]}");
            }
        }
    }
}
