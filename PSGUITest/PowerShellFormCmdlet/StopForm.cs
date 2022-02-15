using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellFormCmdlet
{
    [Cmdlet(VerbsLifecycle.Stop, "Form")]
    public sealed class StopForm : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Config Config { get; set; }

        protected override void ProcessRecord()
        {
            Config.Form.Close();
        }
    }
}
