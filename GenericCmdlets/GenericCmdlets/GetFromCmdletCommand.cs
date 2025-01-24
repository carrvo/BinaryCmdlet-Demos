using System;
using System.Management.Automation;

namespace GenericCmdlets
{
    /// <summary>
    /// <para type="notes">
    /// This cannot be called from PowerShell (gives error).
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Cmdlet(VerbsCommon.Get, "FromCmdlet")]
    public class GetFromCmdletCommand<T> : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public T InputObject { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject($"{InputObject} is of type {InputObject.GetType()}");
        }
    }
}
