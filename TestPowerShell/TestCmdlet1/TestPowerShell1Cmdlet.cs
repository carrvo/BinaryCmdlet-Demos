﻿using System;
using System.Management.Automation;

namespace TestCmdlet1
{
    /// <summary>
    /// <para type="synopsis">Simple Hello World example.</para>
    /// <example>
    ///     <para>PS></para>
    ///     <code>Test-PowerShell1 -Name World</code>
    /// </example>
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "PowerShell1")]
    [OutputType(typeof(string))]
    public sealed class TestPowerShell1Cmdlet : Cmdlet
    {
        /*
        /// <summary>
        /// This is what a Console Application would normally look like.
        /// <param name="args">Command line arguments.</param>
        /// </summary>
        public static void Main(string[] args)
        {
            if (args.Length != 1)
                exit("must have exactly one input!");
            Console.WriteLine("Hello ${args[0]}");
        }
        */

        /// <summary>
        /// <para type="description">Name to say 'Hello' to.</para>
        /// </summary>
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject($"Hello {Name}");
        }
    }
}
