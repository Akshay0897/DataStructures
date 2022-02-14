using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class IntervalListIntersections
    {
        public static int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            var resultArray = new List <int[]> { };
            var left = 0;
            var right = 0;

            while (left < firstList.Length && right < secondList.Length) 
            {
                var p1 = Math.Max(firstList[left][0], secondList[right][0]);
                var p2 = Math.Min(firstList[left][1], secondList[right][1]);

                if (p1 <= p2) 
                {
                    resultArray.Add(new int[] { p1, p2 });
                }

                if (firstList[left][1] > secondList[right][1])
                {
                    right++;
                }
                else 
                {
                    left++;
                }
            }

            Display2DArr(resultArray.ToArray());

            return resultArray.ToArray();
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
