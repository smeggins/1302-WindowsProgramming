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
    // add Logger implementation
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
    ///     choose attack or dodge
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
        public static bool debugMode = true;
        ILogger Logger = new ConsoleLogger();

        private void attackLoop(Player player1, Enemy Enemy)
        {
            int round = 1;
            
            while ((player1.CurrentHealth > 0 && Enemy.CurrentHealth > 0))
            {
                Console.Clear();
                BattleUI.drawBattle(round, player1, Enemy);
                ConsoleKey SelectedOption;

                UILineManager.clearConsoleBuffer();
                if (player1.CurrentEnergy == 10)
                {
                    SelectedOption = UILineManager.waitForKeys(new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3 });
                }
                else
                {
                    SelectedOption = UILineManager.waitForKeys(new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.D2 });
                }
                Console.Clear();
                
                if (SelectedOption == ConsoleKey.D1)
                {
                    player1.attack(Enemy, Dialogue.Instance.getRandomAttackMsg());
                }
                else if (SelectedOption == ConsoleKey.D2)
                {
                    player1.Defend();
                }
                else if (SelectedOption == ConsoleKey.D3)
                {
                    player1.specialAttack(Enemy);
                }

                if (Enemy.CurrentHealth > 0)
                {
                    if (Enemy.ChargingSpecialAttack == false)
                    {
                        Enemy.attack(player1, Dialogue.Instance.getRandomAttackMsg());
                    }
                    else
                    {
                        Enemy.specialAttack(player1);
                        Enemy.ChargingSpecialAttack = false;
                    }
                }
                UILineManager.PrintLine($"\nEnd of round {round}\n\n");
                round++;
                Logger.logDebugInformation($"\nPlayer defence:        {player1.Defence}, " +
                                           $"\nPlayer is Defending: {player1.Defending}");
                player1.Defending = false;
                UILineManager.waitForEnter();
            }
        }

        

        private void cheat(Player player, string cheatkey)
        {
            if(player.Name == cheatkey)
            {
                player.Attack = 1000;
                player.TotalHealth = 1000;
                player.CurrentHealth = player.TotalHealth;
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
            
            Logger.logDebugInformation(($"\n\n---------------------\nEnemy ChooseEnemy: {rng}\n" +
                $"impPriority: {(((100 - cryptLordPriority - vampirePriority - demonPriority) > 0) ? 100 - cryptLordPriority - vampirePriority - demonPriority : 0)}\n" +
                $"demonPriority: {demonPriority}\n" +
                $"vampirePriority: {vampirePriority}\n" +
                $"cryptLordPriority: {cryptLordPriority}\n" +
                $"---------------------\n\n"));
            
            if (rng < cryptLordPriority)
            {
                return new CryptLord("Crypt Lord", playerLevel, Logger);
            }
            else if (rng < vampirePriority)
            {
                return new Vampire("Vampire", playerLevel, Logger);
            }
            else if (rng < demonPriority)
            {
                return new Demon("Demon", playerLevel, Logger);
            }
            else
            {
                return new Imp("Imp", playerLevel, Logger);
            }
        }

        public void start()
        {

            UILineManager.PrintChars("What is your Name: ");
            Knight player1;
            try
            {
                player1 = new Knight(Console.ReadLine(), Logger); cheat(player1, "p");
            }
            catch (Exception ex)
            {
                Logger.logException("Exception assigning player name.", ex);
                throw new ArgumentException();
            }

            Enemy Enemy;

            Console.Clear();
            Position position = new Position();
            position.Layout[2][4] = player1;
            BattleUI.DrawBattleField(position.Layout);
            UILineManager.waitForEnter();

            Console.Clear();
            UILineManager.PrintLine("You arrive in the desolate, uforgiving mega death mountain." +
                "\nOnly the strongest can reach the top." +
                "\nGood luck...");
            UILineManager.waitForEnter();
            int levels = 0;

            

            while (levels < 9)
            {
                Enemy = chooseEnemy(player1.Level, new Random());
                UILineManager.PrintLine($"As you walk around the bend,{Enemy.Name} Appears in front of you, blocking your way.");
                attackLoop(player1, Enemy);

                if (player1.CurrentHealth > 0)
                {
                    UILineManager.PrintLine($"Congrats {player1.Name}, You survived another level of MEGA DEATH MOUNTAIN!");
                    UILineManager.PrintLine($"\n{player1.Name} stats:");
                    UILineManager.PrintLine($"Health: {player1.CurrentHealth}");
                    UILineManager.PrintLine($"Energy: {player1.CurrentEnergy}");
                    player1.makeCamp();
                    UILineManager.waitForEnter();
                    player1.level();
                    UILineManager.waitForEnter();
                }
                else
                {
                    UILineManager.PrintLine("You had a good run, maybe next time you'll conquer MEGA DEATH MOUNTAIN!");
                    UILineManager.waitForEnter();
                    break;
                }
                levels++;
            }

            Console.Clear();
            UILineManager.PrintLine("Thanks for playing");

        }
    }
}
