using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace TestMultipleBackends
{
    [Cmdlet(VerbsLifecycle.Invoke, "MyApp")]
    public class InvokeMyAppCommand : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public ISQLProvider SQL { get; set; }

        protected override void ProcessRecord()
        {
            SQL.CreateTable("MyApp");
            SQL.CreateRecord("MyRecord", "hello from MyApp");
        }
    }
}
