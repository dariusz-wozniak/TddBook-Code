using System;

namespace TddBook.Refactoring.BeforeRefactoring
{
    public class ProductNotSupportedException : Exception
    {
        public ProductNotSupportedException(string messsage)
        {
            throw new NotImplementedException();
        }
    }
}