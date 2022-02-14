using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.MergeIntervalsPattern
{
    // problem link -> https://leetcode.com/problems/maximum-swap/

    public static class Maximum_Swap
    {
        public static int MaximumSwap(int num)
        {
            var charArr = num.ToString().ToCharArray();
            var arr = new int[10];

            // prepare for last index
            for (int i = 0; i < charArr.Length; i++) 
            {
                int digit = charArr[i] - '0';
                arr[digit] = i;
            }

            bool flag = false;
            // find swap pos
            for (int i = 0; i < charArr.Length; i++) 
            {
                int digit = charArr[i] - '0';
                for (int j = 9; j > digit; j--) 
                {
                    if (i < arr[j]) 
                    {
                        swap(charArr, i, arr[j]);
                        flag = true;
                        break;
                    }
                }
                
                if (flag == true) 
                {
                    break;
                }
            }

            var resStr = "";
            foreach (var item in charArr)
            {
                resStr += item;
            }
            Console.WriteLine(resStr);
            return int.Parse(resStr.ToString());
        }

        private static void swap(char[] charArr, int i, int v)
        {
            var temp = charArr[i];
            charArr[i] = charArr[v];
            charArr[v] = temp;
        }
    }
}
