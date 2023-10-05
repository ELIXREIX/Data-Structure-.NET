using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forhuff
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var frequencies = new int[] { 5, 9, 12, 13, 16, 45 };
            var huffmanTree = HuffmanTree.Encode(frequencies);

            // Encode and decode a sample text
            var text = "HUFFMAN";
            var encodedText = Encode(text, huffmanTree);
            var decodedText = Decode(encodedText, huffmanTree);

            Console.WriteLine($"Original Text: {text}");
            Console.WriteLine($"Encoded Text: {encodedText}");
            Console.WriteLine($"Decoded Text: {decodedText}");
        }

        public static string Encode(string text, HuffmanTree huffmanTree)
        {
            var encodedText = new StringBuilder();
            foreach (var c in text)
            {
                var current = huffmanTree.Root;
                while (!current.IsLeaf())
                {
                    var bit = c < current.Character ? '0' : '1';
                    encodedText.Append(bit);
                    current = bit == '0' ? current.Left : current.Right;
                }
            }
            return encodedText.ToString();
        }

        public static string Decode(string encodedText, HuffmanTree huffmanTree)
        {
            var decodedText = new StringBuilder();
            var current = huffmanTree.Root;

            foreach (var bit in encodedText)
            {
                current = bit == '0' ? current.Left : current.Right;
                if (current.IsLeaf())
                {
                    decodedText.Append(current.Character);
                    current = huffmanTree.Root;
                }
            }

            return decodedText.ToString();
        }
    }
}
