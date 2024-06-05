using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    public class _4_04_142
    {
        public ListNode DetectCycle(ListNode head)
        {
            HashSet<ListNode> hashSet = new HashSet<ListNode>();

            ListNode cur = head; 
            while (cur != null)
            {
                if (!hashSet.Add(cur))
                    return cur;
                cur = cur.next;
            }
            return null;
        }
    }
}
