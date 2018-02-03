using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    public class PlatformDependentTests
    {
        [Test]
        [Platform(Include = "64-Bit-OS")]
        public void _64_bits_only()
        {
            Assert.Pass();
        }

        [Test]
        [Platform(Exclude = "Win95,Win98,WinMe")]
        public void excluding_old_windows_versions()
        {
            Assert.Pass();
        }

        [Test]
        [Platform(Include = "Win95,Win98,WinMe")]
        public void including_old_windows_versions()
        {
            Assert.Pass();
        }

        [Test]
        [Ignore("AmigaOS is not supported")]
        [Platform(Include = "AmigaOS")]
        public void amiga_test()
        {
            Assert.Pass();
        }
    }
}