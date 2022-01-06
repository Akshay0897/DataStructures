using System;
using System.Collections.Generic;
using System.Linq;
using static DataStructures.BufferExtensions;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var element = 2;
            SortedSet<int> inputArr = new SortedSet<int>() { -22123213 };
            //var (doesExist, at) = InsertPositionUsingBinarySearch(element, inputArr.ToArray());
            //if (doesExist)
            //{
            //    Console.WriteLine($"{String.Join(",", inputArr)} at {at}");
            //}
            //else 
            //{
            //    Console.WriteLine($"{element} should be inserted in {String.Join(",", inputArr)} at {at}");
            //}
            int[] mountainArr = new int[] { 1, 2 };
            // Console.WriteLine($"largest at {SearchInRotatedArrayWithDuplicates.FindLargest(mountainArr)}");
            //var peakElementIndex = FindPeekElement.BinarySearchForPeakElement(mountainArr);
            //Console.WriteLine($"Found a peak element at {peakElementIndex}");
            //Console.WriteLine(FindInRotatedArray.FindPivot(mountainArr));
            //Console.WriteLine(FindInRotatedArray.MinhInRotatedArray(mountainArr));
            // Console.WriteLine(SearchInRotatedArrayWithDuplicates.FindPivot(new int[] { 18, 18, 8, 8, 9, 11, 16, 17, 18 }));
            // Console.WriteLine(MatchPrefix.LongestPalindrome("aaaAaaaa"));
            // Console.WriteLine(SearchInRotatedArrayWithDuplicates.FindPivot(mountainArr));
            Console.WriteLine(MajorityElementIII.FindGreater(2147483486));
        }

        public static (bool, int?) BinarySearch(int element, int[] inputArr) 
        {
            var start = 0;
            var end = inputArr.Length - 1;
           
            while (start <= end) 
            {
                var middle = ((start + end) / 2);
                
                if (element > inputArr[middle])
                {
                    start = middle + 1;
                }
                else if(element < inputArr[middle])
                {
                    end = middle - 1;
                }
                else
                { 
                    return (true, middle);
                }
            }
            return (false, null);
        }

        public static (bool, int?) BinarySearchOrderAgnostic(int element, int[] inputArr)
        {
            var start = 0;
            var end = inputArr.Length - 1;

            while (start <= end)
            {
                var middle = ((start + end) / 2);

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
                    return (true, middle);
                }

            }
            return (false, null);
        }

        public static (bool, int?) InsertPositionUsingBinarySearch(int element, int[] inputArr)
        {
            var start = 0;
            var end = inputArr.Length - 1;

            while (start <= end)
            {
                var middle = ((start + end) / 2);

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
                    return (true, middle);
                }
            }
            return (false, start);
        }

        static void ConsoleWrite(double item) 
        {
            Console.WriteLine(item);
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;

            buffer.Dump(ConsoleWrite);
            
            while (!buffer.IsEmpty())
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
