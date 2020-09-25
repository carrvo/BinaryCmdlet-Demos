using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// <para type="synopsis">Determine whether Interface can define such that is acceptable to PowerShell.</para>
    /// </summary>
    interface IAdvancedHello
    {
        /// <summary>
        /// <para type="description">The name to say hello to.</para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        String Name { get; set; }
    }
}
