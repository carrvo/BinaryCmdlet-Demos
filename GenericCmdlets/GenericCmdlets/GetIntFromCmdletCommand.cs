using System;
using System.Management.Automation;

namespace GenericCmdlets
{
    /// <summary>
    /// <para type="notes">
    /// However, this *can* be called by PowerShell.
    /// </para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "IntFromCmdlet")] // must be unique name
    public sealed class GetIntFromCmdletCommand : GetFromCmdletCommand<Int32>
    {
    }
}
