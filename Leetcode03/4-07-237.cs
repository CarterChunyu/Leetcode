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

    public class _4_07_237
    {
        public void DeleteNode(ListNode node)
        {
            ListNode nextNode = node.next;
            node.val = nextNode.val;
            node.next = nextNode.next.next;
        }
    }
}
