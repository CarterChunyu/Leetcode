﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode06
{
    public class _7_5_02_122
    {
        // prices =[7,1,5,3,6,4]
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;

            // 0表示不持股, 1表示持股
            int[,] dp = new int[n,2];
            dp[0, 0] = 0;
            dp[0, 1] = -prices[0];

            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i-1,1] +prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
            }
            return dp[n-1, 0];
        }
    }
}
