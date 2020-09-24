using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Xunit;
using TestCmdlet1;

namespace XUnitTest
{
    public sealed class UsingCmdletIndirectly
    {
        [Fact]
        public void WhenSimpleHappyPathShouldOutput()
        {
            var ps = PowerShell.Create();
            ps.AddCommand("Import-Module");
            ps.AddParameter("Name", "TestPowerShell1Cmdlet.dll");
            ps.AddCommand("Test-PowerShell1");
            ps.AddParameter("Name", "me");
            var output = ps.Invoke<string>().First<string>();
            Assert.Equal("Hello me", output);
        }

        [Fact]
        public void WhenComplexHappyPathShouldOutput()
        {
            var ps = PowerShell.Create();
            var cmdlet = new CmdletInfo("Test-PowerShell1", typeof(TestCmdlet1.TestPowerShell1Cmdlet));
            ps.AddCommand(cmdlet);
            ps.AddParameter("Name", "me");
            var output = ps.Invoke<string>().First<string>();
            Assert.Equal("Hello me", output);
        }
    }
}
