using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace forhuff
{
    public class BinaryTree
    {
        public class Node
        {
            public char Character { get; set; }
            public int Frequency { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(char character, int frequency)
            {
                Character = character;
                Frequency = frequency;
                Left = null;
                Right = null;
            }

            public bool IsLeaf()
            {
                return Left == null && Right == null;
            }
        }

        protected Node root;

        public BinaryTree(Node root)
        {
            this.root = root;
        }

        public Node Root => root;

        public int NumNodes()
        {
            return NumNodes(root);
        }

        public int Depth()
        {
            return Depth(root);
        }

        private int NumNodes(Node node)
        {
            if (node == null)
                return 0;
            return 1 + NumNodes(node.Left) + NumNodes(node.Right);
        }

        private int Depth(Node node)
        {
            if (node == null)
                return -1;
            return 1 + Math.Max(Depth(node.Left), Depth(node.Right));
        }

        public object[] ToArray(int u)
        {
            int n = NumNodes(root);
            object[] a = new object[n];
            if (u == 0) ToArrayPreorder(root, a, 0);
            if (u == 1) ToArrayInorder(root, a, 0);
            if (u == 2) ToArrayPostorder(root, a, 0);
            return a;
        }

        private int ToArrayPreorder(Node x, object[] a, int k)
        {
            if (x == null) return k;
            a[k++] = x.Character;
            k = ToArrayPreorder(x.Left, a, k);
            k = ToArrayPreorder(x.Right, a, k);
            return k;
        }

        private int ToArrayInorder(Node x, object[] a, int k)
        {
            if (x == null) return k;
            k = ToArrayInorder(x.Left, a, k);
            a[k++] = x.Character;
            k = ToArrayInorder(x.Right, a, k);
            return k;
        }

        private int ToArrayPostorder(Node x, object[] a, int k)
        {
            if (x == null) return k;
            k = ToArrayPostorder(x.Left, a, k);
            k = ToArrayPostorder(x.Right, a, k);
            a[k++] = x.Character;
            return k;
        }

        public void PrintBinaryTree()
        {
            PrintBinaryTree(root, "");
        }

        private void PrintBinaryTree(Node node, string prefix)
        {
            if (node != null)
            {
                Console.WriteLine(prefix + "├─ " + node.Character);
                if (node.Left != null || node.Right != null)
                {
                    PrintBinaryTree(node.Left, prefix + "│  ");
                    PrintBinaryTree(node.Right, prefix + "│  ");
                }
            }
        }
    }
}
