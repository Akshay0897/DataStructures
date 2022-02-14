using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.MergeIntervalsPattern
{
    // problem link - https://leetcode.com/problems/car-pooling/
    public static class CarPoolingProblem
    {
        public static bool CarPooling(int[][] trips, int capacity)
        {
            // sort it by ascending order of strating point
            Array.Sort(trips, (p, q) => {
                if (p[1] != q[1])
                {
                    return p[1].CompareTo(q[1]);
                }
                else 
                {
                    return p[2].CompareTo(q[2]);   
                }}
            );

            Display2DArr(trips);
            
            var result = new List<int[]> { };

            // add the first one by default
            result.Add(trips[0]);

            for (int i = 1; i < trips.Length; i++)
            {
                // get the previous one
                var prevInterval = result[result.Count - 1];
                var nextInterval = trips[i];

                if (prevInterval[2] > nextInterval[1])
                {
                    // then we can merge
                    prevInterval[2] = Math.Min(prevInterval[2], nextInterval[2]);
                    prevInterval[1] = Math.Max(prevInterval[1], nextInterval[1]);
                    prevInterval[0] = prevInterval[0] + nextInterval[0];

                    if (prevInterval[0] > capacity) 
                    {
                        Console.WriteLine($"total capacity exceeded {prevInterval[0]} bro we are only allowing {capacity} folks at the time.");
                        return false;
                    }
                }
                else
                {
                    if (nextInterval[0] > capacity)
                    {
                        Console.WriteLine($"total capacity exceeded {nextInterval[0]} bro we are only allowing {capacity} folks at the time.");
                        return false;
                    }

                    result.Add(trips[i]);
                }

                Console.WriteLine($"{prevInterval[0]}, {prevInterval[1]}, {prevInterval[2]}");
            }

            // print
            //Display2DArr(result.ToArray());

            return true;
        }

        private static void Display2DArr(int[][] intervals)
        {
            foreach (var interval in intervals)
            {
                Console.WriteLine($"{interval[0]}, {interval[1]}, {interval[2]}");
            }
        }
    }
}
