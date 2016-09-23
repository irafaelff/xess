using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Peca : Label
    {
        public string team;
        public string tipo;

        public Peca(System.Drawing.Image img, string team, string tipo)
        {
            this.tipo = tipo;
            this.team = team;
            base.Image = img;
            base.ImageAlign = ContentAlignment.MiddleCenter;
        }


    }
}
