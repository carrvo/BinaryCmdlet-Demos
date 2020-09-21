using System;
using TestPowerShell1Cmdlet;

namespace TestPowerShell2
{
    class TestPowerShell2
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
                throw new Exception("must have exactly one input!");
            TestPowerShell1Cmdlet.TestPowerShell1Cmdlet t = new TestPowerShell1Cmdlet.TestPowerShell1Cmdlet();
            t.Name = args[0];
            foreach (string s in t.Invoke<string>())
            {
                Console.WriteLine(s);
            }
        }
    }
}
