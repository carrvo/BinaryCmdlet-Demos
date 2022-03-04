using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerShellFormCmdlet
{
    public class Config : IExternalConfig
    {
        internal SquareForm Form { get; }

        public Color BackColor { get => Form.BackColor; set => Form.BackColor = value; }

        private Boolean clicked = false;
        private readonly Object clickedLock = new Object();
        public Boolean ReadClick
        {
            get
            {
                lock (clickedLock)
                {
                    var old = clicked;
                    clicked = false;
                    return old;
                }
            }
        }

        public Int32 ButtonXLocation { get => Form.Interactive.Location.X; set => Form.Interactive.Location = new Point(value, Form.Interactive.Location.Y); }

        public Int32 ButtonYLocation { get => Form.Interactive.Location.Y; set => Form.Interactive.Location = new Point(Form.Interactive.Location.X, value); }

        public String ButtonText { get => Form.Interactive.Text; set => Form.Interactive.Text = value; }

        public void ClickTheForm()
        {
            Form.Interactive.PerformClick();
        }

        internal Config(SquareForm form)
        {
            Form = form;
            Form.Interactive.Click += Form_Click;
            Form.Interactive.Click += Form_Click_Feedback;
        }

        private void Form_Click_Feedback(object sender, EventArgs e)
        {
            Form.Interactive.Text = "clicked";
        }

        private void Form_Click(object sender, EventArgs e)
        {
            lock (clickedLock)
            {
                clicked = true;
            }
        }
    }
}
