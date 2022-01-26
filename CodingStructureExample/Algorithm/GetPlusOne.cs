using System;
using System.Management.Automation;
using Example.Concrete;

namespace Example.Algorithm
{
    [Cmdlet(VerbsCommon.Get, "PlusOne")]
    [OutputType(typeof(Int32))]
    public sealed class GetPlusOne : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public DTO InputObject { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(InputObject.Value + 1);
        }
    }
}
