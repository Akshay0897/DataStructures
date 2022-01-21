using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.ChainingTechnique
{
    public static class MaxChunkI
    {
        public static int CountMaxChunk(int[] arr) 
        {
            int count = 0;
            int max = 0;

            for (int i = 0; i < arr.Length; i++) 
            {
                max = Math.Max(max, arr[i]);
                if (max == i) 
                {
                    count++;
                }
            }

            return count;
        }
    }
}
