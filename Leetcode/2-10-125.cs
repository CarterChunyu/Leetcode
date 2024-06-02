using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_10_125
    {
        public bool IsPalindrome(string s)
        {
            s = s.ToLower();

            int l = 0;
            int r = s.Length-1;
            while(l < r)
            {
                // 去除左邊非字符元素
                while (l < r && !char.IsLetterOrDigit(s[l]))
                    l++;
                // 去除右邊非字符元素
                while (l <r && !char.IsLetterOrDigit(s[r]))
                    r--;
                if (char.ToLower(s[l]) == char.ToLower(s[r]))
                // 左右指針移動一步考察新的元素
                l++;
                r--;
            }
            return true;
        }
    }
}
