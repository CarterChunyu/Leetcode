using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode05
{
    public class _6_9_47
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> list =new List<int>();
            bool[] used = new bool[nums.Length];
            PermuteUniqueRecursion(nums);
            return res;
            
            void PermuteUniqueRecursion(int[] numsArr)
            {
                for (int i = 0; i < numsArr.Length ; i++)
                {
                    if (used[i])
                        continue;
                    if (i > 0 && !used[i - 1] && nums[i] == nums[i - 1])
                        continue;
                    
                    list.Add(numsArr[i]);
                    used[i] = true;
                    PermuteUniqueRecursion(numsArr);
                    list.RemoveAt(list.Count - 1);
                    used[i] = false;
                }
            }
        }
    }
}
