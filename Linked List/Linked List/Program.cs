using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation
{

    public class Node
    {
        public int Val;
        public Node Next;

        public Node(int val)
        {
            this.Val = val;
            this.Next = null;
        }
    }

    public class LinkedList : IEnumerable
    {
        Node head;
        Node tail;
        public int size;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        // 1. Inserting at end..
        public void InsertAtEnd(Node node)
        {
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            this.size++;
        }

        // 2. Inserting at a certain position..
        public void InsertAtPos(int pos, int val)
        {
            if (pos == 1)
            {
                Node newNode = new Node(val);
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                int count = 1;
                Node prevPtr = head;
                while (count < pos - 1)
                {
                    prevPtr = prevPtr.Next;
                    count++;
                }
                Node newNode = new Node(val);
                newNode.Next = prevPtr.Next;
                prevPtr.Next = newNode;
            }
            this.size++;
            Console.WriteLine($"Inserted {val} at position {pos}.");
        }

        // 3. Removing last node..
        public int RemoveLastNode()
        {
            if (size == 0) throw new System.Exception("List is Empty!");

            if (head == tail)
            {
                head = null;
                tail = null;
                return head.Val;
            }
            int count = 1;
            Node prevPtr = head;
            while (count < size - 1)
            {
                prevPtr = prevPtr.Next;
                count++;
            }
            int valueDeleted = tail.Val;
            tail = prevPtr;
            tail.Next = null;
            size--;
            return valueDeleted;

        }

        // 4. Removing a particular position..
        public int RemoveFromPos(int pos)
        {
         if (size == 0) throw new System.Exception("List is Empty!");

         if (pos > size)
            {
         throw new System.Exception("Element is not present!");
            }
            int count = 1;
            Node prevPtr = null;
            Node currPtr = head;
            while (count < pos - 1) 
            // traversing of curr and prev node till our destination.
            {
             prevPtr = currPtr;
             currPtr = currPtr.Next;
             count++;
      }
      if (pos == size) /*if we have to remove last node,
                        * we will update the tail of our linked list.*/
       {
       tail = prevPtr;
        }
        prevPtr.Next = currPtr.Next;
        size--;  // removing means reducing size.
        return currPtr.Val;
        }

        // 5. Finding the center of linked list..
        public int FindMid()
        {
        if (size == 0) throw new System.Exception("List is Empty!");
        Node fast = head, slow = head;
        while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            return slow.Val;
        }

        // 6. Sorting the list..
        public void SortList()
        {
            if (size == 0) throw new System.Exception("List is Empty!");
            Node currNode = head;
            int temp;

            while (currNode != null)
            {
                Node fast = currNode.Next;
                while (fast != null)
                {
                    if (fast.Val < currNode.Val)
                    {
                        // basic swapping
                        temp = fast.Val;
                        fast.Val = currNode.Val;
                        currNode.Val = temp;
                    }
                    fast = fast.Next;
                }
                currNode = currNode.Next;
            }
        }

        // 7. Reversing the list..
        public void ReverseList()
        {
            if (size == 0) throw new System.Exception("List is Empty!");

            Node currNode = head;
            Node prevNode = null;
            while (currNode != null)
            {
                Node nextNode = currNode.Next;
                currNode.Next = prevNode;
                prevNode = currNode;
                currNode = nextNode;
            }
            head = prevNode;

        }

        // 8. Iterator
        public IEnumerable<int> GetIteratedList()
        {
            Node temp = head;
            while (temp != null)
            {
                yield return temp.Val;
                temp = temp.Next;
            }

        }
        public IEnumerator GetEnumerator()  // gives a iterator to iterate over our non generic class.
        {
            throw new NotImplementedException();
        }

        // Printing the list..
        public void PrintList()
        {
            if (head == null) throw new System.Exception("List is Empty!");

            Node temp = head;
            while (temp != null)
            {
                Console.Write($"{temp.Val} -> ");
                temp = temp.Next;
            }
            Console.WriteLine("Null \n");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            int choice = -1;
            while (true)
            {
                Console.WriteLine("1. Insert Element at end");
                Console.WriteLine("2. Insert at certain position");
                Console.WriteLine("3. Delete from end");
                Console.WriteLine("4. Delete from a particular position");
                Console.WriteLine("5. Get Middle/center element");
                Console.WriteLine("6. Sort the Linked List");
                Console.WriteLine("7. Reverse the Linked List");
                Console.WriteLine("8. Size of list");
                Console.WriteLine("9. Iterator");
                Console.WriteLine("10. Print the List");
                Console.WriteLine("0. Exit..");

                Console.WriteLine();
                Console.WriteLine("Enter your Choice from 1-10: ");

                if (int.TryParse(Console.ReadLine(), out choice) && (choice >= 0 && choice <= 10))
                {
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Terminating!!");
                            return;

                        case 1:
                            Console.Write("Value for the element: ");
                            int value = int.Parse(Console.ReadLine());
                            Node node = new Node(value);
                            list.InsertAtEnd(node);
                            Console.WriteLine("Node added Successfully!! \n");

                            break;

                        case 2:
                            Console.Write("Enter the position to insert: ");
                            int pos = int.Parse(Console.ReadLine());
                            Console.Write("Enter the value to insert: ");
                            int val = int.Parse(Console.ReadLine());

                            list.InsertAtPos(pos, val);
                            Console.WriteLine();
                            break;

                        case 3:
                            Console.WriteLine("Removing the last Node!!");
                            int removedElement = list.RemoveLastNode();
                            Console.WriteLine($"Removed element is {removedElement}. \n");
                            break;

                        case 4:
                            Console.Write("Enter position to delete: ");
                            pos = int.Parse(Console.ReadLine());

                            removedElement = list.RemoveFromPos(pos);
                            Console.WriteLine($"Removed element is {removedElement}");
                            Console.WriteLine();
                            break;

                        case 5:
                            Console.WriteLine("Getting the mid element of list..");
                            int midElement = list.FindMid();
                            Console.WriteLine($"Mid element is: {midElement} \n");
                            break;

                        case 6:
                            list.SortList();
                            Console.WriteLine("List sorted successfully!! \n");
                            break;

                        case 7:
                            list.ReverseList();
                            Console.WriteLine("List reversed successfully!! \n");
                            break;

                        case 8:
                            Console.WriteLine($"Size of list: {list.size}");
                            Console.WriteLine();
                            break;

                        case 9:
                            IEnumerable<int> IteratedLinkedList = list.GetIteratedList();
                            Console.WriteLine("\nIterated list is: ");
                            foreach (int item in IteratedLinkedList)
                            {
                                Console.Write(item + " ");
                            }
                            Console.WriteLine();
                            break;

                        case 10:
                            list.PrintList();
                            break;

                        default:
                            Console.WriteLine("Wrong input!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.. Please try again!!");
                    continue;
                }
            }


        }
    }
}