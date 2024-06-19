
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_18_226
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return root;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    // 交換
                    TreeNode temp = node.left;
                    node.left = node.right;
                    node.right = temp;
                    if(node.left!= null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }
            return root;
        }
    }
}
