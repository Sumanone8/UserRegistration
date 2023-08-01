using System;

class Program
{
    static bool ValidateMobileNumber(string mobileNumber)
    {
        // Check if the mobile number has a space at index 2 and is 13 characters long (including the space).
        if (mobileNumber.Length == 13 && mobileNumber[2] == ' ')
        {
            // Remove the country code and space from the mobile number and check if the rest are all digits.
            string numberPart = mobileNumber.Substring(3);
            foreach (char digit in numberPart)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        Console.Write("Enter your mobile number: ");
        string userInput = Console.ReadLine();

        if (ValidateMobileNumber(userInput))
        {
            Console.WriteLine("Valid mobile number");
        }
        else
        {
            Console.WriteLine("Invalid mobile number. Please enter a mobile number in the format '91 9919819801'.");
        }
    }
}
