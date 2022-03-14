using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.heaps
{
    // problem link: https://www.geeksforgeeks.org/nearly-sorted-algorithm/
    public static class NearlySortedArray
    {
        public static int[] FindKthLargest(int[] nums, int k, int x)
        {
            PriorityQueue<Pair> maxHeap = new PriorityQueue<Pair>(isdesc: false);
            var result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                maxHeap.Enqueue(new Pair(Math.Abs(nums[i] - x), nums[i]));

                if (maxHeap.Count > k)
                {
                    // Console.WriteLine(maxHeap.Peek().value);
                    maxHeap.Dequeue();
                }
            }

            while (maxHeap.Count > 0) 
            {
                var curritem = maxHeap.Dequeue();
                Console.WriteLine(curritem.value);
                result.Add(curritem.value);
            }

            var resultentArr = result.ToArray();
            Array.Sort(resultentArr);

            return resultentArr;

            //for (int i = 0; i < k; i++) 
            //{
            //    result.Add(maxHeap.Dequeue().value);
            //}

            //for (int i = 0; i < result.Count; i++)
            //{
            //    Console.WriteLine(result[i]);
            //}
        }
    }

    public class Pair : IComparable<Pair>
    {
        public int diff;
        public int value;

        public Pair(int diff, int value)
        {
            this.diff = diff;
            this.value = value;
        }

        public int CompareTo(Pair other) 
        {
            if (diff == other.diff)
            {
                return Math.Min(value, other.value);
            }
            else 
            {
                return Math.Max(diff, other.diff);
            }
        }
    }
}
