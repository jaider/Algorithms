using System;

namespace Algorithms.Sorting
{
    public class MergeSort : ISort
    {
        public int[] Sort(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            int[][] ab = Split(array);
            int[] a = ab[0];
            int[] b = ab[1];

            var aSort = Sort(a);
            var bSort = Sort(b);

            return MergeAndSort(aSort, bSort);
        }

        private int[][] Split(int[] array)
        {
            int[] a = new int[array.Length / 2];
            int[] b = new int[(array.Length / 2) + (array.Length % 2)];
            var j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if(i < array.Length / 2)
                {
                    a[i] = array[i];
                }
                else
                {
                    b[j] = array[i];
                    j++;
                }
            }

            return new int[][] { a, b };
        }

        private int[] MergeAndSort(int[] a, int[] b)
        {
            var result = new int[a.Length + b.Length];
            int i = 0, j = 0, r = 0;
            while(i < a.Length && j < b.Length)
            {
                if(a[i] < b[j])
                {
                    result[r] = a[i];
                    i++;
                }
                else
                {
                    result[r] = b[j];
                    j++;
                }

                r++;
            }

            if (i < a.Length)
            {
                for (; i < a.Length; i++, r++)
                {
                    result[r] = a[i];
                }
            }

            if (j < b.Length)
            {
                for (; j < b.Length; j++, r++)
                {
                    result[r] = b[j];
                }
            }

            return result;
        }
    }

    public interface ISort
    {
        int[] Sort(int[] array);
    }
}
