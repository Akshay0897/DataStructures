using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class SearchInRotatedArrayWithDuplicates
    {
        public static int FindPivot(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                Console.WriteLine($"start: {start} end: {end}");

                if (mid < end && arr[mid] > arr[mid + 1])
                {
                    return mid;
                }
                else if (mid > start && arr[mid - 1] > arr[mid])
                {
                    return mid - 1;
                }

                // if both end and start is equal skip them and reduce our search space to uniuque elements only
                else if (arr[mid] == arr[start] && arr[end] == arr[start])
                {
                    if (start == end)
                    {
                        return start;
                    }

                    // if start is pivot then return start
                    if (arr[start] > arr[start + 1])
                    {
                        return start;
                    }
                    start++;

                    //check if end is pivot or not
                    if (arr[end] < arr[end - 1])
                    {
                        return end - 1;
                    }
                    end--;
                }
                // left side is sorted so pivot must be in right side
                else if (arr[mid] >= arr[start] || (arr[mid] == arr[start] && arr[mid] > arr[end]))
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return -1;
        }

        public static int FindLargest(int[] arr) 
        {
            var largestElement = arr[0];
            var largestElementIndex = 0;
            for (int i = 0; i < arr.Length; i++) 
            {
                if (arr[i] >= largestElement) 
                {
                    largestElement = arr[i];
                    largestElementIndex = i;
                }
            }
            return largestElementIndex;
        }

        public static int BinarySearchInRotatedArrayWithDuplicates(int[] nums, int target)
        {
            int pivot = FindPivot(nums);
            Console.WriteLine($"pivot is {pivot}");
            if (pivot == -1)
            {
                return -1;
            }
            else if (nums[pivot] == target)
            {
                Console.WriteLine("adsa");
                return pivot;
            }
            else if (target >= nums[0])
            {
                return BinarySearch(0, pivot - 1, target, nums);
            }
            else
            {
                return BinarySearch(pivot + 1, nums.Length - 1, target, nums);
            }
        }

        public static bool IsRotatedAndSorted(int[] nums) 
        {
            int rotates = 0;

            for (int i = 0; i < nums.Length; ++i)
                if (nums[i] > nums[(i + 1) % nums.Length] && ++rotates > 1)
                    return false;

            return true;
        }

        public static int[] TakeTill(int startPos, int endPos, int[] arr) 
        {
            IList <int> list = new List<int>();
            if (arr.Length == 1) 
            {
                return arr;
            }
            for (int i = startPos; i <= endPos; i++) 
            {
                list.Add(arr[i]);
            }
            return list.ToArray();
        }

        public static bool IsSorted(int[] arr) 
        {
            if (arr.Length == 1) 
            {
                return true;
            }
            var isSorted = true;
            for (int i = 0; i < arr.Length - 1; i++) 
            {
                // Console.WriteLine($"{arr[i]} {arr[i + 1]}");
                if (arr[i] > arr[i + 1]) 
                {
                    isSorted = false;
                }
            }
            return isSorted;
        }

        private static int BinarySearch(int start, int end, int element, int[] arr)
        {
            Console.WriteLine($"start {start} end: {end}");
            while (start <= end)
            {
                var middle = ((start + end) / 2);

                if (element > arr[middle])
                {
                    start = middle + 1;
                }
                else if (element < arr[middle])
                {
                    end = middle - 1;
                }
                else
                {
                    return middle;
                }

            }
            return -1;
        }

        public static int RemoveDups(int[] nums) 
        {
            IList<int> resultedArr = new List<int>() { nums[0] };

            var currentElementIndex = 0;
            var nextElementIndex = 0;

            for (int i = 0; i < nums.Length; i++) 
            {
                if (nums[currentElementIndex] == nums[nextElementIndex])
                {
                    nextElementIndex++;
                }
                else 
                {
                    currentElementIndex = i;
                    resultedArr.Add(nums[i]);
                    nextElementIndex++;
                }    
            }

            foreach (var item in resultedArr) 
            {
                Console.Write(item);
            }

            return resultedArr.Count;
        }
    }
}
