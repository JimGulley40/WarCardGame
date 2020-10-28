using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWar
{
    public class CardDeck
    {
        private Dictionary<string, int> _deckOfCards = new Dictionary<string, int>()
        {
                { "Five of Spades", 10 },
                { "Ace of Clubs", 1 },
                { "Four of Clubs", 11 },
                { "Jack of Clubs", 4 },
                { "Five of Clubs", 10 },
                { "Eight of Spades", 7 },
                { "Eight of Clubs", 7 },
                { "Three of Clubs", 12 },
                { "Nine of Diamonds", 6 },
                { "Seven of Hearts", 8 },
                { "Ten of Diamonds", 5 },
                { "Nine of Clubs", 6 },
                { "Queen of Hearts", 3 },
                { "King of Spades", 2 },
                { "Three of Spades", 12 },
                { "Three of Hearts", 12 },
                { "Nine of Hearts", 6 },
                { "Four of Spades", 11 },
                { "Queen of Diamonds", 3 },
                { "Six of Diamonds", 9 },
                { "Queen of Spades", 3 },
                { "Eight of Diamonds", 7 },
                { "Nine of Spades", 6 },
                { "Ace of Spades", 1 },
                { "Seven of Spades", 8 },
                { "Ten of Hearts", 5 },
                { "Eight of Hearts", 7 },
                { "Two of Hearts", 13 },
                { "Ace of Diamonds", 1 },
                { "King of Diamonds", 2 },
                { "Jack of Diamonds", 4 },
                { "Ace of Hearts", 1 },
                { "Five of Hearts", 10 },
                { "Seven of Diamonds", 8 },
                { "Three of Diamonds", 12 },
                { "Queen of Clubs", 3 },
                { "Ten of Spades", 5 },
                { "Six of Hearts", 9 },
                { "Two of Spades", 13 },
                { "King of Hearts", 2 },
                { "Four of Diamonds", 11 },
                { "Jack of Spades", 4 },
                { "Ten of Clubs", 5 },
                { "Two of Clubs", 13 },
                { "King of Clubs", 2 },
                { "Four of Hearts", 11 },
                { "Six of Spades", 9 },
                { "Seven of Clubs", 8 },
                { "Jack of Hearts", 4 },
                { "Two of Diamonds", 13 },
                { "Six of Clubs", 9 },
                { "Five of Diamonds", 10 },

                };

        public Dictionary<string, int> NewDeck()
        {
            return _deckOfCards;
        }
    }
}