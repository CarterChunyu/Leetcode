using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_15_02_103
    {
        // 羽
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;
            
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool isLeft = true;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                IList<int> list = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    list.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if(node.right!=null)
                        queue.Enqueue(node.right);
                }
                list = isLeft ? list : list.Reverse().ToList();
                res.Add(list);
                isLeft = !isLeft;
            }
            return res;
        }
    }
}
