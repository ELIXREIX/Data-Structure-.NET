using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forhuff
{
    public class HuffmanTree : BinaryTree, IComparable
    {
        public HuffmanTree(char character, int frequency, Node left, Node right) : base(new Node(character, frequency))
        {
        }

        public int CompareTo(object x)
        {
            return Frequency() - ((HuffmanTree)x).Frequency();
        }

        public int Frequency()
        {
            return root.Frequency;
        }

        public static HuffmanTree Encode(int[] frequencies)
        {
            var h = new BinaryMinHeap(0);
            for (int i = 0; i < frequencies.Length; i++)
            {
                h.Enqueue(new HuffmanTree((char)('A' + i), frequencies[i], null, null));
            }

            for (int i = 0; i < frequencies.Length - 1; i++)
            {
                HuffmanTree t1 = (HuffmanTree)h.Dequeue();
                HuffmanTree t2 = (HuffmanTree)h.Dequeue();
                int sumFrequency = t1.Frequency() + t2.Frequency();
                h.Enqueue(new HuffmanTree(' ', sumFrequency, t1.root, t2.root));
            }

            return (HuffmanTree)h.Dequeue();
        }
    }

}
