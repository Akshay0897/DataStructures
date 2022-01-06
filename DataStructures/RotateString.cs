using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class RotateString
    {
        public static bool IsPossible(string s, string goal) 
        {
            char[] firstStrArr = new char[s.Length];
            char[] goalStrArr = new char[goal.Length];
            
            if (s.Length != goal.Length)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                firstStrArr[i] = s[i];
                goalStrArr[i] = goal[i];
            }

            Console.WriteLine("string after converted to input : {0}", new string(firstStrArr));
            Console.WriteLine("string after converted to goa : {0}", new string(goalStrArr));

            for (int i = 0; i < firstStrArr.Length; i++) 
            {
                firstStrArr = Rotate(firstStrArr, 1);
                Console.WriteLine("string after one rotation : {0}", new string(firstStrArr));
                if (new string(firstStrArr).Equals(new string(goalStrArr))) 
                {
                    return true;
                }
            }

            return false;
        }

        public static char[] Rotate(char[] a, int k)
        {
            k = k % a.Length;
            if (k < 0)
            {
                k += a.Length;
            }

            Reverse(a, 0, a.Length - k - 1);
            Reverse(a, a.Length - k, a.Length - 1);
            Reverse(a, 0, a.Length - 1);

            return a;
        }

        public static char[] Reverse(char[] arr, int li, int ri) 
        {
            while (li < ri)
            {
                char temp = arr[li];
                arr[li] = arr[ri];
                arr[ri] = temp;

                li++;
                ri--;
            }

            return arr;
        }
    }
}
