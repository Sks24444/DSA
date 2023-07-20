using System;

class PriorityQueue<T>
{
    private class Node
    {
        public T data;
        public int priority;
        public Node next;

        public Node(T data, int priority)
        {
            this.data = data;
            this.priority = priority;
            this.next = null;
        }
    }

    private Node head;

    public PriorityQueue()
    {
        head = null;
    }

    public void Enqueue(T item, int priority)
    {
        Node newNode = new Node(item, priority);

        if (head == null || priority > head.priority)
        {
            newNode.next = head;
            head = newNode;
        }
        else
        {
            Node current = head;

            while (current.next != null && current.next.priority >= priority)
            {
                current = current.next;
            }

            newNode.next = current.next;
            current.next = newNode;
        }
    }

    public T Dequeue()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T item = head.data;
        head = head.next;
        return item;
    }

    public T Peek()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return head.data;
    }

    public bool Contains(T item)
    {
        Node current = head;

        while (current != null)
        {
            if (current.data.Equals(item))
            {
                return true;
            }

            current = current.next;
        }

        return false;
    }

    public int Size()
    {
        int size = 0;
        Node current = head;

        while (current != null)
        {
            size++;
            current = current.next;
        }

        return size;
    }

    public void Reverse()
    {
        Node previous = null;
        Node current = head;

        while (current != null)
        {
            Node next = current.next;
            current.next = previous;
            previous = current;
            current = next;
        }

        head = previous;
    }

    public T Center()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        int middleIndex = Size() / 2;
        Node current = head;

        for (int i = 0; i < middleIndex; i++)
        {
            current = current.next;
        }

        return current.data;
    }

    public void Iterator(Action<T> action)
    {
        Node current = head;

        while (current != null)
        {
            action(current.data);
            current = current.next;
        }
    }
    public void Traverse()
    {
        if (head == null)
        {
            Console.WriteLine("Priority queue is empty.");
        }
        else
        {
            Console.WriteLine("Priority queue elements:");
            Node current = head;
            while (current != null)
            {
                Console.WriteLine("Value: " + current.data + " Priority: " + current.priority);
                current = current.next;
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        PriorityQueue<string> queue = new PriorityQueue<string>();

        while (true)
        {
            Console.WriteLine("1. enqueue");
            Console.WriteLine("2. dequeue");
            Console.WriteLine("3. peek");
            Console.WriteLine("4. contains");
            Console.WriteLine("5. size");
            Console.WriteLine("6. reverse");
            Console.WriteLine("7. center");
            Console.WriteLine("8. traverse");
            Console.WriteLine("9. quit");

            Console.WriteLine("Enter any Choice:");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "enqueue":
                    Console.WriteLine("Enter item into the queue:");
                    string item = Console.ReadLine();

                    Console.WriteLine("Enter priority:");
                    int priority = int.Parse(Console.ReadLine());

                    queue.Enqueue(item, priority);
                    break;

                case "dequeue":
                    try
                    {
                        string dequeuedItem = queue.Dequeue();
                        Console.WriteLine("Dequeued item: " + dequeuedItem);
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    break;

                case "peek":
                    try
                    {
                        string peekedItem = queue.Peek();
                        Console.WriteLine("Peeked item: " + peekedItem);
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    break;

                case "contains":
                    Console.WriteLine("Enter item:");
                    string itemToCheck = Console.ReadLine();

                    bool containsItem = queue.Contains(itemToCheck);
                    Console.WriteLine("Queue " + (containsItem ? "contains: " : "does not contain") + " item " + itemToCheck);
                    break;

                case "size":
                    int size = queue.Size();
                    Console.WriteLine("Queue size: " + size);
                    break;

                case "reverse":
                    queue.Reverse();
                    Console.WriteLine("Queue reversed: ");
                    break;

                case "center":
                    try
                    {
                        string centerItem = queue.Center();
                        Console.WriteLine("Center item: " + centerItem);
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    break;

                case "traverse":
                    Console.WriteLine("Queue contents:");
                    queue.Traverse();
                    break;

                case "quit":
                    Console.WriteLine("Goodbye!");
                    return;
                   

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

        }
    }
}