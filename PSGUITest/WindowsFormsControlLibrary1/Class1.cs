using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsControlLibrary1
{
    [Cmdlet(VerbsCommon.Get, "Config")]
    [OutputType(typeof(Interface1))]
    public sealed class Class1 : Cmdlet
    {
        private Interface1 singleton;

        protected override void BeginProcessing()
        {
            var form = Form1.SingleTon ?? new Form1();
            form.Show();
            singleton = (Interface1)form;
        }

        protected override void EndProcessing()
        {
            WriteObject(singleton);
        }
    }
}
