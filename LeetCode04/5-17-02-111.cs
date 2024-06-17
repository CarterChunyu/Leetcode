using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_17_02_111
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt = 0;
            while (queue.Count > 0)
            {
                cnt++;
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left == null && node.right == null)
                        return cnt;
                    if(node.left!= null)
                        queue.Enqueue(node.left);
                    if(node.right!= null)
                        queue.Enqueue(node.right);
                }
            }
            return cnt;
        }
    }
}
