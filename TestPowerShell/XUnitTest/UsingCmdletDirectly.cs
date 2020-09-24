using System;
using Xunit;
using System.Management.Automation;
using TestCmdlet1;
using System.Linq;

namespace XUnitTest
{
    public sealed class UsingCmdletDirectly
    {
        [Fact]
        public void WhenHappyPathShouldOutput()
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
