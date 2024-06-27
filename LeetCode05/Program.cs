namespace LeetCode05 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                bool[] x11 = new bool[1];
                Console.WriteLine(x11[0]);

                int[] nums = new int[] { 1,1,2 };
                var x = new _6_9_47().PermuteUnique(nums);
                Console.WriteLine(new _6_2_78().Print(x));
            }
        }

        // 經典遞歸例子 前 n 項之和

        // 用遞歸算法實現函數: int Sum( int n); 
        // 比如 Sum(1) 返回 1 解釋: 1
        // 比如 Sum(2) 返回 3 解釋: 1 + 2 = 3
        // 比如 Sum(3) 返回 6 解釋: 1 + 2 + 3 = 6
        // 比如 Sum(4) 返回 10 解釋: 1 + 2 + 3 + 4 = 10

        // Sum(4) = 4 + Sum(3)
        // Sum(3) = 3 + Sum(2)
        // Sum(2) = 2 + Sum(1)
        // Sum(1) = 1
        
        //        / 1 (n == 1)
        // Sum(n) 
        //        \ n + Sum(n-1) (n > 1)

        // 遞歸
        // 代碼特點:
        // 一個函數內部調用自己
        // 函數內部的代碼是相同的, 只是針對參數不同, 處理的結果不同
        // 當參數滿足一個條件時, 函數不在執行, 這個非常重要: 通常被稱為遞歸的出口, 否則出現死循環!

        // 明白一個函數的作用並相信它能完成這個任務, 千萬不要跳進這個函數裡面企圖研究更多細節, 否則
        // 就會陷入無窮的細節無法自拔, 人腦能壓幾個棧啊 :)
       

        // 計算 1+2+3+4+...+n 的和
        public int Sum(int n)
        {
            if (n == 1)
                return 1;
            return n + Sum(n - 1);
        }
    }
}