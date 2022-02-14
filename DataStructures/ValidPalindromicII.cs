using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    // problem link - https://leetcode.com/problems/valid-palindrome-ii/

    public static class ValidPalindromicII
    {
        public static bool IsValidPalindrom(string s) 
        {
            var left = 0;
            var right = s.Length - 1;

            while (left < right && s[left] == s[right]) 
            {
                left++;
                right--;
            }

            Debugger.Launch();

            if (left > right) 
            {
                return true;
            }

            var stringWithoutLeft = s.Substring(left, right - left);
            var stringWithoutRight = s.Substring(left + 1, right - left);

            if (IsPalim(stringWithoutLeft) || IsPalim(stringWithoutRight)) 
            {
                return true;
            }

            return false;    
        }

        public static bool IsPalim(string inputStr) 
        {
            var left = 0;
            var right = inputStr.Length - 1;

            while (left < right) 
            {
                if (inputStr[left] == inputStr[right])
                {
                    left++;
                    right--;
                }
                else 
                {
                    return false;
                }
            }

            return true;
        }
    }
}
