using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class FirstAndLastPositionInSortedArray
    {
        private static int BinarySearch(int element, int[] inputArr, bool isStartPos)
        {
            var start = 0;
            var end = inputArr.Length - 1;
            var middle = 0;
            int answer = -1;

            while (start <= end)
            {
                middle = ((start + end) / 2);

                Console.WriteLine($"{start}, {middle}, {end}");

                if (element > inputArr[middle])
                {
                    start = middle + 1;
                }
                else if (element < inputArr[middle])
                {
                    end = middle - 1;
                }
                else
                {
                    answer = middle;
                    if (isStartPos)
                    {
                        end = middle - 1;
                    }
                    else 
                    {
                        start = middle + 1;
                    }
                }
            }
            return answer;
        }

        public static int[] FindFirstAndLast(int element, int[] arr) 
        {
            var firstPos = BinarySearch(element, arr, true);
            var lastPos = BinarySearch(element, arr, false);

            var answers = new int[2];

            answers[0] = firstPos;
            answers[1] = lastPos;
            return answers;
        }
    }
}
