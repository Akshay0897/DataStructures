using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Two_pointer
{
    // problem link -  https://leetcode.com/problems/rearrange-array-elements-by-sign/
    public static class Rearrange_Array_Elements_by_Sign
    {
        //  [3,1,-2,-5,2,-4]
        public static int[] RearrangeArray(int[] nums, int pivot)
        {
            var result = new int[nums.Length];
            var posIndex = 0;
            var pivotCnt = 0;

            foreach (var item in nums)
            {
                if (item < pivot) 
                {
                    result[posIndex] = item;
                    posIndex += 1;
                }
                if (item == pivot) 
                {
                    pivotCnt++;
                }
            }

            for (int i = 0; i< pivotCnt; i++) 
            {
                result[posIndex++] = pivot;
            }

            foreach (var item in nums)
            {
                if (item > pivot)
                {
                    result[posIndex] = item;
                    posIndex += 1;
                }
            }

            foreach (var item in result) 
            {
                Console.WriteLine(item);    
            }

            return result;

        }
    }
}
