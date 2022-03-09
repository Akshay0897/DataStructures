using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    public static class Longest_K_AtLeast_Unique_Characters_Substring
    {
        public static int GetSubStr(string s, int k)
        {
            Dictionary<char, int> charFrequancyMap = new Dictionary<char, int>();
            int p1 = 0;
            int p2 = 0;
            int ans = 0;

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

                if (charFrequancyMap.Keys.Count < k)
                {
                    while (true)
                    {
                        if (charFrequancyMap[s[p2]] == 1)
                        {
                            charFrequancyMap.Remove(s[p2]);
                        }
                        else
                        {
                            charFrequancyMap[s[p2]]--;
                        }

                        p2++;
                        if (charFrequancyMap.Keys.Count <= k)
                        {
                            break;
                        }
                    }
                }
                ans = Math.Max(ans, p1 - p2 + 1);
                p1++;
            }
            return ans;
        }
    }
}
