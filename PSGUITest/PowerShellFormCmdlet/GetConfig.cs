using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellFormCmdlet
{
    [Cmdlet(VerbsCommon.Get, "Config")]
    [OutputType(typeof(IExternalConfig))]
    public sealed class GetConfig : Cmdlet
    {
        private IExternalConfig config;

        protected override void BeginProcessing()
        {
            config = new Config(SquareForm.SingleTon);
        }

        protected override void EndProcessing()
        {
            WriteObject(config);
        }
    }
}
