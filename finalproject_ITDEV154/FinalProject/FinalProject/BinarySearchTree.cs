using System;

namespace FinalProject
{
    public class BinarySearchTree
    {
        public class Node
        {
            public int data;
            public Node left, right = null;

            //Node constructor
            public Node(int d)
            {
              data = d;
              left = null;
              right = null;
            }
        }

        //main method
        public static void Main(string[] args)
        {
            Console.WriteLine("To start we will create a Binary Search Tree and enter in some data behind the scenes");
            Console.WriteLine();

            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(10);
            tree.Insert(80);
            tree.Insert(60);
            tree.Insert(90);
            tree.Insert(45);
            tree.Insert(30);
            tree.Insert(25);
            tree.Insert(75);

            Console.WriteLine("Here is the BST in order from lowest to highest");
            tree.InOrder();
            Console.WriteLine();
            Console.WriteLine("Now we will delete 4 nodes from the list: 60, 40, 25, and 30");
            tree.Delete(60);
            tree.Delete(40);
            tree.Delete(25);
            tree.Delete(30);
            Console.WriteLine();
            Console.WriteLine("Here is the new list: ");
            tree.InOrder();
            Console.WriteLine();
            Console.WriteLine("Now we will search for a few numbers: 75, 40, and 25");

            //search for 75
            if(tree.Search(tree.root, 75))
            {
                Console.WriteLine("75 is in this Binary Search Tree");
            }
            else
            {
                Console.WriteLine("75 is not in this Binary Search Tree");
            }

            //search for 40
            if (tree.Search(tree.root, 40))
            {
                Console.WriteLine("40 is in this Binary Search Tree");
            }
            else
            {
                Console.WriteLine("40 is not in this Binary Search Tree");
            }

            //search for 25
            if (tree.Search(tree.root, 25))
            {
                Console.WriteLine("25 is in this Binary Search Tree");
            }
            else
            {
                Console.WriteLine("25 is not in this Binary Search Tree");
            }

            tree.PrintInRange(tree.root, 70, 30);
            Console.WriteLine();
            Console.ReadKey();
        }

        //BST root
        Node root;

        //BST constructor
        BinarySearchTree()
        {
            root = null;
        }

        //insert method that calls a recursive method to insert a new node
        public void Insert(int key)
        {
            root = InsertRecursively(root, key);
        }

        //recursiveinsert method
        private Node InsertRecursively(Node root, int key)
        {
            if(root == null)
            {
                root = new Node(key);
                return root;
            }

            //recur down the tree
            if(key < root.data)
            {
                root.left = InsertRecursively(root.left, key);
            }else if(key > root.data)
            {
                root.right = InsertRecursively(root.right, key);
            }

            return root;
        }

        //delete method that calls a recursive method to delete a node
        public void Delete(int key)
        {
            root = DeleteRecursively(root, key);
        }

        //delete recursively method
        public Node DeleteRecursively(Node root, int key)
        {
            if(root == null)
            {
                return root;
            }

            //recur down the tree
            if(key < root.data)
            {
               root.left = DeleteRecursively(root.left, key);
            }else if(key > root.data)
            {
                root.right = DeleteRecursively(root.right, key);
            }

            //if key = roots key then this is the node to be deleted
            else
            {
                //node with only one child or no child
                if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }

                //node with two children. return the inorder successor
                root.data = minValue(root.right);

                // Delete the inorder successor
                root.right = DeleteRecursively(root.right, root.data);
            }
            return root;
        }

        //method used in delete function to find the smallest child value
        public int minValue(Node root)
        {
            int minv = root.data;
            while (root.left != null)
            {
                minv = root.left.data;
                root = root.left;
            }
            return minv;
        }

        //BST search method
        public bool Search(Node root, int key)
        {
            while(root != null)
            {
                //pass right subtree as new tree
                if(key > root.data)
                {
                    root = root.right;
                }
                else if(key < root.data)
                {
                    root = root.left;
                }
                else
                {
                    return true; //key is found
                }
            }
            return false;  //key is not found
        }

        //Display list in order method
        public void InOrder()
        {
            InOrderRecursively(root);
        }

        //recursive method to display BST in order
        private void InOrderRecursively(Node root)
        {
            if(root != null)
            {
                InOrderRecursively(root.left);
                Console.WriteLine(root.data);
                InOrderRecursively(root.right);
            }
        }

        //Print node data in a given range
        public void PrintInRange(Node node, int k, int j)
        {
            if(node == null)
            {
                return;
            }

            if(k < node.data)
            {
                PrintInRange(node.left, k, j);
            }

            //if roots data lies in range, then print roots data
            if(k <= node.data && j >= node.data)
            {
                Console.WriteLine(node.data + " ");
            }

            //recursively call the right subtree
            PrintInRange(root.right, k, j);
        }
    }
}
