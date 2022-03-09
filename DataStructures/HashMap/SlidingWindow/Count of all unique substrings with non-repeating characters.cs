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
        public static int DistinctSubstring(string s, int k) 
        {
            var p1 = 0;
            var p2 = 0;
            var result = 0;
            Dictionary<char, int> charFrequancyMap = new Dictionary<char, int>();
            var distinctChars = 0;

            while (p1 < s.Length)
            {
                if (!charFrequancyMap.ContainsKey(s[p1]))
                {
                    charFrequancyMap.Add(s[p1], 1);
                    distinctChars++;
                }
                else
                {
                    charFrequancyMap[s[p1]]++;
                }

                while (distinctChars > charFrequancyMap.Keys.Count)
                {
                    charFrequancyMap[s[p2]]--;
                    if (charFrequancyMap.TryGetValue(s[p2], out var leftPointerValue) && leftPointerValue == 0) 
                    {
                        charFrequancyMap.Remove(s[p2]);
                        distinctChars--;
                    }
                    p2++;
                }
                result += p1 - p2 + 1;
                p1++;
            }
            return result;
        }

        public static int DistinctSubstringWithExactK(int[] s, int k) 
        {
            return SubarraysWithKDistinct(s , k) - SubarraysWithKDistinct(s , k - 1);
        }

        public static int SubarraysWithKDistinct(int[] nums, int k)
        {
            var p1 = 0;
            var p2 = 0;
            var result = 0;
            Dictionary<int, int> charFrequancyMap = new Dictionary<int, int>();
            var distinctChars = 0;

            while (p1 < nums.Length)
            {
                if (!charFrequancyMap.ContainsKey(nums[p1]))
                {
                    charFrequancyMap.Add(nums[p1], 1);
                    distinctChars++;
                }
                else
                {
                    charFrequancyMap[nums[p1]]++;
                }

                while (distinctChars > k)
                {
                    charFrequancyMap[nums[p2]]--;
                    if (charFrequancyMap.TryGetValue(nums[p2], out var leftPointerValue) && leftPointerValue == 0)
                    {
                        charFrequancyMap.Remove(nums[p2]);
                        distinctChars--;
                    }
                    p2++;
                }

                Console.WriteLine($"{p1} {p2}");

                result += p1 - p2 + 1;
                p1++;
            }
            return result;
        }

        public static int SubstringWithKDistinctChars(string s, int K)
        {
            char[] A = s.ToCharArray();
            int left = 0, right = 0;
            Dictionary<char, int> numCount = new Dictionary<char, int>();
            int distinct = 0;
            int result = 0;
            int prefix = 0;
            while (right < A.Length)
            {
                if (numCount.ContainsKey(A[right]) && numCount[A[right]] != 0)
                    numCount[A[right]]++;
                else
                {
                    distinct++;
                    numCount[A[right]] = 1;
                }

                if (distinct > K) //increment left pointer
                {
                    numCount[A[left]]--;
                    prefix = 0; // resetting the prefix since previous elements can not be used in next subset to keep k distinct elements
                    distinct--;
                    left++;
                }
                while (numCount[A[left]] > 1)
                {
                    numCount[A[left]]--;
                    left++;
                    prefix++;
                }
                if (distinct == K)
                    result += 1 + prefix;

                right++;
            }

            return result;

            // Hey thanks for the explanation and the colour table which really helped me to get this!
            // For those who still do not get how it works, let me try and help.

            //The Main idea of this approach is to keep track of the number of subarrays with the same number of distinct integers. (we store it in our variable prefix)
            //These subarrays are POTENTIAL candidates of having K distinct integers, they are not actual candidates yet. (not until we have encountered K distinct integers)
            //We only add this prefix to our res variable(which represents the no.of subarrays with K distinct integers) when we have actually encountered K distinct integers.

            //The Algorithm:

            //We start our left and right pointer at index = 0.
            //We increment count of the number at the right pointer into a hashmap / array(which will store the counts of all integers that exist in our window.)
            //The Loop begins here:

            //We shift our right pointer by 1.If the right pointer has exceeded the length of the array, then we exit our loop and return res.
            //We increment the count of the number at the right pointer into the hashmap.
            //We check the number at our left pointer. If this number has no duplicates in our current window(its count is 1 in the hashmap), head to step 6) .
            //If it has duplicates, head to step 5) .
            //We will shrink our window to the minimum possible size while maintaining the same number of distinct integers.
            //We do this by shifting our left pointer by 1.Also, we decrement its count in the hashmap and add 1 to our prefix variable.
            //Then, repeat step 4) .
            //If we have encountered exactly K distinct integers, we will add prefix + 1 to our res variable.
            //(because that many POTENTIAL candidates have now become ACTUAL/ SUCCESSFUL candidates)
            //Else if we have encountered > K distinct integers, we will shift our left pointer by 1 so that we maintain K distinct integers in the window. On top of that, we also reset prefix to 0.
            //(resetting of prefix to 0 is necessary because now every POTENTIAL candidate we kept record of previously can no longer be a potential candidate
            //in this new window.This is because those candidates will all contain > K distinct integers in the new window)
            //Else we do not need to do anything.
            //We then go back to step 3) and repeat from there.
            //===================================================================================================================
            //Hopefully I did not miss anything out while detailing the algorithm... Below I follow through some of the key steps in the algorithm using the above example.

            //Using the above example, the sequence [5,7,5,2,3,3,4,1,5,2,7,4,6,2,3,8,4,5,7] and k = 7. We use D to denote distinct integers encountered so far.

            //We increment count of number at right pointer = 5 in our hashmap. We check whether we have duplicates of number at left pointer = 5. Since no, we just shift right pointer.
            //D < k, do nothing.
            //We increment count of number at right pointer = 7 in our hashmap. We check whether we have duplicates of number at left pointer = 5. Since no, we just shift right pointer.
            //D < k, do nothing.
            //We increment count of number at right pointer = 5 in our hashmap. We check whether we have duplicates of number at left pointer = 5.
            //Since we have, we shift left pointer by 1 and add 1 to prefix. It now points to 7. We decrement count of 5 in hashmap by 1. Then we shift right pointer.
            //D < k, do nothing.
            //We increment count of number at right pointer = 2 in our hashmap. We check whether we have duplicates of number at left pointer = 7. Since no, we just shift right pointer.
            //D < k, do nothing.
            //Keep performing the above steps. We will skip to when we encounter 6, where it gets interesting.
            //We increment count of number at right pointer = 6 in our hashmap. We check whether we have duplicates of number at left pointer = 3. Since no, we just shift right pointer.
            //Since D == k, we add prefix + 1 to res. Prefix at this point = 5, hence res += 6.
            //Keep performing the above steps. We will skip to when we encounter 8, where it gets interesting.
            //We increment count of number at right pointer = 8 in our hashmap. We check whether we have duplicates of number at left pointer = 1. Since no, we just shift right pointer.
            //Since D > k, we reset prefix to 0 and shift left pointer by 1 to point to 5.
            //Hope this helped in any way :D
        }
    }
}
