## Set Data Structure Tutorial

### Introduction

A set is a data structure that stores a collection of *unique* elements.  Unlike lists or arrays, sets do not allow duplicate values.  Sets are designed for efficient membership testing, insertion, and deletion of elements.  This tutorial assumes you have a basic understanding of C# programming.

### Benefits of Sets

* **Uniqueness:** Guarantees that each element in the set is unique.  This is useful for eliminating duplicates.
* **Efficient Membership Testing:** Sets can quickly determine whether a specific element is present.
* **Efficient Insertion and Deletion:** Adding and removing elements from a set is generally faster than in other data structures, especially for large collections.
* **Mathematical Set Operations:** Sets support operations like union, intersection, and difference, which are useful in various algorithms and data analysis tasks.

## Set Operations

The primary operations performed on a set are:

- **.Add(element)**: Adds an element to the set. If the element is already present, the set remains unchanged.
- **.Remove(element)**: Removes the specified element from the set. Returns `true` if the element was successfully removed, `false` otherwise.
- **.Contains(element)**: Checks if the set contains the specified element. Returns `true` if the element is present, `false` otherwise.
- **.Count**: Returns the number of elements in the set.
- **.Clear()**: Removes all elements from the set.
- **.UnionWith(otherSet)**: Modifies the current set to contain all elements from itself and the `otherSet`.
- **.IntersectWith(otherSet)**: Modifies the current set to contain only the elements present in both itself and the `otherSet`.
- **.ExceptWith(otherSet)**: Modifies the current set to contain only the elements present in itself but not in the `otherSet`.
- **.IsSubsetOf(otherSet)**: Determines whether the current set is a subset of the `otherSet`.
- **.IsSupersetOf(otherSet)**: Determines whether the current set is a superset of the `otherSet`.

### Time Complexity

| Operation                | Description                                                                | Time Complexity |
|--------------------------|----------------------------------------------------------------------------|-----------------|
| `Add(element)`           | Adds an element to the set                                                 | O(1) average    |
| `Remove(element)`        | Removes the specified element from the set                                 | O(1) average    |
| `Contains(element)`      | Checks if the set contains the specified element                           | O(1) average    |
| `Count`                  | Returns the number of elements in the set                                  | O(1)            |
| `Clear()`                | Removes all elements from the set                                          | O(n)            |
| `UnionWith(otherSet)`    | Adds all elements from another set                                         | O(m)            |
| `IntersectWith(otherSet)`| Keeps only elements that exist in both sets                                | O(m)            |
| `ExceptWith(otherSet)`   | Removes elements in the other set from the current set                     | O(m)            |
| `IsSubsetOf(otherSet)`   | Checks if all elements of the current set exist in the other set           | O(m)            |
| `IsSupersetOf(otherSet)` | Checks if all elements of the other set exist in the current set           | O(m)            |

> _Note: `n` is the size of the current set, `m` is the size of the `otherSet`._

### Visual Representation

While sets don't have a linear ordering like queues, you can visualize them as a collection of distinct items:
```
{ Element1, Element2, Element3, Element4 }
```

### C# Implementation

C# provides the `HashSet<T>` class in the `System.Collections.Generic` namespace for implementing sets. Here's how you can use it:

