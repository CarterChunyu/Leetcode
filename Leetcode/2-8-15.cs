using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_8_15
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            // 先排序
            Sort(nums);

            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                if (i-1 >= 0 && nums[i] == nums[i - 1])
                    continue;
                if (nums[i] > 0)
                    break;
                for (int j = i+1; j < n; j++)
                {
                    if (j-1 >= i+1 && nums[j] == nums[j-1])
                        continue;
                    for (int k = j+1; k < n; k++)
                    {
                        if (k - 1 >= j + 1 && nums[k] == nums[k - 1])
                            continue;
                        if (nums[i] + nums[j] + nums[k] == 0)
                            list.Add(new List<int> { nums[i], nums[j], nums[k] });
                    }
                }
            }

            return list;
        }

        private void Sort(int[] nums)
        {
            for (int i = nums.Length-1; i >= 0 ; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
           
        }
    }
}
