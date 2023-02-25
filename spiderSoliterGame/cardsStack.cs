using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace spiderSoliterGame
{
   public class cardsStack : Panel
    {

       public cardsStack()
       {
           this.ControlRemoved += (s, e) =>
           {
               
               this.CardVeiwTop -= 20;
           };
       }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Point[] ps = new Point[]{
                new Point(0,this.Height/5),
              new Point(0,0)
             ,new Point(this.Width-1,0)
              ,new Point(this.Width-1,this.Height/5)
            };
            e.Graphics.DrawLines(new Pen(new SolidBrush(Color.Red), 3), ps);
            // e.Graphics.DrawPolygon(new Pen(new SolidBrush(Color.Red),3), ps);
        }
        int CardVeiwTop = 0;

        public int CardVeiwTop1
        {
            get { return CardVeiwTop; }
            set { CardVeiwTop = value; }
        }
        public void Add(Card c,bool cliped)
        {
            CardVeiw tmp = new CardVeiw(c);
            tmp.Cliped = cliped;

            tmp.Size = new System.Drawing.Size(this.Width, 110);
          //  tmp.Padding = new System.Windows.Forms.Padding(2);
         //
            
            //tmp.BackColor = Color.Transparent;
            tmp.SizeMode = PictureBoxSizeMode.StretchImage;
            tmp.MouseEnter += tmp_MouseEnter;
            tmp.MouseLeave += tmp_MouseLeave;

            tmp.Top = CardVeiwTop;
            if (this.Controls.Count == 0)
                tmp.Top = CardVeiwTop = 0;
            
            {
                if (tmp.Cliped)
                    CardVeiwTop += 10;
                else
                    CardVeiwTop += 20;
            }
            // c.Left = 5;
            this.Controls.Add(tmp);
          //  this.st.Add(c);
          
            tmp.BringToFront();

        }
        public bool hasFullStack()
        {
            if(this.Controls.Count<13)
                return false;
            for (int i = 0; i < 12; i++)
            {
                if (((CardVeiw)this.Controls[i]).Card.CardType - ((CardVeiw)this.Controls[i+1]).Card.CardType != -1)
                    return false;
            }
            return true;
        }
        public bool DragOn(Card firstCard)
        {
            if (this.Controls.Count!=0 &&
                ((CardVeiw)this.Controls[0]).Card.CardType - firstCard.CardType != 1)
            {

                return false;
            }
            return true;

        }

        public bool Dragable(int i)
        {


            if (!((CardVeiw)this.Controls[i]).Cliped)
            {

                for (; i > 0; i--)
                {
                    if (((CardVeiw)this.Controls[i]).Card.CardType - ((CardVeiw)this.Controls[i - 1]).Card.CardType != 1)
                    {

                        return false;
                    }
                }
            }
            else
                return false;
            return true;
        }
        void tmp_MouseLeave(object sender, EventArgs e)
        {
            this.Refresh();
           // for (int j = this.Controls.IndexOf((Control)sender); j >= 0; j--)
             //   this.Controls[j].CreateGraphics().DrawRectangle(new Pen(new SolidBrush(Color.White), 3), this.Controls[j].ClientRectangle);

        }


       // List<CardVeiw> cards = new List<CardVeiw>();
        void tmp_MouseEnter(object sender, EventArgs e)
        {

           int i = this.Controls.IndexOf((Control)sender);
                if (Dragable(i))
                {
                    for (int j = i; j >= 0; j--)
                    {
                       // Rectangle r = this.Controls[j].ClientRectangle;
                       // this.Controls[j].CreateGraphics().DrawRectangle(new Pen(new SolidBrush(Color.Yellow), 3), this.Controls[j].ClientRectangle);
                       this.Controls[j].CreateGraphics().DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(255,Color.Yellow)), 3),this.Controls[j].ClientRectangle/* new Rectangle(new Point(r.X - 3, r.Y - 3), new Size(r.Width + 3, r.Height + 3))*/);
                     //  ((PictureBox)this.Controls[j]).BorderStyle = BorderStyle.FixedSingle;
                       
                    }
                }

        }

        internal void Clip()
        {
            if (this.Controls.Count > 0)
            {
                ((CardVeiw)this.Controls[0]).Clip();
                this.CardVeiwTop += 10;
            }

        }
    }
}
