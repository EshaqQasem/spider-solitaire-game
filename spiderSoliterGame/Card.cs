using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace spiderSoliterGame
{
    public enum CardType
    {
        A=1, _2=2, _3=3, _4=4, _5=5, _6=6, _7=7, _8=8, _9=9, _10=10, J=11, Q=12, K=13
    }
    public class Card
    {
        public Card(CardType ct)
        {
            this.CardType = ct;
          
        }
        private CardType cardType;

        public CardType CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }

       
    }
}
