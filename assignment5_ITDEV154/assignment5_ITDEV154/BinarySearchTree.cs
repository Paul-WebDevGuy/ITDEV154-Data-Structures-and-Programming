using System;

namespace assignment5_ITDEV154
{
    public class BinarySearchTree
    {
        public static void Main()
        {
            BinarySearchTree tree = new BinarySearchTree();

            //Insert a bunch of values into the tree
            tree.InsertNode(24);
            tree.InsertNode(57);
            tree.InsertNode(22);
            tree.InsertNode(8);
            tree.InsertNode(99);
            tree.InsertNode(73);
            tree.InsertNode(2);
            tree.InsertNode(89);

            //Display current tree
            tree.DisplayTree();

            //remove a few values and update
            tree.Remove(22);
            tree.Remove(89);
            tree.Remove(8);
            Console.WriteLine();
            Console.WriteLine();

            //Display updated tree
            tree.DisplayTree();


        }
        private Node root;
        public BinarySearchTree()
        {
            root = null;
        }

        public void InsertNode (int data)
        {
            //if tree is empty, return a single node
            if(root == null)
            {
                root = new Node(data);
                return;
            }
            //otherwise, recursively call down the tree to find a spot
            //for the new node
            InsertRec(root, new Node(data));
        }

        private void InsertRec(Node root, Node newNode)
        {
            if (root == null)
            {
                root = newNode;
            }
            if(newNode.Data < root.Data)
            {
                if(root.Left == null)
                {
                    root.Left = newNode;
                }else
                {
                    InsertRec(root.Left, newNode);
                }
            }else
            {
                if(root.Right == null)
                {
                    root.Right = newNode;
                }
                else
                {
                    InsertRec(root.Right, newNode);
                }
            }
        }

        private void DisplayTree(Node root)
        {
            if (root == null)
                return;

            DisplayTree(root.Left);
            Console.Write(root.Data + " ");
            DisplayTree(root.Right);
        }

        public void DisplayTree()
        {
            DisplayTree(root);
        }

        public void Remove(int key)
        {
            RemoveHelper(root, key);
        }

        private Node RemoveHelper(Node root, int key)
        {
            if (root == null)
                return root;
            //if key is less than the root node, recurse through left sub tree
            if (key < root.Data)
                root.Left = RemoveHelper(root.Left, key);
            //if key is more than root node, recurse through right sub tree
            else if(key > root.Data)
            {
                root.Right = RemoveHelper(root.Right, key);
            }

            //else we found the key
            else
            {
                //case 1: Node to be deleted has no children
                if(root.Left == null && root.Right == null)
                {
                    root = null;
                }
                //case 2: node to be deleted has 2 children
                else if(root.Left != null && root.Right !=null)
                {
                    var maxNode = FindMax(root.Right);
                    //copy the value
                    root.Data = maxNode.Data;
                    root.Right = RemoveHelper(root.Right, maxNode.Data);
                }
                //node to be deleted has one child
                else
                {
                    var child = root.Left != null ? root.Left : root.Right;
                    root = child;
                }
            }

            return root;
        }

        private Node FindMax(Node node)
        {
            while(node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            this.Data = data;
            Left = null;
            Right = null;
        }
    }
}
