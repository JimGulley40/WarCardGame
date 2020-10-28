using CardGameWar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class HandleCards
    {
        public void ShowHand(Dictionary<string, int> deck)
        {
            foreach (KeyValuePair<string, int> card in deck)
            {
                Console.WriteLine(card);
            }
            Console.ReadLine();
        }

    }
    class AClass
    {
        CardDeck _cards = new CardDeck();
        HandleCards _handleCards = new HandleCards();
        Dictionary<string, int> dictOne = new Dictionary<string, int>();
        Dictionary<string, int> dictTwo = new Dictionary<string, int>();
        
        


        public Tuple<Dictionary<string, int>, Dictionary<string, int>> MyMethodOne()
        {
            Dictionary<string, int> dictOne = _cards.NewDeck()  ;
            Dictionary<string, int> dictTwo = new Dictionary<string, int>()
            {

            };

            while (dictTwo.Count < 26)
            {
                foreach (KeyValuePair<string, int> card in dictOne)
                {
                    //PlayingDeck2.Add(card.Key, card.Value);

                    //Random rnd = new Random();
                    Random r = new Random();
                    int i = 0;
                    i = r.Next(2);
                    if (i == 0)
                    {
                        //cardInHand = card.Key;
                        //Console.WriteLine("you get the " + card.Key);
                        //Console.ReadLine();
                        dictTwo.Add(card.Key, card.Value);
                        // Thread.Sleep(pause);
                    }
                if (dictTwo.Count == 26)
                {
                    //dictOne.Remove(cardy.Key);
                    break;
                }
                }

                foreach (KeyValuePair<string, int> cardy in dictTwo)
                {
                    dictOne.Remove(cardy.Key);

                }
            }
           /* _handleCards.ShowHand(dictOne);
            Console.WriteLine("The other Deck has");
            Console.WriteLine(dictTwo.Count);
           _handleCards.ShowHand(dictTwo);
            Console.ReadLine();*/
            return new Tuple<Dictionary<string, int>, Dictionary<string, int>>(dictOne, dictTwo);
        }
    }
}