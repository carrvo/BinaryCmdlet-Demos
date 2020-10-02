using System;
using TestCmdlet1;

namespace TestCmdlet2
{
    /// <summary>
    /// Simple Hello World example.
    /// </summary>
    public static class TestPowerShell2
    {
        /// <summary>
        /// Demonstrates how a Console Application can layer on top of, and natively use, a cmdlet.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
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
