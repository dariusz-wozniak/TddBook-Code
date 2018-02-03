using System;

namespace TddBook.AgeCalculator
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}