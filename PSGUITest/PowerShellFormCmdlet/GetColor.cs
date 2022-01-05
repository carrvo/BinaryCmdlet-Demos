using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellFormCmdlet
{
    [Cmdlet(VerbsCommon.Get, "Color")]
    [OutputType(typeof(Color))]
    public sealed class GetColor : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "update")]
        public Color BaseColor { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "update")]
        [Parameter(Mandatory = true, ParameterSetName = "new")]
        [ValidateNotNull]
        [ValidateRange(0, 255)]
        public Int32? RedShading { get; set; } = null;

        [Parameter(Mandatory = false, ParameterSetName = "update")]
        [Parameter(Mandatory = true, ParameterSetName = "new")]
        [ValidateNotNull]
        [ValidateRange(0, 255)]
        public Int32? GreenShading { get; set; } = null;

        [Parameter(Mandatory = false, ParameterSetName = "update")]
        [Parameter(Mandatory = true, ParameterSetName = "new")]
        [ValidateNotNull]
        [ValidateRange(0, 255)]
        public Int32? BlueShading { get; set; } = null;

        protected override void ProcessRecord()
        {
            if (!RedShading.HasValue)
            {
                RedShading = BaseColor.R;
            }

            if (!GreenShading.HasValue)
            {
                GreenShading = BaseColor.G;
            }

            if (!BlueShading.HasValue)
            {
                BlueShading = BaseColor.B;
            }

            var newColor = Color.FromArgb(RedShading.Value, GreenShading.Value, BlueShading.Value);
            WriteObject(newColor);
        }
    }
}
