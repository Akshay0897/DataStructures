using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.ChainingTechnique
{
    // maintian the list of right mind and left max approach
    // also the candidate for
    // so we are not allowed to use division operation itself

    public static class ProductOfAnArrayItself
    {
        public static int[] ProductArr(int[] nums)
        {
            int[] rightMinArr = new int[nums.Length];
            int[] res = new int[nums.Length];

            var product = 1;

            for (int i = nums.Length - 1; i >= 0; i--) 
            {
                product = product * nums[i];
                rightMinArr[i] = product;   
            }

            //PrintArr(rightMinArr);

            product = 1;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                var leftProduct = product;
                var rightProduct = rightMinArr[i+1];

                res[i] = leftProduct * rightProduct;

                product *= nums[i];
            }

            res[nums.Length - 1] = product;

            PrintArr(res);

            return res;
        }

        private static void PrintArr(int[] arr) 
        {
            foreach (var element in arr) 
            {
                Console.WriteLine(element);
            }
        }

       
    }
}
