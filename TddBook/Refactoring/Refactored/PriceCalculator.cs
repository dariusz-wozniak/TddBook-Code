namespace TddBook.Refactoring.Refactored
{
    public static class PriceCalculator
    {
        private static decimal tax = 0.23m;

        public static decimal Calculate(decimal newPrice, ProductType productType)
        {
            return newPrice * tax;
        }
    }
}