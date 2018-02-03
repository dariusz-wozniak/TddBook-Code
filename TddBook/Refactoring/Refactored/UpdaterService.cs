using System;
using System.Collections.Generic;
using System.Linq;

namespace TddBook.Refactoring.Refactored
{
    public static class UpdaterService
    {
        private static IProductsRepository _productsRepository;

        /// <summary>
        /// Horrible, horrible method used as an example for unit testing :)
        /// </summary>
        public static void Update(IEnumerable<IProduct> products, IEnumerable<ICustomer> customers, decimal newPrice)
        {
            List<IProduct> allProducts = _productsRepository.GetProducts();

            foreach (var product in allProducts)
            {
                var productToUpdate = allProducts.Single(x => x.Id == product.Id);

                productToUpdate.Price = PriceCalculator.Calculate(newPrice, product.Type);
                productToUpdate.MarkAsUpdated(DateTime.Now);
            }

            foreach (var customer in customers)
            {
                customer.RecalculatePrices();
            }
        }
    }
}
