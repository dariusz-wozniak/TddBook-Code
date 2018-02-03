using System;

namespace TddBook.AgeCalculator
{
    public class AgeCalculator
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public AgeCalculator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public int GetAge(DateTime dateOfBirth)
        {
            DateTime now = _dateTimeProvider.GetDateTime();
            int age = now.Year - dateOfBirth.Year;

            if (now.Month < dateOfBirth.Month || 
                now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)
            {
                age--;
            }

            return age;
        }
    }
}