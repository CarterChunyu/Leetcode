using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode05
{
    public class _6_2_78
    {
        // 羽
        public IList<IList<int>> Subsets1(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            res.Add(new List<int>());
            Subset(nums);
            return res;

            void Subset(int[] nums)
            {
                if (nums.Length == 0)

                    return;

                else
                {
                    int n = nums[0];
                    IList<IList<int>> tempLists = new List<IList<int>>();
                    foreach (var list in res)
                    {
                        List<int> temp = new List<int>(list);
                        temp.Add(n);
                        tempLists.Add(temp);
                    }
                    foreach (var item in tempLists)
                    {
                        res.Add(item);
                    }
                    Subset(RemoveFirst(nums));
                }
            }

            int[] RemoveFirst(int[] nums)
            {
                List<int> list = nums.ToList();
                list.RemoveAt(0);
                return list.ToArray();

            }
        }


        public IList<IList<int>> Subsets2(int[] nums)
        {
            return Subsets(nums, nums.Length);

            IList<IList<int>> Subsets(int[] nums, int len)
            {
                if (len == 0)
                    return new List<IList<int>> { new List<int>() };
                else
                {
                    IList<IList<int>> subList = Subsets(nums, len - 1);
                    // ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ 
                    int size = subList.Count;
                    int num = nums[len - 1];
                    // ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ 新加入的不參與
                    for (int i = 0; i < size; i++)
                    {
                        IList<int> sub = subList[i];
                        // 拷貝一份 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                        IList<int> temp = new List<int>(sub);
                        temp.Add(num);
                        subList.Add(temp);
                    }
                    return subList;
                }
            }
        }


        // 回朔法 (深度優先)
        public IList<IList<int>> Subsets(int[] nums)
        {
            // res 存儲所有子集
            IList<IList<int>> res = new List<IList<int>>();
            // list 存儲單個子集
            IList<int> list = new List<int>();

            SubSetRecusion(nums, 0);
            return res;

            void SubSetRecusion(int[] nums, int start)
            {
                res.Add(new List<int>(list));

                for (int i = start; i < nums.Length; i++)
                {
                    list.Add(nums[i]);
                    SubSetRecusion(nums, i + 1);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }

        // 指收集特定長度的子集
        public IList<IList<int>> Subsets(int[] nums, int cnt)
        {
            IList<int> list = new List<int>();
            IList<IList<int>> res = new List<IList<int>>();
            SubsetRecursion(nums, 0);
            return res;

            void SubsetRecursion(int[] nums, int start)
            {
                if (list.Count == cnt)
                {
                    res.Add(new List<int>(list));
                }
                for (int i = start; i < nums.Length; i++)
                {
                    list.Add(nums[i]);
                    SubsetRecursion(nums, i + 1);
                    list.Remove(nums[list.Count - 1]);
                }
            }
        }


        public string Print(IList<IList<int>> list)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                builder.Append($"[ {string.Join(",", list[i])} ]");
            }
            return builder.ToString();
        }
    }
}
