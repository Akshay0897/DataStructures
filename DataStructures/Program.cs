using DataStructures.BinarySearch;
using DataStructures.BitManipulation;
using DataStructures.ChainingTechnique;
using DataStructures.HashMap;
using DataStructures.HashMap.MonotonicQueue;
using DataStructures.HashMap.SlidingWindow;
using DataStructures.heaps;
using DataStructures.MergeIntervalsPattern;
using DataStructures.Stack;
using DataStructures.Stack.StockSpanner;
using DataStructures.Two_pointer;
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
            // Console.WriteLine(MajorityElementIII.FindGreater(2147483486));

            var utcDate = DateTime.SpecifyKind(DateTimeOffset.UtcNow.DateTime, DateTimeKind.Utc);
            var localTime = utcDate.ToLocalTime();

            // [10,16],[2,8],[1,6],[7,12]

            //[[1,1,4],[9,4,9],[9,1,9],[2,3,5],[4,1,5],[10,4,5]]

            //Console.WriteLine(CarPoolingProblem.CarPooling(new int[][] { new int[] { 1, 1, 4 }, new int[] { 9, 4, 9 }, new int[] { 9, 1, 9 }, new int[] { 2, 3, 5 }, 
            //     new int[] { 4, 1, 5 }, new int[] { 10, 4, 5 } }, 33));
            // Console.WriteLine(CarPoolingProblem.CarPooling(new int[][] { new int[] { 2, 1, 5 }, new int[] { 3, 5, 7 } }, 3));
            // Console.WriteLine(ValidPalindromicII.IsValidPalindrom("deeee"));

            //StockSpanner sp = new StockSpanner();

            //// 73,74,75,71,69,72,76,73

            //sp.Next(2);
            //sp.Next(5);
            //sp.Next(9);
            //sp.Next(3);
            //sp.Next(1);
            //sp.Next(12);
            //sp.Next(6);
            //sp.Next(8);
            //sp.Next(7);

            //Console.WriteLine(MaximalRectangle.GetMaximalRectangle(new char[][]
            //{ 
            //    new char[] { '1', '0', '1', '0', '0' }, 
            //    new char[] { '1', '1', '1', '1', '1' },
            //    new char[] { '1', '1', '1', '1', '1' },
            //    new char[] { '1', '0', '0', '1', '0' } 
            //}));

            // [3,3],[5,-1],[-2,4]

            // [1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]
            Console.WriteLine(Find_Original_Array_From_Doubled_Array.IsGoodArray(new int[] { 1, 3, 4, 2, 6, 8 }));
            Console.ReadLine();
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
