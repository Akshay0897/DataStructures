using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class FindPositionInInfiniteArr
    {
		// Simple binary search algorithm
		private static int binarySearch(int start, int end, int element, int[] arr)
		{
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

		public static (int, int) findPos(int[] arr, int key)
		{
			// first find the range where your element lies
			var start = 0;
			var end = 1;
			var chunkSize = 2;

			while (key > arr[end])
			{
				// double the range each time not found
				var newStart = end + 1;
				end = end + (end - start + 1) * 2;
				start = newStart;

				Console.WriteLine($"Start pos {start}, end pos: {end}");
			}

			return (start, end);
		}

		public static void Run()
		{
			int[] arr = new int[]{3, 5, 7, 9, 10, 90, 100, 130, 140, 160, 170, 1111, 111111, 1111111};

			(var start, var end) = findPos(arr, 100);
			
			//Console.WriteLine($"Start pos {start}, end pos: {end}");

			int ans = binarySearch(start, end, 100, arr);

			if (ans == -1)
				Console.Write("Element not found");
			else
				Console.Write("Element found at "
								+ "index " + ans);
		}
	}
}
