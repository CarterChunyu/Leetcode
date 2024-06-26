using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_09_03_145
    {
        public IList<int> PostorderTraversal1(TreeNode root)
        {
            IList<int> list = new List<int>();
            PostOrder(root);
            return list;

            void PostOrder(TreeNode node)
            {
                if (node == null)
                    return;
                PostOrder(node.left);
                PostOrder(node.right);
                list.Add(node.val);
            }
        }

        public IList<int> PostorderTraversal2(TreeNode root)
        {
            IList<int> res = new List<int>();
            if (root == null)
                return res;

            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            stack1.Push(root);

            while(stack1.Count > 0)
            {
                TreeNode node = stack1.Pop();
                stack2.Push(node);
                if (node.left != null)
                    stack1.Push(node.left);
                if (node.right != null)
                    stack1.Push(node.right);
            }

            while(stack2.Count >0)
            {
                TreeNode node = stack2.Pop();
                res.Add(node.val);
            }

            return res;
        }

        public IList<int> PostorderTraversal3(TreeNode root)
        {
            IList<int> res = new List<int>();
            if (root == null)
                return res;
            Stack<Command> stack = new Stack<Command>();
            stack.Push(new Command("go", root));
            while (stack.Count > 0) 
            {
                Command command = stack.Pop();
                TreeNode node = command.node;
                stack.Push(new Command("do", node));
                if (node.right != null)
                    stack.Push(new Command("go", node.right));
                if (node.left != null)
                    stack.Push(new Command("go", node.left));
            }
            return res;

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
