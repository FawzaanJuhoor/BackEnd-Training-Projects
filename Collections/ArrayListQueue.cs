using System;
using System.Collections.Generic;

//ArrayList Class
class ArrayList<T>
{
    private List<T> data;

    //Initializes a new ArrayList.
    public ArrayList()
    {
        data = new List<T>();
    }

    //Retrieves the number of elements in the ArrayList.
    public int Size
    {
        get { return data.Count; }
    }

    //Checks if the ArrayList is empty.
    public bool IsEmpty
    {
        get { return data.Count == 0; }
    }

    //Adds an element to the ArrayList.
    public void Add(T element)
    {
        data.Add(element);
    }

    //Removes the specified element from the ArrayList.
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

    //Prints the elements of the ArrayList.
    public void Display()
    {
        Console.WriteLine(string.Join(", ", data));
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
        // Example usage:
        ArrayList<int> myArrayList = new ArrayList<int>();
        Console.WriteLine("Is the list empty? " + myArrayList.IsEmpty);  // Output: True

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

        //////////////////////////////////////////////////////////////////////////////////////////////////
        // Example usage:
        Queue<int> myQueue = new Queue<int>();
        Console.WriteLine("Is the queue empty? " + myQueue.IsEmpty);  // Output: True

        myQueue.Enqueue(1);
        myQueue.Enqueue(2);
        myQueue.Enqueue(3);
        myQueue.Enqueue(4);

        Console.WriteLine("Size of the queue: " + myQueue.Count);  // Output: 4

        myQueue.Display();  // Output: 1 2 3 4

        int dequeuedElement = myQueue.Dequeue();
        Console.WriteLine("Dequeued element: " + dequeuedElement);  // Output: 1
        Console.WriteLine("Size of the queue after dequeue: " + myQueue.Count);  // Output: 3

        int peekedElement = myQueue.Peek();
        Console.WriteLine("Peeked element: " + peekedElement);  // Output: 2
    }
}