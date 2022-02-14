using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class MergeIntervals
    {
        public static int[][] Merge(int[][] intervals)
        {
            // sort by starting point
            Array.Sort(intervals, (p, q) => p[0].CompareTo(q[0]));
            IList<int[]> result = new List<int[]>();

            Display2DArr(intervals);

            if (intervals.Length == 1) 
            {
                return intervals;
            }

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
                    prevInterval[1] = Math.Max(prevInterval[1], nextInterval[1]);
                }
                else 
                {
                    result.Add(intervals[i]);
                }
            }

            Display2DArr(result.ToArray());

            return result.ToArray();
        }

        public static int[][] MergeGiven(int[][] intervals, int[] newInterval)
        {
            // sort by starting point
            var intervalsList = intervals.ToList();
            intervalsList.Add(newInterval);

            intervals = intervalsList.ToArray();
                
            Array.Sort(intervals, (p, q) => p[0].CompareTo(q[0]));
            IList<int[]> result = new List<int[]>();

            Display2DArr(intervals);

            if (intervals.Length == 1)
            {
                return intervals;
            }

            // add the first one by default
            result.Add(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {
                // get the previous one
                var prevInterval = result[result.Count - 1];
                var nextInterval = intervals[i];

                if (prevInterval[1] >= nextInterval[0])
                {
                    // then we can merge
                    prevInterval[1] = Math.Max(prevInterval[1], nextInterval[1]);
                }
                else
                {
                    result.Add(intervals[i]);
                }
            }

            Display2DArr(result.ToArray());

            return result.ToArray();
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
