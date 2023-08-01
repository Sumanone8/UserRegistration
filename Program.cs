using System;
using System.Text.RegularExpressions;

class Program
{
    static bool ValidateEmail(string email)
    {
        // Define the regular expression pattern for a valid email address
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Use Regex.IsMatch to check if the email matches the pattern
        if (Regex.IsMatch(email, pattern))
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
        string[] validEmails = {
            "abc@yahoo.com",
            "abc-100@yahoo.com",
            "abc.100@yahoo.com",
            "abc111@abc.com",
            "abc-100@abc.net",
            "abc.100@abc.com.au",
            "abc@1.com",
            "abc@gmail.com.com",
            "abc+100@gmail.com"
        };

        string[] invalidEmails = {
            "abc",
            "abc@.com.my",
            "abc123@gmail.a",
            "abc123@.com",
            "abc123@.com.com",
            ".abc@abc.com",
            "abc()*@gmail.com",
            "abc@%*.com",
            "abc..2002@gmail.com",
            "abc.@gmail.com",
            "abc@abc@gmail.com",
            "abc@gmail.com.1a",
            "abc@gmail.com.aa.au"
        };

        Console.WriteLine("Valid Emails:");
        foreach (string email in validEmails)
        {
            if (ValidateEmail(email))
            {
                Console.WriteLine($"- {email}");
            }
        }

        Console.WriteLine("\nInvalid Emails:");
        foreach (string email in invalidEmails)
        {
            if (!ValidateEmail(email))
            {
                Console.WriteLine($"- {email}");
            }
        }
    }
}