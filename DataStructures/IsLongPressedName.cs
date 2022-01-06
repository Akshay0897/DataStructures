using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class IsLongPressedName
    {
        public static bool IsLongPressed(string name, string typed)
        {
            if(name.Length > typed.Length) return false;
            int i = 0;
            int j = 0;

            while (i < name.Length && j < typed.Length) 
            {
                if (name[i] == typed[j])
                {
                    i++;
                    j++;
                }
                else if (i > 0 && name[i - 1] == typed[j])
                {
                    j++;
                }
                else 
                {
                    return false;
                }
            }

            while (j < typed.Length) 
            {
                if(name[i - 1] != typed[j]) return false;
                j++;
            }

            return i < name.Length ? false : true;
        }
    }
}
