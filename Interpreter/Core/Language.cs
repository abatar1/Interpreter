namespace Interpreter.Core
{
    public class Language 
    {
        public override bool Equals(object other)
        {
            var toCompareWith = (Language)other;
            if (toCompareWith == null)
                return false;
            return Name == toCompareWith.Name &&
                   Code == toCompareWith.Code;
        }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}