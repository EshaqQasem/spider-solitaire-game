using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using spiderSoliterGame.Properties;
namespace spiderSoliterGame
{
    class CardVeiw:PictureBox
    {
       
        public CardVeiw(Card c)
        {
            card = c;
            this.ForeImage = Images[(int)card.CardType-1];
            this.cliped = true;
        }
        static Image[] Images = { Resources._1, Resources._2, Resources._3, Resources._4, Resources._5,
                                Resources._6,Resources._7,Resources._8,Resources._9,Resources._10,
                                Resources._11,Resources._12,Resources._13};
       private Card card;

       public Card Card
       {
           get { return card; }
           set { card = value; }
       }
       private bool cliped;

       public bool Cliped
       {
           get { return cliped; }
           set { cliped = value;
           this.Image = value ? CardVeiw.backImage : this.ForeImage;
           this.Invalidate();
           }
       }
       public void Clip()
       {
          

           Cliped = !Cliped;


       }



       private Image image;

       public Image ForeImage
       {
           get { return image; }
           set { image = value; }
       }

       public static Image backImage = Resources.background;

    }
}
