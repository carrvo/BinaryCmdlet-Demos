using System;
using Xunit;
using System.Management.Automation;
using TestPowerShell1Cmdlet;
using System.Linq;

namespace XUnitPowerShellTest
{
    public class UnitTest1
    {
        [Fact]
        public void Output()
        {
            var cmdlet = new TestPowerShell1Cmdlet.TestPowerShell1Cmdlet
            {
                Name = "me"
            };
            string output = cmdlet.Invoke<string>().First<string>();
            Assert.Equal("Hello me", output);
        }
    }
}
