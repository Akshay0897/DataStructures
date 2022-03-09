using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public static class Replace_Elements_with_Greatest_Element_on_Right_Side
    {
        public static int[] ReplaceElements(int[] arr)
        {
            DMQ q = new DMQ(-1, arr.Length);

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                q.Push(new Item(arr[i], i));
            }

            for (int i = 0; i < arr.Length; i++) 
            {
                arr[i] = q.nearestValues[i];
            }
            return arr;
        }
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
                nearestValues[currentItem.Index] = dequeue.Peek().Value;
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
