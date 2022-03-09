﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.MonotonicQueue
{
    // problem link: https://leetcode.com/problems/largest-rectangle-in-histogram/
    
    public static class Largest_Rectangle_in_Histogram
    {
        public static int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;

            // default nearest value for increasing mq from left to right is -1
            var leftRight = new DMQ(-1, n);
            for (int i = 0; i < n; i++)
            {
                leftRight.Push(new Item(heights[i], i));
            }

            // default nearest value for increasing mq from right to left is n
            var rightLeft = new DMQ(n, n);
            for (int i = n - 1; i >= 0; i--)
            {
                rightLeft.Push(new Item(heights[i], i));
            }


            Console.WriteLine("Nearest smaller element to left");
            leftRight.PrintQueue();
            Console.WriteLine("Nearest smaller element to right ");
            rightLeft.PrintQueue();

            int maxArea = 0;
            for (int i = 0; i < n; i++)
            {
                int width = rightLeft.nearestValues[i] - leftRight.nearestValues[i] - 1;
                int currentArea = width * heights[i];
                maxArea = Math.Max(maxArea, currentArea);
            }
            return maxArea;
        }

        public class DMQ
        {
            private readonly Stack<Item> dequeue = new Stack<Item>();
            public readonly int[] nearestValues;
            private readonly int defaultValue;

            public DMQ(int defaultValue, int size)
            {
                this.nearestValues = new int[size];
                this.defaultValue = defaultValue;
            }

            public void Push(Item currentItem)
            {
                while (dequeue.Count != 0 && currentItem.Value <= dequeue.Peek().Value)
                {
                    dequeue.Pop();
                }

                // if we can't find the nearest smallest value from the array
                // we will take the default one
                if (dequeue.Count == 0)
                {
                    nearestValues[currentItem.Index] = defaultValue;
                }

                // the nearest smallest item will be at the peek of the queue
                // since we removed all the values that are bigger then the current
                else
                {
                    nearestValues[currentItem.Index] = dequeue.Peek().Index;
                }

                dequeue.Push(currentItem);
            }

            public void PrintQueue()
            {
                foreach (var item in nearestValues)
                {
                    Console.WriteLine($"{item}");
                }
            }
        }

        public class Item
        {
            public int Value;
            public int Index;

            public Item(int val, int ind)
            {
                this.Value = val;
                this.Index = ind;
            }
        }
    }
}
