using System;

namespace BST___Find_the_Inorder_Ancestor_and_Successor
{
    class Program
    {
        class Node
        {
            public int value;
            public Node left, right, parent;
            public Node(int val)
            {
                value = val;
                left = right = parent = null;
            }
        }

        static void Main(string[] args)
        {
            BinarySearch bs = new BinarySearch();
            Node root = null;
            root = bs.Insert(root, 50);
            root = bs.Insert(root, 16);
            root = bs.Insert(root, 90);
            root = bs.Insert(root, 14);
            root = bs.Insert(root, 40);
            root = bs.Insert(root, 80);
            root = bs.Insert(root, 100);
            root = bs.Insert(root, 10);
            root = bs.Insert(root, 15);
            root = bs.Insert(root, 35);
            root = bs.Insert(root, 45);
            root = bs.Insert(root, 75);
            root = bs.Insert(root, 82);
            root = bs.Insert(root, 105);
            root = bs.Insert(root, 5);
            root = bs.Insert(root, 32);
            root = bs.Insert(root, 36);
            root = bs.Insert(root, 81);
            root = bs.Insert(root, 85);
            root = bs.Insert(root, 30);
            root = bs.Insert(root, 37);
            root = bs.Insert(root, 87);
            Node answer = bs.GetInorderSuccesor(root.left.left.right); // 45
            Console.WriteLine("Succecor of {0} is {1}", root.left.left.right.value, answer?.value);
            answer = bs.GetInorderAncestor(root.right.left.left); // 75
            Console.WriteLine("Ancestor of {0} is {1}", root.right.left.left.value, answer?.value);
        }

        class BinarySearch
        {
            public Node Insert(Node root, int val)
            {

                if (root == null) return new Node(val);

                if (val <= root.value)
                {
                    Node temp = Insert(root.left, val);
                    root.left = temp;
                    temp.parent = root;
                }
                else
                {
                    Node temp = Insert(root.right, val);
                    root.right = temp;
                    temp.parent = root;
                }

                return root;
            }

            public Node GetInorderSuccesor(Node node)
            {
                // when right child is present
                if (node.right != null)
                {
                    Node temp = node.right;
                    while (temp != null) temp = temp.left;

                    return temp;
                }

                // when no right child
                Node parent = node.parent;
                while(parent != null && parent.right == node)
                {
                    node = parent;
                    parent = parent.parent;
                }

                return parent;
            }

            public Node GetInorderAncestor(Node node)
            {
                // if left child is exist
                if (node.left != null)
                {
                    Node temp = node.left;
                    while (temp != null) temp = temp.right;

                    return temp;
                }

                // if no left child
                Node parent = node.parent;
                while (parent != null && parent.left == node)
                {
                    node = parent;
                    parent = parent.parent;
                }

                return parent;
            }
        }
    }
}
