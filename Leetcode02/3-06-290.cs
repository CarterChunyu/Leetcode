using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode02
{
    public class _3_06_290
    {
        // 羽
        public bool WordPattern1(string pattern, string s)
        {
            string[] sArr = s.Split(' ');
            
            char[] cArr = pattern.ToCharArray();
            if (cArr.Length != sArr.Length)
                return false;
            Dictionary<int, char> dic1 = new Dictionary<int, char>();
            Dictionary<char, string> dic2 = new Dictionary<char, string>();
            Dictionary<int, string> dic3 = new Dictionary<int, string>();
            Dictionary<string, char> dic4 = new Dictionary<string, char>();
            for (int i = 0; i < cArr.Length; i++)
            {
                dic1.Add(i, cArr[i]);
                if (!dic2.ContainsKey(cArr[i]))
                    dic2.Add(cArr[i], sArr[i]);

                dic3.Add(i, sArr[i]);
                if (!dic4.ContainsKey(sArr[i]))
                    dic4.Add(sArr[i], cArr[i]);
            }
            string compare1 = "";
            string pattern1 = "";
            for (int i = 0; i < cArr.Length; i++)
            {
                char c = dic1[i];
                string str = dic2[c];
                compare1 += str;
                if (i < cArr.Length - 1)
                    compare1 += " ";
                string key = dic3[i];
                pattern1 += dic4[key];
            }
            return s == compare1 && pattern == pattern1;
        }

        public bool WordPattern2(string pattern, string s)
        {
            char[] patternArr = pattern.ToCharArray();
            string[] sArr = s.Split(' ');
            if(patternArr.Length != sArr.Length)
                return false;
            // ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆  正反反正都要比
            Dictionary<char, string> dic1 = new Dictionary<char, string>();
            Dictionary<string, char> dic2 = new Dictionary<string, char>();
            for (int i = 0; i < patternArr.Length; i++)
            {
                if (!dic1.ContainsKey(patternArr[i]))
                    dic1.Add(patternArr[i], sArr[i]);
                if (!dic2.ContainsKey(sArr[i]))
                    dic2.Add(sArr[i], patternArr[i]);
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                string compare1 = dic1[patternArr[i]];
                char compare2 = dic2[sArr[i]];
                if (compare1 != sArr[i] || compare2 != patternArr[i])
                    return false;
            }

            return true;
        }
    }
}
