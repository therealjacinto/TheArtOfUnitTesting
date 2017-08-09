using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = MakeAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = MakeAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = MakeAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.SLF");

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_Throws()
        {
            LogAnalyzer analyzer = MakeAnalyzer();

            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));

            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        [TestCase("badfilename.foo", false)]
        [TestCase("goodfilename.slf", true)]
        public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer analyzer = MakeAnalyzer();

            analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);
        }
    }
}
