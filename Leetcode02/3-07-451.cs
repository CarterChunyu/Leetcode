using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode02
{
    public class _3_07_451
    {
        // 羽
        public string FrequencySort1(string s)
        {
            Dictionary<char, int> dic1 = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (dic1.ContainsKey(c))
                    dic1[c]++;
                else
                    dic1.Add(c, 1);
            }

            Dictionary<int, List<char>> dic2 = new Dictionary<int, List<char>>();
            List<int> cnt = new List<int>();
            foreach (var item in dic1)
            {
                if (dic2.ContainsKey(item.Value))
                    dic2[item.Value].Add(item.Key);
                else
                {
                    dic2.Add(item.Value, new List<char> { item.Key });
                    cnt.Add(item.Value);
                }
            }
            int[] orderArr = cnt.ToArray();
            Array.Sort(orderArr);
            Array.Reverse(orderArr);
            //OrderBydesc(orderArr);
            string ans = "";
            for (int i = 0; i < orderArr.Length; i++)
            {
                int count = orderArr[i];
                foreach (char c in dic2[count])
                {
                    for (int j = 0; j < count; j++)
                    {
                        ans += c;
                    }
                }
            }
            return ans;

            //void OrderBydesc(int[] nums)
            //{
            //    int n = nums.Length;
            //    for (int i = 1; i < n; i++)
            //    {
            //        int c = nums[i];
            //        int index = i;
            //        for (int j = i-1; j >=0 ; j--)
            //        {
            //            if (c > nums[j])
            //            {
            //                nums[j + 1] = nums[j];
            //                index = j;
            //            }
            //            else
            //                break;
            //        }
            //        nums[index] = c;
            //    }
            //}
        }

        public string FrequencySort2(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i]))
                    dic.Add(s[i], 1);
                else
                    dic[s[i]]++;
            }
            List<Pair> pairs = new List<Pair>();
            foreach (var item in dic)
            {
        
                pairs.Add(new Pair(item.Key, item.Value));
            }
            pairs.Sort();
            //Sort1(pairs);

            StringBuilder builder = new StringBuilder();
            for (int i = pairs.Count-1; i >=0 ; i--)
            {
                Pair p = pairs[i];
                for (int j = 0; j < p.freq; j++)
                {
                    builder.Append(p.c);
                }
            }
            return builder.ToString();  
            
            void Sort1<T>(List<T> ts) where T : IComparable<T>
            {
                int n = ts.Count;
                for (int i = n-1; i >=0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (ts[j].CompareTo(ts[j+1]) > 0)
                        {
                            T temp = ts[j];
                            ts[j] = ts[j+1];
                            ts[j + 1] = temp;
                        }
                    }
                }
            }
        }
    }
    class Pair :IComparable<Pair>
    {
        public Pair(char c, int seq)
        {
            this.c = c;
            freq = seq;
        }

        public char c { get; set; }
        public int freq { get; set; }

        public int CompareTo(Pair? other)
        {
            return this.freq - other.freq;
        }
    }

}
