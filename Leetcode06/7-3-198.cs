using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode06
{
    public class _7_3_198
    {

        // nums = [2,7,9,3,1]
        // 避免觸動警報, 間隔搶, 暴力枚舉所有位置的搶劫方案, 從中選取得到一個金額最高的方案
        // 位置一 : nums = [2,7,9,3,1] [2,9,1] = 12
        public int Rob(int[] nums)
        {
            return RobRecursion(0);

            int RobRecursion(int start)
            {
                if (start >= nums.Length)
                    return 0;
                int maxMoney = 0;
                for (int i = start; i < nums.Length ; i++)
                {
                    int money = nums[i] + RobRecursion(i + 2);
                    maxMoney = Math.Max(maxMoney, money);
                }
                return maxMoney;
            }
        }

        public int Rob1(int[] nums)
        {
            int[] memo = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                memo[i] = -1;
            }

            return RobRecursion(0);

            int RobRecursion(int start)
            {
                if (start >= nums.Length)
                    return 0;
                int maxMoney = 0;
                if (memo[start] != -1)
                    return memo[start];
                for (int i = start; i < nums.Length; i++)
                {
                    int money = nums[i] + RobRecursion(i + 2);
                    maxMoney = Math.Max(money, maxMoney);
                }
                memo[start] = maxMoney;
                return maxMoney;
            }
        }

        // 動態規劃
        // 首先考慮最簡單的情況。 如果只有一間房屋, 則偷該房屋 nums = 3 maxMoney =3

        // 如果有兩間房屋, 由於兩間房屋相鄰, 選擇其中金額較高的房屋偷竊 nums = [1,3] maxMoney=max(nums[0], nums[1]) = 3

        // 如果房屋數量大於兩間, 應該如何計算能夠偷竊到的最高總金額呢? 對於第 i(i=2..... nums.Length-1) 間的房屋, 有兩個選項:

        // 1.偷竊第 i 間房屋, 那麼就不能偷竊 i-1 間房屋, 偷竊的總金額為前 i-2 間房屋的最高總金額與第 i 間房屋的金額之和。
        // nums=[1,3,5] i=2 maxMoney = 5 + 1 = 6

        // 2.不偷竊第 i 間房屋, 偷竊總金額為前 i-1 間房屋的最高總金額
        // nums=[1,3,5] i=2 maxMoney = 3

        // 在1.2.兩個選項中選擇偷竊總金額較大的選項, 能偷去到的最高總金額。
        // maxMoney = max(6,3) = 6

        // 用dp[i] 表示前 i 間房屋能偷竊到的最高總金額, 那麼就有如下的轉移方程:
        // dp[i] = max(dp[i-2]+nums[i], dp[i-1])

        // 邊界條件
        // dp[0] = nums[0] 只有一間房屋, 則偷竊該房屋
        // dp[1] = max(nums[0], nums[1]) // 選擇其中金額較高的房屋進行偷竊
        public int Rob2(int[] nums)
        {

            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            if(nums.Length >=2)
                dp[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }

            return dp[nums.Length - 1];
        }


    }
}
