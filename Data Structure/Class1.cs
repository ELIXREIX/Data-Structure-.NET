using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
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

    class HuffmanCoding
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
            var priorityQueue = new List<Node>(frequency.Select(kv => new Node(kv.Key, kv.Value)));
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
        static void Main()
        {
            string text1 = "Video provides a powerful way to help you prove your point. When you click Online Video, you can paste in the embed code for the video you want to add. You can also type a keyword to search online for the video that best fits your document.\r\nTo make your document look professionally produced, Word provides header, footer, cover page, and text box designs that complement each other. For example, you can add a matching cover page, header, and sidebar. Click Insert and then choose the elements you want from the different galleries.\r\nThemes and styles also help keep your document coordinated. When you click Design and choose a new Theme, the pictures, charts, and SmartArt graphics change to match your new theme. When you apply styles, your headings change to match the new theme.\r\nSave time in Word with new buttons that show up where you need them. To change the way a picture fits in your document, click it and a button for layout options appears next to it. When you work on a table, click where you want to add a row or a column, and then click the plus sign.\r\nReading is easier, too, in the new Reading view. You can collapse parts of the document and focus on the text you want. If you need to stop reading before you reach the end, Word remembers where you left off - even on another device.";
            var (encodedText, mapping) = HuffmanEncode(text1);

            Console.WriteLine($"Encoded Text: {encodedText}");
            foreach (var kv in mapping)
            {
                Console.WriteLine($"Character: {kv.Key}, Huffman Code: {kv.Value}");
            }
            var frequency = BuildFrequency(text1);
            double H = Entropy(frequency, text1.Length);
            double Lavg = AverageLength(frequency, mapping);
            double Hce = H / Lavg;

            Console.WriteLine($"Entropy: {H}");
            Console.WriteLine($"Average Length: {Lavg}");
            Console.WriteLine($"Huffman code efficiency: {Hce}");
        }
    }

}
