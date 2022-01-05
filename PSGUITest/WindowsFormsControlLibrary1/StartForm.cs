using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsControlLibrary1
{
    [Cmdlet(VerbsLifecycle.Start, "Form")]
    public sealed class StartForm : Cmdlet
    {
        protected override void BeginProcessing()
        {
            var form = SquareForm.SingleTon;
            form.Show();
        }
    }
}
