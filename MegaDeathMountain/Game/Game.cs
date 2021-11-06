using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaDeathMountain;

namespace MegaDeathMountain
{
    //TODO Add intro to battles
    // make alternate character types
    // add logger implementation
    // add intro screen
    // add exit screen


    /// <summary>
    /// you choose a character and go on an adventure. you fight, then you choose how long to wait. the longer you wait the longer you heal but
    /// you also get an attack bonus after a fight that you loose at double the rate you heal.
    /// 
    /// loose attack double the rate you regen with higher base attack and defense(Knight)
    /// lose the attack as fast as you heal but gain attack twice as fast with half health(beast)
    /// lose attack at half the rate you heal with lower base attack rate(priest)
    /// 
    /// each fight is a level
    /// when fight starts you choose an option and the ai chooses an option until one person is dead.
    /// no option to run
    /// 
    /// 
    /// enemy stats randomized based on player level
    /// 
    /// intro
    /// choose class
    /// instructions
    /// fight
    ///     choose attack or defend
    ///     enemy attack
    ///     repeat
    /// choose to rest
    ///     how many hours
    ///     gain hp lose energy
    ///  fight
    ///  choose rest
    ///  repeat x times
    ///  boss
    ///  end screen
    ///  main menu
    /// </summary>
    class Game
    {

        bool debugMode = true;
        ILogger logger = new WriteLogger();

        private void attackLoop(Player player1, Enemy Enemy)
        {
            int round = 1;
            while ((player1._CurrentHealth > 0 && Enemy._CurrentHealth > 0))
            {
                Console.Clear();
                Console.WriteLine($"\n{player1._Name} health: {player1._CurrentHealth}");
                Console.WriteLine($"Enemy health: {Enemy._CurrentHealth}\n");

                player1.attack(Enemy, Dialogue.Instance.getRandomAttackMsg());

                if (Enemy._CurrentHealth > 0)
                {
                    if (Enemy.waitingToAttack == false)
                    {
                        Enemy.attack(player1, Dialogue.Instance.getRandomAttackMsg());
                    }
                    else
                    {
                        Enemy.specialAttack(player1);
                        Enemy.waitingToAttack = false;
                    }
                }
                Console.WriteLine($"\nEnd of round {round}\n\n");
                round++;
                waitForEnter();
            }
        }

        public static void clearConsoleBuffer()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(false);
        }

        public static void waitForEnter()
        {
            Console.WriteLine("\nPress Enter To Continue:");
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        private void cheat(Player player, string cheatkey)
        {
            if(player._Name == cheatkey)
            {
                player._Attack = 1000;
                player._TotalHealth = 1000;
                player._CurrentHealth = player._TotalHealth;
            }
        }

        private Enemy chooseEnemy(int playerLevel, Random RNG)
        {
            int rng = RNG.Next(0, 100);

            //level 1 spawn priority
            int demonPriority = 8;
            int vampirePriority = 4;
            int cryptLordPriority = 2;

            if (playerLevel > 1) 
            {
                cryptLordPriority = cryptLordPriority * playerLevel;
                vampirePriority = vampirePriority * playerLevel;
                demonPriority = demonPriority * playerLevel;
            }
            if (this.debugMode == true)
            {
                logger.logDebugInformation(($"\n\n---------------------\nEnemy ChooseEnemy: {rng}\n" +
                    $"impPriority: {(((100 - cryptLordPriority - vampirePriority - demonPriority) > 0) ? 100 - cryptLordPriority - vampirePriority - demonPriority : 0)}\n" +
                    $"demonPriority: {demonPriority}\n" +
                    $"vampirePriority: {vampirePriority}\n" +
                    $"cryptLordPriority: {cryptLordPriority}\n" +
                    $"---------------------\n\n"));
            }

            if (rng < cryptLordPriority)
            {
                return new CryptLord("Crypt Lord", playerLevel);
            }
            else if (rng < vampirePriority)
            {
                return new Vampire("Vampire", playerLevel);
            }
            else if (rng < demonPriority)
            {
                return new Demon("Demon", playerLevel);
            }
            else
            {
                return new Imp("Imp", playerLevel);
            }
        }

        public void start()
        {
            Console.Write("What is your Name: ");
            Knight player1;
            try
            {
                player1 = new Knight(Console.ReadLine()); cheat(player1, "p");
            }
            catch (Exception ex)
            {
                logger.logException("Exception assigning player name.", ex);
                throw new ArgumentException();
            }

            Enemy Enemy;

            Console.Clear();
            Console.WriteLine("You arrive in the desolate, uforgiving mega death mountain." +
                "\nOnly the strongest can reach the top." +
                "\nGood luck...");
            waitForEnter();
            int levels = 0;

            while (levels < 9)
            {
                Enemy = chooseEnemy(player1._Level, new Random());
                attackLoop(player1, Enemy);

                if (player1._CurrentHealth > 0)
                {
                    Console.WriteLine($"Congrats {player1._Name}, You survived another level of MEGA DEATH MOUNTAIN!");
                    Console.WriteLine($"\n{player1._Name} stats:");
                    Console.WriteLine($"Health: {player1._CurrentHealth}");
                    Console.WriteLine($"Energy: {player1._CurrentEnergy}");
                    player1.makeCamp();
                    waitForEnter();
                    player1.level();
                    waitForEnter();
                }
                else
                {
                    Console.WriteLine("You had a good run, maybe next time you'll conquer MEGA DEATH MOUNTAIN!");
                    waitForEnter();
                    break;
                }
                levels++;
            }

            

            Console.Clear();
            Console.WriteLine("Thanks for playing");

        }
        
        
    }
}
