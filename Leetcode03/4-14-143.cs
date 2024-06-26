using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    public class _4_14_143
    {
        // 羽
        public void ReorderList1(ListNode head)
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
                cur = cur.next;
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

        // 好解法
        public void ReorderList2(ListNode head)
        {
            if (head == null || head.next == null)
                return;
            ListNode cur = head;
            List<ListNode> list = new List<ListNode>();
            while (cur != null)
            {
                list.Add(cur);
                cur = cur.next;
            }
            int l = 0;
            int r = list.Count - 1;

            
            while(l < r)
            {
                list[l].next = list[r];
                l++;
                if (l == r)
                    break;
                list[r].next = list[l];
                r--;
            }
            list[l].next = null;
        }

        public void ReorderList3(ListNode head)
        {
            if (head == null || head.next == null)
                return;
            int length = getLentgth(head);
            ListNode firstHead = head;
            ListNode firstTail = head;
            for (int i = 0; i < length/2-1; i++)
            {
                firstTail = firstTail.next;
            }
            ListNode secondHead = firstTail.next;

            // 反轉前先斷開
            firstTail.next = null;
            secondHead = Reverse(secondHead);

            ListNode cur = firstHead;
            firstHead = firstHead.next;
            while (firstHead != null && secondHead != null)
            {
                cur.next = secondHead;
                cur = cur.next;
                secondHead = secondHead.next;

                cur.next = firstHead;
                cur = cur.next;
                firstHead = firstHead.next;
            }

            if (secondHead != null)
                cur.next = secondHead;

            Console.WriteLine();

            int getLentgth(ListNode head)
            {
                int cnt = 0;
                ListNode cur = head;
                while(cur != null)
                {
                    cnt++;
                    cur = cur.next;
                }
                return cnt;
            }

            ListNode Reverse(ListNode head)
            {
                if (head == null || head.next == null)
                    return null;
                ListNode pre = null;
                ListNode cur = head;

                while(cur != null)
                {
                    ListNode next = cur.next;
                    cur.next = pre;
                    pre = cur;
                    cur = next;
                }
                return pre;
            }
        }
    }
}
