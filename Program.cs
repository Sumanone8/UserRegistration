using NUnit.Framework;
using System.Text.RegularExpressions;

[TestFixture]
public class UserValidationTests
{
    [TestCase("John", "Doe", "john.doe@example.com", "1234567890", "SecurePassword123")]
    [TestCase("Jane", "Smith", "jane.smith@example.com", "9876543210", "StrongPassword456")]
    public void ValidEntries_ShouldReturnTrue(string firstName, string lastName, string email, string mobile, string password)
    {
        Assert.IsTrue(ValidateUserEntry(firstName, lastName, email, mobile, password));
    }

    [TestCase("John", "Doe", "invalid-email", "1234567890", "WeakPassword with c# code")]
    [TestCase("", "Smith", "jane.smith@example.com", "9876543210", "StrongPassword456")]
    [TestCase("Jane", "", "jane.smith@example.com", "9876543210", "StrongPassword456")]
    [TestCase("John", "Doe", "john.doe@example.com", "invalid-mobile", "SecurePassword123")]
    public void InvalidEntries_ShouldReturnFalse(string firstName, string lastName, string email, string mobile, string password)
    {
        Assert.IsFalse(ValidateUserEntry(firstName, lastName, email, mobile, password));
    }

    static bool ValidateUserEntry(string firstName, string lastName, string email, string mobile, string password)
    {
        return ValidateName(firstName) &&
               ValidateName(lastName) &&
               ValidateEmail(email) &&
               ValidateMobile(mobile) &&
               ValidatePassword(password);
    }

    static bool ValidateName(string name)
    {
        // Validate name logic here
        return !string.IsNullOrEmpty(name);
    }

    static bool ValidateEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }

    static bool ValidateMobile(string mobile)
    {
        // Validate mobile logic here
        return !string.IsNullOrEmpty(mobile) && mobile.Length == 10 && long.TryParse(mobile, out _);
    }

    static bool ValidatePassword(string password)
    {
        // Validate password logic here
        return !string.IsNullOrEmpty(password) && !password.Contains("c# code");
    }
}
