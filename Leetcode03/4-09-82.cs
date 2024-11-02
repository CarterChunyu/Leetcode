using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    public class _4_09_82
    {
        // 羽 
        public ListNode DeleteDuplicates1(ListNode head)
        {
            ListNode dummyNode = new ListNode(-1, head);
            ListNode pre = dummyNode;
            ListNode cur = head;

            bool flag = false;
            while(cur != null)
            {
                if (cur.next != null && cur.val == cur.next.val)
                {
                    cur = cur.next;
                    flag = true;
                    continue;
                }
                if (flag)
                {
                    pre.next = cur.next;
                    cur = cur.next;
                    flag = false;
                }
                else {
                    pre = cur;
                    cur = cur.next;
                }
                  
            }

            return dummyNode.next;
            
        }

        public ListNode DeleteDuplicates2(ListNode head)
        {
            ListNode dummyNode = new ListNode(-1, head);
            ListNode cur = dummyNode;

            while(cur.next != null && cur.next.next != null)
            {
               // if(cur.next!= null && cur.next.next!=null &&  cur.next.val == cur.next.next.val)
                if(cur.next.val == cur.next.next.val)
                {
                    int val = cur.next.val;
                    while (cur.next != null &&cur.next.val == val)
                        cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next;
                }
            }
            return dummyNode.next;
        }

        public ListNode DeleteDuplicates3(ListNode head)
        {
            ListNode dummyNode = new ListNode(-1, head);
            ListNode pre = dummyNode;
            ListNode cur = head;

            while(cur!= null)
            {
                if(cur.next != null && cur.val== cur.next.val)
                {
                    int val = cur.val;
                    while(cur!= null && cur.val == val)
                    {
                        pre.next = cur.next;
                        cur = cur.next;
                    }
                }
                else
                {
                    pre = cur;
                    cur = cur.next
                }
            }
            return dummyNode.next;
        }

        // 羽
        public ListNode DeleteDuplicates4(ListNode head)
        {
            ListNode dummyNode = new ListNode(-1, head);
            ListNode pre = dummyNode;
            ListNode cur = head;

            while (cur != null)
            {
                if (cur.next != null && cur.val == cur.next.val)
                {
                    while (cur.next != null && cur.val == cur.next.val)
                        cur = cur.next;
                    cur = cur.next;
                    pre.next = cur;
                }
                else
                {
                    pre = cur;
                    cur = cur.next;
                }
            }
            return dummyNode.next;
        }

    }
}
