using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode02
{
    public class _3_01_217
    {
        public bool ContainsDuplicate1(int[] nums)
        {
            SelectSort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                    return true;
            }
            return false;
        }
        public void SelectSort(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                int index = i;
                for (int j = i; j < n; j++)
                {
                    if (nums[j] < nums[index])
                    {
                        index = j;
                    }
                }
                int temp = nums[index];
                nums[index] = nums[i];
                nums[i] = temp;
            }
        }

        // 羽
        public bool ContainsDuplicate2(int[] nums)
        {
            HashSet<int> ints = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                ints.Add(nums[i]);
            }
            return nums.Length != ints.Count;
        }

        public bool ContainsDuplicate3(int[] nums)
        {
            ISet<int> set = new HashSet<int>();
            foreach (int item in nums)
            {
                //  重複的元素不會加入, 並回傳false
                if (!set.Add(item))
                    return true;
            }
            return false;
        }
    }
}
