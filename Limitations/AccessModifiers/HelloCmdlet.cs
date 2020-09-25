using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    /// <summary>
    /// <para type="synopsis">Determine whether different access modifiers are acceptable to PowerShell.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Hello", RemotingCapability = RemotingCapability.None)]
    public sealed class HelloCmdlet : Cmdlet
    {
        /// <summary>
        /// <para type="description">The name to say hello to.</para>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Public")]
        public String PublicName { get; private set; }
        /// <summary>
        /// <para type="description">The name to say hello to.</para>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Private")]
        public String PrivateName { get; private set; }
        /// <summary>
        /// <para type="description">The name to say hello to.</para>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Protected")]
        public String ProtectedName { get; private set; }
        /// <summary>
        /// <para type="description">The name to say hello to.</para>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Internal")]
        public String InternalName { get; private set; }
        /// <summary>
        /// <para type="description">The name to say hello to.</para>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "ProtectedInternal")]
        public String ProtectedInternalName { get; private set; }
        /// <summary>
        /// <para type="description">The name to say hello to.</para>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "PrivateProtected")]
        public String PrivateProtectedName { get; private set; }
        /// <summary>
        /// <para type="description">The name to say hello to.</para>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "NoSetter")]
        public String NoSetterName { get; private set; }

        protected override void ProcessRecord()
        {
            var name = String.Join(String.Empty, new String[]
            {
                PublicName,
                PrivateName,
                ProtectedName,
                InternalName,
                ProtectedInternalName,
                PrivateProtectedName,
                NoSetterName
            });
            WriteObject($"Hello {name}");
        }
    }
}
