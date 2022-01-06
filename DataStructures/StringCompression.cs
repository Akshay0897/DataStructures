using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class StringCompression
    {
        public static int Compress(char[] chars) 
        {
            var len = chars.Length;
            char[] compressedCharArr = new char[] { };
            for(int i =0; i < len; i++) 
            {
                int cnt = 1;
                
                while (i + 1 < len && chars[i] == chars[i+1]) 
                {
                    // Console.WriteLine($"{s[i]} , {s[i+1]}");
                    cnt++;
                    i++;
                }

                if (cnt > 1)
                {
                    compressedCharArr.Append(chars[i]);
                    compressedCharArr.Append((char)cnt);
                }
                else 
                {
                    compressedCharArr.Append(chars[i]);
                }
            }
            Console.WriteLine(new String(compressedCharArr));
            return compressedCharArr.Length;
        }
    }
}
