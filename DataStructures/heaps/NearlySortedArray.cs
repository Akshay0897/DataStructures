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
        public static int[] FindKthLargest(int[] arr, int k, int x)
        {
            Heap<Pair> maxHeap = new Heap<Pair>(1, isMaxHeap: true);
            var result = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                maxHeap.Insert(new Pair(Math.Abs(arr[i] - x), arr[i]));

                if (maxHeap.Count > k)
                {
                    maxHeap.Remove();
                }
            }

            while (maxHeap.Count > 0) 
            {
                var curritem = maxHeap.Remove();
                result.Add(curritem.value);
            }

            var resultentArr = result.ToArray();
            Array.Sort(resultentArr);

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(resultentArr[i]);
            }
            return resultentArr;
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
                return value.CompareTo(other.value);
            }
            else 
            {
                return diff.CompareTo(other.diff);
            }
        }
    }
}
