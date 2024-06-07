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
        //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        // 因為數組

        // 羽
        public ListNode RemoveElements1(ListNode head, int val)
        {
            //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            // 因為鏈表的節點都是 引用類型, 複製的是他的指向物件的參考位址, 其實 head cur pre 指向同一個物件。
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
                else
                {
                    pre = cur;
                    cur = cur.next;
                }
            }
            return head;
        }

        public ListNode RemoveElements2(ListNode head, int val)
        {


            while(head != null && head.val == val)
            {
                head = head.next;
            }


            //if (head == null)
            //    return null;

            ListNode cur = head;

            while(cur!= null && cur.next!= null)
            {
                if (cur.next.val == val)
                {
                    // ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                    // 跳過等於 val 的節點, 不需要移動到下一個節點, 因為需要檢查當前下一個節點是否也等於 val 
                    cur.next = cur.next.next;
                }
                else
                    cur = cur.next;

            }

            return head;
        }

        // 虛擬頭節點
        public ListNode RemoveElements3(ListNode head, int val)
        {
            //if (head == null)
            //    return null;

            ListNode dummyNode = new ListNode(-1, head);
            ListNode cur = dummyNode;

            while(cur!= null && cur.next!= null)
            {
                if(cur.next.val == val)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next;
                }
            }
            return dummyNode.next;
        }
    }
}
