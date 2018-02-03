using System;
using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class CultureDependentTests
    {
        [Test]
        [SetCulture("pl-PL")]
        public void polish_locale_date_test()
        {
            string date = new DateTime(1948, 4, 28).ToString("dd MMMM yyyy");

            Assert.That(date, Is.EqualTo("28 kwietnia 1948"));
        }

        [Test]
        [SetCulture("ka-GE")]
        public void georgian_locale_date_test()
        {
            string date = new DateTime(1948, 4, 28).ToString("dd MMMM yyyy");

            Assert.That(date, Is.EqualTo("28 აპრილი 1948"));
        }

        [Test]
        [SetCulture("tr-TR")]
        public void turkish_i_problem()
        {
            const string lowerCased = "interesting";

            string actualUpperCased = lowerCased.ToUpper();

            TestContext.WriteLine($"Actual upper cased `interesting` for tr-TR is: {actualUpperCased}");

            Assert.That(actualUpperCased, Is.Not.EqualTo("INTERESTING"));
            Assert.That(actualUpperCased, Is.EqualTo("İNTERESTİNG"));
        }

        [Test]
        [SetCulture("fa-IR")]
        public void farsi_decimal_mark()
        {
            double number = 82.8;

            string actual = number.ToString();

            Assert.That(actual, Is.EqualTo("82/8"));
        }

        [Test]
        [Culture("fa-IR")]
        public void farsi_only_test()
        {
            Assert.Pass("This test will pass only if the current locale is set to Farsi - Iran");
        }

        [Test]
        [Culture(Include = "en,pl,de")]
        public void test_for_some_cultures_only()
        {
            Assert.Pass("This test will pass only if the current locale is set to en or pl or de");
        }
    }
}