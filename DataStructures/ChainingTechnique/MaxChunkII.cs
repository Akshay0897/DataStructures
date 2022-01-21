using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.ChainingTechnique
{
    public static class MaxChunkII
    {
        public static int CountMaxChunk(int[] arr)
        {
            var rightMinArr = new int[arr.Length + 1];
            rightMinArr[arr.Length] = int.MaxValue;
            var totalChunk = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                rightMinArr[i] = Math.Min(rightMinArr[i+1], arr[i]);
            }

            // iterate an array and manage the left max
            var leftMax = int.MinValue;

            for (int i = 0; i < arr.Length; i++) 
            {
                leftMax = Math.Max(leftMax, arr[i]);

                if (leftMax <= rightMinArr[i + 1]) 
                {
                    totalChunk++;
                }
            }

            return totalChunk;
        }
    }
}
