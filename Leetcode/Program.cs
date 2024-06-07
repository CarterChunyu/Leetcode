using System.Data.SqlTypes;

namespace Leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
           for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 3 && j == 0)
                        break;
                    Console.WriteLine($"{i}-{j}");
                }
            }
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