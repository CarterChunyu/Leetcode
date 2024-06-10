using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    public class _4_08_LCR_021
    {
        // 羽 
        public ListNode RemoveNthFromEnd1(ListNode head, int n)
        {
            ListNode cur = head;
            int cnt = 0;
            while(cur!= null)
            {
                cnt++;
                cur = cur.next;
            }
            if (cnt == n)
                return head.next;
           
            ListNode fast = head;
            ListNode slow = head;
            for (int i = 0; i <= n; i++)
            {
                fast = fast.next;
            }


            while(fast != null)
            {
                cnt++;
                fast= fast.next;
                slow= slow.next;
            }           
            slow.next = slow.next.next;
            return head;
        }

        // 虛擬頭節點
        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            ListNode dummyNode = new ListNode(-1, head);
            int len = Length(head);
            // 要刪除節點的上一個節點
            ListNode cur = dummyNode;
            for (int i = 0; i < len-n; i++)
            {
                cur = cur.next;
            }
            cur.next = cur.next.next;
            return dummyNode.next;

            int Length(ListNode head)
            {
                int cnt = 0;
                ListNode cur = head;
                while( cur!= null)
                {
                    cnt++;
                    cur = cur.next;
                }
                return cnt;
            }
        }
    }
}
