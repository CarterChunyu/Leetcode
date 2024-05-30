using System.Data.SqlTypes;

namespace Leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 2,7,11,13};
            int[] nums2 = { 1, 2,3 };
            int m = 3;
            int n = 3;
            new _2_7_167().TwoSum3(nums1, 9);
        }


        public static int RemoveElement2(int[] nums, int val) // 羽
        {
            int i = 0;
            int j = nums.Length;

            while (i < j)
            {
                if (nums[i] == val)
                {
                    j--;
                    nums[i] = nums[j];
                }
                else
                    i++;
            }
            return j;
        }
    }
}