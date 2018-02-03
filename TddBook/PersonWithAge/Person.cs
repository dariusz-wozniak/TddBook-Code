using System;

namespace TddBook.PersonWithAge
{
    public class Person : IPerson
    {
        private int _age;
        private const int MaxAge = 122;

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(value),
                        message: $"Age must be less or equal to {MaxAge}");    
                }
                _age = value;
            }
        }
    }
}
