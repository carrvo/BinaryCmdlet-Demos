using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class Form1 : Form, Interface1
    {
        internal static Form1 SingleTon { get; private set; }

        public Form1()
        {
            InitializeComponent();
            SingleTon = this;
        }

        private void Form1_BackColorChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
