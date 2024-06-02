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
    }
}
