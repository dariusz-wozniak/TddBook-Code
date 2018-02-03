using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TddBook.Tests.Unit.ParametrizedTests
{
    public class AdditionTestCaseData
    {
        public static IEnumerable<ITestCaseData> AdditionCases
        {
            get
            {
                yield return new TestCaseData(2, 2)
                    .Returns(4)
                    .SetName("2 plus 2 must equal 4");

                yield return new TestCaseData(1, -1)
                    .Returns(0)
                    .SetName("1 plus -1 must equal 0");
            }
        }
    }
}