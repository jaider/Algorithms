using System.Linq;

namespace Algorithms.Sorting
{
    public class MergeSort2 : ISort
    {
        public int[] Sort(int[] array)
        {
            int[][] splits = Split(array);
            int[] blank = new int[0];
            while (true)
            {
                int[][] temp = new int[splits.Length / 2 + splits.Length % 2][];
                int k = 0;
                for (int i = 0; i < splits.Length; i += 2)
                {
                    var b = blank;
                    if (i + 1 < splits.Length)
                        b = splits[i + 1];
                    temp[k++] = SortAndMerge(splits[i], b);
                }

                splits = temp;

                if (temp.Length == 1)
                    break;
            }

            return splits[0];
        }

        private static int[][] Split(int[] array)
        {
            return array.Select(x => new int[1] { x }).ToArray();
        }

        static int[] SortAndMerge(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            int i = 0, j = 0, k = 0;

            while (i < a.Length && j < b.Length)
            {
                if (a[i] > b[j])
                {
                    c[k++] = b[j++];
                }
                else
                {
                    c[k++] = a[i++];
                }
            }

            while (i < a.Length)
            {
                c[k++] = a[i++];
            }

            while (j < b.Length)
            {
                c[k++] = b[j++];
            }

            return c;
        }
    }
}
