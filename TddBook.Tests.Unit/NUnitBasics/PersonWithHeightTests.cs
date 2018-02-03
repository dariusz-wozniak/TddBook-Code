using NUnit.Framework;
using TddBook.PersonWithHeight;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class PersonWithHeightTests
    {
        [Test]
        public void when_two_persons_have_different_heights_than_they_are_different()
        {
            var comparer = new PersonByHeightComparer();

            Assert
                .That(Person.WithHeigthInCentimeters(170),
                    Is.LessThan(Person.WithHeigthInCentimeters(180))
                .Using(comparer));
        }
    }
}