using System.Collections.Generic;

namespace TddBook.Refactoring.BeforeRefactoring
{
    internal interface IProductsRepository
    {
        List<IProduct> GetProducts();
    }
}