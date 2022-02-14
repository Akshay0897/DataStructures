using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.MergeIntervalsPattern
{
    // problem link - https://leetcode.com/problems/non-overlapping-intervals/

    public static class Non_overlapping_Intervals
    {
        public static int GetCntForNonOverLap(int[][] intervals) 
        {
            // sort it by ascending order of strating point
            Array.Sort(intervals, (p, q) => p[0].CompareTo(q[0]));

            Display2DArr(intervals);

            var result = new List<int[]> { };

            // add the first one by default
            result.Add(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {
                // get the previous one
                var prevInterval = result[result.Count - 1];
                var nextInterval = intervals[i];

                if (prevInterval[1] > nextInterval[0])
                {
                    // then we can merge
                    prevInterval[1] = Math.Min(prevInterval[1], nextInterval[1]);
                }
                else
                {
                    result.Add(intervals[i]);
                }
            }

            // print
            Display2DArr(result.ToArray());

            return intervals.Length - result.Count;
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
