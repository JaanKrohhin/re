using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinuVorm
{
    class Bilerid : Form
    {
            public Bilerid()
            {
                this.ClientSize = new System.Drawing.Size(1000, 600);
                //BackColor = Color.Black;

                TextBox box = new TextBox();
                box.Location = new Point(70, 100);

            }

        }
}
