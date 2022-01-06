using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class FindInRotatedArray
    {
        public static int FindPivot(int[] arr) 
        {
            int start = 0;
            int end = arr.Length -1;

            while (start <= end) 
            {
                int mid = start + (end - start)/2;
                if (mid < end && arr[mid] > arr[mid + 1])
                {
                    return mid;
                }
                else if (mid > start && arr[mid - 1] > arr[mid])
                {
                    return mid - 1;
                }
                else if (arr[start] > arr[mid])
                {
                    end = mid - 1; 
                }
                else 
                {
                    start = mid + 1;
                }
            }
            return -1;
        }

        public static int BinarySearchInRotatedArray(int[] nums, int target) 
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

        public static int MinhInRotatedArray(int[] nums)
        {
            int pivot = FindPivot(nums);

            Console.WriteLine($"pivot is {pivot}");

            if (pivot == -1)
            {
                return -1;
            }
            else if (nums[0] > nums[pivot + 1])
            {
               return nums[pivot + 1];
            }
            else
            {
                return nums[0];
            }
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
    }
}
