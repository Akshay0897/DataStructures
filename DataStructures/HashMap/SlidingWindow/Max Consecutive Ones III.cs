using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link - https://leetcode.com/problems/max-consecutive-ones-iii/
    public static class Max_Consecutive_Ones_III
    {
        public static int LongestOnes(int[] nums, int k)
        {
            // someone you loved
            Dictionary<int, int> charFrequancyMap = new Dictionary<int, int>();
            int p1 = 0;
            int p2 = 0;
            int ans = 0;
            int maxCount = int.MinValue;

            while (p1 < nums.Length)
            {
                if (!charFrequancyMap.ContainsKey(nums[p1]))
                {
                    charFrequancyMap.Add(nums[p1], 1);
                }
                else
                {
                    charFrequancyMap[nums[p1]]++;
                }

                charFrequancyMap.TryGetValue(1, out var oneFreq);
                maxCount = Math.Max(maxCount, oneFreq);

                while (p1 - p2 + 1 - maxCount > k)
                {
                    if (charFrequancyMap[nums[p2]] == 1)
                    {
                        charFrequancyMap.Remove(nums[p2]);
                    }
                    else
                    {
                        charFrequancyMap[nums[p2]]--;
                    }
                    p2++;
                }

                ans = Math.Max(ans, p1 - p2 + 1);
                p1++;
            }
            return ans;
        }

        public static int MaxConsecutiveAnswers(string answerKey, int k)
        {
            var s = answerKey.ToCharArray();
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
