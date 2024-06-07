using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode02
{
    public class _3_08_1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            
            for (int i = 0; i < nums.Length; i++)
            {
                // 如果數組 nums 中有相同的數, 記錄第二的數的索引 index
                // 因為題目表示只有一組解代表相同的數至多兩個, 而第一個索引會被迴圈先指定到
                dic[nums[i]]= i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int nowTarget = target-nums[i];
                if (dic.ContainsKey(nowTarget) && dic[nowTarget] != i)
                {
                    return new int[] { i, dic[nowTarget] };
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
