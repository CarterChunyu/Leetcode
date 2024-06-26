using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    public class _4_10_206
    {
        // 羽
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode pre = head;
            ListNode cur = head.next;
            // ☆☆☆☆☆☆☆☆☆☆☆☆☆ 末尾必須指向空, 且必須在給變數 cur 賦值之後
            // 否則 cur 會變成 null
            pre.next = null;
            while (cur != null)
            {
                ListNode next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;

        }

        public ListNode ReverseList2(ListNode head)
        {
            if (head == null)
                return null;
            List<ListNode> lists = new List<ListNode>();
            ListNode cur = head;
            while (cur != null)
            {
                lists.Add(cur);
                cur = cur.next;
            }
            for (int i = 0; i < lists.Count; i++)
            {
                if (i == 0)
                    lists[i].next = null;
                else
                    lists[i].next = lists[i-1];
            }
            return lists[lists.Count-1];
        }

        // 三指針 
        public ListNode ReverseList3(ListNode head)
        {
            ListNode pre = null;
            ListNode cur = head;
            ListNode next = null;

            while (cur != null)
            {
                next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }
    }
}
