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
            int playerCurrentHP = 50;
            int playerFullHP = 100;
            double playerCurrentEXP = 0;
            double playerFullEXP = 100;
            int playerCurrentLevel = 1;
            int playerAttack = 10;
            string playerWeapon = "Fists";

            int attackBonus = 0;
            int speechBonus = 0;
            int sneakBonus = 0;
            int armourBonus = 0;
            int castingBonus = 0;
            int teamMates = 1;
            int steps = 0;
            int diceRolled;
            int savedChecker = 0;


            // X and Y axis
            int CharMoveLeftRight = 10;
            int CharMoveUpDown = 10;

            int gameOver = 0;
            string playerName = "";
            string currentCommand;
            int restingTime;
            string playerStatus ="neutral";
            string playerClass = "";
            int errorCode = 0;

            //foe
            string enemyName = "";
            

            int enemyHPCurrent;
            int enemyHPFull;
            int enemyAttack;
            int enemyAttackBonus;
            
            //Random
            Random diceRoll = new Random();
            //Array
            string[,] inventory = new string[10,20];
            string[,] spellBook = new string[10, 50];

            do
            {
                //Count exp:
                if (playerCurrentEXP >= playerFullEXP)
                {
                    playerCurrentEXP = playerCurrentEXP - playerFullEXP;
                    playerCurrentLevel++;
                    playerFullEXP = playerFullEXP * 1.20;
                }

                //Character creation: here the player can choose a name
                if (playerName == "" && playerClass == "")
                {
                    //tutorial mission
                    Console.SetCursorPosition(3, 5);
                    Console.WriteLine("You wake up in a prison cell, deep down in a dark cellar. You search your body but ");
                    Console.SetCursorPosition(3, 6);
                    Console.WriteLine("you cannot find a single item on your person.  ");
                    Console.SetCursorPosition(3, 7);
                    Console.WriteLine("You can feel the dried blood on your fists from the fight you put up. You didnt go down easy. ");
                    Console.SetCursorPosition(3, 8);
                    Console.WriteLine("Unfortunately you can also feel the dried blood in your hair from when they smashed your skull.   ");
                    Console.SetCursorPosition(3, 9);
                    Console.WriteLine("Apart from the pain from your wounds and bruises you cannot really think of or feel much else.  ");
                    Console.SetCursorPosition(3, 10);
                    Console.WriteLine("Trying to remember what happened you realise you dont even remember your own name.   ");
                    Console.SetCursorPosition(3, 11);
                    Console.WriteLine("Press [Enter] to proceed.");
                    Console.ReadLine();
                    
                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 3);
                Console.Write("Please enter your character name : ");
                playerName = Console.ReadLine();
                Console.Clear();
                
                do
                {
                        // here he can choose a class 
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

                    // if selected class is not OK he will have to try again
                    if (selectedClass == "OUTLAW" || selectedClass == "PALADIN" || selectedClass == "MAGE" || selectedClass == "WARRIOR" || selectedClass == "ROGUE" || selectedClass == "PRIEST")
                    {
                        errorCode = 1;
                        playerClass = selectedClass;
                            switch (selectedClass)
                            {
                                case "OUTLAW": 
                                    {
                                        attackBonus += 3 ;
                                        speechBonus += 7;
                                        sneakBonus += 10;
                                        armourBonus += 2;
                                        castingBonus += 1;
                                        spellBook[0, 0] = "Lesser healing";
                                        spellBook[1, 0] = "15";
                                        spellBook[2, 0] = "HEALING";
                                    }
                                    break;
                                case "PALADIN":
                                    {
                                        attackBonus += 7;
                                        speechBonus += 3;
                                        sneakBonus += 2;
                                        armourBonus += 10;
                                        castingBonus += 2;
                                        spellBook[0, 0] = "Lesser healing";
                                        spellBook[1, 0] = "15";
                                        spellBook[2, 0] = "HEALING";
                                    }
                                    break;
                                case "MAGE":
                                    {
                                        attackBonus += 5;
                                        speechBonus += 5;
                                        sneakBonus += 5;
                                        armourBonus += 1;
                                        castingBonus += 10;
                                        spellBook[0, 0] = "Flames";
                                        spellBook[1, 0] = "5";
                                        spellBook[2, 0] = "DAMAGE";
                                        spellBook[0, 1] = "Frostbite";
                                        spellBook[1, 1] = "6";
                                        spellBook[2, 1] = "DAMAGE";

                                    }
                                    break;
                                case "WARRIOR":
                                    {
                                        attackBonus += 10;
                                        speechBonus += 3;
                                        sneakBonus += 3;
                                        armourBonus += 6;
                                        castingBonus += 2;
                                        spellBook[0, 0] = "Lesser healing";
                                        spellBook[1, 0] = "12";
                                        spellBook[2, 0] = "HEALING";
                                    }
                                    break;
                                case "ROGUE":
                                    {
                                        attackBonus += 5;
                                        speechBonus += 5;
                                        sneakBonus += 5;
                                        armourBonus += 5;
                                        castingBonus += 5;
                                        spellBook[0, 0] = "Lesser healing";
                                        spellBook[1, 0] = "12";
                                        spellBook[2, 0] = "HEALING";
                                    }
                                    break;
                                case "PRIEST":
                                    {
                                        attackBonus += 3;
                                        speechBonus += 10;
                                        sneakBonus += 6;
                                        armourBonus += 5;
                                        castingBonus += 8;
                                        spellBook[0, 0] = "Lesser healing";
                                        spellBook[1, 0] = "15";
                                        spellBook[2, 0] = "HEALING";
                                    }
                                    break;
                                default: Console.Write("something went wrong please try again");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                    else
                    {
                        errorCode = 0;
                        
                    }

                } while (errorCode==0);


                }






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
                Console.SetCursorPosition(0, 27);
                Console.WriteLine("______________________________________________________________________________________________________________________");
                Console.SetCursorPosition(67, 28);
                Console.WriteLine("Available commands: {0} {1} {2}  ", "status", "inv", "rest");
                Console.SetCursorPosition(0, 29);
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

                //Intro mission continue
                //tutorial mission
                if (steps == 0)
                {
                    Console.SetCursorPosition(3, 5);
                    Console.WriteLine("Suddenly you hear steps closing in on you and the urge to run increases.");

                    Console.SetCursorPosition(3, 6);
                    Console.WriteLine("It might be your rescue, but it might be somethin much much worse... ");
                    Console.SetCursorPosition(3, 7);
                    Console.WriteLine("the lack of memories and the feeling of unkown makes you feel sick. What do you do? ");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 3);
                    Console.WriteLine("WAIT (Hope for a savior)");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 2);
                    Console.WriteLine("RUN (Escape whoever is coming)");
                    Console.SetCursorPosition(0, 29);
                    currentCommand = Console.ReadLine().ToUpper();

                    if (currentCommand == "WAIT")
                    {
                        diceRolled = diceRoll.Next(0, 4);
                        if (diceRolled == 1 || diceRolled == 0)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(3, 5);
                            Console.WriteLine("The footsteps stops some meters away from you. You can only see darkness but ");
                            Console.SetCursorPosition(3, 6);
                            Console.WriteLine("you hear metal scraping as the never-in-onehundred-years oiled door opens.");
                            Console.SetCursorPosition(3, 7);
                            Console.WriteLine("\"Pssst! Hey comon' do you wanna live laddie?\" You hear a dark man voice calling.");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 3);
                            Console.WriteLine("WAIT (Hope for the best...)");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 2);
                            Console.WriteLine("RUN (Escape whoever is coming)");
                            Console.SetCursorPosition(0, 29);
                            currentCommand = Console.ReadLine().ToUpper();
                            if (currentCommand == "WAIT")
                            {
                                Console.Clear();
                                Console.SetCursorPosition(3, 5);
                                Console.WriteLine("The footsteps are closing in on you and you are focusing your eyes on a spot in the dark that is rapidly growing");
                                Console.SetCursorPosition(3, 6);
                                Console.WriteLine("A man enters your field of vision. Gray sparks in his black hair floats together with his long beard.");
                                Console.SetCursorPosition(3, 7);
                                Console.WriteLine("Man: Schh, do not make a sound, Im here to help you escape, but i think I was folowed down here.. ");
                                Console.SetCursorPosition(3, 8);
                                Console.WriteLine("The man lights a candle he brought up from somewhere inside his cloak. He turns and walks out..");
                                Console.SetCursorPosition(3, 9);
                                Console.WriteLine("You stare after the man who dosnt even glance back.");
                                Console.SetCursorPosition(3, 10);
                                Console.WriteLine("As the light begins to fade you giva a start and hurries after him. ");
                                teamMates++;
                                Console.SetCursorPosition(3, 11);
                                Console.WriteLine("As you catch up to your savior you hear a low clicking as from metal gears sliding together followed by a click ");
                                Console.SetCursorPosition(3, 12);
                                Console.WriteLine("and the floor openes beneth you. ");

                                Console.SetCursorPosition(2, 27);
                                Console.WriteLine("[Enter] to enter combat");
                                Console.Read();
                                Console.Clear();
                                steps = 1;

                            }
                        }
                        else if (currentCommand == "RUN")
                        {
                            Console.Clear();
                            Console.SetCursorPosition(3, 5);
                            Console.WriteLine("As you rush away in the dark you hear the man growl at you and shouts \"Carefull! You dont know whats out there\"! ");
                            Console.SetCursorPosition(3, 6);
                            Console.WriteLine("His voice is snapped as you fall through the floor into utter darkness. ");
                            Console.SetCursorPosition(3, 7);
                            Console.WriteLine("You climb to your knees and curses yourself for your stupidity.. rushing away in the dark..  ");
                            Console.SetCursorPosition(3, 8);
                            Console.WriteLine("Press [Enter] to proceed.");
                            Console.Read();
                            Console.Clear();
                            steps = 1;
                        }
                        {
                            Console.Clear();
                            Console.SetCursorPosition(3, 5);
                            Console.WriteLine("You stare out in the dark, noticing a spot of pitch-black mater moving towards you.. ");
                            Console.SetCursorPosition(3, 6);
                            Console.WriteLine("Its like the darkness itself is concentrated at the moving spot. ");
                            Console.SetCursorPosition(3, 7);
                            Console.WriteLine("You move backwards until your knees hits the side of the bed and you sits down in startlement. ");
                            Console.SetCursorPosition(3, 8);
                            Console.WriteLine("Press [Enter] to proceed.");
                            Console.Read();
                            Console.Clear();
                            steps = 1;
                        }
                    }
                    if (currentCommand == "RUN")
                    {
                        diceRolled = diceRoll.Next(1, 5);
                        if (diceRolled == 3)
                        {
                            steps = 2;

                            Console.Clear();
                            Console.SetCursorPosition(3, 9);
                            Console.WriteLine("You managed to escape! press [Enter] to proceed.");
                            Console.Read();


                        }
                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition(3, 5);
                            Console.WriteLine("You sneak your way out of your cell, witch makes a loud grinding noice as you push it open. ");
                            Console.SetCursorPosition(3, 6);
                            Console.WriteLine("The footsteps has stopped, and as you hide closely to the wall you se a shape backing "); 
                            Console.SetCursorPosition(3, 7);
                            Console.WriteLine("off in the edge off your field of view. Whoever it was, it must have changed its mind about you. ");
                            Console.SetCursorPosition(3, 8);
                            Console.WriteLine("You find some stairs sided by spiderswebb that you slowly walks down. In the dim light you see a ");
                            Console.SetCursorPosition(3, 9);
                            Console.WriteLine("gate and sets your path towards it. From a dark corner something dark rises towards you...");
                            Console.SetCursorPosition(3, 10);
                            Console.WriteLine("In shock, you stutters and falls back on the last step of the stairs... ");
                            Console.SetCursorPosition(3, 11);
                            Console.WriteLine("Press [Enter] to proceed.");
                            Console.Read();
                            Console.Clear();
                            steps = 1;
                        }
                    }
                }
                if (steps  == 1)
                {
                    //foe: 
                    enemyName = "Shade";
                    enemyHPFull = 40;
                    enemyHPCurrent = 40;
                    enemyAttack = 5;
                    currentCommand = "COMBAT";
                    enemyAttackBonus = 1;


                    //the combat
                    do
                    {

                        if (enemyHPCurrent == enemyHPFull)
                        {
                            Console.SetCursorPosition(3, 5);
                            Console.WriteLine("You raise to shaky legs, staring into eyes like empty pits, trying to focus on ");
                            Console.SetCursorPosition(3, 6);
                            Console.WriteLine("the thing in front of you. Its eyeless stare makes your bones freeze. it glides towards you...");
                            Console.SetCursorPosition(3, 7);
                            Console.WriteLine("You search for your companion and .. ");
                        }
                        //show hp and such
                       
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
                        //display enemy stats
                        Console.SetCursorPosition(7, 3);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enemy Stats");
                        Console.SetCursorPosition(37, 3);
                        Console.WriteLine("Enemy type: {0}", enemyName);
                        Console.SetCursorPosition(67, 3);
                        Console.WriteLine("HP: {0}/{1}", enemyHPCurrent, enemyHPFull);
                        Console.WriteLine("______________________________________________________________________________________________________________________");
                        Console.ForegroundColor = ConsoleColor.White;


                        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 3);
                    Console.WriteLine("[1] To attack");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 2);
                    Console.WriteLine("[2] To Cast Magick");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 1);
                    Console.WriteLine("[3] To Heal yourself for 10 points");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 );
                    Console.WriteLine("[4] To Attemt Fleeing");
                    Console.SetCursorPosition(0, 29);
                    currentCommand = Console.ReadLine();
                        Console.Clear();
                        switch (currentCommand)
                        {
                            case "1":
                                {
                                    diceRolled = diceRoll.Next(1, playerAttack + attackBonus);
                                    enemyHPCurrent -= diceRolled;
                                    Console.SetCursorPosition(3, 7);
                                    Console.WriteLine("You attack the {0} with your {1} and strikes {2} points of damage.", enemyName, playerWeapon, diceRolled);
                                    if (enemyHPCurrent > 0)
                                    {
                                        diceRolled = diceRoll.Next(1, enemyAttack + enemyAttackBonus);
                                        playerCurrentHP -= diceRolled;
                                        Console.SetCursorPosition(3, 8);
                                        Console.WriteLine("The {0} attacks you and strikes for {1} points of damage.", enemyName, diceRolled);
                                    }
                                    else if (playerCurrentHP <= 0)
                                    {
                                        gameOver = 1;
                                        Console.SetCursorPosition(3, 9);
                                        Console.WriteLine("You died and lost the game. press [Enter] to proceed.");
                                        Console.Read();

                                    }
                                    else 
                                    {
                                        Console.SetCursorPosition(3, 9);
                                        Console.WriteLine("You killed your enemy! press [Enter] to proceed.");
                                        Console.Read();
                                        steps = 2;
                                    }
                                }
                                break;
                            case "2":
                                {
                                    if (enemyHPCurrent > 0)
                                    {


                                        int linecounter = 16;
                                        Console.SetCursorPosition(3, 7);
                                        Console.WriteLine("Select a spell from your spellbook: ");


                                        Console.SetCursorPosition(10, 16);
                                        Console.WriteLine("Name: ");
                                        Console.SetCursorPosition(20, 16);
                                        Console.WriteLine("Points:");
                                        Console.SetCursorPosition(30, 16);
                                        Console.WriteLine("Effect:");
                                        for (int y = 0; y <= 49; y++)
                                        {
                                            for (int x = 0; x <= 9; x++)
                                            {
                                                if (spellBook[x, y] != "" && spellBook[x, y] != null)
                                                {
                                                    Console.SetCursorPosition(6, y + 17);
                                                    Console.WriteLine("{0}.", y);
                                                    linecounter++;
                                                    Console.SetCursorPosition(x * 10 + 10, y + 17);
                                                    Console.WriteLine("{0}", spellBook[x, y]);

                                                }

                                            }
                                        }
                                        for (int checker = 0; checker >= 49; checker--)
                                        {
                                            if (spellBook[0, checker] == "" || spellBook[0, checker] == null)
                                            {

                                            }
                                            else
                                            {
                                                savedChecker = checker;
                                                checker = 0;
                                            }
                                        }
                                        //  Console.SetCursorPosition(10, savedChecker + 1 + 17);
                                        Console.SetCursorPosition(0, 29);
                                        currentCommand = Console.ReadLine().ToUpper();
                                        int yVal = Convert.ToInt32(currentCommand);
                                        int castDmg = Convert.ToInt32(spellBook[1, yVal]);
                                        Console.Clear();
                                        if (spellBook[2, yVal] == "DAMAGE")
                                        {
                                            enemyHPCurrent -= castDmg;
                                            Console.SetCursorPosition(3, 7);
                                            Console.WriteLine("You attack the {0} with your magic and strikes {1} points of damage.", enemyName, castDmg);
                                        }
                                        else if (spellBook[2, yVal] == "HEALING")
                                        {
                                            playerCurrentHP += castDmg;
                                            if (playerCurrentHP > playerFullHP)
                                            {
                                                playerCurrentHP = playerFullHP;
                                            }
                                            Console.SetCursorPosition(3, 7);
                                            Console.WriteLine("You heal yourself with {0} points of health.", castDmg);

                                        }

                                        else if (playerCurrentHP <= 0)
                                        {
                                            gameOver = 1;
                                            Console.SetCursorPosition(3, 9);
                                            Console.WriteLine("You died and lost the game. press [Enter] to proceed.");
                                            Console.Read();

                                        }


                                    }
                                    else
                                        {
                                            Console.SetCursorPosition(3, 9);
                                            Console.WriteLine("You killed your enemy! press [Enter] to proceed.");
                                            Console.Read();
                                            steps = 2;
                                        }
                                }

                                break;
                        case "3":
                            {
                                playerCurrentHP += 10;
                                    Console.SetCursorPosition(3, 7);
                                    Console.WriteLine("You drink a potion and heal yourself with {0} points of health.", 10);
                                    if (enemyHPCurrent > 0)
                                {
                                    diceRolled = diceRoll.Next(1, enemyAttack + enemyAttackBonus);
                                    playerCurrentHP -= diceRolled;
                                        Console.SetCursorPosition(3, 8);
                                        Console.WriteLine("The {0} attacks you and strikes for {1} points of damage.", enemyName, diceRolled);
                                    }
                                    else if (playerCurrentHP <= 0)
                                    {
                                        gameOver = 1;
                                        Console.SetCursorPosition(3, 9);
                                        Console.WriteLine("You died and lost the game. press [Enter] to proceed.");
                                        Console.Read();

                                    }
                                }
                            break;
                        case "4":
                            {
                                diceRolled = diceRoll.Next(1, 5);
                                if (diceRolled == 3)
                                {
                                    steps = 2;
                                        
                                          
                                            Console.SetCursorPosition(3, 9);
                                            Console.WriteLine("You managed to escape! press [Enter] to proceed.");
                                            Console.Read();

                                        
                                    }
                                if (enemyHPCurrent > 0)
                                {
                                    diceRolled = diceRoll.Next(1, enemyAttack + enemyAttackBonus);
                                    playerCurrentHP -= diceRolled;
                                        Console.SetCursorPosition(3, 8);
                                        Console.WriteLine("The {0} attacks you and strikes for {1} points of damage.", enemyName, diceRolled);
                                    }
                                    else if (playerCurrentHP <= 0)
                                    {
                                        gameOver = 1;
                                        Console.SetCursorPosition(3, 9);
                                        Console.WriteLine("You died and lost the game. press [Enter] to proceed.");
                                        Console.Read();

                                    }
                                }
                            break;
                        default:
                            break;
                    }
                    } while (steps < 2);
                    Console.SetCursorPosition(0, 29);
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
                    if (playerCurrentHP < playerFullHP * 0.6 && playerCurrentHP > playerFullHP * 0.5)
                    {
                        playerStatus = "You have felt better.. ";
                    }
                    if (playerCurrentHP < playerFullHP * 0.5 && playerCurrentHP > playerFullHP * 0.3)
                    {
                        playerStatus = "You feel pretty bad..";
                    }
                    if (playerCurrentHP < playerFullHP * 0.3 && playerCurrentHP > playerFullHP * 0.11)
                    {
                        playerStatus = "You are badly hurt..";
                    }
                    if (playerCurrentHP < playerFullHP * 0.1 && playerCurrentHP > playerFullHP * 0)
                    {
                        playerStatus = "you are dying... ";
                    }
                    //Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 3);

                    Console.Write("{0} ", playerStatus );
                    Console.SetCursorPosition(0, 29);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(currentCommand);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("< Back? ");
                    Console.SetCursorPosition(1, 30);
                    currentCommand = Console.ReadLine().ToUpper();
                    if (currentCommand == "BACK" || currentCommand == "<" || currentCommand == "yes")
                    {
                        Console.Clear();
                    }
                }


            } while (gameOver == 0);


        }
    }
    
}
