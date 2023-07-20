using System;
using System.Collections.Generic;

public class Hash_Table
{
    private const int INITIAL_CAPACITY = 10;
    private int[] keys;
    private int[] values;
    private bool[] isDeleted;
    private int capacity;
    private int size;

    // Constructor to initialize the hash table
    public Hash_Table()
    {
        keys = new int[INITIAL_CAPACITY];
        values = new int[INITIAL_CAPACITY];
        isDeleted = new bool[INITIAL_CAPACITY];
        capacity = INITIAL_CAPACITY;
        size = 0;
    }

    // Hash function to get the index for a given key
    private int HashFunction(int key)
    {
        return key % capacity;
    }

    // Insert a key-value pair into the hash table
    public void Insert(int key, int value)
    {
        // If the hash table is half full, double its capacity
        if (size >= capacity / 2)
        {
            Resize();
        }

        // Get the index for the key using the hash function
        int index = HashFunction(key);

        // Handle collisions by probing linearly
        while (keys[index] != 0 && keys[index] != key && !isDeleted[index])
        {
            index = (index + 1) % capacity;
        }

        // Update the value if the key already exists in the hash table
        if (keys[index] == key && !isDeleted[index])
        {
            values[index] = value;
        }
        // Insert the key-value pair if the key is not already in the hash table
        else
        {
            keys[index] = key;
            values[index] = value;
            isDeleted[index] = false;
            size++;
        }
    }

    // Delete a key-value pair from the hash table
    public void Delete(int key)
    {
        int index = FindIndex(key);

        if (index != -1)
        {
            isDeleted[index] = true;
            size--;
        }
    }

    // Check if the hash table contains a given key
    public bool Contains(int key)
    {
        return FindIndex(key) != -1;
    }

    // Get the value associated with a given key in the hash table
    public int GetValue(int key)
    {
        int index = FindIndex(key);

        if (index != -1)
        {
            return values[index];
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }

    // Get the size of the hash table
    public int Size()
    {
        return size;
    }

    // Enumerate the values in the hash table
    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < capacity; i++)
        {
            if (keys[i] != 0 && !isDeleted[i])
            {
                yield return values[i];
            }
        }
    }

    // Traverse the values in the hash table and apply an action to each value
    public void Traverse(Action<int> action)
    {
        for (int i = 0; i < capacity; i++)
        {
            if (keys[i] != 0 && !isDeleted[i])
            {
                action(values[i]);
            }
        }
    }

    // Find the index of a given key in the hash table
    private int FindIndex(int key)
    {
        int index = HashFunction(key);

        while (keys[index] != 0)
        {
            if (keys[index] == key && !isDeleted[index])
            {
                return index;
            }

            index = (index + 1) % capacity;
        }

        return -1;
    }

    private void Resize()
    {
        int[] oldKeys = keys;
        int[] oldValues = values;
        bool[] oldIsDeleted = isDeleted;

        capacity *= 2;
        size = 0;
        keys = new int[capacity];
        values = new int[capacity];
        isDeleted = new bool[capacity];

        for (int i = 0; i < oldKeys.Length; i++)
        {
            if (oldKeys[i] != 0 && !oldIsDeleted[i])
            {
                Insert(oldKeys[i], oldValues[i]);
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Hash_Table hashTable = new Hash_Table();

        while (true)
        {
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Delete");
            Console.WriteLine("3. Contains");
            Console.WriteLine("4. Get Value by Key");
            Console.WriteLine("5. Size");
            Console.WriteLine("6. Traverse");
            Console.WriteLine("7. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter key: ");
                    int key = int.Parse(Console.ReadLine());

                    Console.Write("Enter value: ");
                    int value = int.Parse(Console.ReadLine());

                    hashTable.Insert(key, value);
                    Console.WriteLine("Element inserted.");
                    break;

                case 2:
                    Console.Write("Enter key: ");
                    key = int.Parse(Console.ReadLine());

                    hashTable.Delete(key);
                    Console.WriteLine("Element deleted.");
                    break;

                case 3:
                    Console.Write("Enter key: ");
                    key = int.Parse(Console.ReadLine());

                    if (hashTable.Contains(key))
                    {
                        Console.WriteLine("Element found.");
                    }
                    else
                    {
                        Console.WriteLine("Element not found.");
                    }

                    break;

                case 4:
                    Console.Write("Enter key: ");
                    key = int.Parse(Console.ReadLine());

                    try
                    {
                        value = hashTable.GetValue(key);
                        Console.WriteLine($"Value for key {key}: {value}");
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine("Key not found.");
                    }

                    break;

                case 5:
                    Console.WriteLine($"Size: {hashTable.Size()}");
                    break;

                case 6:
                    Console.WriteLine("Traversing elements:");

                    foreach (int val in hashTable)
                    {
                        Console.WriteLine(val);
                    }

                    break;

                case 7:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine();
        }
    }
}