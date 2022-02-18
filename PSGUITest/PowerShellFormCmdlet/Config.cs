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

        public Config(SquareForm form)
        {
            Form = form;
            Form.Interactive.Click += Form_Click;
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
