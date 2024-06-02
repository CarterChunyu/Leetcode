using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode02
{
    public class _3_04_242
    {
        // 羽
        public bool IsAnagram1(string s, string t)
        {
            if(s.Length != t.Length)
                return false;
            Dictionary<char,int> dic =new Dictionary<char,int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                    dic[s[i]]++;
                else
                    dic.Add(s[i], 1);
            }

            foreach (var c in t)
            {
                if (dic.ContainsKey(c) && dic[c] > 0)
                    dic[c]--;
                else
                    return false;
            } 

            return true; 
        }


        public bool IsAnagram2(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            char[] sArr = s.ToCharArray();
            Array.Sort(sArr);
            char[] tArr = t.ToCharArray();
            Array.Sort(tArr);

            int i = 0;
            while(i < s.Length)
            {
                if (sArr[i] != tArr[i])
                    return false;
                else
                    i++;
            }
            return true;
        }
    }
}
