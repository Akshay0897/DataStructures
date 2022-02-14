using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link - https://www.geeksforgeeks.org/count-of-all-unique-substrings-with-non-repeating-characters/

    // amazon question - https://leetcode.com/discuss/interview-question/370157

    // similar for tomorrow - https://www.geeksforgeeks.org/count-number-of-substrings-with-exactly-k-distinct-characters/

    public static class Count_of_all_unique_substrings_with_non_repeating_characters
    {
        public static int DistinctSubstring(string s) 
        {
            var p1 = 0;
            var p2 = 0;
            var result = 0;
            Dictionary<char, int> charFrequancyMap = new Dictionary<char, int>();
            HashSet<string> uniqueStrs = new HashSet<string>();

            while (p1 < s.Length)
            {
                if (!charFrequancyMap.ContainsKey(s[p1]))
                {
                    charFrequancyMap.Add(s[p1], 1);
                }
                else
                {
                    charFrequancyMap[s[p1]]++;
                }

                while (charFrequancyMap.TryGetValue(s[p1], out var leftVal) && leftVal > 1)
                {
                    charFrequancyMap[s[p2]]--;
                    p2++;
                }

                // compute all the substring b/w p1 and p2 ?
                PrintHashSet(uniqueStrs, p2, p1, s);
                p1++;
            }
            //
            return uniqueStrs.Count;
        }

        private static void PrintHashSet(HashSet<string> ts, int start, int end, string str) 
        {
            for (int i = start; i < end; i++)
            {
                for (int j = start; j <= end - i; j++)
                {
                    // Please refer below article for details
                    // of substr in Java
                    // https://www.geeksforgeeks.org/java-lang-string-substring-java/
                    ts.Add(str.Substring(i, j));
                    Console.WriteLine(str.Substring(i, j));
                }
            }
        }
    }
}
