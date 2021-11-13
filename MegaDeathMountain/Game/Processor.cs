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
        ILogger Logger;
        Random randomizer;

        private static Position position;
        public static Player Player;
        public static List<Enemy> Enemies;

        public Processor()
        {
            Logger = new ConsoleLogger();
            position = new Position(Logger);
            randomizer = new Random();
            Enemies = new List<Enemy>();
        }

        public static void WhipeEnemyFromExistence(Enemy enemy)
        {
            Processor.position.Layout[enemy.LayoutPosition.X][enemy.LayoutPosition.Y] = null;
            Enemies.Remove(enemy);
            // Brutal ;)
        }

        private void attackLoop(Player Player, Enemy Enemy)
        {
            int round = 1;
            
            while ((Player.CurrentHealth > 0 && Enemy.CurrentHealth > 0))
            {
                UILineManager.ClearScreen();
                BattleUI.drawBattle(round, Player, Enemy);
                ConsoleKey SelectedOption;

                UILineManager.clearConsoleBuffer();
                if (Player.CurrentEnergy == 10)
                {
                    SelectedOption = UILineManager.waitForKeys(new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3 });
                }
                else
                {
                    SelectedOption = UILineManager.waitForKeys(new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.D2 });
                }
                UILineManager.ClearScreen();
                
                if (SelectedOption == ConsoleKey.D1)
                {
                    Player.attack(Enemy, Dialogue.Instance.getRandomAttackMsg());
                }
                else if (SelectedOption == ConsoleKey.D2)
                {
                    Player.Defend();
                }
                else if (SelectedOption == ConsoleKey.D3)
                {
                    Player.specialAttack(Enemy);
                }

                if (Enemy.CurrentHealth > 0)
                {
                    if (Enemy.ChargingSpecialAttack == false)
                    {
                        Enemy.attack(Player, Dialogue.Instance.getRandomAttackMsg());
                    }
                    else
                    {
                        Enemy.specialAttack(Player);
                        Enemy.ChargingSpecialAttack = false;
                    }
                }
                UILineManager.PrintLine($"\nEnd of round {round}\n\n");
                round++;
                Logger.logDebugInformation($"\nPlayer defence:        {Player.Defence}, " +
                                           $"\nPlayer is Defending: {Player.Defending}");
                Player.Defending = false;
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

        private void ExitGame()
        {
            Environment.Exit(0);
        }

        public async void ExitOnESCAsync()
        {
            Task task =  Task.Run(() =>
            {
                while(true)
                {
                    //if (Console.KeyAvailable)
                    //{
                    //    Logger.logDebugInformation($"Console key : {Console.Read()}");
                    //    Console.ReadLine();
                    //    if (Console.ReadKey(false).Key == ConsoleKey.Escape)
                    //    {
                    //        ExitGame();
                    //    }
                    //}
                    if(Key == ConsoleKey.Escape)
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

        public static ConsoleKey Key;
        public static void UpdateKeyAsync()
        {
            Task UpdateKeyTask = Task.Run(() =>
            {
                while (true)
                {
                    if (Console.KeyAvailable == true)
                    {
                        Processor.Key = Console.ReadKey(true).Key;
                    }
                }
            });
        }

        private bool isAdjacent(Actor actor)
        {
            int X = actor.LayoutPosition.X;
            int Y = actor.LayoutPosition.Y;

            if ( ( (X + 1 == Player.LayoutPosition.X) || (X - 1 == Player.LayoutPosition.X) ) && (Y == Player.LayoutPosition.Y) )
            {
                return true;
            }
            else if (((Y + 1 == Player.LayoutPosition.Y) || (Y - 1 == Player.LayoutPosition.Y)) && (X == Player.LayoutPosition.X))
            {
                return true;
            }            

            return false;
        }

        private void FightNearest()
        {
            List<Enemy> CurrentEnemy = null;

            foreach (var enemy in Enemies)
            {
                if (isAdjacent(enemy))
                {
                    if (CurrentEnemy == null)
                    {
                        CurrentEnemy = new List<Enemy>();
                    }

                    CurrentEnemy.Add(enemy);
                }
            }

            if (CurrentEnemy != null && CurrentEnemy.Count != 0)
            {
                foreach (var enemy in CurrentEnemy)
                {
                    attackLoop(Player, enemy);
                }
            }
        }

        public void BattleFieldController(IActor[][] layout)
        {
            RandomlyAssignActorPosition(Player);
            RandomlyAssignActorPosition(Enemies);


            while (Enemies.Count > 0 && Player.CurrentHealth > 0)
            {
                UILineManager.ClearScreen();
                BattleUI.DrawBattleField(layout);
                UILineManager.PrintLine("\nTo move use your arrow keys");
                ConsoleKey key = UILineManager.waitForKeys(new ConsoleKey[] { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow, });

                int X = Player.LayoutPosition.X;
                int Y = Player.LayoutPosition.Y;
                Logger.logDebugInformation($"BattleFieldController(): ConsoleKey key = UILineManager.waitForKeys = {key}");
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                       position.UpdatePosition(Player, (X, Y + 1));
                        break;
                    case ConsoleKey.DownArrow:
                        position.UpdatePosition(Player, (X, Y - 1));
                        break;
                    case ConsoleKey.LeftArrow:
                        position.UpdatePosition(Player, (X - 1, Y));
                        break;
                    case ConsoleKey.RightArrow:
                        position.UpdatePosition(Player, (X + 1, Y));
                        break;
                }
                Key = ConsoleKey.F1;

                FightNearest();
            }

            position.ResetLayout();
        }

        private void RandomlyAssignActorPosition(Actor actor)
        {
            //TODO could be refactored to be more efficient
            (int X, int Y)? NewPosition = null;
            int X = 0;
            int Y = 0;

            while (NewPosition == null || position.Layout[X][Y] != null) 
            {
                X = randomizer.Next(0, position.Layout.Length-1);
                Y = randomizer.Next(0, position.Layout[0].Length-1);
                NewPosition = (X, Y);
            }
            actor.LayoutPosition = (X, Y);
            position.Layout[X][Y] = actor;
        }

        private void RandomlyAssignActorPosition(List<Enemy> actors)
        {
            //TODO could be refactored to be more efficient
            foreach (var actor in actors)
            {
                (int X, int Y)? NewPosition = null;
                int X = 0;
                int Y = 0;

                while (NewPosition == null || position.Layout[X][Y] != null)
                {
                    X = randomizer.Next(0, position.Layout.Length - 1);
                    Y = randomizer.Next(0, position.Layout[0].Length - 1);
                    NewPosition = (X, Y);
                }
                actor.LayoutPosition = (X, Y);
                position.Layout[X][Y] = actor;
            }
        }

        public async void start()
        {
            UpdateKeyAsync();
            ExitOnESCAsync();
            
            CreateCharacter();

            UILineManager.ClearScreen();
            UILineManager.PrintLine("You arrive in the desolate, uforgiving mega death mountain." +
                "\nOnly the strongest can reach the top." +
                "\nGood luck...");
            UILineManager.waitForEnter();

            int levels = 0;

            while (levels < 9)
            {
                for (int i = 0; i < randomizer.Next(1, 3); i++)
                {
                    Enemies.Add(chooseEnemy(Player.Level, new Random()));
                }

                UILineManager.SkipLine(4);
                UILineManager.PrintLine($"As you walk around the bend, Enemies appear in front of you, blocking your way.");
                UILineManager.waitForEnter();

                BattleFieldController(position.Layout);

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
