using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_5_88
    {
        public void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            // 先放入尾部
            for (int i = 0; i < n; i++)
            {
                nums1[m + i] = nums2[i];
            }

            // 排序 
            for (int i = 1; i < m + n; i++)
            {
                int c = nums1[i];
                int index = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (c < nums1[j])
                    {
                        nums1[j + 1] = nums1[j];
                        index = j;
                    }
                    else
                        break;
                }
                nums1[index] = c;
            }
        }

        // 類似 merge sort
        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int[] temp = new int[m + n];
            int i = 0; // nums1
            int j = 0; // nums2
            int k = 0; // temp

            while(k < m + n)
            {
                if(i<m & j< n)
                {
                    if (nums1[i] < nums2[j])
                        temp[k++] = nums1[i++];
                    else
                        temp[k++] = nums2[j++];                    
                }
                else if (i < m)
                    temp[k++] = nums1[i++];
                else if(j<n)
                    temp[k++] = nums2[j++]; 
            }
            for (int l = 0; l <m+n; l++)
            {
                nums1[l] = temp[l];
            }
        }

        // 類似插入排序
        public void Merge3(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int c = nums2[i];
                int index = m + i;
                for (int j = m + i - 1; j >= 0; j--)
                {
                    if (c < nums1[j])
                    {
                        nums1[j + 1] = nums1[j];
                        index = j;
                    }
                    else
                        break;
                }
                nums1[index] = c;

            }

        }
    }
}