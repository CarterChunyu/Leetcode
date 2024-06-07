using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_13_3
    {

        // 羽
        public int LengthOfLongestSubstring1(string s)
        {
            int n = s.Length;

            int i = 0;
            int j = -1;

            int length = 0;
            string nowStr = string.Empty;

            while(j+1 < n)
            {
                j++;
                if (!nowStr.Contains(s[j]))
                {
                    nowStr = $"{nowStr}{s[j]}";
                    length = Math.Max(length, j - i + 1);
                }
                else
                {
                    nowStr = nowStr.Substring(1, nowStr.Length - 1);
                    i++;
                    j--;
                }
            }
            return length;
        }

        public int LengthOfLongestSubstring2(string s)
        {
            int n = s.Length;

            // s[i..j] 為滑動窗口 
            int i = 0;
            int j = -1;

            HashSet<char> set= new HashSet<char>();
            int length = 0;

            while(i < n)
            {
                if (j+1 < n && !set.Contains(s[j + 1]))
                {
                    j++;
                    set.Add(s[j]);
                }
                else
                {
                    set.Remove(s[i]);
                    i++;
                }
                length = Math.Max(length, j - i + 1);
            }

            return length;
        }
    }
}
