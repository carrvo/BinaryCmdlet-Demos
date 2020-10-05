﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// <para type="synopsis">Determine whether inherited properties from an Interface are acceptable to PowerShell.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AdvancedHello", RemotingCapability = RemotingCapability.None)]
    public sealed class AdvancedHelloCmdlet : Cmdlet, IAdvancedHello
    {
        // Intentionally no in-line documentation here.
        public String Name { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject($"Hello {Name}");
        }
    }
}