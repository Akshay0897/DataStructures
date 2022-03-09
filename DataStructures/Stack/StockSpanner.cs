using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack.StockSpanner
{
    public class StockSpanner
    {
        private readonly Stack<int[]> _stack;

        public StockSpanner()
        {
            _stack = new Stack<int[]>();
        }

        public int Next(int price)
        {
            //  default value 
            int span = 1;

            while (_stack.Count != 0  && _stack.Peek()[0] <= price)
            {
                int[] curr = _stack.Pop();
                span += curr[1];
            }

            _stack.Push(new int[] { price, span });

            Console.WriteLine(span);

            return span;
        }
    }
}
