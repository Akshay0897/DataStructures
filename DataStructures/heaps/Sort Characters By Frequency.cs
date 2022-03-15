using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.heaps
{
    // problem link: https://leetcode.com/problems/sort-characters-by-frequency/

    public static class Sort_Characters_By_Frequency
    {
        public static string FrequencySort(string s)
        {
            var result = new List<char>();
            Heap<CharPair> maxHeap = new Heap<CharPair>(1, isMaxHeap: true);

            var charFrequancyMap = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!charFrequancyMap.ContainsKey(s[i]))
                {
                    charFrequancyMap.Add(s[i], 1);
                }
                else
                {
                    charFrequancyMap[s[i]]++;
                }
            }

            foreach (var item in charFrequancyMap)
            {
                maxHeap.Insert(new CharPair(item.Value, item.Key));
            }


            while (maxHeap.Count > 0)
            {
                var currentElement = maxHeap.Peek();
                for (int i = 0; i < currentElement.frequancy; i++)
                {
                    result.Add(currentElement.value);
                }
                maxHeap.Remove();
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            return string.Join("", result);
        }
    }

    public class CharPair : IComparable<CharPair>
    {
        public int frequancy;
        public char value;

        public CharPair(int frequancy, char value)
        {
            this.frequancy = frequancy;
            this.value = value;
        }

        public int CompareTo(CharPair other)
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
