using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinaryTree
    {
        public Node Root
        {
            get { return root; }
            set { root = value; }
        }
        public class Node
        {
            public object e;
            public Node left, right;
            public Node(object e, Node left, Node right)
            {
                this.e = e;
                this.left = left;
                this.right = right;
            }
            public bool isLeaf()
            {
                return left == null && right == null;
            }
        }
        protected Node root;
        public int numNodes()
        {
            return numNodes(root);
        }
        public int depth()
        {
            return depth(root);
        }
        private int numNodes(Node node)
        {
            if (node == null)
                return 0;
            return 1 + numNodes(node.left) + numNodes(node.right);
        }
        private int depth(Node node)
        {
            if (node == null)
                return -1;
            return 1 + Math.Max(depth(node.left), depth(node.right));
        }
        public object[] toArray(int u)
        {
            //int n = numNodes(root);
            //object[] a = new object[n];
            //toArrayPreorder(root, a, 0);
            //return a;
            int n = numNodes(root);
            object[] a = new object[n];
            if (u == 0) toArrayPreorder(root, a, 0);
            if (u == 1) toArrayInorder(root, a, 0);
            if (u == 2) toArrayPostorder(root, a, 0);
            return a;


        }
        private int toArrayPreorder(Node x, object[] a, int k)
        {
            if (x == null) return k;
            a[k++] = x.e;//บน
            k = toArrayPreorder(x.left, a, k);// ซ้าย
            k = toArrayPreorder(x.right, a, k);// ขวา
            return k;
        }
        //From here is toArray--
        private int toArrayInorder(Node x, object[] a, int k)
        {
            if (x == null) return k;
            k = toArrayInorder(x.left, a, k);// ซ้าย
            a[k++] = x.e;//บน
            k = toArrayInorder(x.right, a, k);// ชวา
            return k;
        }

        private int toArrayPostorder(Node x, object[] a, int k)
        {
            if (x == null) return k;
            k = toArrayPostorder(x.left, a, k);//ซ้าย
            k = toArrayPostorder(x.right, a, k);//ขวา
            a[k++] = x.e;//บน
            return k;
        }

        public void generateTree()
        {
            root = new Node('A',
                new Node('B', new Node('D', null, null), null),
                new Node('C', null, null)
                );
        }

    }
}
