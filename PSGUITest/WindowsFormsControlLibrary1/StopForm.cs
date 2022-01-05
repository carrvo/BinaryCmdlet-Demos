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
        protected override void BeginProcessing()
        {
            var form = SquareForm.SingleTon;
            form.Close();
        }
    }
}
