using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeetCode04
{
    public class _5_09_01_144
    {
        public IList<int> PreorderTraversal1(TreeNode root)
        {
            IList<int> list = new List<int>();
            PreorderTraversal1(root, list);
            return list;

            void PreorderTraversal1(TreeNode root, IList<int> list)
            {
                if (root == null)
                    return;
                list.Add(root.val);
                PreorderTraversal1(root.left, list);
                PreorderTraversal1(root.right, list);
            }
        }

        public IList<int> PreorderTraversal2(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null)
                return list;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while(stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                list.Add(node.val);
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);    
            }
            return list;
        }

        public IList<int> PreorderTraversal3(TreeNode root)
        {
            IList<int> list = new List<int>();  
            if (root == null)
                return list;
            Stack<Command> stack = new Stack<Command>();
            stack.Push(new Command("go",root));
            while(stack.Count > 0)
            {
                Command command = stack.Pop();
                TreeNode node = command.node;
                if (command.s == "do")
                    list.Add(node.val);
                else
                {
                    if (node.right != null)
                        stack.Push(new Command("go", node.right));
                    if (node.left != null)
                        stack.Push(new Command("go", node.left));
                    stack.Push(new Command("do", node));
                }
            }
            return list;
        }

        class Command
        {
            public string s;
            public TreeNode node;

            public Command(string s, TreeNode node)
            {
                this.s = s;
                this.node = node;
            }
        }
    }
}
