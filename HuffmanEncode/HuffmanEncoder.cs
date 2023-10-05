using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Node : IComparable<Node>
    {
        public char Char { get; set; }
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(char character, int freq)
        {
            Char = character;
            Frequency = freq;
            Left = null;
            Right = null;
        }

        public int CompareTo(Node other)
        {
            return Frequency - other.Frequency;
        }
    }

    class Program
    {
        public static Dictionary<char, string> GenerateCodes(Node node, string code = "")
        {
            var mapping = new Dictionary<char, string>();

            if (node == null)
                return mapping;

            if (node.Char != '\0')
            {
                mapping[node.Char] = code;
                return mapping;
            }

            var leftCode = code + "0";
            var rightCode = code + "1";

            mapping = mapping.Concat(GenerateCodes(node.Left, leftCode))
                .Concat(GenerateCodes(node.Right, rightCode))
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            return mapping;
        }

        public static string Encode(string text, Dictionary<char, string> mapping)
        {
            var encodedText = new StringBuilder();
            foreach (var c in text)
            {
                if (mapping.ContainsKey(c))
                    encodedText.Append(mapping[c]);
            }
            return encodedText.ToString();
        }

        public static Node BuildTree(Dictionary<char, int> frequency)
        {
            var priorityQueue = new List<Node>(frequency.Select(kv => new Node(kv.Key, kv.Value));
            priorityQueue.Sort();

            while (priorityQueue.Count > 1)
            {
                var left = priorityQueue[0];
                var right = priorityQueue[1];
                priorityQueue.RemoveRange(0, 2);

                var merged = new Node('\0', left.Frequency + right.Frequency)
                {
                    Left = left,
                    Right = right
                };

                priorityQueue.Add(merged);
                priorityQueue.Sort();
            }

            return priorityQueue[0];
        }

        public static Dictionary<char, int> BuildFrequency(string text)
        {
            var frequency = new Dictionary<char, int>();
            foreach (var c in text)
            {
                if (!frequency.ContainsKey(c))
                    frequency[c] = 0;
                frequency[c]++;
            }
            return frequency;
        }

        public static (string, Dictionary<char, string>) HuffmanEncode(string text)
        {
            var frequency = BuildFrequency(text);
            var root = BuildTree(frequency);
            var mapping = GenerateCodes(root);
            var encodedText = Encode(text, mapping);
            return (encodedText, mapping);
        }

        public static double Entropy(Dictionary<char, int> frequency, int totalSymbols)
        {
            double H = 0;
            foreach (var kv in frequency)
            {
                double prob = (double)kv.Value / totalSymbols;
                H -= prob * Math.Log(prob, 2);
            }
            return H;
        }

        public static double AverageLength(Dictionary<char, int> frequency, Dictionary<char, string> huffmanMapping)
        {
            double Lavg = 0;
            int totalSymbols = frequency.Values.Sum();
            foreach (var kv in frequency)
            {
                double prob = (double)kv.Value / totalSymbols;
                Lavg += prob * huffmanMapping[kv.Key].Length;
            }
            return Lavg;
        }


    }
}
