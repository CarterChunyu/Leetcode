using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_1_283
    {
        //283
        public static void MoveZeros1(int[] nums)
        {
            // 下一個非0元素的位置
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    j++;
                }
            }
        }

        public static void MoveZero2(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    if (i != j)
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                        j++;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }

        // 直接賦值
        public static void MoveZero3(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    if (i != j)
                    {
                        nums[j] = nums[i];
                        j++;
                    }
                }
            }
            for (int i = j; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
