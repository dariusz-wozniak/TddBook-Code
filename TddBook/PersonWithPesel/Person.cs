namespace TddBook.PersonWithPesel
{
    public class Person
    {
        public string Pesel { get; private set; }

        public static Person WithPesel(string pesel)
        {
            return new Person { Pesel = pesel };
        }
    }
}
