using Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tree.BinaryTree;

namespace Tree
{
    public class Program
    {

        /*       static void Main(string[] args)
               {
                   BinaryTree tree = new BinaryTree();

                   // Create the tree
                   tree.Root = new BinaryTree.Node("Animals",
                       new BinaryTree.Node("Mammals",
                           new BinaryTree.Node("Elephant", null, null),
                           new BinaryTree.Node("Lion", null, null)),
                       new BinaryTree.Node("Reptiles",
                           new BinaryTree.Node("Snake", null, null),
                           new BinaryTree.Node("Crocodile", null, null))
                   );

                   // Calculate the number of nodes and depth of the tree
                   int numNodes = tree.numNodes();
                   int treeDepth = tree.depth();

                   // Convert the tree to arrays in different traversal orders
                   object[] preOrderArray = tree.toArray(0);  // Pre-order
                   object[] inOrderArray = tree.toArray(1);   // In-order
                   object[] postOrderArray = tree.toArray(2); // Post-order

                   // Display the results
                   Console.WriteLine("Animal Tree:");
                   Console.WriteLine("Number of nodes: " + numNodes);
                   Console.WriteLine("Tree depth: " + treeDepth);
                   Console.WriteLine("Pre-order traversal: " + string.Join(", ", preOrderArray));
                   Console.WriteLine("In-order traversal: " + string.Join(", ", inOrderArray));
                   Console.WriteLine("Post-order traversal: " + string.Join(", ", postOrderArray));


                   //generate array
                   object[] x = new object[]{ 170, 45, 75, 90, 802, 24, 2, 66 };
                   BinaryHeap.heapSort(x);
                   for (int i = 0; i < x.Length; i++)
                       Console.WriteLine(x[i]);
               }*/

        static void Main(string[] args)
        {
            string text1 = "Video provides a powerful way to help you prove your point. When you click Online Video, you can paste in the embed code for the video you want to add. You can also type a keyword to search online for the video that best fits your document.\r\nTo make your document look professionally produced, Word provides header, footer, cover page, and text box designs that complement each other. For example, you can add a matching cover page, header, and sidebar. Click Insert and then choose the elements you want from the different galleries.\r\nThemes and styles also help keep your document coordinated. When you click Design and choose a new Theme, the pictures, charts, and SmartArt graphics change to match your new theme. When you apply styles, your headings change to match the new theme.\r\nSave time in Word with new buttons that show up where you need them. To change the way a picture fits in your document, click it and a button for layout options appears next to it. When you work on a table, click where you want to add a row or a column, and then click the plus sign.\r\nReading is easier, too, in the new Reading view. You can collapse parts of the document and focus on the text you want. If you need to stop reading before you reach the end, Word remembers where you left off - even on another device.";

            // Create a frequency array for the characters in the text
            int[] frequency = new int[256];
            foreach (char c in text1)
            {
                frequency[c]++;
            }

            // Encode the text using Huffman coding
            HuffmanTree huffmanTree = HuffmanTree.encode(frequency);
            string encodedText = huffmanTree.EncodeText(text1);

            // Display the encoded text
            Console.WriteLine($"Encoded Text: {encodedText}");

            // Calculate and display entropy, average length, and Huffman code efficiency
            double H = Entropy(frequency, text1.Length);
            double Lavg = huffmanTree.AverageCodeLength();
            double Hce = H / Lavg;

            Console.WriteLine($"Entropy: {H}");
            Console.WriteLine($"Average Length: {Lavg}");
            Console.WriteLine($"Huffman code efficiency: {Hce}");
        }

        // Helper function to calculate entropy
        static double Entropy(int[] frequency, int total)
        {
            double entropy = 0.0;
            foreach (int freq in frequency)
            {
                if (freq > 0)
                {
                    double probability = (double)freq / total;
                    entropy -= probability * Math.Log(probability, 2);
                }
            }
            return entropy;
        }
    
    

       
    }
}

