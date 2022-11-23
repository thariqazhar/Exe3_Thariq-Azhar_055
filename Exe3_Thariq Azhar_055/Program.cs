using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Linked_List_A
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
        public Node prev;
    }

    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }

        /*Create a method for adding node*/
        public void addNode()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter the name of the student");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.rollNumber = nim;
            newNode.name = nm;

            if (LAST == null)
            {
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            else if (nim <= LAST.rollNumber)
            {
                if (LAST != null && nim == LAST.rollNumber)
                {
                    Console.WriteLine("\nDuplicate student number are not allowed");
                    return;
                }
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = LAST; current != null && nim >= current.rollNumber; previous = current, current = current.next)
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }

        /*Searches for the specified node*/
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST; current != null &&
                rollNo != current.rollNumber; previous = current,
                current = current.next)
            { }
            /*The above for loop traverses the list. If the specified node
             is found then the function return true, otherwise false.*/
            return (current != null);
        }

        /*Deletes the specified node*/
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current == LAST)/*If the first node is to be deleted*/
            {
                LAST = LAST.next;
                if (LAST != null)
                    LAST.prev = null;
                return true;
            }
            if (current.next == null)/*if the last node is to be deleted*/
            {
                previous.next = null;
                return true;
            }
            /*If the node to be deleted is in between the list then the
             following lines of code is executed*/
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        /*Create a method for showing that the list is empty*/
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        /*traverses all the nodes of the list*/
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of " +
                    "roll numbers are: \n");
                Node currentNode;
                for (currentNode = LAST; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + "  "
                        + currentNode.name + "\n");
            }
        }

        /*Creating a method to shwo the first record in the list*/
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n " + LAST.next.rollNumber + "     " + LAST.next.name);
        }

        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record in the list");
                    Console.WriteLine("2. Delete a record in the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. Display the first record in the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter your choice (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}