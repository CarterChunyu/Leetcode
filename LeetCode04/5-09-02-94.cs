using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_09_02_94
    {
        public IList<int> InorderTraversal1(TreeNode root)
        {
            IList<int> list = new List<int>();
            InOrder(root);
            return list;

            void InOrder(TreeNode node)
            {
                if (node == null)
                    return;
                InOrder(node.left);
                list.Add(node.val);
                InOrder(node.right);
            }
        }

        public IList<int> InorderTraversal2(TreeNode root)
        {
            IList<int> list = new List<int>();
            InOrder(root);
            return list;

            void InOrder(TreeNode node)
            {
                if (node == null)
                    return;
                InOrder(node.left);
                list.Add(node.val);
                InOrder(node.right);
            }
        }
        public IList<int> InorderTraversal3(TreeNode root)
        {
            IList<int> res = new List<int>();
            if (root == null)
                return res;
            Stack<Command> stack = new Stack<Command>();
            stack.Push(new Command("go",root));

            while(stack.Count > 0)
            {
                Command command = stack.Pop();
                TreeNode node = command.node;
                if (command.s == "do")
                    res.Add(node.val);
                else
                {
                    if (node.right != null)
                        stack.Push(new Command("go", node.right));
                    stack.Push(new Command("do", node));
                    if (node.left != null)
                        stack.Push(new Command("go", node.left));
                }
            }
            return res;
        }

        private class Command
        {
            public string s; // go, do
            public TreeNode node;

            public Command(string s, TreeNode node)
            {
                this.s = s;
                this.node = node;
            }
        }
    }

    
}
