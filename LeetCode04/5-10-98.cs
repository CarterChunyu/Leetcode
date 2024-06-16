using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_10_98
    {
        // 羽
        public bool IsValidBST1(TreeNode root)
        {
            List<int> list = new List<int>();
            InOrder(root);
            for (int i = 0; i < list.Count-1; i++)
            {
                if (list[i] >= list[i+1])
                    return false;
            }
            return true;

            void InOrder(TreeNode root)
            {
                if (root == null)
                    return;
                InOrder(root.left);
                list.Add(root.val);
                InOrder(root.right);
            }
        }

        public bool IsValidBST2(TreeNode root)
        {
            Stack<Command> stack = new Stack<Command>();
            stack.Push(new Command("go", root));

            long val = long.MinValue;
            while(stack.Count > 0)
            {
                Command command = stack.Pop();
                TreeNode node = command.node;

                if (command.s == "do" )
                {
                    if (val >= node.val)
                        return false;
                    else
                        val = node.val;
                }
                else
                {
                    if (node.right != null)
                        stack.Push(new Command("go", node.right));
                    stack.Push(new Command("do", node));
                    if (node.left != null)
                        stack.Push(new Command("go", node.left));
                }
            }
            return true;
        }

        public bool IsValidBST3(TreeNode root)
        {
            Stack<Command> stack = new Stack<Command>();
            stack.Push(new Command("go", root));

            int? val = null;
            while (stack.Count > 0)
            {
                Command command = stack.Pop();
                TreeNode node = command.node;

                if (command.s == "do")
                {
                    if (val == null)
                        val = node.val;
                    else
                    {
                        if (val >= node.val)
                            return false;
                        else
                            val = node.val;
                    }
                }
                else
                {
                    if (node.right != null)
                        stack.Push(new Command("go", node.right));
                    stack.Push(new Command("do", node));
                    if (node.left != null)
                        stack.Push(new Command("go", node.left));
                }
            }
            return true;
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
