using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_4_75
    {
        public void SortColors1(int[] nums)
        {
            int zeroIndex = 0;
            int twoIndex = nums.Length;

            int i = 0;

            while (i < twoIndex)
            {
                if (nums[i] == 0)
                {
                    int temp = nums[zeroIndex];
                    nums[zeroIndex] = nums[i];
                    nums[i] = temp;
                    zeroIndex++;
                    i++;
                }
                else if (nums[i] == 1)
                {
                    i++;
                }
                else
                {
                    twoIndex--;
                    int temp = nums[twoIndex];
                    nums[twoIndex] = nums[i];
                    nums[i] = temp;
                }
            }
        }

        public void SortColors2(int[] nums)
        {
            int[] count = { 0, 0, 0 };
            for (int i = 0; i < nums.Length; i++)
            {
                //int num = nums[i];
                //count[num]++;
                count[nums[i]]++;
            }

            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    nums[index] = i;
                    index++;
                }
            }
        }
    }
}
