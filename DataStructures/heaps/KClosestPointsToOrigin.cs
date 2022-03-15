using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.heaps
{
    // problem link: https://leetcode.com/problems/k-closest-points-to-origin/
    public static class KClosestPointsToOrigin
    {
        public static int[][] KClosest(int[][] points, int k)
        {
            var pairs = new int[k][];

            Heap<PointPair> maxHeap = new Heap<PointPair>(1, isMaxHeap: false);

            for (int i = 0; i < points.Length; i++)
            {
                maxHeap.Insert(new PointPair(CalcDistanceToOrigin(new Point(points[i][0], points[i][1])), new Point(points[i][0], points[i][1])));

                if (maxHeap.Count > k)
                {
                    maxHeap.Remove();
                }
            }

            while (maxHeap.Count > 0)
            {
                var curritem = maxHeap.Remove();
                pairs[maxHeap.Count] = new int[] { curritem.value.x, curritem.value.y };
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                Console.WriteLine($"{pairs[i][0]}, {pairs[i][1]}");
            }

            return pairs;
        }

        private static int CalcDistanceToOrigin(Point pair) 
        {
            return (pair.y * pair.y) + (pair.x * pair.x);
        }
    }

    public class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class PointPair : IComparable<PointPair>
    {
        public int key;
        public Point value;

        public PointPair(int key, Point value)
        {
            this.key = key;
            this.value = value;
        }

        public int CompareTo(PointPair other)
        {
            return other.key.CompareTo(key);
        }
    }
}