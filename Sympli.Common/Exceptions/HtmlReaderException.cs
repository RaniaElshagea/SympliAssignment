using System;

namespace Sympli.Common.Exceptions
{
    public class HtmlReaderException : Exception
    {
        // In the future: Custom Error Page, Error messsage and further Exception handling and Logging should be considered.
        public HtmlReaderException() { }
        public HtmlReaderException(string message) : base(message) { }
        public HtmlReaderException(string message, Exception inner) : base(message, inner) { }
    }
}
