using System;

namespace assignment3_ITDEV154
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice, data, k, x;

            SingleLinkedList list = new SingleLinkedList();

            list.CreateList();

            while(true)
            {
                choice = GetMenuChoice();

                if (choice == 18)
                    break;

                switch(choice)
                {
                    case 1:  //Display the list
                        list.DisplayList();
                        break;
                    case 2:  //Count the Nodes
                        list.CountNodes();
                        break;
                    case 3:  //Search for a node with a specific value
                        Console.WriteLine("Enter an integer value to search for: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.Search(data);
                        break;
                    case 4:  //Insert into an empty list
                        Console.WriteLine("Enter an integer value to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.InsertAtBeginning(data);
                        list.DisplayList();
                        break;
                    case 5:  //Insert at end of list
                        Console.WriteLine("Enter an integer value to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.InsertAtEnd(data);
                        list.DisplayList();
                        break;
                    case 6:  //Insert after a specificed node
                        Console.WriteLine("Enter an integer value to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the value of the Node to be inserted After: ");
                        k = Convert.ToInt32(Console.ReadLine());
                        list.InsertAfter(data, k);
                        list.DisplayList();
                        break;
                    case 7:  //Insert before a specificed node
                        Console.WriteLine("Enter an integer value to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the value of the Node to be inserted Before: ");
                        k = Convert.ToInt32(Console.ReadLine());
                        list.InsertBefore(data, k);
                        list.DisplayList();
                        break;
                    case 8:  //Insert at a specificed position
                        Console.WriteLine("Enter an integer value to be inserted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the position where you want the value to be inserted: ");
                        k = Convert.ToInt32(Console.ReadLine());
                        list.InsertAtPosition(data, k);
                        list.DisplayList();
                        break;
                    case 9:  //Delete the first node
                        list.DeleteFirstNode();
                        Console.WriteLine("First node deleted.");
                        list.DisplayList();
                        break;
                    case 10:  //Delete the last node
                        list.DeleteLastNode();
                        Console.WriteLine("Last node deleted.");
                        list.DisplayList();
                        break;
                    case 11:  //Delete a node with a specified value
                        Console.WriteLine("Enter an integer value of the node to be deleted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.DeleteNodeWithValue(data);
                        list.DisplayList();
                        break;
                    case 12:  //Reverse the List
                        list.ReverseList();
                        Console.WriteLine("List reversed.");
                        list.DisplayList();
                        break;
                    case 13:  //Bubble sort by exchanging data
                        list.BubbleSortData();
                        Console.WriteLine("List sorted.");
                        break;
                    case 14:  //Bubble sort by exchanging links
                        list.BubbleSortLinks();
                        Console.WriteLine("List sorted.");
                        break;
                    case 15:  //Insert a cycle
                        Console.WriteLine("Enter an integer value to search for and insert a cycle at: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.InsertCycle(data);
                        break;
                    case 16:  //Detect cycle
                        if (list.FindCycle() != null)
                            Console.WriteLine("Cycle detected at node with value: " + list.FindCycle().data.ToString());
                        else
                            Console.WriteLine("No cycle detected.");
                        break;
                    case 17:  //Remove cycle
                        list.RemoveCycle();
                        break;
                    case 18: //Quit
                        break;
                    default:
                        Console.WriteLine("You chose poorly");
                        break;
                }
            }
        }

        private static int GetMenuChoice()
        {
            int choice;
            Console.WriteLine("");
            Console.WriteLine("1 - Display List");
            Console.WriteLine("2 - Count Nodes");
            Console.WriteLine("3 - Search");
            Console.WriteLine("4 - Insert In Empty List");
            Console.WriteLine("5 - Insert at End");
            Console.WriteLine("6 - Insert after specified Node");
            Console.WriteLine("7 - Insert before Specificed Node");
            Console.WriteLine("8 - Insert at Position");
            Console.WriteLine("9 - Delete First Node");
            Console.WriteLine("10 - Delete Last Node");
            Console.WriteLine("11 - Delete Node with Value");
            Console.WriteLine("12 - Reverse the List");
            Console.WriteLine("13 - Bubble Sort by Exchanging Data");
            Console.WriteLine("14 - Bubble Sort by Exchanging Links");
            Console.WriteLine("15 - Insert Cycle");
            Console.WriteLine("16 - Delete Cycle");
            Console.WriteLine("17 - Remove Cycle");
            Console.WriteLine("18 - Quit");
            Console.WriteLine("You must choose wisely!");
            Console.WriteLine("");
            choice = Convert.ToInt32(Console.ReadLine());
            return choice;

        }
    }
}
