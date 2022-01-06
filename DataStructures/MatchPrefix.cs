using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class MatchPrefix
    {
        public static string ReplaceWordsWithPrefix(string[] prefixes, string sentence)
        {
            string[] tokens = sentence.Split(' ');
            foreach (var token in tokens.Select((value, index) => new { index, value }))
            {
                var currentToken = token.value;
                foreach (var prefix in prefixes.Select((value, index) => new { index, value })) 
                {
                    if (currentToken.StartsWith(prefix.value) && prefix.value.Length < currentToken.Length) 
                    {
                        currentToken = prefix.value;
                    }
                }
                tokens[token.index] = currentToken;
            }
            return string.Join(" ", tokens);
        }
        
        public static IList<string> WordSubsets(string[] A, string[] B)
        {
            IList<string> words = new List<string>();
            int[] word2CharFrequancy = new int[26];

            // bulding frequancy counter for word 2
            //e.g. ['c', 'cu', 'ccccc']
            // [0, 0, 4] since we have max 4 c
            foreach (var item in B)
            {
                var itemFrequancy = GetCharFrequancy(item);
                for (int i = 0; i < 26; i++) 
                {
                    word2CharFrequancy[i] = Math.Max(itemFrequancy[i], word2CharFrequancy[i]);
                }
            }

            // builing the frequancy counter for first word
            foreach (var item in A) 
            {
                var isUniversalWord = true;
                var itemFrequancy = GetCharFrequancy(item);
                for (int i = 0; i < 26; i++)
                {
                    if (itemFrequancy[i] < word2CharFrequancy[i]) 
                    {
                        isUniversalWord = false;
                    }
                }

                if (isUniversalWord) { words.Add(item); }
            }
                
            Console.WriteLine($"{String.Join(" ", words)}");
            return words;
        }
        
        public static int[] GetCharFrequancy(string s) 
        {
            int[] charArr = new int[] { };
            foreach (var c in s) 
            {
                if (charArr.Contains(c))
                {
                    charArr[c]++;
                }
                else 
                {
                    charArr[c] = 0;
                }
            }

            foreach (var cnt in charArr) 
            {
                Console.WriteLine(cnt);
            }
            return charArr;
        }

        public static int LongestPalindrome(string s)
        {
            char[] charArr = s.ToCharArray();
            int[] count = new int[128];

            var cnt = 0;

            foreach (var item in charArr) 
            {
                count[item]++;
            }

            foreach (var item in count) 
            {
                Console.WriteLine(item);
            }

            foreach (var item in count) 
            {
                cnt += item / 2 * 2;

                // this is to check if we already have one letter or not
                if (cnt % 2 == 0 && item % 2 == 1) 
                {
                    cnt++;
                }
            }
            return cnt;
        }
    }
}
