using System;
using System.Collections.Generic;

//ArrayList Class
class ArrayListGeneric<T>
{
    private List<T> data;

    //Initializes a new ArrayListGeneric.
    public ArrayListGeneric()
    {
        data = new List<T>();
    }

    //Retrieves the number of elements in the ArrayListGeneric.
    public int Size
    {
        get { return data.Count; }
    }

    //Checks if the ArrayListGeneric is empty.
    public bool IsEmpty
    {
        get { return data.Count == 0; }
    }

    //Adds an element to the ArrayListGeneric.
    public void Add(T element)
    {
        data.Add(element);
    }

    //Removes the specified element from the ArrayListGeneric.
    public void Remove(T element)
    {
        if (data.Contains(element))
        {
            data.Remove(element);
        }
        else
        {
            Console.WriteLine($"{element} not found in the list.");
        }
    }

    //Retrieves the element at the specified index.
    public T Get(int index)
    {
        if (index >= 0 && index < data.Count)
        {
            return data[index];
        }
        else
        {
            Console.WriteLine("Index out of bounds.");
            return default(T);
        }
    }

    //Prints the elements of the ArrayListGeneric.
    public void Display()
    {
        Console.WriteLine(string.Join(", ", data));
    }
}





public class ArrayList
{
    private object[] data;    // Array to store elements
    private int count;         // Number of elements currently in the array
    private int capacity = 10; // Initial capacity of the array

    public ArrayList()
    {
        // Constructor: Initializes the ArrayList with an array of initial capacity and count set to 0.
        data = new object[capacity];
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public bool IsEmpty
    {
        get { return count == 0; }
    }

    public void Add(object element)
    {
        EnsureCapacity();   // Ensure enough capacity before adding a new element
        data[count++] = element;  // Add the element to the end of the array and increment count
    }

    public object Get(int index)
    {
        // Retrieve the element at the specified index
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Index out of range.");
            return null;
        }
        return data[index];
    }

    public void Remove(object element)
    {
        int index = Array.IndexOf(data, element, 0, count);

        if (index >= 0)
        {
            // Element found: Shift elements to fill the gap
            Array.Copy(data, index + 1, data, index, count - index - 1);
            count--;

            // Set the last element to null
            data[count] = null;
        }
        else
        {
            Console.WriteLine("Element not found in the ArrayList.");
        }
    }

    private void EnsureCapacity()
    {
        if (count == data.Length)
        {
            // If the array is full, double its capacity
            int newCapacity = data.Length * 2;
            Array.Resize(ref data, newCapacity);    // Modifies the array by resizing it
        }
    }

    public void Display()
    {
        // Display the elements in the array
        for (int i = 0; i < count; i++)
        {
            Console.Write(data[i] + " ");
        }
        Console.WriteLine();
    }
}


public class Queue<T>
{
    //Private class to represent a node in the linked list.
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
    }

    private Node front;
    private Node rear;

    //Initializes an empty queue.
    public Queue()
    {
        front = null;
        rear = null;
    }

    //Retrieves the number of elements in the queue.
    public int Count
    {
        get
        {
            int count = 0;
            Node current = front;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    //Checks if the queue is empty.
    public bool IsEmpty
    {
        get { return front == null; }
    }

    //Adds an element to the rear of the queue.
    public void Enqueue(T element)
    {
        Node newNode = new Node { Value = element, Next = null };

        if (rear == null)
        {
            // If the queue is empty, set both front and rear to the new node
            front = rear = newNode;
        }
        else
        {
            // Otherwise, add the new node to the rear and update the rear
            rear.Next = newNode;
            rear = newNode;
        }
    }

    //Removes and returns the element from the front of the queue.
    public T Dequeue()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Queue is empty.");
            return default(T);
        }

        T element = front.Value;

        if (front == rear)
        {
            // If there is only one element, set both front and rear to null
            front = rear = null;
        }
        else
        {
            // Otherwise, move the front to the next node
            front = front.Next;
        }

        return element;
    }

    //Retrieves the element at the front of the queue without removing it.
    public T Peek()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Queue is empty.");
            return default(T);
        }

        return front.Value;
    }

    //Prints the elements of the queue.
    public void Display()
    {
        Node current = front;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

class ArrayListQueue
{
    static void Main()
    {

        /*
        // Example usage:
        ArrayListGeneric<int> myArrayList = new ArrayListGeneric<int>();
        // Console.WriteLine("Is the list empty? " + myArrayList.IsEmpty);  // Output: True
    
        myArrayList.Add(1);
        myArrayList.Add(2);
        myArrayList.Add(3);
        myArrayList.Add(4);

        Console.WriteLine("Size of the list: " + myArrayList.Size);  // Output: 4

        myArrayList.Display();  // Output: 1, 2, 3, 4

        myArrayList.Remove(2);
        myArrayList.Display();  // Output: 1, 3, 4

        Console.WriteLine("Element at index 1: " + myArrayList.Get(1));  // Output: 3
        Console.WriteLine("Is the list empty? " + myArrayList.IsEmpty);  // Output: False

        */

        //////////////////////////////////////////////////////////////////////////////////////////////////
        System.Console.WriteLine();
        System.Console.WriteLine("Non-Generic arraylist:");

        //NON-GENERIC ARRAYLIST
         // Example usage of ArrayList
        ArrayList arrayList = new ArrayList();

        System.Console.WriteLine("Adding elements to array list");
        
        // Adding elements to the ArrayList
        arrayList.Add(1);
        arrayList.Add("Hello");
        arrayList.Add(3.14);
        arrayList.Add(true);

        Console.WriteLine("Elements in ArrayList:");
        arrayList.Display();
        Console.WriteLine("ArrayList Count: " + arrayList.Count);
        // Console.WriteLine("Is ArrayList Empty? " + arrayList.IsEmpty);


        // Removing an element
        System.Console.WriteLine("\nRemoving hello from array list");
        arrayList.Remove("Hello");

        Console.WriteLine("Updated Elements in ArrayList:");
        arrayList.Display();

        Console.WriteLine("ArrayList Count after removing an element: " + arrayList.Count);





        ////////////////////////////////////////////////////////////////////////////
        // Example usage:
        Queue<int> myQueue = new Queue<int>();
        Console.WriteLine();  // Output: True
        System.Console.WriteLine("FAWZ QUEUE");

        myQueue.Enqueue(1);
        myQueue.Enqueue(2);
        myQueue.Enqueue(3);
        myQueue.Enqueue(4);

        
        System.Console.WriteLine("Adding elements to queue");
        myQueue.Display();  // Output: 1 2 3 4
        Console.WriteLine("Size of the queue: " + myQueue.Count);  // Output: 4

        System.Console.WriteLine("removing element from queue");
        int dequeuedElement = myQueue.Dequeue();
        Console.WriteLine("Dequeued element: " + dequeuedElement);  // Output: 1
        Console.WriteLine("Size of the queue after dequeue: " + myQueue.Count);  // Output: 3

        
        int peekedElement = myQueue.Peek();
        Console.WriteLine("Peeked element: " + peekedElement);  // Output: 2

        myQueue.Display();
    }
}