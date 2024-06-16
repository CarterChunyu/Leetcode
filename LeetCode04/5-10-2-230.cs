using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_10_2_230
    {
        public int KthSmallest(TreeNode root, int k)
        {
            List<int> list = new List<int>();
            InOrder(root);
            return list[k - 1];

            void InOrder(TreeNode node)
            {
                if(node == null || list.Count>=k) 
                    return;
                InOrder(node.left);
                list.Add(node.val);
                InOrder(node.right);
            }
        }

        public int KthSmallest2(TreeNode root, int k)
        {
            Stack<Command> stack = new Stack<Command>();
            stack.Push(new Command("go", root));
            int index = 0;
            while(stack.Count > 0)
            {
                Command command = stack.Pop();
                TreeNode node = command.node;
                if(command.s == "do")
                {
                    index++;
                    if (index == k)
                        return command.node.val;
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
            return -1;
        }
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
