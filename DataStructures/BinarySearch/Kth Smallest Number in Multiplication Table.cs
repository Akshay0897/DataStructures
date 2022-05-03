using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinarySearch
{
    // problem link - https://leetcode.com/problems/kth-smallest-number-in-multiplication-table/
    public static class Kth_Smallest_Number_in_Multiplication_Table
    {
        public static int FindSmallest(int m , int n, int k)
        {
            var low = 0;
            var high = n * m;

            while (low < high)
            {
                var mid = low + (high - low) / 2;

                // Trick here in using binary search is that we need to able to find the base condition on which we can search in searchspace and reduce it
                // here we are using this CountPairs function to decide where to move in the Search Space, likewise there could be anything
                if (CountLessThanMid(m, n, mid) < k)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return high;
        }

        // trick in these kind of question is how to write the countn function
        private static int CountLessThanMid(int m, int n, int target)
        {
            int i = m, j = 1;
            int count = 0;
            while (i >= 1 && j <= n)
            {
                if (i * j <= target)
                {
                    count += i;
                    j++;
                }
                else
                {
                    i--;
                }
            }
            return count;
        }
    }
}
