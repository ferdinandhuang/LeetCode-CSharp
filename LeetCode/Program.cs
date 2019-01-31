using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var ret = solution.FindMedianSortedArrays(new int[] { 2 }, new int[] {  });

            Console.WriteLine("Hello World!");
        }

        static double Average(int left, int right) => ((double)(left + right)) / 2;

        public double FindMedianSortedArrays(int[] left, int[] right)
        {
            var merged = merge(left, right);
            int centerIndex = merged.Length / 2;
            return merged.Length % 2 == 0
                ? Average(merged[centerIndex], merged[centerIndex - 1])
                : merged[centerIndex];
        }

        static int[] merge(int[] left, int[] right)
        {
            int i = 0;
            int j = 0;
            var result = new int[left.Length + right.Length];
            while (i < left.Length && j < right.Length)
            {
                result[i + j] = left[i] < right[j] ? left[i++] : right[j++];
            }
            if (i < left.Length)
            {
                Array.ConstrainedCopy(
                    sourceArray: left,
                    sourceIndex: i,
                    destinationArray: result,
                    destinationIndex: i + j,
                    length: left.Length - i
                );
            }
            else if (j < right.Length)
            {
                Array.ConstrainedCopy(
                    sourceArray: right,
                    sourceIndex: j,
                    destinationArray: result,
                    destinationIndex: i + j,
                    length: right.Length - j
                );
            }
            return result;
        }
    }
}
