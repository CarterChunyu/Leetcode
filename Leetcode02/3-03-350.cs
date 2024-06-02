using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode02
{
    public class _3_03_350
    {
        // 羽
        public int[] Intersect1(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            int i = 0;
            int j = 0;
            List<int> ans = new List<int>();

            // ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            // nums1 或 nums2 的指針在小於時都做 i++ j++, 如果其中一個指針以達到邊界代表已經沒有數字匹配,自動結束循環
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                    i++;
                else if (nums1[i] > nums2[j])
                    j++;
                else //nums1[i] == nums1[j]
                {
                    ans.Add(nums1[i]);
                    i++;
                    j++;
                }
            }

            return ans.ToArray();
        }

        public int[] Intersect2(int[] nums1, int[] nums2)
        {
            Dictionary<int,int> dic = new Dictionary<int,int>();

            foreach (int num in nums1)
            {
                if (dic.ContainsKey(num))
                    dic[num] = dic[num] + 1;
                else
                    dic.Add(num, 1);
            }

            List<int> ans = new List<int>();
            foreach (int num in nums2)
            {
                if (dic.ContainsKey(num) && dic[num] > 0)
                {
                    ans.Add(num);
                    dic[num] = dic[num] - 1;
                }                    
            }
            return ans.ToArray();
        }
    }
}
