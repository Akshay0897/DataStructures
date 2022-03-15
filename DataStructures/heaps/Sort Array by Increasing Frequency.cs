using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.heaps
{
    // problem link: https://leetcode.com/problems/sort-array-by-increasing-frequency/submissions/

    public static class Sort_Array_by_Increasing_Frequency
    {
        public static int[] FrequencySort(int[] nums)
        {
            var result = new List<int>();
            Heap<PairTwo> maxHeap = new Heap<PairTwo>(1, isMaxHeap: false);

            var charFrequancyMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!charFrequancyMap.ContainsKey(nums[i]))
                {
                    charFrequancyMap.Add(nums[i], 1);
                }
                else
                {
                    charFrequancyMap[nums[i]]++;
                }
            }

            foreach (var item in charFrequancyMap)
            {
                maxHeap.Insert(new PairTwo(item.Value, item.Key));
            }


            while (maxHeap.Count > 0)
            {
                var currentElement = maxHeap.Peek();
                for (int i = 0; i < currentElement.frequancy; i++) 
                {
                    result.Add(currentElement.value);
                }
                maxHeap.Remove();
                // Console.WriteLine(maxHeap.Remove().value);
            }

            foreach (var item in result) 
            {
                Console.WriteLine(item);
            }

            return result.ToArray();
        }
    }

    public class PairTwo : IComparable<PairTwo>
    {
        public int frequancy;
        public int value;

        public PairTwo(int frequancy, int value)
        {
            this.frequancy = frequancy;
            this.value = value;
        }

        public int CompareTo(PairTwo other)
        {
            if (frequancy == other.frequancy)
            {
                return other.value.CompareTo(value);
            }
            else
            {
                return frequancy.CompareTo(other.frequancy);
            }
        }
    }
}
