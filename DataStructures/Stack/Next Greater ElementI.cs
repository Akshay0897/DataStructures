using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    // problem-link: https://leetcode.com/problems/next-greater-element-i/

    public static class Next_Greater_Element_To_Right
    {
        public static int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var resultArr = new List<int>();
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

            var queue = new DMQ(-1, nums2.Length);

            for (int i = nums2.Length - 1; i >= 0 ; i--) 
            {
                queue.Push(new Item(nums2[i], i));
            }

            // storing it baby !
            for (int i = 0; i < nums2.Length; i++)
            {
                keyValuePairs.Add(nums2[i], queue.nearestValues[i]);
            }

            foreach (var item in keyValuePairs) 
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

            foreach (var item in nums1)
            {
                if (keyValuePairs.TryGetValue(item, out var val))
                {
                    resultArr.Add(val);
                }
                else 
                {
                    resultArr.Add(-1);
                }
            }

            foreach (var item in resultArr) 
            {
                Console.WriteLine(item);
            }

            return resultArr.ToArray();
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
                while (dequeue.Count != 0 && currentItem.Value >= dequeue.Peek().Value)
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
                    nearestValues[currentItem.Index] = dequeue.Peek().Value;
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
