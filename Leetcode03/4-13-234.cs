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
            // 只有一個節點也算回文
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

        // 羽 較好
        public bool IsPalindrome1(ListNode head)
        {
            if (head == null || head.next == null)
                return true;

            ListNode pre = null;
            ListNode oneCur = head;
            ListNode twoCur = head;
            Stack<int> stack = new Stack<int>();
            while (twoCur != null && twoCur.next != null)
            {
                pre = oneCur;
                oneCur = oneCur.next;
                twoCur = twoCur.next.next;
                stack.Push(pre.val);
            }

            if (twoCur != null)
                oneCur = oneCur.next;
            while (oneCur != null)
            {
                if (oneCur.val != stack.Pop())
                    return false;
                oneCur = oneCur.next;
            }
            return true;
        }
    }
}
