using static Leetcode03._4_01_01ListNode;

namespace Leetcode03
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class Program
    {
        

        static void Main(string[] args)
        {
            #region 4-01
            {
                _4_01_01ListNode.Show();
            }
            #endregion
            #region 4-03
            {
                // 創建鏈表節點
                ListNode oneNode = new ListNode(1, null);
                ListNode twoNode = new ListNode(2, null);
                ListNode threeNode = new ListNode(3, null);
                ListNode fourNode = new ListNode(4, null);
                ListNode fiveNode = new ListNode(5, null);

                // 在鏈表中穿針引線
                oneNode.next = twoNode;
                twoNode.next = threeNode;
                threeNode.next = fourNode;
                fourNode.next = fiveNode;
                fiveNode.next = null;

                // 倒數第三
                int result = new _4_03_().KthToLast2(oneNode, 1);
                Console.WriteLine(result);
            }
            #endregion
        }
    }
}