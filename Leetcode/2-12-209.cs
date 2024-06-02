using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_12_209
    {
       // 暴力 超時 
        public int MinSubArrayLen1(int target, int[] nums)
        {
            int n = nums.Length;

            int cnt = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = i; j < n; j++)
                {
                    sum = sum + nums[j];
                    if (sum >= target)
                    {
                        cnt = Math.Min(cnt, j - i + 1);
                        break;
                    }
                }
            }
            return cnt == int.MaxValue ? 0 : cnt;
        }

        // 羽
        public int MinSubArrayLen2(int target, int[] nums)
        {
            int n = nums.Length; 
            int cnt = int.MaxValue;

            int i =0;
            int j = -1;
            int sum = 0;


            while (i < n || j+1 < n)
            {
                if(i == 3)
                {

                }
                if(j+1 < n && sum < target)
                {
                    j++;
                    sum = sum + nums[j];
                    continue;
                }

                if(i < n && sum >= target)
                {
                    cnt = Math.Min(cnt, j - i + 1);
                    sum = sum - nums[i];
                    i++;  
                    continue;
                }
                break;
            }

            return cnt == int.MaxValue ? 0 : cnt;
        }

        // 時間複查度: O(n)
        // 雙指針-滑動窗口
        public int MinSubArrayLen3(int target, int[] nums)
        {
            int n = nums.Length;

            // nums[i...j] 為我們的滑動窗口
            int i = 0;
            int j = -1;

            int cnt = int.MaxValue;
            int sum = 0;

            while (i < n)
            {
                if (j + 1 < n && sum < target)
                {
                    j++;
                    sum += nums[j];
                }
                else
                {
                    sum -= nums[i];
                    i++;
                }

                if (sum >= target)
                    cnt = Math.Min(cnt, j - i + 1);
            }

            return cnt == int.MaxValue ? 0 : cnt;
        }
    }
}
