using NUnit.Framework;
using System;
using System.Collections;
using System.Text.RegularExpressions;

[TestFixture]
public class EmailValidationParameterizedTests
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData("abc@yahoo.com").Returns(true);
            yield return new TestCaseData("abc-100@yahoo.com").Returns(true);
            yield return new TestCaseData("abc.100@yahoo.com").Returns(true);
            yield return new TestCaseData("abc111@abc.com").Returns(true);
            yield return new TestCaseData("abc-100@abc.net").Returns(true);
            yield return new TestCaseData("abc.100@abc.com.au").Returns(true);
            yield return new TestCaseData("abc@1.com").Returns(true);
            yield return new TestCaseData("abc@gmail.com.com").Returns(true);
            yield return new TestCaseData("abc+100@gmail.com").Returns(true);

            yield return new TestCaseData("abc").Returns(false);
            yield return new TestCaseData("abc@.com.my").Returns(false);
            yield return new TestCaseData("abc123@gmail.a").Returns(false);
            yield return new TestCaseData("abc123@.com").Returns(false);
            yield return new TestCaseData("abc123@.com.com").Returns(false);
            yield return new TestCaseData(".abc@abc.com").Returns(false);
            yield return new TestCaseData("abc()*@gmail.com").Returns(false);
            yield return new TestCaseData("abc@%*.com").Returns(false);
            yield return new TestCaseData("abc..2002@gmail.com").Returns(false);
            yield return new TestCaseData("abc.@gmail.com").Returns(false);
            yield return new TestCaseData("abc@abc@gmail.com").Returns(false);
            yield return new TestCaseData("abc@gmail.com.1a").Returns(false);
            yield return new TestCaseData("abc@gmail.com.aa.au").Returns(false);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public bool ValidateEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }
}