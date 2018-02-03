using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class CollectionTests
    {
        [Test]
        public void test()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            // Classic Model:
            CollectionAssert.Contains(numbers, 2);
            CollectionAssert.AllItemsAreUnique(numbers);
            CollectionAssert.AllItemsAreNotNull(numbers);
            CollectionAssert.AllItemsAreInstancesOfType(numbers, typeof(int));
            CollectionAssert.IsEmpty(new List<int>());
            CollectionAssert.IsSubsetOf(new List<int> { 1, 3 }, numbers);
            CollectionAssert.IsSupersetOf(numbers, new List<int> { 4, 1 });
            CollectionAssert.IsOrdered(numbers);
            CollectionAssert.AreEquivalent(new List<int> { 6, 5, 4, 3, 2, 1 }, numbers);

            // Constraint-Based Model:
            Assert.That(numbers, Has.Member(2));
            Assert.That(numbers, Does.Not.Contains(7));
            Assert.That(numbers, Is.Unique);
            Assert.That(numbers, Has.Some.GreaterThan(3));
            Assert.That(numbers, Has.None.Null);
            Assert.That(numbers, Has.None.GreaterThan(6));
            Assert.That(numbers, Has.Exactly(6).Items);
            Assert.That(numbers, Has.Exactly(3).Items.LessThanOrEqualTo(3));
            Assert.That(numbers, Has.Exactly(1).EqualTo(1).And.Exactly(1).EqualTo(3));
            Assert.That(numbers, Is.All.Not.Null);
            Assert.That(numbers, Has.All.GreaterThan(0));
            Assert.That(numbers, Has.All.InstanceOf<int>());
            Assert.That(new List<int>(), Is.Empty);
            Assert.That(numbers, Is.Not.Empty);
            Assert.That(numbers, Is.SupersetOf(new List<int> { 4, 1 }));
            Assert.That(new List<int> { 1, 3 }, Is.SubsetOf(numbers));
            Assert.That(numbers, Is.Ordered);
            Assert.That(numbers, Is.EquivalentTo(new List<int> { 6, 5, 4, 3, 2, 1 }));
        }
    }
}
