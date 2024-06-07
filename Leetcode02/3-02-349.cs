using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode02
{
    public class _3_02_349
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            //HashSet<int> set1 = new HashSet<int>();
            //foreach (int i in nums1)
            //    set1.Add(i);
            HashSet<int> set1 = new HashSet<int>(nums1);
            
            HashSet<int> inner = new HashSet<int>();
            foreach(int i in nums2)
            {
                if (set1.Contains(i))
                    inner.Add(i);
            }
            return inner.ToArray();
        }
    }
}
