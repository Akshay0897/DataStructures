using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class FindPeekElement
    {
        public static int BinarySearchForPeakElement(int[] nums)
        {
            var start = 0;
            var end = nums.Length - 1;
            //if (nums.Length == 1)
            //{
            //    return start;
            //}
            while (start <= end)
            {
                var middle = ((start + end) / 2);

                // it's given that it does ecist so we will always have left and right element
                Console.WriteLine($"middle {middle} start {start} end {end}");

                var (left, ifLeftEixsts) = (nums.ElementAtOrDefault(middle - 1), TryGet(out var elemLeft, nums, middle - 1));
                var (right, ifRightEixsts) = (nums.ElementAtOrDefault(middle + 1), TryGet(out var elemRight, nums, middle + 1));

                if (IsPeakElement(nums[middle], (left, ifLeftEixsts), (right, ifRightEixsts))) 
                {
                    return middle;
                }
                else if (ifLeftEixsts && nums[middle] < left)
                {
                    end = middle - 1;
                }
                else if (ifRightEixsts && nums[middle] < right)
                {
                    start = middle + 1;
                }
            }
            return -1;
        }

        private static bool TryGet(out int element, int[] nums, int index) 
        {
            try
            {
                element = nums[index];
                return true;
            }
            catch (IndexOutOfRangeException exception) 
            {
                element = -1;
                return false;
            };
        }

        private static bool IsPeakElement(int middle, (int left, bool ifLeftEixsts) leftNode, (int right, bool ifRightEixsts) rightNode)
        {
            Console.WriteLine($"{middle} {leftNode} {rightNode}");
            if (leftNode.ifLeftEixsts && rightNode.ifRightEixsts)
            {
                return (middle > leftNode.left && middle > rightNode.right);
            }
            else if (leftNode.ifLeftEixsts && !rightNode.ifRightEixsts)
            {
                return (middle > leftNode.left);
            }
            else if (!leftNode.ifLeftEixsts && rightNode.ifRightEixsts)
            {
                return (middle > rightNode.right);
            }
            else 
            {
                return true;
            }
        }
    }
}
