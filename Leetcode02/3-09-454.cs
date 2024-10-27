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
            int n = nums1.Length;
            Dictionary<int, int> dic1 = new Dictionary<int, int>();
            Dictionary<int, int> dic2 = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int sum = nums1[i] + nums2[j];
                    if (dic1.ContainsKey(sum))
                        dic1[sum]++;
                    else
                        dic1.Add(sum, 1);

                    int sum2 = nums3[i] + nums4[j];
                    if (dic2.ContainsKey(sum2))
                        dic2[sum2]++;
                    else
                        dic2.Add(sum2, 1);
                }
            }

            int cnt = 0;
            foreach (var d1_key in dic1.Keys)
            {
                if (dic2.ContainsKey(-d1_key))
                    cnt += dic1[d1_key] * dic2[-d1_key];
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
