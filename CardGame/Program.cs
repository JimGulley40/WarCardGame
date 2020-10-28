using CardGameWar;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Program
    {

        static void Main(string[] args)
        {
            AClass aClass = new AClass();
            HandleCards _handleCards = new HandleCards();
            Tuple<Dictionary<string, int>, Dictionary<string, int>> splitResults = aClass.MyMethodOne();

            Dictionary<string, int> myDeck = splitResults.Item1;
            Dictionary<string, int> compDeck = splitResults.Item2;

            _handleCards.ShowHand(myDeck);
            _handleCards.ShowHand(compDeck);
            int myCardCount = 26;
            int compCardCount = 26;
            int compWinCount = 0;
            int myWinCount = 0;
            int warPileCount = 0;
            var winCard = "";
            int winCardRank;
            int myWarCardRank;
            int compWarCardRank;
            bool inWar = false;

            var myCard = "";

            var myWarCard = "";
            var compWarCard = "";
            int myCardRank = 0;
            int x = 0;
            var compCard = "";
            int compCardRank = 0;

            //creating seperate piles for wins and war
            Dictionary<string, int> myWinPile = new Dictionary<string, int>()
            {

            };
            Dictionary<string, int> compWinPile = new Dictionary<string, int>()
            {

            };
            Dictionary<string, int> warPile = new Dictionary<string, int>()
            {

            };


            // begins game play
            while (myCardCount > 0 && myCardCount < 52)//check to see if we won or lost
            {
                //Win Writeline
  
                while (myDeck.Count > 0 || myWinPile.Count > 0)
                {

                    myCardCount = myDeck.Count + myWinPile.Count;
                    if (myCardCount == 0 || myCardCount == 52)
                    {
                        break;
                    }
                    //_handleCards.ShowHand(myWinPile);
                    if (myDeck.Count <= 3)
                    {
                        int i = myWinPile.Count;
                        while (i > 0)
                        {
                            winCard = myWinPile.First().Key;
                            winCardRank = myWinPile.First().Value;
                            myDeck.Add(winCard, winCardRank);
                            myWinPile.Remove(winCard);
                            i -= 1;
                        }

                    }
                    compCardCount = compDeck.Count + compWinPile.Count;
                    myCardCount = myDeck.Count + myWinPile.Count;
                    if (myCardCount == 0 || compCardCount == 0)
                    {

                        break;
                    }
                    myCardCount = myDeck.Count;
                    compCardCount = compDeck.Count;

                    if (myCardCount == 0 || compCardCount == 0)
                    {
                        myWinCount = myWinPile.Count;
                        compWinCount = compWinPile.Count;

                        while (compWinCount > 0)
                        {
                            winCard = compWinPile.First().Key;
                            winCardRank = compWinPile.First().Value;
                            compDeck.Add(winCard, winCardRank);
                            compWinPile.Remove(winCard);
                            compWinCount -= 1;
                        }
                        while (myWinCount > 0)
                        {
                            winCard = myWinPile.First().Key;
                            winCardRank = myWinPile.First().Value;
                            myDeck.Add(winCard, winCardRank);
                            myWinPile.Remove(winCard);
                            myWinCount -= 1;
                        }
                        myCardCount = myDeck.Count + myWinPile.Count;
                        compCardCount = compDeck.Count +compWinPile.Count;
                        if (myCardCount == 0 || compCardCount == 0)
                        {
                            break;
                        }

                    }
                    myCard = myDeck.First().Key;
                    myCardRank = myDeck.First().Value;

                    compCard = compDeck.First().Key;
                    compCardRank = compDeck.First().Value;
                    Console.WriteLine("Your Card is  " + myCard);
                    Console.WriteLine("The Computer's card is   " +compCard);
                    Console.ReadKey();

                    if (inWar)
                    {
                        if (compDeck.Count == 0)
                        {
                            break;
                        }
                        if (myDeck.Count == 0)
                        {
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        warPile.Add(compCard, compCardRank);
                        warPile.Add(myCard, myCardRank);
                        myDeck.Remove(myCard);
                        compDeck.Remove(compCard);

                        //war card assignments
                        myWarCard = myDeck.First().Key;
                        myWarCardRank = myDeck.First().Value;
                        compWarCard = compDeck.First().Key;
                        compWarCardRank = compDeck.First().Value;



                        if (myWarCardRank < compWarCardRank)
                        {
                            Console.WriteLine("You won the Hand");
                            warPile.Add(compWarCard, compWarCardRank);
                            
                            
                            
                            warPile.Add(myWarCard, myWarCardRank);
                            myDeck.Remove(myWarCard);
                            compDeck.Remove(compWarCard);
                            myCard = myDeck.First().Key;
                            myCardRank = myDeck.First().Value;

                            compCard = compDeck.First().Key;
                            compCardRank = compDeck.First().Value;

                            /*Console.WriteLine("This is in your win pile");
                            _handleCards.ShowHand(myWinPile);
                            Console.WriteLine("this is in your hand");
                            _handleCards.ShowHand(myDeck);
                            Console.WriteLine("this is in warpile");
                            _handleCards.ShowHand(warPile);*/


                            warPileCount = warPile.Count;

                            while (warPileCount > 0)
                            {
                                winCard = warPile.First().Key;
                                winCardRank = warPile.First().Value;
                                myWinPile.Add(winCard, winCardRank);
                                warPile.Remove(winCard);
                                warPileCount -= 1;
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            inWar = false;

                        }
                        else if (compCardRank == myCardRank)
                        {
                            Console.WriteLine("You enter war!");
                            warPile.Add(compWarCard, compWarCardRank);
                            warPile.Add(myWarCard, myWarCardRank);
                            myDeck.Remove(myWarCard);
                            compDeck.Remove(compWarCard);
                            myWarCard = myDeck.First().Key;
                            myWarCardRank = myDeck.First().Value;
                            compWarCard = compDeck.First().Key;
                            compWarCardRank = compDeck.First().Value;

                            inWar = true;
                        }
                        else if (compCardRank < myCardRank)
                        {
                            Console.WriteLine("The Computer won the Hand");


                            warPile.Add(compWarCard, compWarCardRank);
                            warPile.Add(myWarCard, myWarCardRank);
                            myDeck.Remove(myWarCard);
                            compDeck.Remove(compWarCard);

                            warPileCount = warPile.Count;
                            while (warPileCount > 0)
                            {
                                winCard = warPile.First().Key;
                                winCardRank = warPile.First().Value;
                                compWinPile.Add(winCard, winCardRank);
                                warPile.Remove(winCard);
                                warPileCount -= 1;
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            inWar = false;
                            //_handleCards.ShowHand(myWinPile);
                            //_handleCards.ShowHand(compDeck);
                        }
                       // break;
                    }
                    //war card assignments
                    myCard = myDeck.First().Key;
                    myCardRank = myDeck.First().Value;
                    compCard = compDeck.First().Key;
                    compCardRank = compDeck.First().Value;

                    if (myCardRank < compCardRank)
                    {
                        Console.WriteLine("You won the Hand");
                        myWinPile.Add(compCard, compCardRank);
                        myWinPile.Add(myCard, myCardRank);
                        myDeck.Remove(myCard);
                        compDeck.Remove(compCard);
                        //Console.WriteLine("This is in your win pile");
                        // _handleCards.ShowHand(myWinPile);
                        // Console.WriteLine("this is in your hand");
                        // _handleCards.ShowHand(myDeck);
                    }
                    else if (compCardRank == myCardRank)
                    {
                        warPile.Add(compCard, compCardRank);
                        warPile.Add(myCard, myCardRank);
                        myDeck.Remove(myCard);
                        compDeck.Remove(compCard);
                        inWar = true;
                    }
                    else if (compCardRank < myCardRank)
                    {

                       /* Console.WriteLine("This is in your win pile");
                        _handleCards.ShowHand(myWinPile);
                        Console.WriteLine("this is in your hand");
                        _handleCards.ShowHand(myDeck);
                        Console.WriteLine("this is in warpile");
                        _handleCards.ShowHand(warPile);
                        Console.WriteLine("The Computer Hand");
                        _handleCards.ShowHand(compDeck);
                        Console.WriteLine("The Computer wins");
                        _handleCards.ShowHand(compWinPile);
                       */

                        //Console.WriteLine(compCard + "" + myCard);
                        compWinPile.Add(compCard, compCardRank);
                        compWinPile.Add(myCard, myCardRank);
                        myDeck.Remove(myCard);
                        compDeck.Remove(compCard);
                        //_handleCards.ShowHand(myWinPile);
                        //_handleCards.ShowHand(compDeck);
                    }
                    else
                    {
                        Console.WriteLine("there was an error");
                        Console.ReadLine();
                        //Console.ReadLine();
                    }
                    if (myDeck.Count <= 3)
                    {
                        x = myWinPile.Count;
                        while (x > 0)
                        {
                            winCard = myWinPile.First().Key;
                            winCardRank = myWinPile.First().Value;
                            myDeck.Add(winCard, winCardRank);
                            myWinPile.Remove(winCard);
                            x -= 1;
                        }
                    }
                    if (compDeck.Count <= 3)
                    {
                        x = compWinPile.Count;
                        while (x > 0)
                        {
                            winCard = compWinPile.First().Key;
                            winCardRank = compWinPile.First().Value;
                            compDeck.Add(winCard, winCardRank);
                            compWinPile.Remove(winCard);
                            x -= 1;
                        }
                    }

                }

            }
            if (myCardCount == 52)
            {
                Console.WriteLine("you won the game");
                //break;
            }
            else
            {
                Console.WriteLine("The Computer Won! ha ha ha");
                //break;
            }
        }
    }

}



