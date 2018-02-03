using NUnit.Framework;
using TddBook.Calculators;

namespace TddBook.Tests.Unit.Generics
{
    [TestFixture(typeof(double))]
    [TestFixture(typeof(decimal))]
    [TestFixture(typeof(float))]
    [TestFixture(typeof(int))]
    [TestFixture(typeof(long))]
    public class GenericCalculatorTests<T>
    {
        [Test]
        public void addition_test()
        {
            dynamic a = 2;
            dynamic b = 3;

            var calculator = new GenericCalculator<T>();
            dynamic result = calculator.Add(a, b);

            Assert.That(result, Is.EqualTo(5));
        }
    }
}
