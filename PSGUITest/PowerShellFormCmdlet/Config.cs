using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellFormCmdlet
{
    public class Config : IExternalConfig
    {
        internal SquareForm Form { get; }

        public Color BackColor { get => Form.BackColor; set => Form.BackColor = value; }

        public Config(SquareForm form)
        {
            Form = form;
        }
    }
}
