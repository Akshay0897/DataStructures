using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    public static class Longest_Substring_with_At_Least_K_Repeating_Characters
    {
        // getting time limit exeeded in this approach
        public static int LongestSubstring(String s, int k)
        {
            if (String.IsNullOrEmpty(s) || k > s.Length)
            {
                return 0;
            }

            return LongestSubstring(s, 0, s.Length - 1, k);
        }

        // return the length of longest substring T in the range s[start..end]
        private static int LongestSubstring(String s, int start, int end, int k)
        {
            if (end - start + 1 < k)
            {
                return 0; // length of substring s[start..end] is less than k
            }

            int[] map = new int[26]; // letter -> freq
            for (int i = start; i <= end; i++)
            {
                map[s.ElementAt(i) - 'a']++;
            }

            HashSet<char> delimiters = new HashSet<char>(); // set of infrequent letters
            for (int i = start; i <= end; i++)
            {
                char ch = s.ElementAt(i);
                if (0 < map[ch - 'a'] && map[ch - 'a'] < k)
                { 
                    delimiters.Add(ch);
                }
            }

            if (delimiters.Count == 0)
            {
                return end - start + 1; // there's no infrequent letters in current substring
            }

            // split current substring at each delimiter
            int max = 0;      // length of longest substring T in the range s[start..end]
            int left = start; // left end of splitted substring
            for (int right = start; right <= end; right++)
            {
                if (delimiters.Contains(s.ElementAt(right)))
                {
                    max = Math.Max(max, LongestSubstring(s, left, right - 1, k));
                    left = right + 1;
                }
            }

            // Don't forget the last splitted substring after the last delimiter
            max = Math.Max(max, LongestSubstring(s, left, end, k));
            return max;
        }


        // return the length of longest substring T with target number of unique letters
        private static int LongestSubstringWithTargetUniqueLetters(String s, int k, int numUniqueTarget)
        {
            int[] map = new int[26]; // letter -> freq
            int numUnique = 0;   // # of unique letters
            int numAtLeastK = 0; // # of unique letters with occurrence >= k
            int max = 0; // length of longest substring T with target number of unique letters

            // slding window
            // if numUnique <= numUniqueTarget, expand right end, update numUnique & numAtLeastK
            // if numUnique > numUniqueTarget, shrink left end
            int left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                char rChar = s.ElementAt(right); // new rightmost char
                if (map[rChar - 'a'] == 0)
                {
                    numUnique++;
                }
                map[rChar - 'a']++;
                if (map[rChar - 'a'] == k)
                {
                    numAtLeastK++;
                }

                while (numUnique > numUniqueTarget)
                {
                    char lChar = s.ElementAt(left); // leftmost char in current window
                    left++;
                    if (map[lChar - 'a'] == 1)
                    {
                        numUnique--;
                    }
                    if (map[lChar - 'a'] == k)
                    {
                        numAtLeastK--;
                    }
                    map[lChar - 'a']--;
                }

                // now numUnique <= numUniqueTarget
                if (numUnique == numUniqueTarget && numUnique == numAtLeastK)
                {
                    max = Math.Max(max, right - left + 1);
                }
            }

            return max;
        }
    }
}