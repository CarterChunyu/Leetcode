using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    public class _4_13_234
    {
        // 羽
        public bool IsPalindrome(ListNode head)
        {
            List<int> nums = new List<int>();
            ListNode cur = head; 
            while (cur != null)
            {
                nums.Add(cur.val);
                cur = cur.next;
            }
            int l = 0;
            int r = nums.Count-1;
            while(l < r)
            {
                if (nums[l] != nums[r])
                    return false;
                l++;
                r--;

            }
            return true;
        }
    }
}
