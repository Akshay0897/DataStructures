using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.heaps
{
    // problem link: https://leetcode.com/problems/kth-largest-element-in-an-array/submissions/

    public static class Kth_Largest_Element_in_an_Array
    {
        public static int FindKthLargest(int[] nums, int k)
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
            return maxHeap.Peek();
        }

        public static double KthLargestNumber(string[] nums, int k)
        {
            PriorityQueue<double> maxHeap = new PriorityQueue<double>(isdesc: false);

            for (int i = 0; i < nums.Length; i++)
            {
                maxHeap.Enqueue(double.Parse(nums[i]));

                if (maxHeap.Count > k)
                {
                    maxHeap.Dequeue();
                }
            }
            return double.Parse("4.4E-11", System.Globalization.NumberStyles.Any);
        }
    }
}
