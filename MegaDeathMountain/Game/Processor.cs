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
        public ILogger Logger;

        public static IKeyLogger keyLogger;
        public BattleField BattleField;
        public static Position Position;
        public static Player Player;
        public static List<Actor> Enemies;
        public static List<Actor> NPCs;

        public Processor(IKeyLogger keylogger, ILogger logger)
        {
            this.Logger = logger;
            Processor.keyLogger = keylogger;
            InstantiateProcessor();
        }

        private void InstantiateProcessor()
        {
            var PositionTask = Task.Run(() =>
            {
                Position = new Position(this.Logger);
            });
            var EnemiesTask = Task.Run(() =>
            {
                Enemies = new List<Actor>();
            });
            var NPCsTask = Task.Run(() =>
            {
                NPCs = new List<Actor>();
            });
            var BattleFieldTask = Task.Run(() =>
            {
                BattleField = new BattleField(this.Logger);
            });

            Task.WaitAll(PositionTask, EnemiesTask, NPCsTask, BattleFieldTask);
        }

        public static void WipeEnemyFromExistence(Enemy enemy)
        {
            Processor.Position.Layout[enemy.LayoutPosition.X][enemy.LayoutPosition.Y] = null;
            Enemies.Remove(enemy);
            // Brutal ;)
        }
        public static void WipeNPCFromExistence(NPC npc)
        {
            Processor.Position.Layout[npc.LayoutPosition.X][npc.LayoutPosition.Y] = null;
            NPCs.Remove(npc);
            // Brutal ;)
        }

        public void cheat(Player player, string cheatkey)
        {
            if(player.Name == cheatkey)
            {
                player.Attack = 1000;
                player.TotalHealth = 1000;
                player.CurrentHealth = player.TotalHealth;
            }
        }

        private Enemy chooseEnemy(int playerLevel)
        {
            int rng = Randomizer.Instance.RandomNumber(0, 100);

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
            
            this.Logger.logDebugInformation(($"\n\n---------------------\nEnemy ChooseEnemy: {rng}\n" +
                $"impPriority: {(((100 - cryptLordPriority - vampirePriority - demonPriority) > 0) ? 100 - cryptLordPriority - vampirePriority - demonPriority : 0)}\n" +
                $"demonPriority: {demonPriority}\n" +
                $"vampirePriority: {vampirePriority}\n" +
                $"cryptLordPriority: {cryptLordPriority}\n" +
                $"---------------------\n\n"));
            
            if (rng < cryptLordPriority)
            {
                return new CryptLord("Crypt Lord", playerLevel, this.Logger);
            }
            else if (rng < vampirePriority)
            {
                return new Vampire("Vampire", playerLevel, this.Logger);
            }
            else if (rng < demonPriority)
            {
                return new Demon("Demon", playerLevel, this.Logger);
            }
            else
            {
                return new Imp("Imp", playerLevel, this.Logger);
            }
        }

        public static void ExitGame()
        {
            Environment.Exit(0);
        }

        public void CreateCharacter()
        {
            PlayerCreator.RequestName(this.Logger);
            PlayerCreator.RequestClass(this.Logger);
            Player = PlayerCreator.BuildPlayer(this.Logger);
            UILineManager.ClearScreen();
            UILineManager.SkipLine(4);
            UILineManager.PrintLine($"You've chosen to play as a {Player.Class.ToString()} named {Player.Name}");
            UILineManager.ClearScreen();
        }

        private Task GenerateRandomNumberOfNPCs(int maxNumberToAdd)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < Randomizer.Instance.RandomNumber(1, maxNumberToAdd); i++)
                {
                    NPCs.Add(new NPC(this.Logger));
                }
            });
        }
        private Task GenerateRandomNumberOfEnemies(int maxNumberToAdd)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < Randomizer.Instance.RandomNumber(1, maxNumberToAdd); i++)
                {
                    Enemies.Add(chooseEnemy(Player.Level));
                }
            });
            
        }

        public async Task GenerateEntities()
        {
            Task enemygen = GenerateRandomNumberOfEnemies(3);
            Task NPCgen = GenerateRandomNumberOfNPCs(3);

            await Task.WhenAll(enemygen, NPCgen);
        }

        public async Task StartConsoleGame()
        {
            keyLogger.UpdateKeyAsync();
            
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

                await Task.WhenAll(enemygen, NPCgen);
                BattleField.Controller(Position.Layout);

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
