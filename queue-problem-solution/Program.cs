using System;
using System.Collections.Generic;

public class CustomerServiceQueueSimulator
{
    public static void Main(string[] args)
    {
        Queue<string> inquiryQueue = new Queue<string>();
        string command;
        
        Console.WriteLine("Customer Service Queue Simulator");
        Console.WriteLine("---------------------------------");
        
        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Submit a new inquiry (enqueue)");
            Console.WriteLine("2. Process the next inquiry (dequeue)");
            Console.WriteLine("3. View the next inquiry (peek)");
            Console.WriteLine("4. View all current inquiries");
            Console.WriteLine("5. Check number of inquiries in queue");
            Console.WriteLine("6. Check if queue is empty");
            Console.WriteLine("7. Exit");
            
            Console.Write("Enter your choice: ");
            command = Console.ReadLine();
            
            switch (command)
            {
                case "1":
                    Console.Write("Enter customer inquiry description: ");
                    string inquiry = Console.ReadLine();
                    
                    // Add timestamp to the inquiry for better tracking
                    string timestampedInquiry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {inquiry}";
                    inquiryQueue.Enqueue(timestampedInquiry);
                    
                    Console.WriteLine($"Inquiry \"{inquiry}\" has been added to the queue.");
                    Console.WriteLine($"Current position in queue: {inquiryQueue.Count}");
                    break;
                    
                case "2":
                    if (inquiryQueue.Count > 0)
                    {
                        string processedInquiry = inquiryQueue.Dequeue();
                        Console.WriteLine($"Processing inquiry: \"{processedInquiry}\"");
                        Console.WriteLine("Inquiry has been resolved and removed from the queue.");
                    }
                    else
                    {
                        Console.WriteLine("No inquiries in the queue. All customers have been served!");
                    }
                    break;
                    
                case "3":
                    if (inquiryQueue.Count > 0)
                    {
                        string nextInquiry = inquiryQueue.Peek();
                        Console.WriteLine($"Next inquiry to be processed: \"{nextInquiry}\"");
                        Console.WriteLine($"Estimated wait time: {(inquiryQueue.Count - 1) * 5} minutes");
                    }
                    else
                    {
                        Console.WriteLine("No inquiries in the queue.");
                    }
                    break;
                    
                case "4":
                    if (inquiryQueue.Count > 0)
                    {
                        Console.WriteLine("Current inquiries in queue:");
                        int position = 1;
                        foreach (string item in inquiryQueue)
                        {
                            Console.WriteLine($"{position}. {item}");
                            position++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No inquiries in the queue.");
                    }
                    break;
                    
                case "5":
                    int count = inquiryQueue.Count;
                    string inquiryWord = count == 1 ? "inquiry" : "inquiries";
                    Console.WriteLine($"There {(count == 1 ? "is" : "are")} {count} {inquiryWord} in the queue.");
                    
                    if (count > 0)
                    {
                        Console.WriteLine($"Estimated time to clear queue: {count * 5} minutes");
                    }
                    break;
                    
                case "6":
                    bool isEmpty = inquiryQueue.Count == 0;
                    Console.WriteLine($"Is the queue empty? {isEmpty}");
                    break;
                    
                case "7":
                    Console.WriteLine("Thank you for using the Customer Service Queue Simulator!");
                    
                    if (inquiryQueue.Count > 0)
                    {
                        Console.WriteLine($"Warning: There are still {inquiryQueue.Count} unprocessed inquiries in the queue.");
                    }
                    
                    return;
                    
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}