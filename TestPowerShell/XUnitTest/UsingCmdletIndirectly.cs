using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Xunit;
using TestCmdlet1;
using Xunit.Abstractions;

namespace XUnitTest
{
    public sealed class UsingCmdletIndirectly
    {
        private ITestOutputHelper Output { get; }

        public UsingCmdletIndirectly(ITestOutputHelper output)
        {
            Output = output;
        }

        private void CheckForPowerShellErrors(PowerShell ps)
        {
            if (ps.HadErrors)
            {
                Output.WriteLine(String.Join(Environment.NewLine,
                    ps
                        .Streams
                        .Error
                        .ReadAll()
                        .Select(er => $"{er.Exception.Message}{Environment.NewLine}{er.ScriptStackTrace}{Environment.NewLine}{er.Exception.StackTrace}")));
                Assert.True(ps.HadErrors, "PowerShell had one or more errors.");
            }
        }

        [Fact]
        public void WhenSimpleHappyPathShouldOutput()
        {
            var ps = PowerShell.Create();
            ps.AddCommand("Import-Module");
            ps.AddParameter("Name", ".\\TestCmdlet1.dll");
            ps.AddParameter("ErrorAction", "Stop");
            ps.AddStatement();
            ps.AddCommand("Test-PowerShell1");
            ps.AddParameter("Name", "me");
            var output = ps.Invoke<string>().First<string>();
            CheckForPowerShellErrors(ps);
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
            CheckForPowerShellErrors(ps);
            Assert.Equal("Hello me", output);
        }
    }
}
