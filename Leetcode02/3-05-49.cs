using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode02
{
    public class _3_05_49
    {
        // 羽 幾乎超時
        public IList<IList<string>> GroupAnagrams1(string[] strs)
        {
            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            foreach (string str in strs)
            {
                bool conainsFlag = false;
                foreach (string key in dic.Keys)
                {
                    if (Judge(key, str))
                    {
                        dic[key].Add(str);
                        conainsFlag = true;
                    }
                }
                if(!conainsFlag)
                    dic.Add(str, new List<string> { str});
            }
            IList<IList<string>> ans = new List<IList<string>>();
            foreach (IList<string> list in dic.Values)
            {
                ans.Add(list);
            }
            return ans;

            bool Judge(string s1, string s2)
            {
                if (s1.Length != s2.Length)
                    return false;
                char[] c1 = s1.ToCharArray();
                char[] c2 = s2.ToCharArray();
                //Dictionary<char, int> dic = new Dictionary<char, int>();
                //foreach (char c in c1)
                //{
                //    if (dic.ContainsKey(c))
                //        dic[c]++;
                //    else
                //        dic.Add(c, 1);
                //}
                //foreach (char c in c2)
                //{
                //    if (!dic.ContainsKey(c) || dic[c] <= 0)
                //        return false;
                //    else
                //        dic[c]--;
                //}
                //return true;

                Array.Sort(c1);
                Array.Sort(c2);

                for (int i = 0; i < c1.Length; i++)
                {
                    if (c1[i] != c2[i])
                        return false;
                }
                return true;
            }
        }
        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            // 關鍵 用排序過後的異位詞 當作映射的 Key
            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] c = strs[i].ToCharArray();
                Array.Sort(c);
                string sort = new string(c);
                if (dic.ContainsKey(sort))
                    dic[sort].Add(strs[i]);
                else
                    dic.Add(sort, new List<string> { strs[i] });
            }

            //IList<IList<string>> list = new List<IList<string>>();
            //foreach (var item in dic.Values)
            //    list.Add(item);
            //return list;

            return new List<IList<string>>(dic.Values);
        }
        
        // 羽 
        public IList<IList<string>> GroupAnagrams3(string[] strs)
        {
            string[] sort = new string[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                char[] c = strs[i].ToCharArray();
                Array.Sort(c);
                string s = "";
                foreach (char item in c)
                    s += item;
                sort[i] = s;
            }
            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                if (dic.ContainsKey(sort[i]))
                    dic[sort[i]].Add(strs[i]);
                else
                    dic.Add(sort[i],new List<string> { strs[i] });
            }
            IList<IList<string>> list = new List<IList<string>>();
            foreach (var item in dic)
            {
                list.Add(item.Value);
            }
            return list;
        }
    }
}
