# Binary Tree Data Structure Tutorial

## Introduction
A binary tree is a hierarchical data structure in which each node has at most two children: a left child and a right child. Binary trees are fundamental in computer science for representing hierarchical relationships. A Binary Search Tree (BST) is a special type of binary tree where the left child contains a value less than the parent node, and the right child contains a value greater than the parent node. This tutorial assumes you have a basic understanding of C# programming.

## Benefits of Binary Trees
- **Efficient Search**: The average time complexity for search operations in a balanced BST is O(log n).
- **Ordered Structure**: In a Binary Search Tree, elements are stored in a way that allows for fast lookup, insertion, and deletion.
- **Hierarchical Representation**: Useful for representing hierarchical data such as expression trees or file systems.
- **Efficient Traversal**: Various traversal methods (in-order, pre-order, post-order) allow for different ways to process the data.

## Binary Tree Operations

The primary operations performed on a binary tree are:

- **Insert(element)**: Adds an element to the tree in the appropriate position based on the binary search tree property.
- **Search(element)**: Searches for an element in the tree and returns true if found, false otherwise.
- **Delete(element)**: Removes the specified element from the tree.
- **Traversals**: Various methods to visit all nodes in the tree in a specific order.
  - In-Order: Left, Root, Right
  - Pre-Order: Root, Left, Right
  - Post-Order: Left, Right, Root
  - Level-Order: Breadth-first traversal

### Time Complexity

| Operation         | Description                                                           | Time Complexity | 
|-------------------|-----------------------------------------------------------------------|-----------------|
| `Insert(element)` | Adds the element in its appropriate place in the binary tree         | O(log n) average |
| `Search(element)` | Searches for the element in the binary tree and returns true or false | O(log n) average |
| `Delete(element)` | Deletes the element from the binary tree                              | O(log n) average |
| `Traversal`       | Visits all nodes in the tree                                          | O(n)            |

> _Note: The time complexity is O(log n) for balanced trees. In the worst case (unbalanced tree), the time complexity can be O(n)._

### Visual Representation

A binary search tree can be visualized as follows:
```
      10
     /  \
    5    15
   / \     \
  2   7     20
```

## C# Implementation

C# implementation of a binary tree involves defining a node and the tree structure. Here's how you can implement it:

