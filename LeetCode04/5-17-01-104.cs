using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_17_01_104
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return 1 + Math.Max(MaxDepth(root.left),MaxDepth(root.right));
        }
    }
}
