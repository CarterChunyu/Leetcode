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
        public ListNode ReverseList1(ListNode head)
        {
            List<ListNode> list = new List<ListNode>();
            ListNode cur = head;
            while(cur != null)
            {
                list.Add(cur);
                cur = cur.next;
            }
            ListNode dummyNode = new ListNode(-1, null);
            cur = dummyNode;
            for (int i = list.Count-1; i >=0 ; i--)
            {
                cur.next = list[i];
                cur = list[i] ;
            }
            //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ 末尾必須指向空否則有環 
            cur.next = null ;
            return dummyNode.next;
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
