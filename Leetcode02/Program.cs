namespace Leetcode02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 4, 3, 2, 1 };

            new _3_01_217().SelectSort(nums);

            char[] char1 = { 'a', 'b' };
            char[] char2 = { 'a', 'b' };
            Console.WriteLine(char1.GetHashCode());
            Console.WriteLine(char2.GetHashCode());
            Console.WriteLine(char1.SequenceEqual(char2));

            var strs = new string[]{ "eat", "tea", "tan", "ate", "nat", "bat" };
            new _3_05_49().GroupAnagrams2(strs);

            string pattern = "abba";
            string s = "dog cat cat dog";
            new _3_06_290().WordPattern(pattern, s);
        }
    }
}