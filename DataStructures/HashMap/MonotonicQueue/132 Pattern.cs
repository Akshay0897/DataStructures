using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.MonotonicQueue
{
    public static class _132_Pattern
    {
        public static bool Find132pattern(int[] nums)
        {
            var dmq = new DMQ();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (dmq.Push(nums[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class DMQ
    {
        private readonly Stack<int> dequeue; 
        private int previous;

        public DMQ()
        {
            this.dequeue = new Stack<int>();
            previous = int.MinValue;    
        }

        public bool Push(int currentItem)
        {
            if (currentItem < previous) 
            {
                return true;
            }

            while (dequeue.Count != 0 && dequeue.Peek() < currentItem)
            {
                previous = this.dequeue.Pop();
            }

            this.dequeue.Push(currentItem);    
            return false;
        }
    }
}
