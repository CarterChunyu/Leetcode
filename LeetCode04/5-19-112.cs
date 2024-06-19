using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_19_112
    {
        // 羽
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if(root == null) 
                return false;

            HashSet<int> set = new HashSet<int>();
            PathSum(root, 0);
            return set.Contains(targetSum);

            // ☆☆☆☆☆☆☆☆☆☆☆☆☆ 遞規方法一旦 return 就結束遞歸調用, 所以遍歷方法不會出現 return
            void PathSum(TreeNode node, int sum)
            {
                sum += node.val;
                if (node.left == null && node.right == null)
                {
                    set.Add(sum);
                }
                if(node.left != null)
                    PathSum(node.left, sum);
                if(node.right!= null)
                    PathSum(node.right, sum);
            }
        }

        public bool HasPathSum1(TreeNode root, int targetSum)
        {
            if (root == null)
                return false;
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);
            Queue<int> sumQueue
                = new Queue<int>();
            sumQueue.Enqueue(root.val);
            while(nodeQueue.Count > 0)
            {
                int size = nodeQueue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = nodeQueue.Dequeue();
                    int sum = sumQueue.Dequeue();
                    if (node.left == null && node.right == null && sum == targetSum)
                        return true;
                    if(node.left != null)
                    {
                        nodeQueue.Enqueue(node.left);
                        sumQueue.Enqueue(sum + node.left.val);
                    }
                    if (node.right != null)
                    {
                        nodeQueue.Enqueue(node.right);
                        sumQueue.Enqueue(sum + node.right.val);
                    }
                }
            }
            return false;
        }
    }
}
