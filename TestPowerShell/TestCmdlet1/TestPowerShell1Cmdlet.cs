using System;
using System.Management.Automation;

namespace TestCmdlet1
{
    [Cmdlet(VerbsDiagnostic.Test, "PowerShell1")]
    [OutputType(typeof(string))]
    public class TestPowerShell1Cmdlet : Cmdlet
    {
        /*
        static void Main(string[] args)
        {
            if (args.Length != 1)
                exit("must have exactly one input!");
            Console.WriteLine("Hello ${args[0]}");
        }
        */

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject($"Hello {Name}");
        }
    }
}
