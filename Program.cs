using System;

class Program
{
    static bool ValidateFirstName(string firstName)
    {
        // Check if the first name is not empty and has at least 3 characters
        if (!string.IsNullOrEmpty(firstName) && firstName.Length >= 3 && char.IsUpper(firstName[0]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        Console.Write("Enter your First Name: ");
        string userInput = Console.ReadLine();

        if (ValidateFirstName(userInput))
        {
            Console.WriteLine("Valid First Name");
        }
        else
        {
            Console.WriteLine("Invalid First Name. The First Name should start with a capital letter and have at least 3 characters.");
        }
    }
}
