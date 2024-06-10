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
                    //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                    // 更改数组 nums ，使 nums 的前 k 个元素包含唯一元素，并按照它们最初在 nums 中出现的顺序排列。nums 的其余元素与 nums 的大小不重要。
                    // 其餘元素並不考慮, 直接覆蓋
                    nums[j] = nums[i];
                    j++;
                }
            }
            return j; 
        }
    }
}
