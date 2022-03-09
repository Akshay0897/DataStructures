using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public static class NearestGreaterToLeft
    {
        public static int[] NextGreaterElementToLeft(int[] arr)
        {
            var resultArr = new List<int>();
            var queue = new DMQ(-1, arr.Length);

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                queue.Push(new Item(arr[i], i));
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(queue.nearestValues[i]);  
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
                    nearestValues[currentItem.Index] = dequeue.Peek().Value;
                }

                dequeue.Push(currentItem);
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
