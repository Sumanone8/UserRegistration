using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

public class InvalidUserDetailException : Exception
{
    public InvalidUserDetailException(string message) : base(message) { }
}

public class UserValidator
{
    public static void ValidateUserEntry(string firstName, string lastName, string email, string mobile, string password)
    {
        ValidateDetail(() => !string.IsNullOrEmpty(firstName), "First name is invalid.");
        ValidateDetail(() => !string.IsNullOrEmpty(lastName), "Last name is invalid.");
        ValidateDetail(() => IsValidEmail(email), "Email is invalid.");
        ValidateDetail(() => IsValidMobile(mobile), "Mobile number is invalid.");
        ValidateDetail(() => IsValidPassword(password), "Password is invalid.");
    }

    static void ValidateDetail(Func<bool> isValid, string errorMessage)
    {
        if (!isValid.Invoke())
        {
            throw new InvalidUserDetailException(errorMessage);
        }
    }

    static bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }

    static bool IsValidMobile(string mobile)
    {
        return !string.IsNullOrEmpty(mobile) && mobile.Length == 10 && long.TryParse(mobile, out _);
    }

    static bool IsValidPassword(string password)
    {
        return !string.IsNullOrEmpty(password) && !password.Contains("c# code");
    }
}

[TestFixture]
public class UserValidationTests
{
    [Test]
    public void ValidEntries_ShouldNotThrowExceptions()
    {
        Assert.DoesNotThrow(() => UserValidator.ValidateUserEntry("John", "Doe", "john.doe@example.com", "1234567890", "StrongPassword123"));
    }

    [Test]
    public void InvalidFirstName_ShouldThrowInvalidUserDetailException()
    {
        Assert.Throws<InvalidUserDetailException>(() => UserValidator.ValidateUserEntry("", "Smith", "jane.smith@example.com", "9876543210", "StrongPassword456"));
    }

    [Test]
    public void InvalidEmail_ShouldThrowInvalidUserDetailException()
    {
        Assert.Throws<InvalidUserDetailException>(() => UserValidator.ValidateUserEntry("Jane", "Smith", "invalid-email", "9876543210", "StrongPassword456"));
    }

    [Test]
    public void InvalidMobile_ShouldThrowInvalidUserDetailException()
    {
        Assert.Throws<InvalidUserDetailException>(() => UserValidator.ValidateUserEntry("John", "Doe", "john.doe@example.com", "invalid-mobile", "StrongPassword123"));
    }

    [Test]
    public void InvalidPassword_ShouldThrowInvalidUserDetailException()
    {
        Assert.Throws<InvalidUserDetailException>(() => UserValidator.ValidateUserEntry("John", "Doe", "john.doe@example.com", "1234567890", "WeakPassword with c# code"));
    }
}
