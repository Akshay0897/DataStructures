using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.heaps
{
    // problem link: https://leetcode.com/problems/top-k-frequent-elements/

    public static class Top_K_Frequent_Elements
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
            PriorityQueue<int> maxHeap = new PriorityQueue<int>(isdesc: false);
            var result = new int[k];

            for (int i = 0; i < nums.Length; i++)
            {
                maxHeap.Enqueue(nums[i]);
            }

            return result;
        }
    }
}
