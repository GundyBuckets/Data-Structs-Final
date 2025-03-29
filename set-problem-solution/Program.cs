using System;
using System.Collections.Generic;

public class UniqueCharactersFinder
{
    public static string FindUniqueCharacters(string inputString)
    {
        // Use a HashSet to store unique characters.
        HashSet<char> uniqueCharacters = new HashSet<char>();

        // Use a List to store the characters in the order they appear.
        List<char> orderedUniqueChars = new List<char>();

        // Iterate through the input string.
        foreach (char c in inputString)
        {
            // If the character is not already in the HashSet, add it.
            if (uniqueCharacters.Add(c)) // HashSet.Add() returns true if the element was added
            {
                // Also add it to the ordered list.
                orderedUniqueChars.Add(c);
            }
        }

        // Convert the list of unique characters to a string.
        return new string(orderedUniqueChars.ToArray());
    }
}
