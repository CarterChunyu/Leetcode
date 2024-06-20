using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_20_02_113
    {
        // 羽
        public IList<IList<int>> PathSum1(TreeNode root, int targetSum)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;

            PreOrder(root, new Log());
            return res;

            void PreOrder(TreeNode node, Log log)
            {
                // ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                // 注意 引用類型傳遞的是物件存放在系統堆的位址, 必須 new 一個新的
                List<int> path1 = new List<int>(log.Path);
                path1.Add(node.val);
                List<int> path2 = new List<int>(log.Path);
                path2.Add(node.val);
                Log temp1 = new Log(log.Sum + node.val, path1);
                Log temp2 = new Log(log.Sum + node.val, path2);

                if (node.left == null && node.right == null && temp1.Sum == targetSum)
                    res.Add(temp1.Path);
                if (node.left != null)
                    PreOrder(node.left, temp1);
                if (node.right != null)
                    PreOrder(node.right, temp2);
            }
        }

        public IList<IList<int>> PathSum2(TreeNode root, int targetSum)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            Queue<int> sumQueue = new Queue<int>();
            Queue<List<int>> pathQueue = new Queue<List<int>>();
            nodeQueue.Enqueue(root);
            sumQueue.Enqueue(root.val);
            pathQueue.Enqueue(new List<int>() { root.val });

            while (nodeQueue.Count > 0)
            {
                int size = nodeQueue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = nodeQueue.Dequeue();
                    int sum = sumQueue.Dequeue();
                    List<int> path = pathQueue.Dequeue();
                    if (node.left == null && node.right == null && sum == targetSum)
                        res.Add(path);

                    if (node.left != null)
                    {
                        nodeQueue.Enqueue(node.left);
                        sumQueue.Enqueue(sum + node.left.val) ;
                        List<int> list = new List<int>(path);
                        list.Add(node.left.val);
                        pathQueue.Enqueue(list);
                    }
                    if (node.right != null)
                    {
                        nodeQueue.Enqueue(node.right);
                        sumQueue.Enqueue(sum + node.right.val);
                        List<int> list = new List<int>(path);
                        list.Add(node.right.val);
                        pathQueue.Enqueue(list);
                    }
                }
            }
            return res;
        }
        class Log
        {
            public Log(int sum = 0, List<int> path = null)
            {
                this.Sum = sum;
                if (path == null)
                    this.Path = new List<int>();
                else
                    this.Path = path;
            }
            public int Sum { get; set; }

            public List<int> Path { get; set; }
        }
    }
}
