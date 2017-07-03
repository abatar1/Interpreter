using System;

namespace Interpreter.Core
{
    public class LanguageTranslateException : Exception
    {
        public LanguageTranslateException(string message) : base(message)
        {           
        }
    }
}