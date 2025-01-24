using System;
using System.Management.Automation;

namespace Example.Concrete
{
    [Cmdlet(VerbsCommon.Get, nameof(DTO))]
    [OutputType(typeof(DTO))]
    public sealed class GetDTO : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Int32 Value { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(new DTO { Value = Value });
        }
    }
}
