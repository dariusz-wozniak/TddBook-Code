using System.Collections.Generic;

namespace TddBook.Refactoring.BeforeRefactoring
{
    public interface IProductsRepository
    {
        List<IProduct> GetProducts();
    }
}