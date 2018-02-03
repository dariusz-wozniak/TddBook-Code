using System;
using System.Threading.Tasks;

namespace TddBook.Calculators
{
    public class Calculator
    {
        public event EventHandler<decimal> Calculated;

        public decimal Divide(decimal dividend, decimal divisor)
        {
            if (divisor == 0) throw new DivideByZeroException();

            decimal quotient = dividend / divisor;

            OnCalculated(quotient);

            return quotient;
        }

        public async Task<decimal> DivideAsync(decimal dividend, decimal divisor)
        {
            if (divisor == 0) throw new DivideByZeroException();

            return await GetResultFromTimeConsumingDivision(dividend, divisor);
        }

        private static async Task<decimal> GetResultFromTimeConsumingDivision(decimal dividend, decimal divisor)
        {
            // Simulate delay on time consuming calculation:
            await Task.Delay(millisecondsDelay: 300);

            return dividend / divisor;
        }

        protected virtual void OnCalculated(decimal result)
        {
            Calculated?.Invoke(this, result);
        }
    }
}
