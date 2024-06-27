using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode05
{
    public class _6_7_39
    {
        // [2,3] target=6
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> list = new List<int>();
            int sum = 0;
            CombinationSum(0);
            return res;


            void CombinationSum(int start)
            {
                if(sum == target)
                {
                    res.Add(new List<int>(list));
                    return;
                }
                if (sum > target)
                    return;


                for (int i = start; i < candidates.Length; i++)
                {
                    list.Add(candidates[i]);
                    sum += candidates[i];
                    CombinationSum(i);
                    list.RemoveAt(list.Count - 1);
                    sum -= candidates[i];
                }
            }
        }
    }
}
