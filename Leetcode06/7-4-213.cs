using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode06
{
    public class _7_4_213
    {
        // nums=[2,7,9,3,1]
        // 由於環形數組, 首尾相連, 也就是第一間房子和最後一間房子相鄰, 那麼會有如下三種方案
        // 1. 首尾都不偷
        // 2. 偷首不偷尾
        // 3. 偷尾不偷首

        // 那麼通過上述的分析就環形數組轉成了線性數組處理, 和打家劫舍1處理方式一樣
        // 綜上考慮,1方案少偷了一間房子, 偷取的金額肯定是最小的
        // 只須考慮2, 3方案, 在 2, 3方案中取一個最優解, 能偷到最高的金額

        public int Rob(int[] nums)
        {
            if (nums.Length==1)
                return nums[0];

            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            int headMaxMoney = RobRecursion(0,nums.Length-2);
            int tailMaxMoney = RobRecursion(1, nums.Length - 1);

            return Math.Max(headMaxMoney, tailMaxMoney);

            // 返回 nums[start...end] 能搶到的最大值
            int RobRecursion(int start,int end)
            {
                if (start > end)
                    return 0;
                int maxMoney = 0;
                for (int i = start; i <= end ; i++)
                {
                    int money = nums[i] + RobRecursion(i + 2, end);
                    maxMoney = Math.Max(maxMoney, money);
                }
                return maxMoney;
            }
        }


        public int Rob2(int[] nums)
        {
            if(nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            int length = nums.Length;
            int[] memo = new int[length];

            for (int i = 0; i < length; i++)
            {
                memo[i] = -1;
            }
            int money1 = RobRecursion(0,length-2);
            for (int i = 0; i < length; i++)
            {
                memo[i] = -1;
            }
            int money2 = RobRecursion(1,length-1);

            return Math.Max(money1, money2);

            int RobRecursion(int start, int end)
            {
                if (start > end)
                    return 0;
                if (memo[start] != -1)
                    return memo[start];
                int maxMoney = 0;                
                for (int i = start; i <=end ; i++)
                {
                    int money = nums[i] + RobRecursion(i + 2, end);
                    maxMoney = Math.Max(money, maxMoney);
                }
                // ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                memo[start] = maxMoney;
                return maxMoney;
            }
        }

        public int Rob3(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            int n = nums.Length;

            int[] dp = new int[n];

            // 偷首不偷尾

            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i <= n-2 ; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }
            int max1 = dp[n - 2];

            // 偷尾不偷首
            dp[1] = nums[1];
            dp[2] = Math.Max(nums[1], nums[2]);

            for (int i = 3; i <= nums.Length-1; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }
            int max2 = dp[n-1];
            return Math.Max(max1, max2);
        }
    }
}
