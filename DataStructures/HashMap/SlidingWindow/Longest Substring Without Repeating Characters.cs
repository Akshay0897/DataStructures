using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // two pointers
    // problem link - https://leetcode.com/problems/longest-substring-without-repeating-characters/

    public static class Longest_Substring_Without_Repeating_Characters
    {
        public static int GetCnt(string s) 
        {
            var p1 = 0;
            var p2 = 0;
            var result = 0;
            Dictionary<char, int> charFrequancyMap = new Dictionary<char, int>();

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
                result = Math.Max(result, p1 - p2 + 1);
                p1++;
            }
            return result;
        }
    }
}
