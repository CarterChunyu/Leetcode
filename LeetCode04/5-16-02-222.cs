using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_16_02_222
    {
        public int CountNodes(TreeNode root)
        {
            int cnt = 0;
            PreOrder(root);
            return cnt;

            void PreOrder(TreeNode node)
            {
                if (node == null)
                    return;
                cnt++;
                PreOrder(node.left);
                PreOrder(node.right);
            }
        }

    }
}

