using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class _2_7_167
    {
        public int[] TwoSum1(int[] numbers, int target)
        {
            int n = numbers.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                        return new int[] { i + 1, j + 1 };
                }
            }
            return new int[] { -1,-1};
        }

        // 利用有序性 做二分查找
        public int[] TwoSum2(int[] numbers, int target)
        {
            for (int i = 0; i <numbers.Length; i++)
            {
                int search = target - numbers[i];
                int l = i + 1;
                int r = numbers.Length - 1;
                while (l <= r)
                {
                    int mid = (r - l) / 2 + l;
                    if (search == numbers[mid])
                        return new int[] { i + 1, mid + 1 };
                    else if (search < numbers[mid])
                        r = mid - 1;
                    else 
                        l = mid + 1;
                }
            }
            return new int[] { -1, -1 };
        }

        // 雙指針 
        public int[] TwoSum3(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length-1;

            while (l <= r)
            {
                if (numbers[l] + numbers[r] < target)
                    r--;
                else if (numbers[l] + numbers[r] > target)
                    l++;
                else
                    return new int[] { l + 1, r + 1 };
            }
            return new int[] { -1, -1 };
        }
    }
}
