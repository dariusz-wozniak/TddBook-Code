namespace TddBook.CodeCoverage
{
    public class Number
    {
        public static bool IsEven(int number)
        { // 1
            if (number % 2 == 0) // 2
                return true; // 3
            return false; // 4
        } // 5
    }
}
