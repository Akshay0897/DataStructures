using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class CeilUsingBinarySearch
    {
        public static (int, int) Ceil(int target, int[] inputArr)
        {
            var start = 0;
            var end = inputArr.Length - 1;
            int ceilResult = int.MaxValue;
            int floorResult = int.MinValue;

            while (start <= end)
            {
                var middle = ((start + end) / 2);
                Console.WriteLine($"{start} {end} {middle}");

                if (inputArr[middle] >= target && inputArr[middle] <= ceilResult) 
                {
                    ceilResult = inputArr[middle];
                    Console.WriteLine($"ceil {ceilResult}");
                }

                if (inputArr[middle] <= target && inputArr[middle] >= floorResult)
                {
                    floorResult = inputArr[middle];
                    Console.WriteLine($"floor {floorResult}");
                }

                if (target >= inputArr[middle])
                {
                    start = middle + 1;
                }
                else if (target <= inputArr[middle])
                {
                    end = middle - 1;
                }
            }
            return (ceilResult, floorResult);
        }
    }
}
