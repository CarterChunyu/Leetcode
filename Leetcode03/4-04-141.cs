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
    public class _4_04_141
    {
        public bool HasCycle1  (ListNode head)
        {
            // 即便鏈表中的 Val 相同, 他們的記憶體位置也不同, 可以利用集合 HashSet的去重特性做
            HashSet<ListNode> set = new HashSet<ListNode>();
            ListNode cur = head;
            
            while(cur != null)
            {
                if (!set.Add(cur))
                {
                    return true;
                }
                cur = cur.next;
            }
            return false;
        }

        // 快慢指針 龜兔賽跑烏龜和兔子重逢代表有環
        public bool HasCycle2 (ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (fast == slow)
                    return true;
            }

            return false; 
        }
    }
}
