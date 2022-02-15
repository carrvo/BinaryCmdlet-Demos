﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellFormCmdlet
{
    interface IExternalConfig
    {
        Color BackColor { get; set; }

        Boolean ReadClick { get; }

        Int32 ButtonXLocation { get; set; }

        Int32 ButtonYLocation { get; set; }

        String ButtonText { get; set; }
    }
}
