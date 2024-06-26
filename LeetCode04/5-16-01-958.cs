using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_16_01_958
    {
        // 不需要跑 for循環
        public bool IsCompleteTree3(TreeNode root)
        {
            if (root == null)
                return true;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool hasNull = false;
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node.left == null)
                    hasNull = true;
                else
                {
                    if (hasNull)
                        return false;
                    else
                        queue.Enqueue(node.left);
                }
                if (node.right == null)
                    hasNull = true;
                else
                {
                    if (hasNull)
                        return false;
                    else
                        queue.Enqueue(node.right);
                }
            }
            return true;
        }

        public bool IsCompleteTree4(TreeNode root)
        {
            if (root == null)
                return true;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool hasNull = false;
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node == null)
                    hasNull = true;
                else if (hasNull)
                    return false;
                if (node != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            return true;
        }

        // 羽
        public bool IsCompleteTree1(TreeNode root)
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
                    if (node.right == null)
                        nodeNotFull = true;
                    else
                    {
                        if (nodeNotFull)
                            return false;
                        queue.Enqueue(node.right);
                    }
                }
            }
            return true;
        }


        // 空的也塞入
        public bool IsCompleteTree2(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool hasEmptyNode = false;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node == null)
                    {
                        hasEmptyNode = true;
                        continue;
                    }
                    else
                    {
                        if (hasEmptyNode)
                            return false;
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                    }
                }
            }
            return true;
        }
    }
}
