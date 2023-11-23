using System;
using System.Collections;
using System.Collections.Generic;
 
public class ArrayList : IEnumerable<object>, IList<object>, ICollection<object>
{
    private object[] data;
    private int count;
    private int capacity = 10;
 
    public ArrayList()
    {
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
        EnsureCapacity();
        data[count++] = element;
    }
 
    public object Get(int index)
    {
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
            Array.Copy(data, index + 1, data, index, count - index - 1);
            count--;
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
            int newCapacity = data.Length * 2;
            Array.Resize(ref data, newCapacity);
        }
    }
 
    public void Display()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(data[i] + " ");
        }
        Console.WriteLine();
    }
 
    // IEnumerable Interface Implementation
 
    public IEnumerator<object> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return data[i];
        }
    }
 
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
 
    // IList Interface Implementation
 
    public bool IsReadOnly => false;
 
    public int IndexOf(object item)
    {
        return Array.IndexOf(data, item, 0, count);
    }
 
    public void Insert(int index, object item)
    {
        EnsureCapacity();
 
        if (index < count)
        {
            Array.Copy(data, index, data, index + 1, count - index);
        }
 
        data[index] = item;
        count++;
    }
 
    public void RemoveAt(int index)
    {
        if (index >= 0 && index < count)
        {
            Array.Copy(data, index + 1, data, index, count - index - 1);
            count--;
            data[count] = null;
        }
        else
        {
            Console.WriteLine("Index out of range.");
        }
    }
 
    public object this[int index]
    {
        get { return Get(index); }
        set
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("Index out of range.");
            }
            else
            {
                data[index] = value;
            }
        }
    }
 
    // ICollection Interface Implementation
 
    public void AddToCollection(object item)
    {
        Add(item);
    }
 
    public void Clear()
    {
        Array.Clear(data, 0, count);
        count = 0;
    }
 
    public bool Contains(object item)
    {
        return IndexOf(item) != -1;
    }
 
    public void CopyTo(object[] array, int arrayIndex)
    {
        Array.Copy(data, 0, array, arrayIndex, count);
    }
 
    bool ICollection<object>.Remove(object item)
    {
        Remove(item);
        return true;
    }
}
 
 
public class Queue<T> : IEnumerable<T>, IComparer<T> where T : IComparable<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
    }

    private Node front;
    private Node rear;

    private IComparer<T> comparer;

    public Queue() : this(Comparer<T>.Default)
    {
    }

    public Queue(IComparer<T> comparer)
    {
        this.comparer = comparer;
    }

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

    public bool IsEmpty
    {
        get { return front == null; }
    }

    public void Enqueue(T element)
    {
        Node newNode = new Node { Value = element, Next = null };

        if (rear == null)
        {
            front = rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
    }

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
            front = rear = null;
        }
        else
        {
            front = front.Next;
        }

        return element;
    }

    public T Peek()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Queue is empty.");
            return default(T);
        }

        return front.Value;
    }

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

    // Implementation of IEnumerable<T>
    public IEnumerator<T> GetEnumerator()
    {
        return new QueueEnumerator(front);
    }

    // Implementation of IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Nested Enumerator class
    private class QueueEnumerator : IEnumerator<T>
    {
        private Node current;

        public QueueEnumerator(Node front)
        {
            current = new Node { Next = front }; // Dummy node to simplify logic
        }

        public T Current => current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // Dispose logic (if needed)
        }

        public bool MoveNext()
        {
            if (current.Next != null)
            {
                current = current.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    // Implementation of IComparer<T>
    public int Compare(T x, T y)
    {
        return x.CompareTo(y);
    }

    // Sort method for the queue using IComparer<T>
    public void Sort()
    {
        if (front == null || front.Next == null)
        {
            // Nothing to sort for zero or one element
            return;
        }

        Node sorted = null;
        Node current = front;

        while (current != null)
        {
            Node next = current.Next;
            sorted = SortedInsert(sorted, current);
            current = next;
        }

        front = sorted;
    }

    private Node SortedInsert(Node sorted, Node newNode)
    {
        if (sorted == null || Compare(newNode.Value, sorted.Value) <= 0)
        {
            newNode.Next = sorted;
            return newNode;
        }

        Node current = sorted;
        while (current.Next != null && Compare(newNode.Value, current.Next.Value) > 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;

        return sorted;
    }
}

 
 
class Program
{
    static void Main()
    {
        Console.WriteLine("Example usage of ArrayList:");
 
        ArrayList arrayList = new ArrayList();
 
        // Adding elements to the ArrayList
        arrayList.Add(1);
        arrayList.Add("Hello");
        arrayList.Add(3.14);
        arrayList.Add(true);
 
        // Using IEnumerable for iteration
        Console.WriteLine("\nIterating through the ArrayList using IEnumerable:");
        foreach (var element in arrayList)
        {
            Console.Write(element + " ");
        }
 
        // Using IList for specific list operations
        Console.WriteLine("\nInserting 'World' at index 1 using IList:");
        arrayList.Insert(1, "World");
 
        // Displaying elements after insertion
        Console.WriteLine("Updated Elements in ArrayList:");
        foreach (var element in arrayList)
        {
            Console.Write(element + " ");
        }
 
        // Removing an element at index 2
        Console.WriteLine("\nRemoving an element at index 2 using IList:");
        arrayList.RemoveAt(2);
 
        // Displaying elements after removal
        Console.WriteLine("Updated Elements in ArrayList:");
        foreach (var element in arrayList)
        {
            Console.Write(element + " ");
        }
 
        //////////////////////////////////////////////////////////////////////////////
 
        // Example usage:
        Queue<int> myQueue = new Queue<int>();
 
        myQueue.Enqueue(1);
        myQueue.Enqueue(2);
        myQueue.Enqueue(3);
    
        // Iterate through the elements using IEnumerator
        Console.WriteLine("\nElements in the queue using IEnumerator:");
        IEnumerator<int> enumerator = myQueue.GetEnumerator();
        while (enumerator.MoveNext())
        {
            int element = enumerator.Current;
            Console.WriteLine(element);
        }
 
        // Alternatively, you can use foreach
        Console.WriteLine("\nElements in the queue using foreach:");
        foreach (int element in myQueue)
        {
            Console.WriteLine(element);
        }

        // Use the default comparer for integers
        //Queue<int> myQueue = new Queue<int>();

        myQueue.Enqueue(3);
        myQueue.Enqueue(1);
        myQueue.Enqueue(2);

        Console.WriteLine("Elements in the queue before sorting:");
        foreach (int element in myQueue)
        {
            Console.WriteLine(element);
        }

        // Sort the queue
        myQueue.Sort();

        Console.WriteLine("Elements in the queue after sorting:");
        foreach (int element in myQueue)
        {
            Console.WriteLine(element);
        }
    }
}