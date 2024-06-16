using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_11_173
    {
        public class BSTIterator
        {
            private List<int> list = new List<int>();
            private int index = 0;
            public BSTIterator(TreeNode root)
            {
                InOrder(root);
            }

            public int Next()
            {
                //int num = list[index];
                //index++;
                //return num;

                return list[index++];
            }

            public bool HasNext()
            {
                return index < list.Count;
            }

            private void InOrder(TreeNode root)
            {
                if (root == null)
                    return;
                InOrder(root.left);
                list.Add(root.val);
                InOrder(root.right);
            }
        }
    }
}
