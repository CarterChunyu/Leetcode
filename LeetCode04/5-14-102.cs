using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_14_102
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if(root == null)
                return list;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                int size = queue.Count;
                List<int> levelList = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    levelList.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if(node.right != null)
                        queue.Enqueue(node.right);
                }
                list.Add(levelList);
            }
            return list;
        }
    }
}
