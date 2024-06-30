using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode06
{
    public class _7_1_509
    {
        public int Fib(int n)
        {
            if (n == 0)   
                return 0;
            else if (n == 1)
                return 1;
            else //(n >= 2)
                return Fib(n - 1) + Fib(n - 2);
        }

        // 記憶化搜索
        public int Fib1(int n)
        {
            int[] memo = new int[n+1];
            for (int i = 0; i < n+1; i++)
            {
                memo[i] = -1;
            }
            return CalFib(n);

            int CalFib(int n)
            {
                if (n == 0)
                    return 0;
                if (n == 1)
                    return 1;
                if (memo[n] == -1)
                {
                    memo[n] = CalFib(n - 1) + CalFib(n - 2);
                } 
                return memo[n];
                
            }
        }

        // dp[i] 表示第 i 個裴波那契數為 dp[i] dp[N] 表示第 N個 裴波那契數
        // 求 Fib(1) 返回 dp[1]
        // 求 Fib(5) 返回 dp[5] 
        // 求 Fib(N) 返回 dp[N]
        // 動態規劃
        public int Fib3(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            if(n+1 >=2)
                dp[1] = 1;
            // dp: [0,1,1,2,3,5]
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
    }
}
