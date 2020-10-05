using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Basic interface.
    /// </summary>
    interface IHello
    {
        /// <summary>
        /// <para type="description">The name to say hello to.</para>
        /// </summary>
        String Name { get; set; }
    }
}
