﻿using System;
using Xunit;
using System.Management.Automation;
using TestCmdlet1;
using System.Linq;

namespace XUnitTest
{
    /// <summary>
    /// Examples with direct, native use of cmdlets.
    /// </summary>
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
            string output = cmdlet.Invoke<string>().FirstOrDefault<string>();
            Assert.Equal("Hello me", output);
        }

        /// <summary>
        /// Demonstrates the behaviour of invalid parameters when used directly.
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
            string output = cmdlet.Invoke<string>().FirstOrDefault<string>();
            Assert.Equal("Hello ", output);
        }

        /// <summary>
        /// Demonstrates the ability, and how, to use a cmdlet directly.
        /// </summary>
        [Fact]
        public void WhenAlternateHappyPathShouldOutput()
        {
            var cmdlet = new TestCmdlet1.TestPowerShell1Cmdlet();
            cmdlet.Name = "me";
            string output = cmdlet.Invoke<string>().FirstOrDefault<string>();
            Assert.Equal("Hello me", output);
        }

        /// <summary>
        /// Demonstrates the behaviour of invalid parameters when used directly.
        /// </summary>
        /// <remarks>
        /// As it turns out, no validation is performed on direct use.
        /// </remarks>
        [Fact]
        public void WhenAlternateInvalidParameterShouldOutput()
        {
            var cmdlet = new TestCmdlet1.TestPowerShell1Cmdlet();
            cmdlet.Name = "";
            string output = cmdlet.Invoke<string>().FirstOrDefault<string>();
            Assert.Equal("Hello ", output);
        }
    }
}
