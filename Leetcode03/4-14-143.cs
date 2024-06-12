using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    public class _4_14_143
    {
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null)
                return;
            int length = getLength(head);
            ListNode firstHead = head;
            ListNode firstTail = head;
            for (int i = 0; i < (length/2)-1; i++)
            {
                firstTail = firstTail.next;
            }
            ListNode secondHead = firstTail.next;
            // 斷開
            firstTail.next = null;            
            //ListNode secondTail = head;
            //while(secondTail.next!= null)
            //{
            //    secondTail =secondTail.next;
            //}
            secondHead = Reverse(secondHead);
            ListNode cur = firstHead;
            firstHead = firstHead.next;
            while(firstHead != null && secondHead != null)
            {
                cur.next = secondHead;
                secondHead = secondHead.next;
                cur = cur.next;
                cur.next = firstHead;
                firstHead = firstHead.next;
            }
            while (secondHead != null)
            {
                cur.next = secondHead;
                cur = cur.next;
                secondHead = secondHead.next;
            }
            Console.WriteLine();
            ListNode Reverse(ListNode head)
            {
                if (head == null ||  head.next == null)
                    return head;
                ListNode pre = null;
                ListNode cur = head;
                while (cur != null)
                {
                    ListNode next = cur.next;
                    cur.next = pre;
                    pre = cur;
                    cur = next;
                }
                return pre;
            }
            
            int getLength(ListNode head)
            {
                int cnt = 0;
                ListNode cur = head;
                while (cur != null)
                {
                    cnt++;
                    cur = cur.next;
                }
                return cnt;
            }
        }
    }
}
