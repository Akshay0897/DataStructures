using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.heaps
{
    // problem link: https://leetcode.com/problems/top-k-frequent-elements/

    public static class Top_K_Frequent_Elements
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
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

            Heap<PairOne> maxHeap = new Heap<PairOne>(1);
            var result = new List<int>();

            foreach (var item in charFrequancyMap)
            {
                maxHeap.Insert(new PairOne(item.Value, item.Key));
            }

            for (int i = 0; i < charFrequancyMap.Keys.Count - k; i++) 
            {
                maxHeap.Remove();
            }

            while (maxHeap.Count > 0) 
            {
                result.Add(maxHeap.Peek().value);
                Console.WriteLine(maxHeap.Remove().value);
            }

            return result.ToArray();
        }
    }

    public class PairOne : IComparable<PairOne>
    {
        public int frequancy;
        public int value;

        public PairOne(int frequancy, int value)
        {
            this.frequancy = frequancy;
            this.value = value;
        }

        public int CompareTo(PairOne other)
        {
            return frequancy.CompareTo(other.frequancy);
        }
    }
}
