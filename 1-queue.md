# Queue Data Structure Tutorial

## Introduction
A queue is a fundamental data structure that operates on the principle of First-In, First-Out (FIFO). Imagine a line at a ticket counter: the first person in line is the first one to be served. Queues are essential for managing ordered data processing in various applications. This tutorial assumes you have a basic understanding of C# programming.

## Benefits of Queues
- **Order Preservation**: Guarantees that elements are processed in the sequence they were added. This is crucial for maintaining correct order in tasks.
- **Buffering**: Queues can temporarily hold data, acting as a buffer between processes that produce and consume data at different rates. This prevents data loss and system overload.
- **Fairness**: Queues ensure fairness in resource allocation by serving requests in the order they were received.

## Queue Operations
The primary operations performed on a queue are:
- **Enqueue(item)**: Adds an element to the rear (end) of the queue.
- **Dequeue()**: Removes and returns the element at the front of the queue.
- **Peek() / Front()**: Returns the element at the front of the queue without removing it.
- **IsEmpty()**: Checks if the queue contains any elements and returns a boolean value (true if empty, false otherwise).

## Visual Representation
Here's a visual representation of a queue:
```
+------+------+------+------+------+
|      |      |      |      |      | <-- Rear
+------+------+------+------+------+
Front
```

## C# Implementation
C# provides a built-in Queue<T> class in the System.Collections.Generic namespace.

Here's how you can use it:
```csharp
using System;
using System.Collections.Generic;

public class QueueExample
{
    public static void Main(string[] args)
    {
        // Create a queue of strings.
        Queue<string> myQueue = new Queue<string>();
        
        // Enqueue elements.
        myQueue.Enqueue("Item 1");
        myQueue.Enqueue("Item 2");
        myQueue.Enqueue("Item 3");
        
        Console.WriteLine("Queue contents:");
        foreach (string item in myQueue)
        {
            Console.WriteLine(item); // Output: Item 1, Item 2, Item 3
        }
        
        // Peek at the front element.
        string frontItem = myQueue.Peek();
        Console.WriteLine($"\nFront item: {frontItem}"); // Output: Front item: Item 1
        
        // Dequeue an element.
        string dequeuedItem = myQueue.Dequeue();
        Console.WriteLine($"Dequeued item: {dequeuedItem}"); // Output: Dequeued item: Item 1
        
        Console.WriteLine("\nQueue contents after dequeue:");
        foreach (string item in myQueue)
        {
            Console.WriteLine(item); // Output: Item 2, Item 3
        }
        
        // Check if the queue is empty.
        bool isEmpty = myQueue.Count == 0;
        Console.WriteLine($"\nIs the queue empty? {isEmpty}"); // Output: Is the queue empty? False
    }
}
```

## Complete Example Problem: Simulating a Print Queue

### Problem Description:
A computer lab has a shared printer. Multiple students can send print jobs to the printer, but the printer can only process one job at a time. We need to simulate this process using a queue to ensure that print jobs are processed in the order they are submitted.

### Solution:
We can use a Queue<string> to represent the print queue, where each string is the name of the document being printed. Here's a C# program that simulates this:

```csharp
using System;
using System.Collections.Generic;

public class PrintQueueSimulator
{
    public static void Main(string[] args)
    {
        Queue<string> printQueue = new Queue<string>();
        string command;
        
        Console.WriteLine("Print Queue Simulator");
        Console.WriteLine("-----------------------");
        
        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add a print job (enqueue)");
            Console.WriteLine("2. Print the next job (dequeue)");
            Console.WriteLine("3. View the next job (peek)");
            Console.WriteLine("4. View the current queue");
            Console.WriteLine("5. Check if queue is empty");
            Console.WriteLine("6. Exit");
            
            Console.Write("Enter your choice: ");
            command = Console.ReadLine();
            
            switch (command)
            {
                case "1":
                    Console.Write("Enter document name: ");
                    string documentName = Console.ReadLine();
                    printQueue.Enqueue(documentName);
                    Console.WriteLine($"Document \"{documentName}\" added to the queue.");
                    break;
                    
                case "2":
                    if (printQueue.Count > 0)
                    {
                        string printedDocument = printQueue.Dequeue();
                        Console.WriteLine($"Printing document: \"{printedDocument}\"");
                    }
                    else
                    {
                        Console.WriteLine("No documents in the queue.");
                    }
                    break;
                    
                case "3":
                    if (printQueue.Count > 0)
                    {
                        string nextDocument = printQueue.Peek();
                        Console.WriteLine($"Next document to print: \"{nextDocument}\"");
                    }
                    else
                    {
                        Console.WriteLine("No documents in the queue.");
                    }
                    break;
                    
                case "4":
                    if (printQueue.Count > 0)
                    {
                        Console.WriteLine("Current queue:");
                        foreach (string doc in printQueue)
                        {
                            Console.WriteLine($"- {doc}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No documents in the queue.");
                    }
                    break;
                    
                case "5":
                    bool isEmpty = printQueue.Count == 0;
                    Console.WriteLine($"Is the queue empty? {isEmpty}");
                    break;
                    
                case "6":
                    Console.WriteLine("Exiting simulator.");
                    return;
                    
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }
}
```

### Explanation:
1. We create a Queue<string> to store the names of the documents.
2. The program presents a menu of options to the user.
3. The Enqueue operation adds a new document to the print queue.
4. The Dequeue operation removes and "prints" the next document in the queue.
5. The Peek operation shows the next document to be printed without removing it.
6. The program continues until the user chooses to exit.

## Practice Problem: Simulating a Customer Service Queue

### Problem Description:
A customer service center handles customer inquiries. Customers can submit inquiries, and customer service representatives process them in the order they are received. Simulate this process using a queue.

### Requirements:
1. Create a queue to represent the customer service queue.
2. Allow customers to submit inquiries (enqueue).
3. Allow customer service representatives to process the next inquiry (dequeue).
4. Display the next inquiry to be processed (peek).
5. Display all current inquiries in the queue.
6. Allow the user to check the number of inquiries in the queue.
7. Allow the user to check if the queue is empty.

### Link to Solution:
You can find a solution to this problem here: [Customer Service Queue Solution](./queue-problem-solution/Program.cs)