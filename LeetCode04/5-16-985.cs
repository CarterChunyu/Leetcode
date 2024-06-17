using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_16_985
    {
        public bool IsCompleteTree(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool nodeNotFull = false;
            while (queue.Count > 0)
            {
                int size = queue.Count;                
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left == null)
                        nodeNotFull = true;
                    else
                    {
                        if (nodeNotFull)
                            return false;
                        queue.Enqueue(node.left);
                    }
                    if(node.right == null)
                        nodeNotFull = true;
                    else
                    {
                        if(nodeNotFull)
                            return false;
                        queue.Enqueue(node.right);
                    }
                }
            }
            return true;
        }
    }
}
