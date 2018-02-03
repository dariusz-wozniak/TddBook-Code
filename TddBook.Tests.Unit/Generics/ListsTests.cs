using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace TddBook.Tests.Unit.Generics
{
    [TestFixture(typeof(ArrayList))]
    [TestFixture(typeof(List<int>))]
    [TestFixture(typeof(Collection<int>))]
    public class ListsTests<T> where T : IList, new()
    {
        [Test]
        public void when_adding_two_elements_to_list_then_count_should_be_2()
        {
            var list = new T { 2, 3 };

            Assert.That(list, Has.Count.EqualTo(2));
        }
    }
}
