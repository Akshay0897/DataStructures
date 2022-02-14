using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.MergeIntervalsPattern
{
    // problem link - https://leetcode.com/problems/minimum-length-of-string-after-deleting-similar-ends/

    public static class Minimum_Length_of_String_After_Deleting_Similar_Ends
    {
        public static int MinimumLength(string s)
        {
            var left = 0;
            var right = s.Length - 1;

            while (left < right)
            {
                var leftMostChar = s[left];
                var rightMostChar = s[right];

                if (leftMostChar == rightMostChar)
                {
                    while (left < s.Length - 1 && s[left] == leftMostChar) 
                    {
                        left++;
                    }

                    while (right > 0 && s[right] == rightMostChar) 
                    {
                        right--;
                    }
                }
                else 
                {
                    break;
                }
            }

            if (left > right)
            {
                return 0;
            }

            return right - left + 1;
        }
    }
}
