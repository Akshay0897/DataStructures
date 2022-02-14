using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BitManipulation
{
    // problem link  - https://leetcode.com/problems/single-number-ii/

    public static class SingleNumberIII
    {
        public static int FindSingle(int[] nums) 
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

            foreach (int num in nums) 
            {
                if (keyValuePairs.ContainsKey(num)) 
                {
                    keyValuePairs[num]++;
                }
                else
                {
                    keyValuePairs.Add(num, 1);
                }
            }

            foreach (var keyval in keyValuePairs) 
            {
                if (keyval.Value == 1) 
                {
                    return keyval.Key;
                }
            }

            return -1;
        }
    }
}
