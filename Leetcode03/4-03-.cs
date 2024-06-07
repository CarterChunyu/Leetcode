using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    //public class ListNode
    //{
    //    public int val;
    //    public ListNode next;
    //    public ListNode(int val = 0, ListNode next = null)
    //    {
    //        this.val = val;
    //        this.next = next;
    //    }
    //}
    public class _4_03_
    {
        public int KthToLast1(ListNode head, int k)
        {
            int len = 0;
            ListNode cur1 = head;
            while (cur1 != null)
            {
                len++;
                cur1 = cur1.next;
            }

            ListNode cur2 = head;
            
            while(cur2 != null)
            {
                if (len == k)
                    return cur2.val;
                len--;
                cur2 = cur2.next;
            }

            return -1; 
        }

        // 快慢指針 
        public int KthToLast2(ListNode head, int k)
        {
            ListNode slow = head;
            ListNode fast = head;

            // 快指針先走K步
            for (int i = 0; i < k; i++)
            {
                fast = fast.next;
            }

            while(fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            return slow.val;
        }

    }
}
