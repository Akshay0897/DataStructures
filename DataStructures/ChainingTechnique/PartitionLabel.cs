using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.ChainingTechnique
{
    public static class PartitionLabel
    {
        public static IList<int> GetTotalPartition(string s) 
        {
            var freqArr = GetFrequancyArray(s);
            var max = 0;
            var prev = -1;
            var resultArr = new List<int>{ };

            foreach (var item in freqArr) 
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < s.Length; i++) 
            {
                freqArr.TryGetValue(s[i], out var val);
                max = Math.Max(max, val);
                //Console.WriteLine(max);

                if (max == i) 
                {
                    resultArr.Add(max - prev);
                    prev = i;
                }
            }

            return resultArr;
        }

        private static Dictionary<char, int> GetFrequancyArray(string str) 
        {
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++) 
            {
                if (!dict.ContainsKey(str[i])) 
                {
                    dict.Add(str[i], str.LastIndexOf(str[i]));
                }
            }

            return dict;
        }
    }
}
