using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode05
{
    public class _6_4_90
    {
        // 羽
        public IList<IList<int>> SubsetsWithDup1(int[] nums)
        {
            return SubsetsRecursion(nums, nums.Length);

            IList<IList<int>> SubsetsRecursion(int[] nums, int len)
            {
                if(len == 0)
                    return new List<IList<int>>() { new List<int>()};
                else
                {
                    IList<IList<int>> res = SubsetsRecursion(nums, len - 1);
                    int size = res.Count;
                    for (int i = 0; i < size; i++)
                    {
                        List<int> temp = new List<int>(res[i]);
                        temp.Add(nums[len - 1]);
                        if (!isContains(res, temp))
                            res.Add(temp);
                    }
                    return res;
                }
            }

            bool isContains(IList<IList<int>> lists, List<int> list)
            {
                list.Sort();
                foreach (var item in lists)
                { 
                    if(item.Count == list.Count)
                    {                        
                        int cnt = 0;
                        for (int i = 0; i < item.Count; i++)
                        {
                            if (item[i] != list[i])
                                break;
                            cnt++;
                        }
                        if (cnt == item.Count)
                            return true;
                    }                   
                }
                return false;
            }
        }

        
        public IList<IList<int>> SubsetsWithDup2(int[] nums)
        {

            IList<int> list = new List<int>();
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            SubsetsRecursion(nums, 0);
            return res;

            // 遞歸
            // 函數Subsets(int[] nums, int start) 在nums[start...nums.Length-1] 區間選擇一個數
            void SubsetsRecursion(int[] nums, int start)
            {
                // 先把空集合添加進結果集中 然後再接著計算新的子集
                res.Add(new List<int>(list));
                // nums[start...nums.Length-1] 區間選擇一個數 無效區間 選擇失敗 遞歸中止
                for (int i = start; i < nums.Length; i++)
                {
                    // 剪枝邏輯, 值相同樹枝, 只遍歷第一條
                    if (i > start && nums[i] == nums[i - 1])
                        continue;
                    // 做選擇
                    list.Add(nums[i]);
                    // 所小區間 在nums[start+1...nums.Length-1] 區間選擇一個數 通過 start 參數控制樹枝
                    // 的遍歷, 避免產生重複的子集
                    SubsetsRecursion(nums, i + 1);
                    // 撤銷選擇
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
    }
}
