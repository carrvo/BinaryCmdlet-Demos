using System;
using Xunit;
using System.Management.Automation;
using TestCmdlet1;
using System.Linq;

namespace XUnitTest
{
    public sealed class UsingCmdletDirectly
    {
        /// <summary>
        /// Demonstrates the ability, and how, to use a cmdlet directly.
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// As it turns out, no validation is performed on direct use.
        /// </remarks>
        [Fact]
        public void WhenInvalidParameterShouldOutput()
        {
            var cmdlet = new TestCmdlet1.TestPowerShell1Cmdlet
            {
                Name = ""
            };
            string output = cmdlet.Invoke<string>().First<string>();
            Assert.Equal("Hello ", output);
        }
    }
}
