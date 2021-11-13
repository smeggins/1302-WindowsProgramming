using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaDeathMountain;

namespace MegaDeathMountain
{
    //TODO
    //Add intro to battles
    // add intro screen
    // add exit screen


    /// <summary>
    /// you choose a character and go on an adventure. you fight, then you choose how long to wait. the longer you wait the longer you heal but
    /// </summary>
    public class Processor
    {
        public static bool debugMode = false;
        private ILogger Logger;
        private Random randomizer;
        private BattleField BattleField;

        public static ConsoleKey Key;
        public static Position position;
        public static Player Player;
        public static List<Actor> Enemies;
        public static List<Actor> NPCs;

        public Processor()
        {
            Logger = new ConsoleLogger();
            position = new Position(Logger);
            randomizer = new Random();
            Enemies = new List<Actor>();
            NPCs = new List<Actor>();
            BattleField = new BattleField(Logger, randomizer);
        }

        public static void WipeEnemyFromExistence(Enemy enemy)
        {
            Processor.position.Layout[enemy.LayoutPosition.X][enemy.LayoutPosition.Y] = null;
            Enemies.Remove(enemy);
            // Brutal ;)
        }
        public static void WipeNPCFromExistence(NPC npc)
        {
            Processor.position.Layout[npc.LayoutPosition.X][npc.LayoutPosition.Y] = null;
            NPCs.Remove(npc);
            // Brutal ;)
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

        private void ExitGame()
        {
            Environment.Exit(0);
        }

        public void ExitOnESCAsync()
        {
            Task task =  Task.Run(() =>
            {
                while(true)
                {
                    if(KeyLogger.Key == ConsoleKey.Escape)
                    {
                        ExitGame();
                    }
                }
            });
        }

        public void CreateCharacter()
        {
            Player = PlayerCreator.BuildPlayer(Logger);
            UILineManager.ClearScreen();
            UILineManager.SkipLine(4);
            UILineManager.PrintLine($"You've chosen to play as a {Player.Class.ToString()} named {Player.Name}");
            UILineManager.ClearScreen();
        }

        private async Task GenerateRandomNumberOfNPCs(int maxNumberToAdd)
        {
            for (int i = 0; i < randomizer.Next(1, maxNumberToAdd); i++)
            {
                NPCs.Add(new NPC(Logger));
            }
        }
        private async Task GenerateRandomNumberOfEnemies(int maxNumberToAdd)
        {
            for (int i = 0; i < randomizer.Next(1, maxNumberToAdd); i++)
            {
                Enemies.Add(chooseEnemy(Player.Level, randomizer));
            }
        }

        public async Task start()
        {
            KeyLogger.UpdateKeyAsync();
            ExitOnESCAsync();
            
            CreateCharacter(); cheat(Player, "p");

            UILineManager.ClearScreen();
            UILineManager.PrintLine("You arrive in the desolate, uforgiving mega death mountain." +
                "\nOnly the strongest can reach the top." +
                "\nGood luck...");
            UILineManager.waitForEnter();

            int levels = 0;

            while (levels < 9)
            {
                Task enemygen = GenerateRandomNumberOfEnemies(3);
                Task NPCgen = GenerateRandomNumberOfNPCs(3);

                UILineManager.SkipLine(4);
                UILineManager.PrintLine($"As you walk around the bend, Enemies appear in front of you, blocking your way.");
                UILineManager.waitForEnter();

                await enemygen;
                await NPCgen;

                BattleField.Controller(position.Layout);

                if (Player.CurrentHealth > 0)
                {
                    UILineManager.PrintLine($"Congrats {Player.Name}, You survived another level of MEGA DEATH MOUNTAIN!");
                    UILineManager.PrintLine($"\n{Player.Name} stats:");
                    UILineManager.PrintLine($"Health: {Player.CurrentHealth}");
                    UILineManager.PrintLine($"Energy: {Player.CurrentEnergy}");
                    Player.makeCamp();
                    UILineManager.waitForEnter();
                    Player.level();
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

            UILineManager.ClearScreen();
            UILineManager.PrintLine("Thanks for playing");
        }
    }
}
