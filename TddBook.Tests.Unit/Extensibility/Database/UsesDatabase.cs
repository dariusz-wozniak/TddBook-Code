using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TddBook.Tests.Unit.Extensibility.Database
{
    public class UsesDatabase : Attribute, ITestAction
    {
        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }

        public string Username { get; set; }

        public bool IsPoolingEnabled { get; set; }

        public void BeforeTest(ITest test)
        {
            var database = new Database
            {
                Username = Username,
                IsPoolingEnabled = IsPoolingEnabled
            };

            test.Properties.Set(DB.DatabaseKey, database);

            Console.WriteLine("Opening DB connection...");
            database.OpenConnection();
        }

        public void AfterTest(ITest test)
        {
            Console.WriteLine("Closing DB connection...");

            IDatabase database = DB.GetDatabase(test);
            database.CloseConnection();
        }
    }
}