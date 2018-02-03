using NUnit.Framework;

namespace TddBook.Tests.Unit.Extensibility.Database
{
    public class DatabaseTests
    {
        [Test]
        [UsesDatabase(IsPoolingEnabled = true, Username = "dariusz_wozniak")]
        public void some_database_test()
        {
            Assert.Pass();
        }

        [Test]
        [UsesDatabase(IsPoolingEnabled = true, Username = "dariusz_wozniak")]
        public void query_test()
        {
            IDatabase database = DB.GetDatabase(TestContext.CurrentContext);

            var queryResult = database.Query<int>("some query");

            Assert.That(queryResult, Is.EqualTo(0));
        }

        [Test]
        [UsesDatabase]
        public void query_result_should_be_0_for_integers()
        {
            IDatabase database = DB.GetDatabase(TestContext.CurrentContext);

            var queryResult = database.Query<int>("some query");

            Assert.That(queryResult, Is.EqualTo(0));
        }

        [Test]
        [UsesDatabase(Username = "dariusz_wozniak")]
        public void username_should_be_properly_set()
        {
            IDatabase database = DB.GetDatabase(TestContext.CurrentContext);

            var username = database.Username;

            Assert.That(username, Is.EqualTo("dariusz_wozniak"));
        }

        [Test]
        [UsesDatabase(IsPoolingEnabled = true)]
        public void pooling_enabled_should_be_properly_set()
        {
            IDatabase database = DB.GetDatabase(TestContext.CurrentContext);

            var username = database.IsPoolingEnabled;

            Assert.That(username, Is.True);
        }

        [Test]
        [UsesDatabase]
        public void pooling_should_be_disabled_by_default()
        {
            IDatabase database = DB.GetDatabase(TestContext.CurrentContext);

            var username = database.IsPoolingEnabled;

            Assert.That(username, Is.False);
        }
    }
}