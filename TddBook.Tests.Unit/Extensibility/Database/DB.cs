using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TddBook.Tests.Unit.Extensibility.Database
{
    internal class DB
    {
        public static readonly string DatabaseKey = "database";

        public static IDatabase GetDatabase(TestContext context)
        {
            return GetDatabase(context.Test.Properties);
        }

        public static IDatabase GetDatabase(ITest test)
        {
            return GetDatabase(test.Properties);
        }

        private static IDatabase GetDatabase(IPropertyBag propertyBag)
        {
            return propertyBag[DatabaseKey].Cast<IDatabase>().Single();
        }
    }
}