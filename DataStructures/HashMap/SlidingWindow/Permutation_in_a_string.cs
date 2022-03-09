using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link - https://leetcode.com/problems/permutation-in-string/description/
    
    public static class Permutation_in_a_string
    {
        private static Dictionary<char, int> BuildCharFrequeancy(string s)
        {
            Dictionary<char, int> charFrequancyMap = new Dictionary<char, int>();

            foreach (var item in s)
            {
                if (!charFrequancyMap.ContainsKey(item))
                {
                    charFrequancyMap.Add(item, 1);
                }
                else
                {
                    charFrequancyMap[item]++;
                }
            }
            return charFrequancyMap;
        }

        public static bool CheckInclusion(string s1, string s2)
        {
            var begin = 0;
            var end = 0;
            var charFrequancyForTargetStr = BuildCharFrequeancy(s1);
            var counter = charFrequancyForTargetStr.Count;
            var resultlLen = int.MaxValue;
            bool isIncluded = false;

            while (end < s.Length)
            {
                // maintain the counter here
                if (charFrequancyForTargetStr.ContainsKey(s2[end]))
                {
                    charFrequancyForTargetStr[s2[end]]--;
                    if (charFrequancyForTargetStr.TryGetValue(s2[end], out var val) && val == 0)
                    {
                        counter--;
                    }
                }
                while (counter == 0)
                {
                    // Console.WriteLine($"entered in count zero zone {end} {begin}");
                    // decrease the size of the windows as long as we have all the required chars with sufficient freq in our source string 
                    if (resultlLen == s1.Length)
                    {
                        isIncluded = true;
                        break;
                    }

                    if (charFrequancyForTargetStr.ContainsKey(s[begin]))
                    {
                        charFrequancyForTargetStr[s[begin]]++;

                        if (charFrequancyForTargetStr[s[begin]] > 0)
                        {
                            counter++;
                        }
                    }
                    begin++;
                }
                end++;
            }
            return isIncluded;
        }
    }
}
