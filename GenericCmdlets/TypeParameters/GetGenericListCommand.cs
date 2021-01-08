using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Reflection;

namespace TypeParameters
{
    /// <summary>
    /// <para type="notes">
    /// Must use Reflection.
    /// 
    /// Reference: https://stackoverflow.com/questions/2604743/setting-generic-type-at-runtime/2604844#2604844
    /// </para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GenericList")]
    public sealed class GetGenericListCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("Type")]
        public Type ListType { get; set; }

        protected override void BeginProcessing()
        {
            Type genericListType = typeof(List<>).MakeGenericType(new Type[] { ListType }); // List<ListType>
            ConstructorInfo genericListConstructor = genericListType.GetConstructor(new Type[] { }); // empty constructor
            object genericList = genericListConstructor.Invoke(new object[] { }); // instantiate
            WriteObject(genericList);
        }
    }
}
