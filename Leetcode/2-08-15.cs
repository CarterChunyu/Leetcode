using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Leetcode
{
    public class _2_8_15
    {
        // 暴力
        public IList<IList<int>> ThreeSum1(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Sort(nums);
            int n = nums.Length;
            for (int i = 0; i < n ; i++)
            {
                if (i - 1 >= 0 && nums[i] == nums[i - 1])
                    continue;
                if (nums[i] > 0)
                    break;
                for (int j = i+1; j < n; j++)
                {
                    if (j - 1 >= i + 1 && nums[j] == nums[j - 1])
                        continue;
                    if (nums[i] + nums[j] > 0)
                        break;
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

        // 二分法
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();           
            Sort(nums);
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                if (i - 1 >= 0 && nums[i] == nums[i - 1])
                    continue;
                if (nums[i] > 0)
                    break;
                for (int j = i+1; j < n; j++)
                {
                    if (j - 1 >= i + 1 && nums[j] == nums[j - 1])
                        continue;
                    if (nums[i] + nums[j] > 0)
                        break;

                    // 二分法
                    int l = j + 1;
                    int r = n - 1;
                    int target = -nums[i] - nums[j];

                    while(l <= r)
                    {
                        int mid = (r - l) / 2 + l;
                        if (nums[mid] < target)
                            l = mid + 1;
                        else if (nums[mid] > target)
                            r = mid - 1;
                        else
                        {
                            list.Add(new List<int> { nums[i], nums[j], nums[mid] });
                            break; // ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ 一定要加上終止條件
                        }   
                    }
                }
            }

            return list;
        }

        // 雙指針 羽
        public IList<IList<int>> ThreeSum3(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Sort(nums);
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] > 0)
                    break;
                if (i - 1 >= 0 && nums[i] == nums[i - 1])
                    continue;

                int l = i + 1;
                int r = n-1;
                int target = -nums[i];

                while(l < r)
                {
                    if (nums[l] + nums[r] < target)
                        l++;
                    else if (nums[l] + nums[r] > target)
                        r--;
                    else
                    {
                        list.Add(new List<int> { nums[l], nums[r], nums[i] });
                        int numsl = nums[l];
                        int numsr = nums[r];
                        while(l < r && (nums[l] == numsl || nums[r] == numsr))
                        {
                            if (nums[l] == numsl)
                                l++;
                            if (nums[r] == numsr)
                                r--;
                        }
                    }   
                }
            }

            return list;
        }

        // 都是同一個陣列的題目首先想到指針 
        public IList<IList<int>> ThreeSum4(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Sort(nums);
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                // 去重
                if (i - 1 >= 0 && nums[i] == nums[i - 1])
                    continue;
                // 最小都大於0
                if (nums[i] > 0)
                    break;

                // 雙指針
                int l = i + 1;
                int r = n - 1;
                int target = -nums[i];
                while( l < r)
                {
                    if (nums[l] + nums[r] < target)
                        l++;
                    else if (nums[l] + nums[r] > target)
                        r--;
                    else //nums[l] + nums[i] == target
                    {
                        list.Add(new List<int> { nums[l], nums[r], nums[i] });
                        // 去重 l 指針移動到相同元素的最後一個 
                        while (l < r && nums[l] == nums[l + 1])
                            l++;
                        // 去重 r 指針移動到相同元素的最後一個 
                        while (l < r && nums[r] == nums[r - 1])
                            r--;
                        l++;
                        r--;
                    }
                }
            }
            return list;
        }

        private void Sort(int[] nums)
        {
            int n = nums.Length;
            for (int i = n-1; i >=0 ; i--)
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
