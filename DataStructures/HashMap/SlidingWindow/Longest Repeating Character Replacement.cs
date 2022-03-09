using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link - https://leetcode.com/problems/longest-repeating-character-replacement/

    public static class Longest_Repeating_Character_Replacement
    {
        public static int CharacterReplacement(string s, int k)
        {
            Dictionary<char, int> charFrequancyMap = new Dictionary<char, int>();
            int p1 = 0;
            int p2 = 0;
            int ans = 0;
            int maxCount = int.MinValue;

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

                maxCount = Math.Max(maxCount, charFrequancyMap[s[p1]]);

                // p1 - p2 + 1 - maxCount > k
                // this condition basically checks if we have more than K char which can be replaced
                // this is the only thing which make this medium level quesiton o/w it's really straight forward

                while (p1 - p2 + 1 - maxCount > k)
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
                }
                
                ans = Math.Max(ans, p1 - p2 + 1);
                p1++;
            }
            return ans;
        }
    }
}
