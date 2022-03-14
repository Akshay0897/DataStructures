using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap.SlidingWindow
{
    // problem link - https://leetcode.com/problems/minimum-number-of-flips-to-make-the-binary-string-alternating/
    public static class Minimum_Number_of_Flips_to_Make_the_Binary_String_Alternating
    {
        public static int MinFlips(string s)
        {
            //var diff1 = 0;
            //var diff2 = 0;
            //var left = 0;
            //var windowLength = s.Length;
            //var res = s.Length;
            //var alt1 = "";
            //var alt2 = "";

            //s += s;
            //// first prepare the alternating string so that we can compare the origanal string and calculate the diff.
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        alt1 += "0";
            //        alt2 += "1";
            //    }
            //    else
            //    {
            //        alt1 += "1";
            //        alt2 += "0";
            //    }
            //}

            //for (var right = 0; right < s.Length; right++)
            //{
            //    if (s[right] != alt1[right])
            //    {
            //        diff1 += 1;
            //    }
            //    if (s[right] != alt2[right])
            //    {
            //        diff2 += 1;
            //    }

            //    if (right - left + 1 > windowLength)
            //    {
            //        if (s[left] != alt1[left])
            //        {
            //            diff1 -= 1;
            //        }
            //        if (s[left] != alt2[left])
            //        {
            //            diff2 -= 1;
            //        }
            //        left++;
            //    }

            //    if (right - left + 1 == windowLength)
            //    {
            //        res = SmallestAmong(res, diff1, diff2);
            //    }
            //}
            //return res;

            var windowLength = s.Length;
            var res = s.Length;

            var diff1 = 0;
            var diff2 = 0;

            for (int i = 0; i < 2 * windowLength; i++)
            {
                char characterInString = s[i % windowLength];//current character
                char characterInStringStartingWith0 = i % 2 == 0 ? '0' : '1';//calculate character in 01010101..... at i
                char characterInStringStartingWith1 = i % 2 == 0 ? '1' : '0';//calculate character in 10101010..... at i

                if (characterInStringStartingWith0 != characterInString) diff1++;//doesn't match means we need to flip
                if (characterInStringStartingWith1 != characterInString) diff2++;//doesn't match means we need to flip

                if (i >= windowLength)
                {    
                    //valid window
                    int windowStart = i - windowLength;//leftmost element of the window
                    char characterInStringStartingWith0AtWindowStart = windowStart % 2 == 0 ? '0' : '1';//calculate character in 01010101..... at window start
                    char characterInStringStartingWith1AtWindowStart = windowStart % 2 == 0 ? '1' : '0';//calculate character in 10101010..... at window start

                    if (characterInStringStartingWith0AtWindowStart != s[windowStart]) diff1--;//doesn't match means we flipped this before, subtract 1
                    if (characterInStringStartingWith1AtWindowStart != s[windowStart]) diff2--;//doesn't match means we flipped this before, subtract 1

                    //calculate min 
                    res = Math.Min(res, Math.Min(diff1, diff2));
                }
            }
            return res;
        }

        private static int SmallestAmong(int a, int b, int c) 
        {
            if (a <= b && a <= c)
                return a;

            else if (b <= a && b <= c)
                return b;

            else
                return c;
        }
    }
}
