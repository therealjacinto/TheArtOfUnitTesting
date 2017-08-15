using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace LogAn.UnitTests
{
    public class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;

        public bool IsValid(string filename)
        {
            return WillBeValid;
        }
    }

    class TestableLogAnalyzer : LogAnalyzer
    {
        public IExtensionManager Manager;

        public TestableLogAnalyzer(IExtensionManager mgr)
        {
            Manager = mgr;
        }

        protected override IExtensionManager GetManager()
        {
            return Manager;
        }
    }

    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void OverrideTest()
        {
            FakeExtensionManager stub = new FakeExtensionManager()
            {
                WillBeValid = true
            };

            TestableLogAnalyzer logan = new TestableLogAnalyzer(stub);

            bool result = logan.IsValidLogFileName("file.ext");

            Assert.True(result);
        }
    }
}
