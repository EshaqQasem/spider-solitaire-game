using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spiderSoliterGame
{
    class WinStack:Panel
    {
        public WinStack()
        {
            this.AutoSize = true;
        }
        public void Add()
        {
            PictureBox b = new PictureBox();
            b.SizeMode = PictureBoxSizeMode.StretchImage;
            b.Image = global::spiderSoliterGame.Properties.Resources._13;
            b.Size = new System.Drawing.Size(80, 90);
            b.Location = new System.Drawing.Point(this.Controls.Count * 25, 0);
            
            this.Controls.Add(b);
        }

    }
}
