using System;

namespace Interpreter.Core
{
    public class ApiTranslateException : Exception
    {
        public ApiTranslateException(string message) : base(message)
        {
        }
    }
}
