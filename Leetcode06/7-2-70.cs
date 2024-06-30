using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode06
{
    internal class _7_2_70
    {

        public int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            return ClimbStairs(n - 1) + ClimbStairs(n - 2);
        }

        public int ClimbStairs1(int n)
        {
            int[] memo = new int[n+1];
            for (int i = 1; i <= n; i++)
            {
                memo[i] = -1;
            }
            return CaLClimbStairs(n);

            int CaLClimbStairs(int n)
            {
                if (n == 1)
                    return 1;
                if (n == 2)
                    return 2;
                if (memo[n] == -1)
                    memo[n] = CaLClimbStairs(n - 1) + CaLClimbStairs(n - 2);

                return memo[n];
            }
        }

        public int ClimbStairs2(int n)
        {
            int[] dp = new int[n + 1];
            dp[1] = 1;
            if(n >=2)
                dp[2] = 2;
            for (int i = 3; i <= n ; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
    }
}
