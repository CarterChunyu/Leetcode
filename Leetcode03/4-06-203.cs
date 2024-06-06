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
    public class _4_06_203
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode cur = head; 
            ListNode pre = null;

            while(cur!= null)
            {
                
                if(cur.val == val)
                {
                    if(pre == null)
                    {
                        cur = cur.next;
                        head = cur;
                    }
                    else
                    {
                        pre.next = pre.next.next;
                        cur = cur.next;
                    }
                }
            }
            return head;
        }
    }
}
