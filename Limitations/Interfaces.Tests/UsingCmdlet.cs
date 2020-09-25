using System;
using System.Linq;
using System.Management.Automation;
using Xunit;

namespace Interfaces.Tests
{
    public class UsingCmdlet
    {
        [Fact]
        public void ShouldRun()
        {
            var ps = PowerShell.Create();
            var cmdlet = new CmdletInfo("Get-Hello", typeof(HelloCmdlet));
            ps.AddCommand(cmdlet);
            ps.AddParameter("Name", "world");
            var output = ps.Invoke<String>().FirstOrDefault<String>();
            Assert.Equal("Hello world", output);
        }
    }
}
