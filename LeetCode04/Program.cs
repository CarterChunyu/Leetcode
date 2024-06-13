using System.IO.Pipes;

namespace LeetCode04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            {
                //        8
                //      /   \
                //     4     12
                //    / \   /  \
                //   2   6 10  14

                TreeNode eightNode = new TreeNode(8,null,null);
                TreeNode fourNode = new TreeNode(4, null, null);
                TreeNode twelveNode = new TreeNode(12, null, null);
                TreeNode twoNode = new TreeNode(2, null, null);
                TreeNode sixNode = new TreeNode(6, null, null);
                TreeNode tenNode = new TreeNode(10, null, null);
                TreeNode fourteenNode = new TreeNode(14, null, null);

                eightNode.left = fourNode;
                eightNode.right = twelveNode;
                fourNode.left = twoNode;
                fourNode.right = sixNode;
                twelveNode.left = tenNode;
                twelveNode.right = fourteenNode;

                // 前序
                PreOrderRecursion(eightNode);
                Console.WriteLine();
                PreOrder(eightNode);
                Console.WriteLine(); 

                // 中序
                InOrderRecursion(eightNode);
                Console.WriteLine();
                InOrder(eightNode);
                Console.WriteLine();

                // 後序
                PostOrderRecursion(eightNode);
                Console.WriteLine();
                PostOrder(eightNode);
                Console.WriteLine();

                // 前序
                PreOrder1(eightNode);
                Console.WriteLine();
            }
            #endregion
        }

        // 前序遍歷: 對於每一個節點都遵循根做右進行訪問
        public static void PreOrderRecursion(TreeNode root)
        {
            if(root == null) 
                return;
            Console.Write ($"{root.val} ");
            PreOrderRecursion(root.left); 
            PreOrderRecursion(root.right);
        }

        // 前序遍歷 -- 疊代 -- stack
        public static void PreOrder(TreeNode root)
        {
            if (root == null)
                return;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while(stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                Console.Write($"{node.val} ");
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }
        }

        // 前序遍歷 -- 疊代 -- queue 錯誤 -- 右節點會比做節點還優先遍歷不符合 根左右的規則
        //public static void PreOrder1(TreeNode root)
        //{
        //    if (root == null)
        //        return;
        //    Queue<TreeNode> queue = new Queue<TreeNode>();
        //    queue.Enqueue(root);
        //    while(queue.Count > 0)
        //    {
        //        TreeNode node =  queue.Dequeue();
        //        Console.Write($"{node.val} ");
        //        if(node.left != null)
        //            queue.Enqueue(node.left);
        //        if(node.right != null)
        //            queue.Enqueue(node.right);
        //    }
        //}

        // 中序遍歷: 對於每一個節點都遵循左根右進行訪問
        public static void InOrderRecursion(TreeNode root)
        {
            if (root == null)
                return;
            InOrderRecursion(root.left);
            Console.Write($"{root.val} ");
            InOrderRecursion(root.right);
        }  

        // 中序遍歷 -- 疊代
        public static void InOrder(TreeNode root)
        {
            if (root == null)
                return;

            TreeNode cur = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while(stack.Count >0 || cur != null)
            {
                while(cur!= null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                TreeNode node = stack.Pop();
                Console.Write($"{node.val} ");
                if (node.right != null)
                    cur = node.right;
            }
        }

        // 後序遍歷: 對於每一個節點都遵循左右根進行訪問
        public static void PostOrderRecursion(TreeNode root)
        {
            if (root == null)
                return;
            PostOrderRecursion(root.left);
            PostOrderRecursion(root.right);
            Console.Write($"{root.val} "); 
        }

        // 後序遍歷 -- 疊代
        public static void PostOrder(TreeNode root)
        {
            if (root == null)
                return;
            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();

            stack1.Push(root);
            while(stack1.Count != 0)
            {
                TreeNode node = stack1.Pop();
                stack2.Push(node);
                if (node.left != null)
                    stack1.Push(node.left);
                if(node.right != null)
                    stack1.Push(node.right);                
            }
            while(stack2.Count!= 0)
            {
                TreeNode node = stack2.Pop();
                Console.Write($"{node.val} ");
            }
        }

        private class Command
        {
            public string s;  // go, do
            public TreeNode node;

            public Command(string s, TreeNode node)
            {
                this.s = s;
                this.node = node;
            }
        }

        // 前序
        public static void PreOrder1(TreeNode root)
        {
            if (root == null)
                return;
            Stack<Command> stack = new Stack<Command>();
            stack.Push(new Command("go", root));
            
            while(stack.Count != 0)
            {
                Command command = stack.Pop();
                if(command.s == "do")
                    Console.Write($"{command.node.val} ");
                else
                {
                    if (command.node.right != null)
                        stack.Push(new Command("go", command.node.right));
                    if (command.node.left != null)
                        stack.Push(new Command("go", command.node.left));
                    stack.Push(new Command("do", command.node));
                }
            }
            
        } 
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

    }
}