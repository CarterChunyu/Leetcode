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

        public bool WordPattern2(string pattern, string s)
        {
            string[] words = s.Split(' ');
            if(pattern.Length != words.Length) 
                return false;
            // 雙向映射 字符映射字符串 字符串映射字符
            Dictionary<char, string> map1 = new Dictionary<char, string>();
            Dictionary<string, char> map2 = new Dictionary<string, char>();

            for (int i = 0; i < pattern.Length; i++)
            {
                char c = pattern[i];
                string word = words[i];
                // map1沒有字符對應到字符串
                if (!map1.ContainsKey(c))
                {
                    // 如果字符串有對應到字符, 不是一一映射, 一個字符串映射到多個字符, 不符合題目意思。
                    if (map2.ContainsKey(word))
                        return false;
                    // 建立一一映射
                    map1.Add(c, word);
                    map2.Add(word, c); 
                }
                // 字符有對應到的字詞串
                else // map1.ContainsKey(c) 
                {
                    // 字符串有對應到的字符
                    if (!map2.ContainsKey(word))
                        return false; 
                    if (map1[c] != word && map2[word] != c)
                        return false;
                }
            }

            return true;
        }
    }
}
