using System;

class Program
{
    static bool ValidatePassword(string password)
    {
        // Check if the password has a minimum of 8 characters.
        if (password.Length >= 8)
        {
            // Check if the password contains at least one uppercase letter.
            bool hasUppercase = false;
            foreach (char character in password)
            {
                if (char.IsUpper(character))
                {
                    hasUppercase = true;
                    break;
                }
            }

            // Check if the password contains at least one numeric digit.
            bool hasNumeric = false;
            foreach (char character in password)
            {
                if (char.IsDigit(character))
                {
                    hasNumeric = true;
                    break;
                }
            }

            // Return true only if both uppercase and numeric conditions are met.
            return hasUppercase && hasNumeric;
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
            Console.WriteLine("Invalid password. The password must have a minimum of 8 characters, at least one uppercase letter, and at least one numeric digit.");
        }
    }
}
