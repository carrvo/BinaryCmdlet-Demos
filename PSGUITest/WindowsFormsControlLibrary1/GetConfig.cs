using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellFormCmdlet
{
    [Cmdlet(VerbsCommon.Get, "Config")]
    [OutputType(typeof(ExternalConfig))]
    public sealed class GetConfig : Cmdlet
    {
        private ExternalConfig singleton;

        protected override void BeginProcessing()
        {
            var form = SquareForm.SingleTon;
            singleton = (ExternalConfig)form;
        }

        protected override void EndProcessing()
        {
            WriteObject(singleton);
        }
    }
}
