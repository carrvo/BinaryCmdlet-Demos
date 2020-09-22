using System;
using Xunit;
using System.Management.Automation;
using TestCmdlet1;
using System.Linq;

namespace XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Output()
        {
            var cmdlet = new TestCmdlet1.TestPowerShell1Cmdlet
            {
                Name = "me"
            };
            string output = cmdlet.Invoke<string>().First<string>();
            Assert.Equal("Hello me", output);
        }
    }
}
