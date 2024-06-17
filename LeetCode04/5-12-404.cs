using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_12_404
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            int sum = 0;
            InOrder(root, false);
            return sum;
            void InOrder(TreeNode root, bool IsLeft)
            {
                if(root== null) 
                    return;
                InOrder(root.left, true);
                if (IsLeft && root.left == null && root.right == null)
                    sum += root.val;
                InOrder(root.right, false);
            }
        }

        
    }
}
