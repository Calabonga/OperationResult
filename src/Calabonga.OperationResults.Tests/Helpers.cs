using System;

namespace Calabonga.OperationResults.Tests
{
    [Serializable]
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }

    [Serializable]
    public class SimpleCustomException : Exception
    {
        public SimpleCustomException() : base()
        {

        }
    }

    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public static class Messages
    {
        public const string Title1 = "Exception one title";
    }
}