```csharp
using System;
using System.Collections.Generic;

public class SetExample
{
    public static void Main(string[] args)
    {
        // Create a HashSet of integers.
        HashSet<int> mySet = new HashSet<int>();

        // Add elements.
        mySet.Add(1);
        mySet.Add(2);
        mySet.Add(3);
        mySet.Add(1); // Duplicate, will not be added.

        Console.WriteLine("Set contents:");
        foreach (int item in mySet)
        {
            Console.WriteLine(item); // Output: 1, 2, 3 (order may vary)
        }

        // Check if the set contains an element.
        bool containsTwo = mySet.Contains(2);
        Console.WriteLine($"\nContains 2? {containsTwo}"); // Output: Contains 2? True

        // Remove an element.
        bool removed = mySet.Remove(2);
        Console.WriteLine($"Removed 2? {removed}"); // Output: Removed 2? True

        Console.WriteLine("\nSet contents after removal:");
        foreach (int item in mySet)
        {
            Console.WriteLine(item); // Output: 1, 3
        }

        // Get the number of elements.
        int count = mySet.Count;
        Console.WriteLine($"\nCount: {count}"); // Output: Count: 2

        // Check if the set is empty.
        bool isEmpty = mySet.Count == 0;
        Console.WriteLine($"\nIs the set empty? {isEmpty}"); // Output: Is the set empty? False

        // Clear the set.
        mySet.Clear();
        Console.WriteLine($"\nCleared the set. New count: {mySet.Count}"); // Output: 0

        // Re-add elements to demonstrate set operations.
        mySet.UnionWith(new[] { 1, 2, 3 });
        HashSet<int> otherSet = new HashSet<int> { 2, 3, 4 };

        // UnionWith: Adds all elements from otherSet.
        mySet.UnionWith(otherSet);
        Console.WriteLine("\nAfter UnionWith(otherSet):");
        foreach (int item in mySet)
        {
            Console.WriteLine(item); // Output: 1, 2, 3, 4
        }

        // IntersectWith: Keeps only the elements that are in both sets.
        mySet.IntersectWith(new[] { 2, 4 });
        Console.WriteLine("\nAfter IntersectWith({2, 4}):");
        foreach (int item in mySet)
        {
            Console.WriteLine(item); // Output: 2, 4
        }

        // ExceptWith: Removes elements that are also in the other set.
        mySet.ExceptWith(new[] { 4 });
        Console.WriteLine("\nAfter ExceptWith({4}):");
        foreach (int item in mySet)
        {
            Console.WriteLine(item); // Output: 2
        }

        // IsSubsetOf: Check if current set is a subset of another set.
        bool isSubset = mySet.IsSubsetOf(new[] { 1, 2, 3 });
        Console.WriteLine($"\nIsSubsetOf({1, 2, 3}): {isSubset}"); // Output: True

        // IsSupersetOf: Check if current set is a superset of another set.
        bool isSuperset = mySet.IsSupersetOf(new[] { 2 });
        Console.WriteLine($"IsSupersetOf({2}): {isSuperset}"); // Output: True
    }
}

### Complete Example Problem: Finding Unique Words in a Text

### Problem Description:

You have a large text document, and you want to find all the unique words it contains. Case should be ignored, and punctuation should be removed.

### Solution:

We can use a `HashSet<string>` to store the unique words. Here's a C# program that does this:

```csharp
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class UniqueWordsFinder
{
    public static void Main(string[] args)
    {
        string text = "This is a sample text. This text contains sample words, and some words are repeated. Text is important.";
        HashSet<string> uniqueWords = new HashSet<string>();

        // 1. Remove punctuation and convert to lowercase using Regex
        // You don't need to worry about how to use Regex in this tutorial, just know that it's helpful for modifying strings
        string cleanedText = Regex.Replace(text, @"[^\w\s]", ""); // Remove punctuation
        cleanedText = cleanedText.ToLower(); // Convert to lowercase

        // 2. Split the text into words.
        string[] words = cleanedText.Split(' ');

        // 3. Add each word to the HashSet. Duplicates will be ignored.
        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word)) // Prevent empty words from being added
            {
                uniqueWords.Add(word);
            }
        }

        // 4. Print the unique words.
        Console.WriteLine("Unique words:");
        foreach (string word in uniqueWords)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine($"\nTotal unique words: {uniqueWords.Count}");
    }
}
```

### Explanation:

1. We create a `HashSet<string>` called uniqueWords to store the unique words.
2. We use a regular expression to remove punctuation from the text and convert the text to lowercase.
3. We split the text into individual words using the Split() method.
4. We iterate through the words and add each word to the uniqueWords set. Because it's a set, duplicate words are automatically ignored.
5. Finally, we print the unique words in the set.

### Practice Problem: Finding Unique Characters in a String

### Problem Description: 

Given a string, find all the unique characters in the string. Maintain the order in which the unique characters appear in the original string.

### Requirements:

1. Create a new UniqueCharacterFinder class
2. Create a method that takes a string as input and returns as string.
3. Use a set to find the unique characters
4. Add all the unique characters to an ordered list
5. Use the .toArray() function to convert the list to a string by using the string() function
3. Return the new string containing only the unique characters.

### Link to Solution

You can find a solution to this problem here: [Unique Characters Finder Solution](./set-problem-solution/Program.cs) 