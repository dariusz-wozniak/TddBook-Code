namespace TddBook.Tests.Unit.Extensibility.Database
{
    public class Database : IDatabase
    {
        public void OpenConnection() { }

        public void CloseConnection() { }

        public T Query<T>(string query)
        {
            return default(T);
        }

        public string Username { get; set; }

        public bool IsPoolingEnabled { get; set; }
    }
}