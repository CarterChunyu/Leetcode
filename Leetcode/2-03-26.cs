using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_3_26
    {
        public int RemoveDuplicates(int[] nums)
        {
            // 存放不重複元素的位置
            int j = 1;

            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[j] = nums[i];
                    j++;
                }
            }
            return j; 
        }
    }
}
