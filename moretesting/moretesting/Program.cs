using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;



class GamesManager
{
    public static double Money = 500;
    public static void MoneyDisplay()
    {
        int WindowWidth = Console.WindowWidth;
        Console.SetCursorPosition(WindowWidth - 20, 0);
        Console.WriteLine($"Balance: {Money}$");
        Console.SetCursorPosition(0, 0);
    }
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            MoneyDisplay();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Press spacebar to play the OneToTen game");
            Console.WriteLine("Press tab to play RideTheBus");
            Console.WriteLine("Press escape to end program.");

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine($"You finished with {Money}$, ending now.");
                Thread.Sleep(3000);
                return;
            }
            else if (key.Key == ConsoleKey.Spacebar)
            {
                Games.OneToTen();
            }
            else if (key.Key == ConsoleKey.Tab)
            {
                Games.RideTheBus();
            }
        }
    }









    class Games
    {

        public static double InputMoney = 0;
        public static double BaseBet = 0;
        public static void InputMoneyDisplay()
        {
            int WindowWidth = Console.WindowWidth;
            Console.SetCursorPosition(WindowWidth - 40, 0);
            Console.WriteLine($"Bet: {InputMoney}$");
            GamesManager.MoneyDisplay();
        }

        public static void BetMoney()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("Input the ammount of money you want to bet:  ");
            string Input = Console.ReadLine();

            while (!double.TryParse(Input, out InputMoney) || InputMoney < 0 || InputMoney > GamesManager.Money)
            {
                if (!double.TryParse(Input, out InputMoney))
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                else if (InputMoney > GamesManager.Money)
                {
                    Console.WriteLine("Please enter an ammount you can actually afford brokie.");
                }
                else
                {
                    Console.WriteLine("Please enter a posive value.");
                }
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                GamesManager.MoneyDisplay();
                Zero();
                Console.Write("Input the ammount of money you want to bet:  ");
                Input = Console.ReadLine();
            }



            BaseBet = InputMoney;
            GamesManager.Money = GamesManager.Money - InputMoney;
            Console.Clear();
            InputMoneyDisplay();

        }

        public static void Zero()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("                                                                                     ");
            Console.SetCursorPosition(0, 0);
        }



        public static void OneToTen()
        {
            Console.Clear();
            GamesManager.MoneyDisplay();
            System.Threading.Thread.Sleep(1000);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Press any key to start the game.");
            Console.ReadKey(true);
            Console.Clear();
            GamesManager.MoneyDisplay();
            BetMoney();
            Zero();

            Console.WriteLine("You have 3 lives");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Pick a number from 1 to 10");

            Random rng = new Random();
            int correctNumber = rng.Next(1, 11);
            int numberOutOfTen = 0;
            string Input = Console.ReadLine();
            byte threeLives = 3;

            Console.SetCursorPosition(0, 0);
            while (!int.TryParse(Input, out numberOutOfTen) || numberOutOfTen != correctNumber && threeLives > 0)
            {
                if (!int.TryParse(Input, out numberOutOfTen))
                {
                    Console.Clear();
                    InputMoneyDisplay();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Error, please type a number.");
                }
                else if (numberOutOfTen > 10 || numberOutOfTen < 1)
                {
                    Console.Clear();
                    InputMoneyDisplay();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Error, the number doesnt fall between 1 and 10.");
                    Console.WriteLine($"You have {threeLives} lives left.");
                }
                else
                {
                    threeLives--;

                    if (threeLives == 0)
                    {
                        Console.Clear();
                        InputMoneyDisplay();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"Wrong the number was {correctNumber}");
                        System.Threading.Thread.Sleep(2000);
                        break;
                    }
                    Console.Clear();
                    InputMoneyDisplay();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"Wrong, you have {threeLives} lives left.");
                }

                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Press any key to try again");
                Console.ReadKey(true);
                Console.Clear();
                InputMoneyDisplay();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Type a number from 1 to 10.");
                Input = Console.ReadLine();
            }

            Console.Clear();
            InputMoneyDisplay();
            Zero();

            if (threeLives == 0)
            {
                Console.WriteLine("You have no more lives left, you lose.");
                InputMoney = 0;
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                GamesManager.MoneyDisplay();
                Zero();
                Console.WriteLine("Press any key to end game.");
                Console.ReadKey(true);
                Console.Clear();
                GamesManager.MoneyDisplay();
                Zero();
                return;
            }
            else
            {
                Console.Beep();
                GamesManager.Money = GamesManager.Money + InputMoney * 4;
                GamesManager.MoneyDisplay();
                Console.WriteLine($"Congratulations, your payout was {InputMoney * 4}$");
                Console.WriteLine("Press any key to end game.");
                Console.ReadKey(true);
                Console.Clear();
                GamesManager.MoneyDisplay();
                Zero();
                return;
            }
        }







        public static void RideTheBus()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            GamesManager.MoneyDisplay();
            System.Threading.Thread.Sleep(1000);
            Console.SetCursorPosition(0, 0);
            Console.Write("Press any key to start the game.");
            Console.ReadKey(true);
            Console.Clear();
            GamesManager.MoneyDisplay();

            Zero();
            Console.WriteLine("Welcome to ride the bus!");
            BetMoney();

            // Game variables
            int Consolewidth = Console.WindowWidth / 4;
            Random rng = new Random();
            string[] suits = { "hearts", "diamonds", "clubs", "spades" };

            int CardOne = rng.Next(2, 15);
            string CardOneSuit = suits[rng.Next(4)];
            string CardOneColour = CardOneSuit == "clubs" || CardOneSuit == "spades" ? "black" : "red";

            int CardTwo = rng.Next(2, 15);
            string CardTwoSuit = suits[rng.Next(4)];
            string CardTwoColour = CardTwoSuit == "clubs" || CardTwoSuit == "spades" ? "black" : "red";

            int CardThree = rng.Next(2, 15);
            string CardThreeSuit = suits[rng.Next(4)];
            string CardThreeColour = CardThreeSuit == "clubs" || CardThreeSuit == "spades" ? "black" : "red";

            int CardFour = rng.Next(2, 15);
            string CardFourSuit = suits[rng.Next(4)];
            string CardFourColour = CardFourSuit == "clubs" || CardFourSuit == "spades" ? "black" : "red";

            string ColourOneGuess = "";
            string HighLowGuess = "";
            string InOutGuess = "";
            string SuitsGuess = "";

            while (CardTwo == CardOne)
            {
                CardTwo = rng.Next(2, 15);
            }
            CardThree = rng.Next(2, 15);
            while (CardThree == CardOne || CardThree == CardTwo)
            {
                CardThree = rng.Next(2, 15);
            }

            void Wrong()
            {
                Zero();
                Console.WriteLine("You guessed wrong.");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("Press any key to end game.");
                Console.ReadKey(true);
                Console.Clear();
                GamesManager.MoneyDisplay();
            }

            bool Right(float mult, bool finish)
            {

                Zero();
                InputMoney = BaseBet * mult;
                InputMoneyDisplay();
                Zero();
                Console.Write($"Its a match! your payout is {InputMoney}$");
                System.Threading.Thread.Sleep(3000);
                Zero();
                if (finish == false)
                {
                    Console.WriteLine("Press escape to cash out, press any other key to continue.");
                }
                else
                {
                    Console.WriteLine("You have successfully rode the bus.");
                    Console.WriteLine("Press any key to continue");
                }

                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape || finish == true)
                {
                    Console.Clear();
                    GamesManager.Money = InputMoney + GamesManager.Money;
                    Console.Clear();
                    GamesManager.MoneyDisplay();
                    Zero();
                    Console.WriteLine($"You cashed {InputMoney}$");
                    Console.WriteLine("Press any key to end the game.");
                    Console.ReadKey(true);
                    InputMoney = 0;
                    Console.Clear();
                    GamesManager.MoneyDisplay();
                    Zero();

                    return true;
                }

                Zero();
                return false;
            }

            void drawCard(int positionx, int cardValue, string cardColour, string cardSuit)
            {
                Console.SetCursorPosition(positionx, 6);
                if (cardColour == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                string Value = "";
                switch (cardValue)
                {
                    case 14: Value = "A"; break;
                    case 13: Value = "K"; break;
                    case 12: Value = "Q"; break;
                    case 11: Value = "J"; break;
                    default: Value = $"{cardValue}"; break;
                }

                string valueSuit = "";
                switch (cardSuit)
                {
                    case "hearts": valueSuit = "♥"; break;
                    case "diamonds": valueSuit = "♦"; break;
                    case "clubs": valueSuit = "♣"; break;
                    case "spades": valueSuit = "♠"; break;
                }

                Console.Write($"{Value}{valueSuit}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            string getVar(int positionX, string var, string optOne, string optTwo, string optThree, string optFour, byte yeah)
            {
                Console.SetCursorPosition(positionX, 6);
                var = Console.ReadLine();
                while (var != optOne && var != optTwo && var != optThree && var != optFour)
                {
                    gameUI(yeah);
                    Zero();
                    if (optThree != optOne)
                    {
                        Console.Write("Error, please type hearts, clubs, diamonds or spades.");
                    }
                    else
                    {
                        Console.Write($"Error, please type {optOne} or {optTwo}, no capital letters.");
                    }
                    System.Threading.Thread.Sleep(2000);
                    Zero();
                    Console.Write($"Please chose {optOne} or {optTwo}");
                    Console.SetCursorPosition(positionX, 6);
                    var = Console.ReadLine();
                }
                return var;
            }

            void gameUI(byte yeah)
            {
                Console.Clear();
                InputMoneyDisplay();

                //Muliplier (top)
                Console.SetCursorPosition(8, 3);
                Console.Write("2X");
                Console.SetCursorPosition(Consolewidth + 8, 3);
                Console.Write("3X");
                Console.SetCursorPosition(Consolewidth * 2 + 8, 3);
                Console.Write("4X");
                Console.SetCursorPosition(Consolewidth * 3 + 8, 3);
                Console.Write("20X");

                //Signifier (middle)
                Console.SetCursorPosition(1, 5);
                Console.Write("Card   /   Your guess");
                Console.SetCursorPosition(Consolewidth + 1, 5);
                Console.Write("Card   /   Your guess");
                Console.SetCursorPosition(Consolewidth * 2 + 1, 5);
                Console.Write("Card   /   Your guess");
                Console.SetCursorPosition(Consolewidth * 3 + 1, 5);
                Console.Write("Card   /   Your guess");

                //Makeshift underline (bottom)
                Console.SetCursorPosition(1, 7);
                Console.Write("----       ----------");
                Console.SetCursorPosition(Consolewidth + 1, 7);
                Console.Write("----       ----------");
                Console.SetCursorPosition(Consolewidth * 2 + 1, 7);
                Console.Write("----       ----------");
                Console.SetCursorPosition(Consolewidth * 3 + 1, 7);
                Console.Write("----       ----------");

                switch (yeah)
                {
                    case 1:
                        drawCard(2, CardOne, CardOneColour, CardOneSuit);
                        Console.SetCursorPosition(12, 6);
                        Console.Write(ColourOneGuess); break;
                    case 2:
                        drawCard(Consolewidth + 2, CardTwo, CardTwoColour, CardTwoSuit);
                        Console.SetCursorPosition(Consolewidth + 12, 6);
                        Console.Write(HighLowGuess); goto case 1;
                    case 3:
                        drawCard(Consolewidth * 2 + 2, CardThree, CardThreeColour, CardThreeSuit);
                        Console.SetCursorPosition(Consolewidth * 2 + 12, 6);
                        Console.Write(InOutGuess); goto case 2;
                    case 4:
                        drawCard(Consolewidth * 3 + 2, CardFour, CardFourColour, CardFourSuit);
                        Console.SetCursorPosition(Consolewidth * 3 + 12, 6);
                        Console.Write(SuitsGuess); goto case 3;
                }
            }

            gameUI(0);

            //Round one red or black
            Zero();
            Console.WriteLine("Guess the colour of the card (red or black).");
            ColourOneGuess = getVar(12, ColourOneGuess, "red", "black", "red", "black", 0);

            gameUI(1);

            if (ColourOneGuess != CardOneColour)
            {
                Wrong();
                return;
            }

            if (Right(2, false) == true) return;


            //Round two higher or lower
            Console.Write("Please chose higher or lower.");
            HighLowGuess = getVar(Consolewidth + 12, HighLowGuess, "higher", "lower", "higher", "lower", 1);
            gameUI(2);

            string HighLow = (CardTwo > CardOne) ? "higher" : "lower";

            if (HighLowGuess != HighLow)
            {
                Wrong();
                return;
            }

            if (Right(3, false) == true) return;


            //Round three inside or outside
            Console.WriteLine("Please chose inside or outside.");
            InOutGuess = getVar(Consolewidth * 2 + 12, InOutGuess, "inside", "outside", "inside", "outside", 2);
            gameUI(3);

            int low = Math.Min(CardTwo, CardOne);
            int high = Math.Max(CardTwo, CardOne);

            string InOut = (CardThree > low && CardThree < high) ? "inside" : "outside";

            if (InOutGuess != InOut)
            {
                Wrong();
                return;
            }

            if (Right(4, false) == true) return;


            //Round four guess the suit
            Console.WriteLine("Please guess the suit (hearts, clubs, diamonds, spades)");
            SuitsGuess = getVar(Consolewidth * 3 + 12, SuitsGuess, "hearts", "clubs", "diamonds", "spades", 3);
            gameUI(4);

            if (CardFourSuit != SuitsGuess)
            {
                Wrong();
                return;
            }

            Zero();
            gameUI(4);
            Right(20, true);
            return;
        }
    }
}




