using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode06
{
    internal class _7_5_01_121
    {
        // 羽  超時
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;

            for (int i = 0; i < prices.Length - 1; i++)
            {
                int buyPrice = prices[i];
                for (int j = i + 1; j < prices.Length; j++)
                {
                    maxProfit = Math.Max(maxProfit, prices[j] - buyPrice);
                }
            }
            return maxProfit;
        }

        // 輸入: prices = [7,1,5,3,6,4]
        // 輸出: 5

        // 第0天 不持股 或者 持股
        // 1. 不持股 第0天不持股收益為0
        // 2. 持股   第0天持股收益為 -prices[0]

        // 第1天 不持股 或者 持股
        // 不持股 有兩者可能
        // 1. 前一天沒買 第一天不持股收益為 = 第0天不持股收益 = 0
        // 2. 前一天有買 第一天不持股收益為 = (第0天持股收益 + 第1天賣出股票收益) = -prices[0]+prices[1]
        // 從1,2兩種可能中選擇最大收益
        // 第i天不持股收益 = Max(前一天不持股的最大收益, (前一天持股的最大收益+今天賣掉的收益))

        //持股 有兩種可能
        // 1.第0天股票沒賣           第一天持股收益 = 第0天持股收益 = -prices[0]
        // 2.第0天沒滿股票,第一天買  第一天持股收益 = 第1天買入股票收益 = -prices[i]

        public int MaxProfit1(int[] prices)
        {
            // 用0表示不持股,1表示持股
            int n = prices.Length;
            int[,] dp = new int[n, 2];
            // 第0天不持股
            dp[0, 0] = 0;
            dp[0, 1] = -prices[0];

            for (int i = 1; i < n; i++)
            {
                // 第i天的不持股的收益 = Max(前一天不持股的最大收益, (前一天持股最大收益+今天賣掉的收益))
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                // 第i天持股的收益 = Max(前一天持股的最大收益, 今天持股的最大收益)
                dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
            }

            return dp[n - 1, 0];
        }

    }
}
