namespace TddBook.PersonWithHeight
{
    public class Person
    {
        public int HeightInCentimeters { get; private set; }

        public static Person WithHeigthInCentimeters(int heightInCm)
        {
            return new Person { HeightInCentimeters = heightInCm };
        }
    }
}
