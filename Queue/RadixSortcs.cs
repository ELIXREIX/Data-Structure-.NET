using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class RadixSort
    {
        public static void Sort(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
            {
                // Nothing to sort
                return;
            }

            int max = FindMax(arr);

            // Perform counting sort for each digit place (ones, tens, hundreds, etc.)
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSortByDigit(arr, exp);
            }
        }

        private static int FindMax(int[] arr)
        {
            int max = int.MinValue;
            foreach (int num in arr)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }

        private static void CountingSortByDigit(int[] arr, int exp)
        {
            const int radix = 10; // Base 10

            int n = arr.Length;
            var output = new int[n];

            // Initialize queues for each digit (0-9)
            var digitQueues = new ArrayQueue[radix];
            for (int i = 0; i < radix; i++)
            {
                digitQueues[i] = new ArrayQueue(n);
            }

            // Distribute elements into queues based on the current digit
            for (int i = 0; i < n; i++)
            {
                int digit = (arr[i] / exp) % radix;
                digitQueues[digit].enqueue(arr[i]);
            }

            // Gather elements from queues back into the array
            int k = 0;
            for (int i = 0; i < radix; i++)
            {
                while (!digitQueues[i].isEmpty())
                {
                    arr[k++] = (int)digitQueues[i].dequeue();
                }
            }
        }
    }
}
