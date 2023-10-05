using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            
                int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };

                Console.WriteLine("Original Array:");
                PrintArray(arr);

                RadixSort.Sort(arr);

                Console.WriteLine("Sorted Array:");
                PrintArray(arr);
            }

            static void PrintArray(int[] arr)
            {
                foreach (var num in arr)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        
        /*            PriorityQueue q = new LinkedListPriorityQueue();
                    q.enqueue(1);
                    q.enqueue(2);
                    q.enqueue(3);
                    q.enqueue(4);
                    q.enqueue(5);
                    Console.WriteLine(q.dequeue());
                    Console.WriteLine(q.dequeue());
                    Console.WriteLine(q.dequeue());*/
    }
    }

