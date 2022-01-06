using System;
using System.Linq;

public class Solution
{
    public static bool IsBadVersion(int version) 
    {
        var badVersion = 1702766719;
        if (version >= badVersion) 
        {
            return true;
        }
        return false;
    }

    public static int FirstBadVersion(int n)
    {
        double start = 0;
        double end = n - 1;
        var nums = Enumerable.Range(1, n);

        int badVersionIndex = 0;
        while (start <= end)
        {
            var middle = (int)((start + end) / 2);
            var middleElement = nums.ElementAt(middle);
            var isbadVersion = IsBadVersion(middleElement);

            if (isbadVersion)
            {
                badVersionIndex = middleElement;
                end = middle - 1;
            }
            else
            {
                start = middle + 1;
            }
        }
        return badVersionIndex;
    }
}