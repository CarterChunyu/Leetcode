using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_8_15
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    for (int k = j+1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            bool flag = true;
                            foreach (var item in list)
                            {
                                if (item.Contains(nums[i]))
                                {
                                    item.Remove(nums[i]);
                                }
                                if (item.Contains(nums[j]))
                                {
                                    item.Remove(nums[j]);
                                }
                                if (item.Contains(nums[k]))
                                {
                                    item.Remove(nums[k]);
                                }
                                if(item.Count==0)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                list.Add(new List<int>() { nums[i], nums[j], nums[k] });
                            }
                        }
                    }
                }
            }
            return list;
        }
    }
}
