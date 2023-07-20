using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplementation
{
    class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
        }
    }

    class Queue : IEnumerable
    {
        public Node head;
        public Node tail;
        public int size;
        public int capacity;


        public Queue(int capacity)
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
            this.capacity = capacity;
        }



        // whether the queue is full or not ...
        public bool IsFull()
        {
            return size == capacity;
        }

        // whether the queue is empty or not..
        public bool IsEmpty()
        {
            return size == 0;
        }


        // Inserting node from rear end...
        public void Enqueue(int val)
        {
            if (IsFull())
            {
                throw new System.Exception("Queue is already full!!");
            }
            Node newNode = new Node(val);
            if (size == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            size++;
        }

        // Popping out the front element..
        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new System.Exception("Queue is empty!!");
            }
            int val = head.Data;
            head = head.Next;
            size--;
            if (size == 0) // after dequeue.. suppose we dont have any element in queue left..
            {
                tail = null;
            }
            return val;
        }

        // peek element of queue..
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new System.Exception("Queue is empty!!");
            }
            return head.Data;
        }

        // checking the presence of a particular node..
        public bool Contains(int val)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Data == val)
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        // Getting the center element of the queue..
        public int GetMid()
        {
            if (IsEmpty())
            {
                throw new System.Exception("Queue is empty!!");
            }
            Node fast = head;
            Node slow = head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            return slow.Data;
        }

        // Sorting the queue...
        public void SortQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is Empty!");
                return;
            }

            Node curr = head;
            while (curr != null)
            {
                Node fast = curr.Next;
                while (fast != null)
                {

                    if (fast.Data < curr.Data)
                    {
                        int temp = fast.Data;
                        fast.Data = curr.Data;
                        curr.Data = temp;
                    }
                    fast = fast.Next;
                }
                curr = curr.Next;
            }
        }

        // Reversing the queue..
        public void ReverseQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty!!\n");
            }
            Node prev = null;
            Node curr = head;
            while (curr != null)
            {
                Node next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }
            head = prev;
        }

        // Iterate over queue..
        public IEnumerable<int> GetIteratedQueue()
        {
            Node temp = head;
            while (temp != null)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }


        // Printing the queue..
        public void PrintQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is Empty!\n");
            }
            else
            {
                Node temp = head;
                while (temp != null)
                {
                    Console.Write(temp.Data + " ");
                    temp = temp.Next;
                }
                Console.WriteLine();
            }

        }

    }
    class Program
    {
        private static void Main(string[] args)
        {
            Queue queue = new Queue(50);
            Console.WriteLine("-------------- QUEUE IMPLEMENTATION -----------------\n");
            while (true)
            {
                Console.WriteLine("1: Insert element");
                Console.WriteLine("2: Delete element");
                Console.WriteLine("3: Peek element");
                Console.WriteLine("4: Check if queue contains a specific element");
                Console.WriteLine("5: Size of queue");
                Console.WriteLine("6: Get mid element of queue");
                Console.WriteLine("7: Sort the queue");
                Console.WriteLine("8: Reverse the queue");
                Console.WriteLine("9: Iterator for the queue");
                Console.WriteLine("10: Print queue");
                Console.WriteLine("0: Exit\n\n");

                Console.Write("Enter your choice: ");

                // will check whether the choice is in the range.
                if (int.TryParse(Console.ReadLine(), out int choice) && (choice <= 10 && choice >= 0))
                {
                    switch (choice)
                    {

                        case 0:
                            Console.WriteLine("Terminating!!");
                            return;

                        case 1:
                            Console.Write("Enter element value to push: ");
                            int value = int.Parse(Console.ReadLine());
                            queue.Enqueue(value);
                            Console.WriteLine($"Value {value} pushed successfully..\n");
                            break;

                        case 2:
                            int poppedElement = queue.Dequeue();
                            Console.WriteLine($"Value {poppedElement} popped successfully..\n");
                            break;

                        case 3:
                            int peekElement = queue.Peek();
                            Console.WriteLine($"Peek element is {peekElement}..\n");
                            break;

                        case 4:
                            Console.Write("Which element do you want to check? ");
                            int inputVal = int.Parse(Console.ReadLine());
                            if (queue.Contains(inputVal))
                            {
                                Console.WriteLine($"{inputVal} is present in the queue..");
                            }
                            else
                            {
                                Console.WriteLine($"{inputVal} is not present in the queue..");
                            }
                            Console.WriteLine();
                            break;

                        case 5:
                            Console.WriteLine("Size of Queue is: " + queue.size + '\n');
                            break;

                        case 6:
                            int mid = queue.GetMid();
                            Console.WriteLine("Middle element of queue is " + mid + "\n");
                            break;

                        case 7:
                            queue.SortQueue();
                            Console.WriteLine("Sorted the queue successfully!!\n");
                            break;

                        case 8:
                            queue.ReverseQueue();
                            Console.WriteLine("Reversed the queue successfully!!\n");
                            break;

                        case 9:
                            Console.WriteLine("Iterated queue is: ");
                            IEnumerable<int> iteratedQueue = queue.GetIteratedQueue();
                            foreach (int item in iteratedQueue)
                            {
                                Console.WriteLine(item + " ");
                            }
                            Console.WriteLine();
                            break;

                        case 10:
                            queue.PrintQueue();
                            break;

                        default:
                            Console.WriteLine("Invalid choice!!\n");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Enter a valid choice!!");
                    continue;
                }
            }
        }
    }
}