using System;
using System.Collections.Generic;
using System.Text;

namespace assignment3_ITDEV154
{
    class SingleLinkedList
    {
        private node start;

        public SingleLinkedList()
        {
            start = null;
        }

        public void CreateList()
        {
            int i, n, data;

            Console.WriteLine("Enter the number of nodes: ");
            n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
                return;
            for(i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter the element to be inserted: ");
                data = Convert.ToInt32(Console.ReadLine());
                InsertAtEnd(data);
            }
            DisplayList();
        }

        public void InsertAtBeginning(int data)
        {
            node temp = new node(data);
            temp.next = start;
            start = temp;
        }

        public void InsertAtEnd(int data)
        {
            node p;
            node temp = new node(data);

            if(start == null) //Empty List
            {
                start = temp;
                return;
            }

            p = start;
            while (p.next != null)
                p = p.next;

            p.next = temp;
        }

        public void DisplayList()
        {
            node p;
            if(start == null) //Empty list
            {
                Console.WriteLine("List is empty");
                return;
            }
            p = start;
            while(p != null)
            {
                Console.Write(p.data + " ");
                p = p.next;
            }
            Console.WriteLine("");
        }

        public void CountNodes()
        {
            int n = 0;
            node p = start;
            while(p != null)
            {
                n++;
                p = p.next;
            }
            Console.WriteLine("The list has " + n + " Nodes");
        }

        public bool Search(int x)
        {
            int position = 1;
            node p = start;
            while (p != null)
            {
                if (p.data == x)
                    break;
                position++;
                p = p.next;
            }
            if(p == null)
            {
                Console.WriteLine(x + " not found in the list.");
                return false;
            }
            else
            {
                Console.WriteLine(x + " is at position " + position);
                return true;
            }
        }

        public void InsertAfter(int data, int x)
        {
            node p = start;
            while(p != null)
            {
                if (p.data == x)
                    break;
                p = p.next;
            }

            if (p == null)
                Console.WriteLine(x + " is not present in the list.");
            else
            {
                node temp = new node(data);
                temp.next = p.next;
                p.next = temp;
            }
        }

        public void InsertBefore(int data, int x)
        {
            node temp;

            //Empty List
            if(start == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            //x is the first node
            if(x == start.data)
            {
                InsertAtBeginning(data);
            }

            //Get predecessor node
            node p = start;
            while(p.next != null)
            {
                if (p.next.data == x)
                    break;
                p = p.next;
            }
            if (p.next == null) //couldn't find x
                Console.WriteLine(x + " is not present in the list.");
            else 
            {
                temp = new node(data);
                temp.next = p.next;
                p.next = temp;
            }
        }

        public void InsertAtPosition(int data, int k)
        {
            node temp;
            int i;

            if(k == 1)
            {
                InsertAtBeginning(data);
            }

            node p = start;
            //get a reference to the node prior
            for (i = 1; i < k - 1 && p != null; i++)
                p = p.next;

            if (p == null)
                Console.WriteLine("That position is past the end of the list.\nYou can only insert up to the " + i  +"th position.");
            else
            {
                temp = new node(data);
                temp.next = p.next;
                p.next = temp;
            }
     
            
        }

        public void DeleteFirstNode()
        {
            if (start == null)
                return;
            start = start.next;
        }

        public void DeleteLastNode()
        {
            if (start == null)
                return;

            if(start.next == null)
            {
                start = null;
                return;
            }

            node p = start;
            while (p.next.next != null)
                p = p.next;
            p.next = null;
        }

        public void DeleteNodeWithValue(int x)
        {
            if(start == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            //x is found in the first node
            if(start.data == x)
            {
                start = start.next;
                return;
            }

            //x is found elsewhere in the list
            node p = start;
            while(p.next != null)
            {
                if (p.next.data == x)
                    break;
                p = p.next;
            }

            if (p.next == null) //not found
                Console.WriteLine(x + " is not found in the list");
            else
            {
                p.next = p.next.next;
            }
        }

        public void ReverseList()
        {
            node previous;
            node current;
            node next;

            previous = null;
            current = start;
            while(current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            start = previous;
        }

        public void BubbleSortData()
        {
            node end, p, q;
            int passCount = 0;

            for (end = null; end != start.next; end = p)
            {
                for (p = start; p.next != end; p = p.next)
                {
                    q = p.next;
                    if(p.data > q.data)
                    {
                        int tempData = p.data;
                        p.data = q.data;
                        q.data = tempData;
                    }
                }
                passCount++;
                Console.WriteLine("List after pass " + passCount);
                DisplayList();

        }   }

        public void BubbleSortLinks()
        {
            node end, r, p, q, temp;
            int passCount = 0;

            for(end = null; end != start.next; end = p)
            {
                for(r = p = start; p.next != end; r = p, p = p.next)
                {
                    q = p.next;
                    if(p.data > q.data)
                    {
                        p.next = q.next;
                        q.next = p;
                        if (p != start)
                            r.next = q;
                        else
                            start = q;
                        temp = p;
                        p = q;
                        q = temp;
                    }
                }
                passCount++;
                Console.WriteLine("List after pass " + passCount);
                DisplayList();
            }
        }

        public void InsertCycle(int x)
        {
            if (start == null)
                return;

            node p = start;
            node px = null;
            node previous = null;

            while(p != null)
            {
                if (p.data == x)
                    px = p;
                previous = p;
                p = p.next;
            }
            if (px != null)
            {
                previous.next = px;
                Console.WriteLine("Cycle inserted at node with value " + x);
            }
            else
                Console.WriteLine(x + " is not present in the list.");
        }

        public bool HasCycle()
        {
            if (FindCycle() != null)
                return true;
            else
                return false;
        }

        public node FindCycle()
        {
            //Empty list or list with only one node
            if (start == null || start.next == null)
                return null;

            //create two nodes, 1 fast, 1 slow
            node tortoise, hare;
            //put them both on the starting line
            tortoise = start;
            hare = start;

            while(hare != null && hare.next != null)
            {
                tortoise = tortoise.next;//move 1
                hare = hare.next.next; //move 2
                if (tortoise == hare) //found a cycle
                    return tortoise;
            }

            //didnt find a cycle
            return null;
        }

        public void RemoveCycle()
        {
            node cycleFound = FindCycle();
            if (cycleFound == null)
                return;

            Console.WriteLine("Cycle detected at node with value: " + cycleFound.data);

            //find the length of the cycle
            node p = cycleFound;
            node q = cycleFound;

            int cycleLength = 0;
            do
            {
                cycleLength++;
                q = q.next;
            } while (p != q);
            Console.WriteLine("The cycle is " + cycleLength + " nodes long");

            //Find the length of the remaining list
            int remainingListLength = 0;
            p = start;
            while(p != q)
            {
                remainingListLength++;
                p = p.next;
                q = q.next;
            }
            Console.WriteLine("The remaining list is " + remainingListLength + " nodes long.");

            //the total list is the sum of the cycle length and the remaining list length
            int listLength = cycleLength + remainingListLength;
            Console.WriteLine("The whole list is " + listLength + " nodes long");

            //walk the list and reassign next pointer on each node
            p = start;
            for(int i = 1; i <= listLength - 1; i++)
            {
                Console.WriteLine("Reassigning Node:[" + p.data + "].Next -> Node:[" + p.next.data + "]");
                p = p.next;
            }

            //set the next pointer on the last node to be null
            Console.WriteLine("Reassigning node:[" + p.data + "].Next -> null to terminate list.");
            p.next = null;
            Console.WriteLine("Cycle removed.");
        }



        
    }
}
