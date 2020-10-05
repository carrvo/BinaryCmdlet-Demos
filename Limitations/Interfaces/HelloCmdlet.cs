using System;
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
    [Cmdlet(VerbsCommon.Get, "Hello", RemotingCapability = RemotingCapability.None)]
    public sealed class HelloCmdlet : Cmdlet, IHello
    {
        // Intentionally no in-line documentation here.
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public String Name { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject($"Hello {Name}");
        }
    }
}
