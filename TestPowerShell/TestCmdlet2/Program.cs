using System;
using TestCmdlet1;

namespace TestCmdlet2
{
    class TestPowerShell2
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
                throw new Exception("must have exactly one input!");
            TestCmdlet1.TestPowerShell1Cmdlet t = new TestCmdlet1.TestPowerShell1Cmdlet();
            t.Name = args[0];
            foreach (string s in t.Invoke<string>())
            {
                Console.WriteLine(s);
            }
        }
    }
}
