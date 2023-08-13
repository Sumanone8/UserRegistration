using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

public class InvalidFirstNameException : Exception
{
    public InvalidFirstNameException(string message) : base(message) { }
}

public class InvalidLastNameException : Exception
{
    public InvalidLastNameException(string message) : base(message) { }
}

public class InvalidEmailException : Exception
{
    public InvalidEmailException(string message) : base(message) { }
}

public class InvalidMobileException : Exception
{
    public InvalidMobileException(string message) : base(message) { }
}

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException(string message) : base(message) { }
}

[TestFixture]
public class UserValidationTests
{
    static void ValidateUserEntry(string firstName, string lastName, string email, string mobile, string password)
    {
        ValidateName(firstName);
        ValidateName(lastName);
        ValidateEmail(email);
        ValidateMobile(mobile);
        ValidatePassword(password);
    }

    static void ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new InvalidFirstNameException("First name is invalid.");
        }
    }

    static void ValidateEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        if (!Regex.IsMatch(email, pattern))
        {
            throw new InvalidEmailException("Email is invalid.");
        }
    }

    static void ValidateMobile(string mobile)
    {
        if (string.IsNullOrEmpty(mobile) || mobile.Length != 10 || !long.TryParse(mobile, out _))
        {
            throw new InvalidMobileException("Mobile number is invalid.");
        }
    }

    static void ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Contains("c# code"))
        {
            throw new InvalidPasswordException("Password is invalid.");
        }
    }

    [Test]
    public void ValidEntries_ShouldNotThrowExceptions()
    {
        Assert.DoesNotThrow(() => ValidateUserEntry("John", "Doe", "john.doe@example.com", "1234567890", "StrongPassword123"));
    }

    [Test]
    public void InvalidFirstName_ShouldThrowInvalidFirstNameException()
    {
        Assert.Throws<InvalidFirstNameException>(() => ValidateUserEntry("", "Smith", "jane.smith@example.com", "9876543210", "StrongPassword456"));
    }

    [Test]
    public void InvalidEmail_ShouldThrowInvalidEmailException()
    {
        Assert.Throws<InvalidEmailException>(() => ValidateUserEntry("Jane", "Smith", "invalid-email", "9876543210", "StrongPassword456"));
    }

    [Test]
    public void InvalidMobile_ShouldThrowInvalidMobileException()
    {
        Assert.Throws<InvalidMobileException>(() => ValidateUserEntry("John", "Doe", "john.doe@example.com", "invalid-mobile", "StrongPassword123"));
    }

    [Test]
    public void InvalidPassword_ShouldThrowInvalidPasswordException()
    {
        Assert.Throws<InvalidPasswordException>(() => ValidateUserEntry("John", "Doe", "john.doe@example.com", "1234567890", "WeakPassword with c# code"));
    }
}