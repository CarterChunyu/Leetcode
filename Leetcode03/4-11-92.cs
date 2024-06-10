using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    public class _4_11_92
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            List<ListNode> list1 = new List<ListNode>();
            List<ListNode> list2 = new List<ListNode>();
            List<ListNode> list3 = new List<ListNode>();

            ListNode cur = head; 
            for (int i = 0; i < left-1; i++)
            {
                list1.Add(cur);
                cur = cur.next;
            }
            for (int i = left; i < right; i++)
            {
                list2.Add(cur);
                cur = cur.next;
            }
            for (ListNode i = cur; i != null ; i= i.next)
            {
                list3.Add(i);
            }

            ListNode pre = null;
            cur = head;

            for (int i = 1; i < list1.Count; i++)
            {
                cur.next = list1[i];
                pre = cur;
                cur= cur.next;
            }
            pre.next = list2[list2.Count - 1];
            for (int i = list2.Count-2; i >=0 ; i--)
            {
                cur.next = list2[i];
                pre = cur;
                cur= cur.next;
            }
            pre.next = list3[0];
            for (int i = 1; i < list3.Count; i++)
            {
                cur.next = list1[i];
                pre = cur;
                cur = cur.next;
            }
            return head;
        }
    }
}
