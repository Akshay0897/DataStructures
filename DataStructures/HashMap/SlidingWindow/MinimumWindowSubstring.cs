using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link -> https://leetcode.com/problems/minimum-window-substring/description/

        // O(n + K) solution

        //    class Solution :
        //    def minWindow(self, s: str, t: str) -> str:
        //        if t == "": return ""
        
        //        countT, window = {}, { }
        //for c in t:

        //    countT[c] = 1 + countT.get(c, 0)


        //have, need = 0, len(countT)

        //res, resLen = [-1, -1], float("infinity")

        //l = 0
        //        for r in range(len(s)):
        //            c = s[r]
        //            window[c] = 1 + window.get(c, 0)


        //            if c in countT and window[c] == countT[c]:
        //                have += 1


        //            while have == need:
        //                # update our result
        //                if (r - l + 1) < resLen:
        //                    res = [l, r]
        //                    resLen = (r - l + 1)
        //                # pop from the left of our window
        //                window[s[l]] -= 1
        //                if s[l] in countT and window[s[l]] < countT[s[l]]:
        //                    have -= 1
        //                l += 1
        //        l, r = res
        //        return s[l: r + 1] if resLen != float("infinity") else ""

    public static class MinimumWindowSubstring
    {
        public static string MinWindow(string s, string t)
        {
            var minWindowStr = "";
            var left = 0;
            var right = 0;
            var ans = Int32.MaxValue;
            var ansStr = "";
            var flag = false;

            while (right < s.Length)
            {
                minWindowStr += s[right];
                // Console.WriteLine(minWindowStr);
                while (IsAllIncluded(minWindowStr, t)) 
                {
                    if (minWindowStr.Length < ans)
                    {
                        ansStr = minWindowStr;
                    }
                    ans = Math.Min(ans, right - left + 1);
                    
                    // remove first char
                    minWindowStr = minWindowStr.Substring(1);
                    left++;
                    flag = true;
                }
                right++;
            }
            return flag ? ansStr : "";
        }

        private static bool IsAllIncluded(string input, string target) 
        {
            var isAllIncluded = true;
            
            // this can be avoided
            var targetCharArray = BuildCharFrequeancy(target);
            
            var inputCharArray = BuildCharFrequeancy(input);

            foreach (var item in targetCharArray) 
            {
                if (inputCharArray.TryGetValue(item.Key, out var value))
                {
                    isAllIncluded = isAllIncluded && value >= item.Value;
                }
                else 
                {
                    isAllIncluded &= false;
                }
            }
            return isAllIncluded;
        }

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
    }

    public static class SolutionMin
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

        public static string MinWindow(string s, string t)
        {
            var begin = 0;
            var end = 0;
            var charFrequancyForTargetStr = BuildCharFrequeancy(t);
            var counter = charFrequancyForTargetStr.Count;
            var resultlLen = int.MaxValue;
            var minWindow = "";

            while (end < s.Length) 
            {
                // maintain the counter here
                if (charFrequancyForTargetStr.ContainsKey(s[end])) 
                {
                    charFrequancyForTargetStr[s[end]]--;
                    if (charFrequancyForTargetStr.TryGetValue(s[end], out var val) && val == 0)
                    {
                        counter--;
                    }
                }
                while (counter == 0) 
                {
                    Console.WriteLine($"entered in count zero zone {end} {begin}");
                    // decrease the size of the windows as long as we have all the required chars with sufficient freq in our source string 
                    if (resultlLen > end - begin + 1) 
                    {
                        minWindow = s.Substring(begin, end - begin + 1);
                        resultlLen = end - begin + 1;
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
            return minWindow;
        }
    }
}
