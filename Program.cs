using System;

class Program
{
    static bool ValidateLastName(string lastName)
    {
        // Check if the last name is not empty and has at least 3 characters
        if (!string.IsNullOrEmpty(lastName) && lastName.Length >= 3 && char.IsUpper(lastName[0]))
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
        Console.Write("Enter your Last Name: ");
        string userInput = Console.ReadLine();

        if (ValidateLastName(userInput))
        {
            Console.WriteLine("Valid Last Name");
        }
        else
        {
            Console.WriteLine("Invalid Last Name. The Last Name should start with a capital letter and have at least 3 characters.");
        }
    }
}

