using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode05
{
    public class _6_5_77
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> list = new List<int>();
            CombineRecursion(1);
            return res;

            void CombineRecursion(int start)
            {
                if(list.Count == k)
                {
                    res.Add(new List<int>(list));
                    return;
                }

                for (int i = start; i <= n ; i++)
                {
                    list.Add(i);
                    CombineRecursion(i+1);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }


        public IList<IList<int>> Combine1(int n, int k)
        {
            List<int> q = new List<int>();
            for (int i = 1; i <=n ; i++)
            {
                q.Add(i);
            }

            List<int> list = new List<int>();
            IList<IList<int>> res = new List<IList<int>>();
            CombineRecursion(q, 0);
            return res;

            void CombineRecursion(List<int> source, int start)
            {
                if(list.Count ==k)
                    res.Add(new List<int>(list));
                for (int i = start; i < source.Count; i++)
                {
                    list.Add(source[i]);
                    CombineRecursion(source, i + 1);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
    }
}
