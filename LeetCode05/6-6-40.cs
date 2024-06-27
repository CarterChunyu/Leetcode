using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode05
{
    public class _6_6_40
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> list = new List<int>();
            int sum = 0;
            Array.Sort(candidates);
            CombinationSumRecursion(0);
            return res;

            void CombinationSumRecursion(int start)
            {
                if(sum >= target)
                {
                    if (sum == target)
                        res.Add(new List<int>(list));
                    return;
                }

                for (int i = start; i < candidates.Length; i++)
                {
                    if (i > start && candidates[i] == candidates[i - 1])
                        continue;
                    sum+= candidates[i];
                    list.Add(candidates[i]);
                    CombinationSumRecursion(i + 1);
                    // ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ 一樣的意思
                    //sum-= list[list.Count-1];
                    sum -= candidates[i];
                    list.RemoveAt(list.Count - 1);
                }
            } 
        }
    }
}
