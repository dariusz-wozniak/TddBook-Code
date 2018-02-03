using System.Collections.Generic;

namespace TddBook.Tests.Unit.ParametrizedTests
{
    public class AdditionTestData
    {
        public static IEnumerable<int[]> AdditionCases
        {
            get
            {
                yield return new[] { 2, 2, 4 };
                yield return new[] { 1, -1, 0 };
            }
        }
    }
}