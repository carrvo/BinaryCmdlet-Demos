﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerShellFormCmdlet
{
    public partial class SquareForm : Form, IExternalConfig
    {
        public static SquareForm SingleTon { get; private set; } = new SquareForm();

        private SquareForm()
        {
            InitializeComponent();
        }

        private void Form1_BackColorChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
