using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class TwoSum
    {
        public static (int, int) FindPair(int[] inputArr, int targetSum) 
        {
            var startPointer = 0;
            var endPointer = inputArr.Length - 1;

            while (startPointer <= endPointer) 
            {
                Console.WriteLine($"{startPointer} {endPointer}");
                var currentSum = inputArr[startPointer] + inputArr[endPointer];

                if (currentSum == targetSum)
                {
                    return (startPointer, endPointer);
                }

                else if (currentSum > targetSum)
                {
                    endPointer--;
                }
                else 
                {
                    startPointer++;
                }
            }

            return (-1, -1);
        }

        public static int[] RemoveDuplicates(int[] inputArr)
        {
            var startPointer = 0;
            var endPointer = inputArr.Length - 1;
            List<int> uniqueArr = new List<int>();

            //2, 7, 7, 11, 15, 15

            while (startPointer <= endPointer)
            {
                Console.WriteLine($"{startPointer} {endPointer}");
                while (startPointer > endPointer && inputArr[startPointer] == inputArr[startPointer + 1]) 
                {
                    startPointer++;
                }
                uniqueArr.Add(inputArr[startPointer]);
                startPointer++;

                while (endPointer > startPointer && inputArr[endPointer] == inputArr[endPointer - 1])
                {
                    endPointer--;
                }
                uniqueArr.Add(inputArr[endPointer]);
                endPointer--;
            }

            foreach (var element in uniqueArr) 
            {
                Console.Write(element);
            }

            return uniqueArr.ToArray();
        }
    }
}
