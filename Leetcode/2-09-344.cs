using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_9_344
    {
        public void ReverseString1(char[] s)
        {
            for (int i = 0; i <= s.Length/2-1; i++)
            {
                char temp = s[i];
                s[i] = s[s.Length -1 - i];
                s[s.Length - 1 - i] = temp;
            }
        }

        // 正確解法 雙指針
        public void ReverseString2(char[] s)
        {
            int l = 0;
            int r = s.Length - 1;
            while(l < r)
            {
                char temp = s[l];
                s[l] = s[r];
                s[r] = temp;
                l++;
                r--;
            }
        }
    }
}
