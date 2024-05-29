using System.Data.SqlTypes;

namespace Leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 1, 3, 3, 3};
            int reuslt= RemoveElement2(nums, 3);

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