using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_2_27
    { 
        // [1,2,3,4,5] val = 1
        // [2,3,4,5] val =1
        public int RemoveElement1(int[] nums, int val)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[j] = nums[i];
                    j++;
                }
            }
            return j;
        }

        // [1,2,3,4,5] val = 1
        // [5,2,3,4] val = 1
        // 不在乎順序 可以用對撞指針
        public int RemoveElement2(int[] nums, int val) // 羽
        {
            int i = 0;
            int j = nums.Length;

            while (i < j)
            {
                if (nums[i] == val)
                {
                    j--;
                    nums[i] = nums[j];
                }
                else
                    i++;
            }
            return j;
        }


     
    }
}
