using System;

public class BalancedTreeChecker
{
    // Define the TreeNode class
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

    // Main method to check if a tree is balanced
    public static bool IsBalanced(TreeNode root)
    {
        // If tree is empty, it's balanced by definition
        if (root == null)
            return true;

        // Get the height of left and right subtrees
        int leftHeight = GetHeight(root.Left);
        int rightHeight = GetHeight(root.Right);

        // Check if current node is balanced and recursively check subtrees
        return Math.Abs(leftHeight - rightHeight) <= 1 && 
               IsBalanced(root.Left) && 
               IsBalanced(root.Right);
    }

    // Helper method to get the height of a tree
    private static int GetHeight(TreeNode node)
    {
        // Base case: empty tree has height -1
        if (node == null)
            return -1;

        // Recursively get the height of the tallest subtree
        return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
    }

    // A more efficient solution that avoids recalculating heights
    // This solution has O(n) time complexity instead of O(n²)
    public static bool IsBalancedEfficient(TreeNode root)
    {
        return CheckHeight(root) != -2;
    }

    // Helper method that returns height if balanced, -2 if unbalanced
    private static int CheckHeight(TreeNode node)
    {
        // Base case: empty tree
        if (node == null)
            return -1;

        // Check left subtree
        int leftHeight = CheckHeight(node.Left);
        if (leftHeight == -2)
            return -2; // Propagate the "unbalanced" signal up

        // Check right subtree
        int rightHeight = CheckHeight(node.Right);
        if (rightHeight == -2)
            return -2; // Propagate the "unbalanced" signal up

        // Check if current node is balanced
        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -2; // This subtree is unbalanced
        else
            return Math.Max(leftHeight, rightHeight) + 1; // Return the height
    }

    public static void Main(string[] args)
    {
        // Create a balanced binary tree
        //      1
        //     / \
        //    2   3
        //   / \
        //  4   5
        TreeNode balancedRoot = new TreeNode(1);
        balancedRoot.Left = new TreeNode(2);
        balancedRoot.Right = new TreeNode(3);
        balancedRoot.Left.Left = new TreeNode(4);
        balancedRoot.Left.Right = new TreeNode(5);

        // Create an unbalanced binary tree
        //      1
        //     / 
        //    2   
        //   /
        //  3
        // /
        //4
        TreeNode unbalancedRoot = new TreeNode(1);
        unbalancedRoot.Left = new TreeNode(2);
        unbalancedRoot.Left.Left = new TreeNode(3);
        unbalancedRoot.Left.Left.Left = new TreeNode(4);

        // Test both implementations on both trees
        Console.WriteLine("Testing basic implementation:");
        Console.WriteLine($"Balanced tree is balanced: {IsBalanced(balancedRoot)}");
        Console.WriteLine($"Unbalanced tree is balanced: {IsBalanced(unbalancedRoot)}");

        Console.WriteLine("\nTesting efficient implementation:");
        Console.WriteLine($"Balanced tree is balanced: {IsBalancedEfficient(balancedRoot)}");
        Console.WriteLine($"Unbalanced tree is balanced: {IsBalancedEfficient(unbalancedRoot)}");

        // Expected output:
        // Testing basic implementation:
        // Balanced tree is balanced: True
        // Unbalanced tree is balanced: False
        //
        // Testing efficient implementation:
        // Balanced tree is balanced: True
        // Unbalanced tree is balanced: False
    }
}