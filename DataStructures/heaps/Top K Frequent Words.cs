using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.heaps
{
    // problem link: https://leetcode.com/problems/top-k-frequent-words/
    public static class Top_K_Frequent_Words
    {
        public static IList<string> TopKFrequent(string[] words, int k)
        {
            var list = new List<string>(k);
            Heap<StrPair> maxHeap = new Heap<StrPair>(1, isMaxHeap: false);
            var charFrequancyMap = new Dictionary<string, int>();

            foreach (var word in words) 
            {
                if (!charFrequancyMap.ContainsKey(word))
                {
                    charFrequancyMap.Add(word, 1);
                }
                else 
                {
                    charFrequancyMap[word]++;
                }
            }

            foreach (var item in charFrequancyMap)
            {
                maxHeap.Insert(new StrPair(item.Key, item.Value));

                if (maxHeap.Count > k)
                {
                    maxHeap.Remove();
                }
            }

            while (maxHeap.Count > 0)
            {
                var currentElement = maxHeap.Peek();
                list.Add(currentElement.key);
                maxHeap.Remove();
            }

            list.Reverse();

            foreach (var item in list) 
            {
                Console.WriteLine(item);
            }
            return list;
        }

        public class StrPair : IComparable<StrPair>
        {
            public string key;
            public int value;

            public StrPair(string key, int value)
            {
                this.key = key;
                this.value = value;
            }

            public int CompareTo(StrPair other)
            {
                if (value == other.value) 
                {
                    return other.key.CompareTo(key);
                }
                return value.CompareTo(other.value);
            }
        }
    }
}
