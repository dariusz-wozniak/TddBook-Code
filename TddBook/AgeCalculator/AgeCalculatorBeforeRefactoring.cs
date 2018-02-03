using System;

namespace TddBook.AgeCalculator
{
    public class AgeCalculatorBeforeRefactoring
    {
        // Source of the algorithm:
        // https://stackoverflow.com/questions/9/calculate-age-in-c-sharp/229#229
        public int GetAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
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