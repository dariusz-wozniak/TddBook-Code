namespace TddBook.Calculators
{
    public class GenericCalculator<T>
    {
        public T Add(T a, T b)
        {
            return (dynamic) a + b;
        }
    }
}
