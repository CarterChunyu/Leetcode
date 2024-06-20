using System.ComponentModel;
using System.IO.Pipes;
using System.Net;

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
                // 中序
                InOrder1(eightNode);
                Console.WriteLine();
                // 後序
                PostOrder1(eightNode);
                Console.WriteLine();

                // 層序
                LevelOrder(eightNode);
                Console.WriteLine();

                // 層序收集
                IList<IList<int>> list = LevelCollect(eightNode);
            }
            #endregion

            #region 5-19-112
            {
                TreeNode eightNode = new TreeNode(8, null, null);
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

                new _5_19_112().HasPathSum2(eightNode, 5);
            }
            #endregion
            #region 5-20-01-257
            {
                TreeNode eightNode = new TreeNode(8, null, null);
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

                new _5_20_01_257().BinaryTreePaths1(eightNode);
            }
            #endregion
            #region _5_20_02_113
            {
                TreeNode eightNode = new TreeNode(8, null, null);
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

                new _5_20_02_113().PathSum2(eightNode, 5);
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

        // 中序
        public static void InOrder1(TreeNode root)
        {
            if(root == null) 
                return;
            Stack<Command> stack = new Stack<Command>();
            stack.Push(new Command("go", root));
            while(stack.Count != 0)
            {
                Command command = stack.Pop();
                TreeNode node = command.node;

                if(command.s == "do")
                    Console.Write($"{node.val} ");
                else
                {
                    if (node.right != null)
                        stack.Push(new Command("go", node.right));
                    stack.Push(new Command("do",node));
                    if (node.left != null)
                        stack.Push(new Command("go", node.left));                       
                }
            }
        }
        // 後序
        public static void PostOrder1(TreeNode root)
        {
            if (root == null)
                return;
            Stack<Command> stack = new Stack<Command>();
            stack.Push(new Command("go", root) );

            while(stack.Count != 0)
            {
                Command command = stack.Pop();
                TreeNode node = command.node;
                if(command.s == "do")
                    Console.Write($"{node.val} ");
                else
                {
                    stack.Push(new Command("do", node));
                    if (node.right != null)
                        stack.Push(new Command("go", node.right));
                    if (node.left != null)
                        stack.Push(new Command("go", node.left));
                }        
            }
        }

        // 層序遍歷 -- 廣度優先
        public  static void LevelOrder(TreeNode root)
        {
            if (root == null) 
                return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                Console.Write($"{node.val} ");
                if (node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
            }
        }

        // 層序 -- 按層收集
        public static IList<IList<int>> LevelCollect(TreeNode root)
        {
            IList<IList<int>> list =new List<IList<int>>();
            if (root == null)
                return list;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                List<int> levelList = new List<int>();
                int cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    levelList.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                list.Add(levelList);
            }
            return list;
        }
        class KeyValue
        {
            public TreeNode Key { get; set; }
            public int Value { get; set; }
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