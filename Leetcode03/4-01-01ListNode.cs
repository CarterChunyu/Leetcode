using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode03
{
    public class _4_01_01ListNode
    {
        public class ListNode<E>
        {
            public E val;
            public ListNode<E> next;

            public ListNode(E val, ListNode<E> next)
            {
                this.val = val;
                this.next = next;
            }
        }
        public static void Show()
        {
            // 創建鏈表節點
            ListNode<int> oneNode = new ListNode<int>(1, null);
            ListNode<int> twoNode = new ListNode<int>(2, null);
            ListNode<int> threeNode = new ListNode<int>(3, null);
            ListNode<int> fourNode = new ListNode<int>(4, null);
            ListNode<int> fiveNode = new ListNode<int>(5, null);

            // 在鏈表中穿針引線
            oneNode.next = twoNode;
            twoNode.next = threeNode;
            threeNode.next = fourNode;
            fourNode.next = fiveNode;
            fiveNode.next = null;

            // 遍歷鏈表
            for (ListNode<int> i = oneNode; i != null ; i = i.next)
            {
                Console.Write($"{oneNode.val}->");
            }
            Console.WriteLine();

            // 遍歷鏈表
            ListNode<int> cur = oneNode;
            while(cur != null)
            {
                Console.Write($"{cur.val}->");
                cur = cur.next;
            }
            Console.WriteLine();

            Console.WriteLine(GetLen(oneNode));
            Console.WriteLine(GetLen2(oneNode));

            // 刪除頭部節點 2->3->4->5->null
            oneNode.next = null;
            ListNode<int> head = twoNode;
            Cycle(head);

            // 刪除中間四節點 2->3->5->null
            threeNode.next = threeNode.next.next;
            Cycle(head);

            // 刪除尾部節點 2->3->null
            threeNode.next = threeNode.next.next;
            Cycle(head);

            // 刪除總結
            // 刪除頭部節點, 只需要更換新的頭部即可。
            // 刪除中間和緯部節點的操作邏輯是一致的, 需要找到 帶刪除節點 的 前一個節點。 改變前一個節點的指針使它指向 帶刪除節點的 後一個節點 。
            // 由於頭部沒有 前一個節點, 中間和尾部都具備 前一個節點 導致刪除節點邏輯不一致。 後面採用 虛擬頭節點 優化方案。
        }

        // 1->2->3->4->5->null
        // 計算練表長度 返回5
        public static int GetLen(ListNode<int> head)
        {
            int len = 0;
            ListNode<int> cur = head;
            while (cur!= null)
            {
                len++;
                cur = cur.next;
            }
            return len;
        }

        public static int GetLen2(ListNode<int> head)
        {
            int len = 0;
            for (ListNode<int> i = head; i != null ; i = i.next)
            {
                len++;
            }
            return len;
        }

        public static void Cycle(ListNode<int> head)
        {
            for (ListNode<int> i = head; i != null ; i = i.next)
            {
                Console.Write($"{i.val}->");
            }
            Console.WriteLine();
        }
    }
}
