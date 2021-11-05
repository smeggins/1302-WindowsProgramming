using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoomSlayer9000OmegaForce1;
namespace DoomSlayer9000OmegaForce1
{
    //TODO Add intro to battles
    // move battles to method that generates enemy
    // make enemies
    // make alternate character types
    // add logger implementation
    // move method implementations on knight to player as makes sense
    // add intro screen
    // add exit screen
    // fix bug where you can press enter during camp rest ZZZ and it skips ahead screens


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
        private void attackLoop(IActor player1, IActor player2)
        {
            int round = 1;
            while ((player1._CurrentHealth > 0 && player2._CurrentHealth > 0))
            {
                Console.Clear();
                Console.WriteLine($"\nPlayer 1 health: {player1._CurrentHealth}");
                Console.WriteLine($"Player 2 health: {player2._CurrentHealth}\n");

                player1.attack(player2, Dialogue.Instance.getRandomAttackMsg());

                player2.attack(player1, Dialogue.Instance.getRandomAttackMsg());

                Console.WriteLine($"\nEnd of round {round}\n\n");
                round++;
                waitForEnter();
            }
        }

        public void waitForEnter()
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

        public void start()
        {
            Console.WriteLine("What is your Name: ");
            Knight player1 = new Knight(Console.ReadLine());
            cheat(player1, "p");
            Knight player2 = new Knight("Tim The Bastard");

            Console.Clear();
            Console.WriteLine("You arrive in the desolate, uforgiving mega death mountain." +
                "\nOnly the strongest can reach the top." +
                "\nGood luck...");
            waitForEnter();
            int levels = 0;

            while (levels < 5)
            {
                player2 = new Knight("Tim The Bastard");
                attackLoop(player1, player2);

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
