using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class HuffmanTree : BinaryTree, IComparable
    {
        public HuffmanTree(int f, Node left, Node right)
        {
            root = new Node(f, left, right);
        }
        public int CompareTo(object x)
        {
            return Frequency() - ((HuffmanTree)x).Frequency();
        }
        public int Frequency()
        {
            return (int)root.e;
        }
        public static HuffmanTree encode(int[] f)
        {
            BinaryMinHeap h = new BinaryMinHeap(0);
            for (int i = 0; i < f.Length; .i++)
                h.enqueue(new HuffmanTree(f[i], null, null));
            for (int i = 0; i < f.Length - 1; i++)
            {
                HuffmanTree t1 = (HuffmanTree)h.dequeue();
                HuffmanTree t2 = (HuffmanTree)h.dequeue();
                int sumf = t1.Frequency() + t2.Frequency();
                h.enqueue(new HuffmanTree(sumf, t1.root, t2.root));
            }
            return (HuffmanTree)h.dequeue();
        }
        public string EncodeText(string text)
        {
            StringBuilder encodedText = new StringBuilder();

            foreach (char c in text)
            {
                string huffmanCode = FindHuffmanCode(root, c, "");
                encodedText.Append(huffmanCode);
            }

            return encodedText.ToString();
        }

        private string FindHuffmanCode(Node node, char target, string currentCode)
        {
            if (node == null)
            {
                // Character not found, return an appropriate value (e.g., empty string)
                return "";
            }

            if (node.e.Equals(target) && node.isLeaf())
            {
                // Character found, return the current code
                return currentCode;
            }

            // Recursively search for the character in the left and right subtrees
            string leftCode = FindHuffmanCode(node.left, target, currentCode + "0");
            string rightCode = FindHuffmanCode(node.right, target, currentCode + "1");

            // Return the code found in either subtree
            return leftCode != "" ? leftCode : rightCode;
        }
        public double AverageCodeLength()
        {
            // Initialize variables to keep track of the total code length and the total number of symbols
            double totalCodeLength = 0;
            int totalSymbols = 0;

            // Calculate the average code length by traversing the Huffman tree
            CalculateAverageCodeLength(root, "", ref totalCodeLength, ref totalSymbols);

            if (totalSymbols == 0)
            {
                // Handle the case where there are no symbols in the tree
                return 0;
            }

            return totalCodeLength / totalSymbols;
        }

        private void CalculateAverageCodeLength(Node node, string currentCode, ref double totalCodeLength, ref int totalSymbols)
        {
            if (node == null)
            {
                return;
            }

            // If the current node is a leaf (i.e., it represents a symbol)
            if (node.isLeaf())
            {
                totalCodeLength += currentCode.Length;
                totalSymbols++;
            }

            // Recursively traverse the left and right subtrees
            CalculateAverageCodeLength(node.left, currentCode + "0", ref totalCodeLength, ref totalSymbols);
            CalculateAverageCodeLength(node.right, currentCode + "1", ref totalCodeLength, ref totalSymbols);
        }
    }
}
