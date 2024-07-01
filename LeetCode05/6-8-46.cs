using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode05
{
    public class _6_8_46
    {

        // [1,2]
        public IList<IList<int>> Permute1(int[] nums)
        {
            IList<IList<int>> res =new List<IList<int>>();
            IList<int> list = new List<int>();
            bool[] isUse = new bool[nums.Length];
            PermuteRecursion(nums);
            return res;

            void PermuteRecursion(int[] nums)
            {
                if(list.Count==nums.Length)
                {
                    res.Add(new List<int>(list));
                    return;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if (isUse[i])
                        continue;
                    isUse[i] = true;
                    list.Add(nums[i]);
                    PermuteRecursion(nums);
                    list.RemoveAt(list.Count - 1);
                    isUse[i] = false;
                }
            }

        }


        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> list = new List<int>();
            PermuteRecursion(nums);
            return res;

            void PermuteRecursion(int[] nums)
            {
                if (list.Count == nums.Length)
                {
                    res.Add(new List<int>(list));
                    return;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if (list.Contains(nums[i]))
                        continue;

                    list.Add(nums[i]);
                    PermuteRecursion(nums);
                    list.RemoveAt(list.Count-1);
                }
            }
        }
    }
}
