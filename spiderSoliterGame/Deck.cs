using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spiderSoliterGame
{
    class Deck:IEnumerable
    {
        Card[] Cards;
        int cardCount;

        public int CardCount
        {
            get { return cardCount; }
            set { cardCount = value; }
        }
        public Deck(int num,bool initCards=true)
        {
            cardCount = num;
            Cards = new Card[cardCount];
            if(initCards)
            {
                for (int i = 0; i < cardCount; i++)
                {

                    Cards[i] = new Card((CardType)(i % 13 + 1)); ;
                }
            }
        }
        public Card this[int i]
        {
            get
            {
                return Cards[i];
            }
            set
            {
                Cards[i] = value;
            }
        }

       

        public Card Top
        {
            get { return Cards[--CardCount]; }
           
        }
        public void Shuffle()
        {
           
             Random random = new Random();;
            for (int i = 0; i < cardCount; i++)
            {

                int t = random.Next(cardCount);
                Card temp = Cards[i];
                Cards[i] = Cards[t];
                Cards[t] = temp;
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
