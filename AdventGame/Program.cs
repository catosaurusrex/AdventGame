using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // PlayerStats
            int playerCurrentHP = 20;
            int playerFullHP = 100;
            double playerCurrentEXP = 10;
            double playerFullEXP = 100;
            int playerCurrentLevel = 1;

            // X and Y axis
            int CharMoveLeftRight = 10;
            int CharMoveUpDown = 10;

            int gameOver = 0;
            string playerName;
            string currentCommand;
            int restingTime;
            string playerStatus = "Neutral";
            string playerClass;
            int errorCode = 0;
            //Array
            string[,] inventory = new string[10,20];

            do
            {
                //Count exp:
                if (playerCurrentEXP >= playerFullEXP)
                {
                    playerCurrentEXP = playerCurrentEXP - playerFullEXP;
                    playerCurrentLevel++;
                    playerFullEXP = playerFullEXP * 1.20;
                }

                //Character creation:

                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 3);
                Console.Write("Please enter your character name : ");
                playerName = Console.ReadLine();
                Console.Clear();
                do
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 1);
                    Console.Write("Please choose a class : ");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2);
                    Console.Write(" Outlaw      Paladin");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 + 1);
                    Console.Write(" Mage        Warrior");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 + 2);
                    Console.Write(" Priest      Rogue");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 + 3);
                    string selectedClass = Console.ReadLine().ToUpper();
                    Console.Clear();

                    
                    if (selectedClass == "OUTLAW" || selectedClass == "PALADIN" || selectedClass == "MAGE" || selectedClass == "WARRIOR" || selectedClass == "ROGUE" || selectedClass == "PRIEST")
                    {
                        errorCode = 1;
                        playerClass = selectedClass;
                    }
                    else
                    {
                        errorCode = 0;
                        
                    }

                } while (errorCode==0);






                // Draw stats and top box
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("  _____________________________________________________________________________________________________________________");
                Console.SetCursorPosition(7, 1);
                Console.WriteLine("Name: {0}", playerName);
                Console.SetCursorPosition(37, 1);
                Console.WriteLine("HP: {0}/{1}", playerCurrentHP, playerFullHP);
                Console.SetCursorPosition(67, 1);
                Console.WriteLine("EXP: {0}/{1}", playerCurrentEXP, playerFullEXP);
                Console.SetCursorPosition(97, 1);
                Console.WriteLine("Level: {0}", playerCurrentLevel);
                Console.WriteLine("______________________________________________________________________________________________________________________");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("/");
                Console.SetCursorPosition(118, 1);
                Console.WriteLine("/");

                // draw game screen
                for (int i = 3; i <= 27; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine("|");
                    Console.SetCursorPosition(119, i);
                    Console.WriteLine("|");
                }
                Console.SetCursorPosition(0, 28);
                Console.WriteLine("______________________________________________________________________________________________________________________");

                /*
                // Player movement controlls
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (CharMoveLeftRight < 118)
                        {
                        CharMoveLeftRight++;
                        Console.SetCursorPosition(CharMoveLeftRight, CharMoveUpDown);
                        Console.WriteLine("X");
                        Console.SetCursorPosition(CharMoveLeftRight - 1, CharMoveUpDown);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("X");
                        Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {

                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (CharMoveLeftRight>1)
                        {
                        CharMoveLeftRight--;
                        Console.SetCursorPosition(CharMoveLeftRight, CharMoveUpDown);
                        Console.WriteLine("X");
                        Console.SetCursorPosition(CharMoveLeftRight + 1, CharMoveUpDown);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("X");
                        Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {

                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (CharMoveUpDown > 3)
                        {

                        CharMoveUpDown--;
                        Console.SetCursorPosition(CharMoveLeftRight, CharMoveUpDown);
                        Console.WriteLine("X");
                        Console.SetCursorPosition(CharMoveLeftRight, CharMoveUpDown+1);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("X");
                        Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                             
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (CharMoveUpDown < 27)
                        {
                        CharMoveUpDown++;
                        Console.SetCursorPosition(CharMoveLeftRight, CharMoveUpDown);
                        Console.WriteLine("X");
                        Console.SetCursorPosition(CharMoveLeftRight, CharMoveUpDown-1);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("X");
                        Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {

                        }
                        break;
                    case ConsoleKey.Spacebar:
                        Console.SetCursorPosition(CharMoveLeftRight, CharMoveUpDown);
                        Console.WriteLine("X");

                        System.Threading.Thread.Sleep(30);
                        Console.SetCursorPosition(CharMoveLeftRight + 1, CharMoveUpDown);
                        Console.Write("-");
                        Console.SetCursorPosition(CharMoveLeftRight + 1, CharMoveUpDown);
                        System.Threading.Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("-");
                        Console.ForegroundColor = ConsoleColor.White;

                        System.Threading.Thread.Sleep(30);
                        Console.SetCursorPosition(CharMoveLeftRight , CharMoveUpDown-1);
                        Console.Write("|");
                        Console.SetCursorPosition(CharMoveLeftRight, CharMoveUpDown - 1);
                        System.Threading.Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.White;

                        System.Threading.Thread.Sleep(30);
                        Console.SetCursorPosition(CharMoveLeftRight -1 , CharMoveUpDown);
                        Console.Write("-");
                        Console.SetCursorPosition(CharMoveLeftRight - 1, CharMoveUpDown);
                        System.Threading.Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("-");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        break;
                }
                */
                for (int a = 0; a <= 9; a++)
                {
                    for (int b = 0; b <= 19; b++)
                    {
                        inventory[a, b] = "asd";
                    }
                }
                // the players command options
                currentCommand = Console.ReadLine().ToUpper();
                if (currentCommand == "INVENTORY" || currentCommand == "INV")
                {
                    for (int a = 0; a <= 19; a++)
                    {
                        for (int b = 0; b <= 9; b++)
                        {
                            
                            if (b<=10)
                            {
                                Console.SetCursorPosition(b*7+3, 5+a);
                                Console.Write("{0}", inventory[b, a]);
                            }
                            else  { }


                        }
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(currentCommand);
                    Console.ForegroundColor = ConsoleColor.White;
                

                      //  Console.SetCursorPosition(2, 26);
                        Console.Write("< Back? ");
                        Console.SetCursorPosition(1, 30);
                        currentCommand = Console.ReadLine().ToUpper();
                        if (currentCommand == "BACK" || currentCommand == "<")
                        {
                            Console.Clear();
                        }
                        else
                        {

                        }

                }
                if (currentCommand == "SLEEP" || currentCommand == "NAP" || currentCommand == "REST")
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2-5, Console.WindowHeight / 2-3);
                    Console.Write("For how long?");
                    restingTime = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                   
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 3);
                    if (restingTime >=10)
                    {
                        restingTime = 9;
                    }
    
                    for (int a = restingTime; a >= 0; a--)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 3);
                        Console.Write(" Waking up in : {0}", a );  
                        System.Threading.Thread.Sleep(1000);
      
                    }
                    
                    playerCurrentHP = playerCurrentHP + (restingTime) * 15;
                    if (playerCurrentHP > playerFullHP)
                    {
                        playerCurrentHP = playerFullHP;
                    }
                    Console.Clear();
                }
                if (currentCommand == "STATUS")
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 3);
                    Console.Write("Your status is : " + playerStatus);
                }

            } while (gameOver == 0);


        }
    }
    
}
