using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BitManipulation
{
    public static class RightMostSetBitMask
    {
        public static string Mask(int num) 
        {
            return Convert.ToString(num & -num, 2);
        }
    }
}
