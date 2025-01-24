using System;
using System.Management.Automation;

namespace Example.Component
{
    [Cmdlet(VerbsLifecycle.Invoke, "Algorithm")]
    [OutputType(typeof(Int32))]
    public sealed class InvokeAlgorithm : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public IData InputObject { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(InputObject.PlusOne());
        }
    }
}
