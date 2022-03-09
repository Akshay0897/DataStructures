//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataStructures.HashMap.SlidingWindow
//{
//    // problem link - https://leetcode.com/problems/substring-with-concatenation-of-all-words/description/

//    public static class Substring_with_Concatenation_of_All_Words
//    {
//        private static Dictionary<char, int> BuildCharFrequeancy(string s)
//        {
//            Dictionary<char, int> charFrequancyMap = new Dictionary<char, int>();

//            foreach (var item in s)
//            {
//                if (!charFrequancyMap.ContainsKey(item))
//                {
//                    charFrequancyMap.Add(item, 1);
//                }
//                else
//                {
//                    charFrequancyMap[item]++;
//                }
//            }
//            return charFrequancyMap;
//        }


//        public static IList<int> FindSubstring(string s, string[] words)
//        {
//            var resultList = new List<int>() { };

//            var begin = 0;
//            var end = 0;
//            var charFrequancyForTargetStr = BuildCharFrequeancy(p);
//            var counter = charFrequancyForTargetStr.Count;
//            var targetWordLen = p.Length;

//            if (s.Length == 0 || p.Length > s.Length)
//            {
//                return resultList;
//            }

//            while (end < s.Length)
//            {
//                // maintain the counter here
//                if (charFrequancyForTargetStr.ContainsKey(s[end]))
//                {
//                    charFrequancyForTargetStr[s[end]]--;
//                    if (charFrequancyForTargetStr.TryGetValue(s[end], out var val) && val == 0)
//                    {
//                        counter--;
//                    }
//                }
//                while (counter == 0)
//                {
//                    Console.WriteLine($"entered in count zero zone {end} {begin}");
//                    // decrease the size of the windows as long as we have all the required chars with sufficient freq in our source string 
//                    if (end - begin + 1 == targetWordLen)
//                    {
//                        resultList.Add(begin);
//                    }

//                    if (charFrequancyForTargetStr.ContainsKey(s[begin]))
//                    {
//                        charFrequancyForTargetStr[s[begin]]++;

//                        if (charFrequancyForTargetStr[s[begin]] > 0)
//                        {
//                            counter++;
//                        }
//                    }
//                    begin++;
//                }
//                end++;
//            }
//            PrintList(resultList);
//            return resultList;
//        }
//        private static void PrintList(IList<int> list)
//        {
//            foreach (int i in list)
//            {
//                Console.Write(i);
//            }
//        }
//    }
//}
