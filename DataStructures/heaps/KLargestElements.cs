using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.heaps
{
    public static class KLargestElements
    {
        public static void FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int> maxHeap = new PriorityQueue<int>(isdesc: false);

            for (int i = 0; i < nums.Length; i++)
            {
                maxHeap.Enqueue(nums[i]);

                if (maxHeap.Count > k)
                {
                    maxHeap.Dequeue();
                }
            }

            for (int i = 0; i < k; i++) 
            {
                Console.WriteLine(maxHeap.Dequeue());
            }
        }
    }
}
