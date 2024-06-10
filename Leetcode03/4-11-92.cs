using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    public class _4_11_92
    {
        public ListNode ReverseBetween1(ListNode head, int left, int right)
        {
            // 羽
            ListNode firstLastNode = null;
            ListNode twoFirstNode = null;
            ListNode twoLastNode = null;
            ListNode threeFirstNode = null;

            ListNode dummyNode = new ListNode(-1, head);

            ListNode cur = dummyNode;
            for (int i = 0; i < left-1; i++)
            {
                cur = cur.next;
            }
            // ☆☆☆☆☆☆☆☆☆☆☆☆☆☆  一定再出迴圈賦值, 有可能不用盡迴圈
            firstLastNode = cur;
            twoFirstNode = cur.next;
            for (int i = left; i < right+1; i++)
            {
                cur = cur.next;
            }
            twoLastNode = cur;
            threeFirstNode = cur.next;

            ListNode pre = null;
            cur = twoFirstNode;

            ListNode newTwoFirstNode = null;
            ListNode newTwoLastNode = null;
            while(cur != threeFirstNode)
            {
                if (cur == twoFirstNode)
                    newTwoLastNode = cur;
                if (cur == twoLastNode)
                    newTwoFirstNode = cur;
                ListNode next= cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;                
            }

            firstLastNode.next = newTwoFirstNode;
            newTwoLastNode.next = threeFirstNode;

            return dummyNode.next;
        }

        public ListNode ReverseBetween2(ListNode head, int left, int right)
        {
            if (left == right)
                return head;

            ListNode dummyNode = new ListNode(-1, head);
            // 第 1 步: 從虛擬頭節點走 left -1 步, 來到第一段的末尾節點
            ListNode firstLastNode = dummyNode;
            for (int i = 0; i < left-1; i++)
            {
                firstLastNode = firstLastNode.next;
            }
            // 第 2 步: 從虛擬頭節點走 right 步, 來到第二段的末尾節點            
            ListNode secondLastNode = dummyNode;
            for (int i = 0; i < right; i++)
            {
                secondLastNode = secondLastNode.next;
            }
            // 第 3 步: 切斷鏈表分成三部分
            // 在切斷之前, 保存第二段的頭節點和第三段的頭節點
            ListNode secondFirstNode = firstLastNode.next;
            ListNode threeHeadNode = secondLastNode.next;

            firstLastNode.next = null;
            secondLastNode.next = null;

            ListNode tempSecondHead = Reveverse(secondFirstNode);
            firstLastNode.next = tempSecondHead;
            secondFirstNode.next = threeHeadNode;
            return dummyNode.next;

            ListNode Reveverse(ListNode head)
            {
                ListNode pre = null;
                ListNode cur = head;

                while(cur!= null)
                {
                    ListNode next = cur.next;
                    cur.next = pre;
                    pre = cur;
                    cur = next;
                }
                return pre;
            }
        }
     }
}
