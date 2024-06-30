namespace Leetcode7_Recursion_Easy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ListNode oneNode = new ListNode(1, null);
            ListNode twoNode = new ListNode(2, null);
            ListNode threeNode = new ListNode(4, null);
            oneNode.next = twoNode;
            twoNode.next = threeNode;

            ListNode fourNode = new ListNode(1, null);
            ListNode fiveNode = new ListNode(3, null);
            ListNode sixNode = new ListNode(4, null);
            fourNode.next = fiveNode;
            fiveNode.next = sixNode;

            new Program().MergeTwoLists(oneNode, fourNode);
        }


        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;

            ListNode dummyNode = new ListNode(-1, null);
            ListNode cur = dummyNode;
            ListNode cur1 = list1;
            ListNode cur2 = list2;
            if(list1.val <= list2.val)
            {
                dummyNode.next = list1;
                cur = cur.next;
                cur1 = cur1.next;
            }
            else
            {
                dummyNode.next = list2;
                cur = cur.next;
                cur2 = cur2.next;
            }

            while(cur1 != null && cur2!= null)
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
                    cur2 = cur2.next;
                }
            }

            while(cur1!= null)
            {
                cur.next = cur1;
                cur = cur.next;
                cur1 = cur1.next;
            }

            while (cur2 != null)
            {
                cur.next = cur2;
                cur = cur.next;
                cur1 = cur2.next;
            }

            return dummyNode.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val, ListNode next)
        {
            this.val = val;
            this.next = next;
        }
    }
}