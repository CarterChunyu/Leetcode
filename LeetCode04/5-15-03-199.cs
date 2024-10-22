﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_15_03_199
    {
        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> res = new List<int>();
            if (root == null)
                return res;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if(i==size-1)
                        res.Add(node.val);
                    if(node.left!= null)
                        queue.Enqueue(node.left);
                    if(node.right!= null)
                        queue.Enqueue(node.right);                        
                }
            }
            return res;
        }
    }
}
