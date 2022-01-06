using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class SmallestSubArray
    {
        public static int FindMinLengthUnsortedSubarray(int[] nums) 
        {
            int low = 0, high = nums.Length - 1;
            
            while (low < high && nums[low] < nums[low + 1]) 
            {
                low++;
            }

            // array is already sorted
            if (low == nums.Length - 1) return 0;

            while (high > 0 && nums[high] >= nums[high - 1])
            {
                high--;
            }

            var subArray = nums.Skip(low).Take(high - low + 1).Select(eachElement => eachElement).ToArray();

            if (subArray.Length == 0) 
            {
                return 0;
            }

            Console.WriteLine($"SubArray is ");
            foreach (var item in subArray) 
            {
                Console.WriteLine(item);
            }

            var maxInSubArray = subArray.Max();
            var minInSubArray = subArray.Min();

            Console.WriteLine($"low: {subArray.Length} and high: {high}");

            while (low > 0 && nums[low-1] > minInSubArray) 
            {
                low--;
            }

            while (high < nums.Length -1 && nums[high + 1] < maxInSubArray)
            {
                high++;
            }

            Console.WriteLine($"low: {low} and high: {high}");

            if(low == high) return 0;

            return high - low + 1;
        }

        public static bool RemoveBackSpace(string s, string t) 
        {
            int index1 = s.Length - 1; 
            int index2 = t.Length - 1;

            while (index1 >= 0 || index2 >= 0)
            {
                int i1 = GetNextValidCharacter(s, index1);
                int i2 = GetNextValidCharacter(t, index2);

                if (i1 < 0 && i2 < 0) return true;

                if (i1 < 0 || i2 < 0) return false;

                Console.WriteLine($"{i1} {i2}");

                if (s[i1] != t[i2]) return false;

                index1 = i1 - 1;
                index2 = i2 - 1;
            }

            return true;
        }

        public static int GetNextValidCharacter(string s, int index) 
        {
            int backSpaceCnt = 0;
            while (index >= 0) 
            {
                if (s[index] == '#') backSpaceCnt++;
                else if (backSpaceCnt > 0) backSpaceCnt--;
                else break;

                index--;
            }

            return index;
        }
    }
}
