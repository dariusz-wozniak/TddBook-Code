using System;
using System.Collections.Generic;

namespace TddBook.PersonWithPesel
{
    public class PersonByPeselEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return string.Equals(x.Pesel, y.Pesel, StringComparison.InvariantCulture);
        }

        public int GetHashCode(Person obj)
        {
            return obj.Pesel.GetHashCode();
        }
    }
}