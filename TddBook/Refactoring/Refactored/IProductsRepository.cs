using System.Collections.Generic;

namespace TddBook.Refactoring.Refactored
{
    internal interface IProductsRepository
    {
        List<IProduct> GetProducts();
    }
}