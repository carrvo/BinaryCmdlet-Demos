using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellFormCmdlet
{
    [Cmdlet(VerbsLifecycle.Start, "Form")]
    [OutputType(typeof(IExternalConfig))]
    public sealed class StartForm : Cmdlet
    {
        private Config config;

        protected override void BeginProcessing()
        {
            config = new Config(new SquareForm());
            config.Form.Show();
        }

        protected override void EndProcessing()
        {
            WriteObject(config);
        }
    }
}
