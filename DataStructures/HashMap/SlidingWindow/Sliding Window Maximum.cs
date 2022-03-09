using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link - https://leetcode.com/problems/sliding-window-maximum/description/
    // using monotonic queue

    public static class Sliding_Window_Maximum
    {
        // this is brute force approach tc: O(n * k)
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            var resultList = new List<int>();
            var left = 0;
            var right = k;

            while (right <= nums.Length)
            {
                resultList.Add(GetMaxForWindow(left, right, nums));
                left++;
                right++;
            }

            PrintArray(resultList.ToArray());
            return resultList.ToArray();
        }

        private static void PrintArray(int[] vs)
        {
            foreach (var v in vs)
            {
                Console.WriteLine(v);
            }
        }

        private static int GetMaxForWindow(int left, int right, int[] arr)
        {
            var max = int.MinValue;
            for (var i = left; i < right; i++)
            {
                max = Math.Max(max, arr[i]);
            }
            return max;
        }

        public static int[] MaxSlidingWindowOptimized(int[] nums, int k)
        {
            var resultList = new List<int>();

            // nge begin
            int[] nge = new int[nums.Length];
            Stack<int> stack = new Stack<int>();

            stack.Push(nums.Length - 1);
            nge[nums.Length - 1] = nums.Length;

            for (var i = nums.Length - 2; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[i] >= nums[stack.Peek()])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    nge[i] = nums.Length;
                }
                else
                {
                    nge[i] = stack.Peek();
                }

                stack.Push(i);
            }

            // nge end
            int j = 0;
            for (int w = 0; w <= nums.Length - k; w++)
            {
                if (j < w)
                {
                    j = w;
                }

                while (nge[j] < w + k)
                {
                    j = nge[j];
                }

                resultList.Add(nums[j]);
            }

            return resultList.ToArray();
        }
    }
}
