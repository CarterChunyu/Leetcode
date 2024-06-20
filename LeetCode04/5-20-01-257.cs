using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode04
{
    public class _5_20_01_257
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> paths = new List<string>();
            PreOrder(root, string.Empty);
            return paths;

            void PreOrder(TreeNode node, string path)
            {
                // 
                string tempPath = path;
                if (node == null)
                    return;
                if (node.left == null && node.right == null)
                    paths.Add($"{path}{node.val}");
                else                    
                    tempPath += $"{node.val}->";
                // ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ 
                // 雖然 String 為引用類型, 但是 string 對象是不可改變的(只可以讀), 所以一旦創建了該對象,
                // 就不能修改該對象值。 有時看似修改了, 實際上是 string 經過了特殊處理, 每次改變值時, 
                // 都會建立一個新的 string 對象, 變量會指向這個新的對象, 而原來的變量還是指向原對象
                PreOrder(node.left, tempPath);
                PreOrder(node.right, tempPath);
            }
            
        }

        public IList<string> BinaryTreePaths1(TreeNode root)
        {
            IList<string> paths = new List<string>();
            if (root == null)
                return paths;
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);
            Queue<string> pathQueue = new Queue<string>();
            pathQueue.Enqueue($"{root.val}");
            while( nodeQueue.Count > 0 )
            {
                int size = nodeQueue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = nodeQueue.Dequeue();
                    string path = pathQueue.Dequeue();
                    if (node.left == null && node.right == null)
                    {
                        paths.Add(path);
                    }


                    if(node.left != null)
                    {
                        nodeQueue.Enqueue(node.left);
                        pathQueue.Enqueue($"{path}->{node.left.val}");
                    }
                    if(node.right != null)
                    {
                        nodeQueue.Enqueue(node.right);
                        pathQueue.Enqueue($"{path}->{node.right.val}");
                    }
                }
            }
            return paths;
        }
    }
}
