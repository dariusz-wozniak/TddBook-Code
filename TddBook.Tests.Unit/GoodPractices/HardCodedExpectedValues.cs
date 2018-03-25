using System.IO;
using NUnit.Framework;

namespace TddBook.Tests.Unit.GoodPractices
{
    public class HardCodedExpectedValues
    {
        [Test]
        public void combine_creates_proper_path_for_three_directories__wrong()
        {
            var partition = "C";
            var dir1 = "Windows";
            var dir2 = "System32";
            var dir3 = "etc";

            string actualPath = Path.Combine(partition, dir1, dir2, dir3);

            string expectedPath = string.Join(@"\", partition, dir1, dir2, dir3); // Źle!

            Assert.That(actualPath, Is.EqualTo(expectedPath));
        }

        [Test]
        public void combine_creates_proper_path_for_three_directories__ok()
        {
            var partition = "C";
            var dir1 = "Windows";
            var dir2 = "System32";
            var dir3 = "etc";

            string actualPath = Path.Combine(partition, dir1, dir2, dir3);

            string expectedPath = @"C\Windows\System32\etc"; // Dobrze!

            Assert.That(actualPath, Is.EqualTo(expectedPath));
        }
    }
}
