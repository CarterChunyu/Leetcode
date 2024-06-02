using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_11_11
    {
        // 雙指針
        public int MaxArea2(int[] height)
        {
            int n = height.Length;
            int l = 0;
            int r = n - 1;
            int maxArea = 0;

            while (l < r)
            {
                int nowArea = Math.Min(height[l], height[r]) * (r-l);
                if (nowArea > maxArea)
                    maxArea = nowArea;
                if (height[l] <= height[r])
                    l++;
                else
                    r--;
            }
            return maxArea;
        }
    }
}
