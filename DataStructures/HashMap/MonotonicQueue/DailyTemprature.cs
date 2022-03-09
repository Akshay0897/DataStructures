using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.MonotonicQueue
{
    public static class DailyTemprature
    {
        public static int[] DailyTemperatures(int[] temperatures)
        {
            DMQ q = new DMQ(temperatures.Length, 0);

            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                q.Push(new Item(temperatures[i], i));
            }

            return q.GetNearestValues();
        }

        public class DMQ
        {
            private readonly Stack<Item> dequeue = new Stack<Item>();
            private readonly int[] nearestValues;
            private readonly int defaultValue;

            public DMQ(int size, int defaultValue)
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

                SetNearestValue(currentItem.Index);

                dequeue.Push(currentItem);
            }

            private void SetNearestValue(int currentItemIndex)
            {
                nearestValues[currentItemIndex] = defaultValue;
                if (dequeue.Count != 0)
                {
                    nearestValues[currentItemIndex] = dequeue.Peek().Index - currentItemIndex;
                }
            }

            public int[] GetNearestValues()
            {
                foreach (var currentItem in nearestValues) 
                {
                    Console.WriteLine(currentItem);
                }

                return nearestValues;
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
