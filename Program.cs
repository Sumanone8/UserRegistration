using System;

class Program
{
    static bool ValidatePassword(string password)
    {
        // Check if the password has a minimum of 8 characters.
        if (password.Length >= 8)
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
        Console.Write("Enter your password: ");
        string userInput = Console.ReadLine();

        if (ValidatePassword(userInput))
        {
            Console.WriteLine("Valid password");
        }
        else
        {
            Console.WriteLine("Invalid password. The password must have a minimum of 8 characters.");
        }
    }
}