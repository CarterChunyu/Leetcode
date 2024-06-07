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

    public class _4_02_876
    {
        public ListNode MiddleNode1(ListNode head)
        {
            int len = 0;
            for (ListNode i = head; i != null ; i = i.next)
            {
                len++;
            }

            ListNode cur = head;
            for (int i = 0; i < len/2; i++)
            {
                cur = cur.next;
            }
            return cur;
        }

        // 快慢指針
        public ListNode MiddleNode2(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        // 羽
        public ListNode MiddleNode3(ListNode head)
        {
            ListNode fastCur = head;
            ListNode slowCur = head;

            while(fastCur != null)
            {
                fastCur = fastCur.next;
                if(fastCur != null)
                {
                    fastCur = fastCur.next;
                    slowCur = slowCur.next;
                }
            }

            return slowCur;
        }
    }
}
