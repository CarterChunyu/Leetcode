using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode02
{
    public class _3_09_454
    {
        // O(N^4) 一定超時
        public int FourSumCount1(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {

            int cnt = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    for (int k = 0; k < nums3.Length; k++)
                    {
                        for (int l = 0; l < nums4.Length; l++)
                        {
                            if (nums1[i] + nums2[j] + nums3[k] + nums4[l] == 0)
                                cnt++;
                        }
                    }
                }
            }
            return cnt;
        }

        // 利用查找表來解
        public int FourSumCount2(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            Dictionary<int,int> map1 = new Dictionary<int,int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    int sum = nums1[i] + nums2[j];
                    if (map1.ContainsKey(sum))
                        map1[sum]++;
                    else
                        map1[sum] = 1;
                }
            }

            Dictionary<int, int> map2 = new Dictionary<int, int>();
            for (int i = 0; i < nums3.Length; i++)
            {
                for (int j = 0; j < nums4.Length; j++)
                {
                    int sum = nums3[i] + nums4[j];
                    if (map2.ContainsKey(sum))
                        map2[sum]++;
                    else
                        map2[sum] = 1;
                }
            }

            int cnt = 0;
            foreach (var item in map1)
            {
                int target = -item.Key;
                if (map2.ContainsKey(target))
                    cnt += item.Value * map2[target];
            }
            return cnt;
        }

        public int FourSumCount3(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            Dictionary<int, int> map1 = new Dictionary<int, int>();
            for (int i = 0; i < nums3.Length; i++)
            {
                for (int j = 0; j < nums4.Length; j++)
                {
                    int sum = nums3[i] + nums4[j];
                    if (map1.ContainsKey(sum))
                        map1[sum]++;
                    else
                        map1[sum] = 1;
                }
            }

            int cnt = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    int target = -(nums1[i] + nums2[j]);
                    if (map1.ContainsKey(target))
                        cnt += map1[target];
                }
            }
            return cnt; 
        }
    }
}
