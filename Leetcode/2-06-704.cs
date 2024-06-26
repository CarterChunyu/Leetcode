using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_6_704
    {
        public int Search(int[] nums, int target)
        {
            int i = 0;
            int j = nums.Length-1;

            while(i <= j)
            {
                int mid = (j - i) / 2 + i;
                if (nums[mid] == target)
                    return mid;
                else if (target < nums[mid])
                    j = mid - 1;
                else
                    i = mid + 1;
            }
            return -1;
        }

        // 遞歸寫法
        public int Search1(int[] nums, int target)
        {
            return Search(0, nums.Length - 1);
            int Search(int l, int r)
            {
                if (l > r)
                    return -1;
                int mid = (r - l) / 2 + l;
                if (target < nums[mid])
                    return Search(l, r - 1);
                else if (target > nums[mid])
                    return Search(l + 1, r);
                return mid;
            }
        }
    }
}
