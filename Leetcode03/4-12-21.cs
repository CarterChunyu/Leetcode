using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    public class _4_12_21
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if(list1 == null)
                return list2;
            if(list2 == null)
                return list1;

            
            ListNode cur1 = list1;
            ListNode cur2 = list2;
            ListNode dummyNode = new ListNode(-1, null);
            ListNode cur = dummyNode;
            if (list1.val <= list2.val)
            {                
                dummyNode.next = list1;
                cur1 = list1.next;               
            }
            else
            {
                dummyNode.next = list2;
                cur2 = list2.next;
            }
            cur = dummyNode.next;
            

            while (cur1 != null || cur2 != null)
            {
                if(cur1 != null && cur2 != null)
                {
                    if(cur1.val <= cur2.val)
                    {
                        cur.next = cur1;
                        cur = cur.next;
                        cur1 = cur1.next;
                    }
                    else
                    {
                        cur.next = cur2;
                        cur = cur.next;
                        cur2 = cur.next;
                    }
                    continue;
                }

                if(cur1 != null)
                {
                    cur.next = cur1;
                    cur = cur.next;
                    cur1 = cur1.next;
                }

                if(cur2 != null)
                {
                    cur.next = cur2;
                    cur = cur.next;
                    cur2 = cur2.next;
                }
            }
            return dummyNode.next;
        }
    }
}
