using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashMap
{
    public static class ContiguousArray
    {
        public static int LongestContiguousArray(int[] nums) 
        {
            var sum = 0;
            var answer = 0;
            Dictionary<int, int> map = new Dictionary<int, int>() { { 0, -1 } };

            for(int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (num == 1)
                {
                    sum += 1;
                }
                else 
                {
                    sum += -1;
                }

                if (map.ContainsKey(sum))
                {
                    map.TryGetValue(sum, out var sumIndex);
                    if (i - sumIndex > answer) 
                    {
                        answer = i - sumIndex;
                    }
                }
                else 
                { 
                    map.Add(sum, i);
                }
            }

            return answer;
        }
    }
}