```csharp
using System;
using System.Collections.Generic;

// Define a node in the binary tree
class TreeNode {
    public int Value;    // The value stored in the node
    public TreeNode Left;   // Reference to the left child
    public TreeNode Right;  // Reference to the right child

    // Constructor to create a new node with a specific value
    public TreeNode(int value) {
        Value = value;
        Left = null;    // Initialize left child as null
        Right = null;   // Initialize right child as null
    }
}

// Define the Binary Search Tree class
class BinarySearchTree {
    public TreeNode Root;  // The root node of the tree

    // Insert a value into the BST
    public void Insert(int value) {
        // Call recursive helper method starting at the root
        Root = InsertRec(Root, value);
    }

    // Recursive helper method to insert a value
    private TreeNode InsertRec(TreeNode root, int value) {
        // If the tree is empty, create a new node and return it
        if (root == null) return new TreeNode(value);

        // Otherwise, recur down the tree
        if (value < root.Value)
            // Insert in the left subtree if value is less than root
            root.Left = InsertRec(root.Left, value);
        else if (value > root.Value)
            // Insert in the right subtree if value is greater than root
            root.Right = InsertRec(root.Right, value);
        // If value equals root's value, do nothing (no duplicates allowed)

        // Return the unchanged node pointer
        return root;
    }

    // Search for a value in the BST
    public bool Search(int value) {
        // Call recursive helper method starting at the root
        return SearchRec(Root, value);
    }

    // Recursive helper method to search for a value
    private bool SearchRec(TreeNode root, int value) {
        // Base cases: root is null or value is found
        if (root == null) return false;
        if (root.Value == value) return true;

        // Recur down the appropriate subtree
        return value < root.Value 
            ? SearchRec(root.Left, value)  // Search in left subtree
            : SearchRec(root.Right, value); // Search in right subtree
    }

    // Delete a value from the BST
    public void Delete(int value) {
        // Call recursive helper method starting at the root
        Root = DeleteRec(Root, value);
    }

    // Recursive helper method to delete a value
    private TreeNode DeleteRec(TreeNode root, int value) {
        // Base case: if tree is empty
        if (root == null) return null;

        // Recur down the tree
        if (value < root.Value)
            // If value is less than root, delete from left subtree
            root.Left = DeleteRec(root.Left, value);
        else if (value > root.Value)
            // If value is greater than root, delete from right subtree
            root.Right = DeleteRec(root.Right, value);
        else {
            // Node with only one child or no child
            if (root.Left == null) return root.Right;
            if (root.Right == null) return root.Left;

            // Node with two children: Get the inorder successor
            // (smallest in the right subtree)
            root.Value = MinValue(root.Right);

            // Delete the inorder successor
            root.Right = DeleteRec(root.Right, root.Value);
        }

        return root;
    }

    // Helper method to find the minimum value in a tree
    private int MinValue(TreeNode node) {
        int minv = node.Value;
        // Find the leftmost leaf
        while (node.Left != null) {
            minv = node.Left.Value;
            node = node.Left;
        }
        return minv;
    }

    // In-Order traversal (Left, Root, Right)
    public void InOrder(TreeNode node) {
        if (node == null) return;
        
        // First recur on left child
        InOrder(node.Left);
        
        // Then print the data of node
        Console.Write(node.Value + " ");
        
        // Finally recur on right child
        InOrder(node.Right);
    }

    // Pre-Order traversal (Root, Left, Right)
    public void PreOrder(TreeNode node) {
        if (node == null) return;
        
        // First print data of node
        Console.Write(node.Value + " ");
        
        // Then recur on left child
        PreOrder(node.Left);
        
        // Finally recur on right child
        PreOrder(node.Right);
    }

    // Post-Order traversal (Left, Right, Root)
    public void PostOrder(TreeNode node) {
        if (node == null) return;
        
        // First recur on left child
        PostOrder(node.Left);
        
        // Then recur on right child
        PostOrder(node.Right);
        
        // Finally print data of node
        Console.Write(node.Value + " ");
    }

    // Level Order (Breadth-First) traversal
    public void LevelOrder(TreeNode root) {
        if (root == null) return;

        // Create a queue for level order traversal
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        // Enqueue root
        queue.Enqueue(root);

        // Loop until queue is empty
        while (queue.Count > 0) {
            // Dequeue a node from front
            TreeNode node = queue.Dequeue();
            
            // Print the dequeued node
            Console.Write(node.Value + " ");

            // Enqueue left child if it exists
            if (node.Left != null) 
                queue.Enqueue(node.Left);

            // Enqueue right child if it exists
            if (node.Right != null) 
                queue.Enqueue(node.Right);
        }
    }
}
```

### Complete Example Problem: Finding the Height of a Binary Tree

### Problem Description:

The height of a binary tree is the number of edges on the longest path from the root node to any leaf node. Write a function to calculate the height of a binary tree.

### Solution:

```csharp
using System;

public class TreeHeightCalculator
{
    // Define the TreeNode class as before
    public class TreeNode {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value) {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    // Method to calculate height of a binary tree
    public static int CalculateHeight(TreeNode root)
    {
        // Base case: empty tree has height -1
        // A tree with just a root node has height 0
        if (root == null)
            return -1;

        // Recursively calculate height of left and right subtrees
        int leftHeight = CalculateHeight(root.Left);
        int rightHeight = CalculateHeight(root.Right);

        // Return the maximum height plus 1 (for the current node)
        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public static void Main(string[] args)
    {
        // Create a sample binary tree
        //      1
        //     / \
        //    2   3
        //   / \
        //  4   5
        //     /
        //    6
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);
        root.Left.Right.Left = new TreeNode(6);

        // Calculate and print the height
        int height = CalculateHeight(root);
        Console.WriteLine($"The height of the binary tree is: {height}");  // Output: 3
    }
}
```

### Explanation:

1. We define a `CalculateHeight` method that takes the root of a binary tree as input.
2. If the tree is empty (root is null), we return -1 as the height.
3. We recursively calculate the height of the left and right subtrees.
4. We take the maximum of the left and right subtree heights and add 1 (for the current level).
5. In the example tree we created, the longest path from root to leaf has 3 edges (1 -> 2 -> 5 -> 6), so the height is 3.

### Practice Problem: Checking if a Binary Tree is Balanced

### Problem Description:

A balanced binary tree is one where the height of the left and right subtrees of any node differs by no more than 1. Write a function to determine if a binary tree is balanced.

### Requirements:

1. Create a method `IsBalanced` that takes the root of a binary tree as input and returns a boolean.
2. The method should return true if the tree is balanced, and false otherwise.
3. Use recursion to solve this problem efficiently.
4. Utilize the height calculation concept from the previous example.

### Link to Solution

You can find a solution to this problem here: [Balanced Binary Tree Checker Solution](./binary-tree-problem-solution/Program.cs)
