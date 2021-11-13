using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public class BattleField
    {
        ILogger Logger;

        public BattleField(ILogger logger)
        {
            Logger = logger;
        }

        private bool PositionIsolated(IActor[][] layout, int x, int y)
        {

            if (layout[x][y] != null)
            {
                return false;
            }

            if ((x + 1) <= layout.Length - 1 && (x + 1) >= 0)
            {
                if (layout[x + 1][y] != null)
                {
                    return false;
                }
            }

            if ((x - 1) <= layout.Length - 1 && (x - 1) >= 0)
            {
                if (layout[x - 1][y] != null)
                {
                    return false;
                }
            }

            if ((y + 1) <= layout[0].Length - 1 && (y + 1) >= 0)
            {
                if (layout[x][y + 1] != null)
                {
                    return false;
                }
            }

            if ((y - 1) <= layout[0].Length - 1 && (y - 1) >= 0)
            {
                if (layout[x][y - 1] != null)
                {
                    return false;
                }
            }

            return true;
        }

        private void RandomlyAssignActorPosition(Actor actor, IActor[][] layout)
        {
            int X = 0;
            int Y = 0;
            bool Isolated = false;

            while (Isolated == false)
            {
                X = Randomizer.Instance.RandomNumber(0, layout.Length - 1);
                Y = Randomizer.Instance.RandomNumber(0, layout[0].Length - 1);
                Isolated = PositionIsolated(layout, X, Y);
            }
            actor.LayoutPosition = (X, Y);
            layout[X][Y] = actor;
        }

        private void RandomlyAssignActorPosition(List<Actor> actors, IActor[][] layout)
        {
            foreach (var actor in actors)
            {
                RandomlyAssignActorPosition(actor, layout);
            }
        }

        private bool isAdjacent(Actor actor1, Actor actor2)
        {
            int X = actor1.LayoutPosition.X;
            int Y = actor1.LayoutPosition.Y;
            bool adj = false;

            if (((X + 1 == actor2.LayoutPosition.X) || (X - 1 == actor2.LayoutPosition.X)) && (Y == actor2.LayoutPosition.Y))
            {
                adj = true;
            }
            else if (((Y + 1 == actor2.LayoutPosition.Y) || (Y - 1 == actor2.LayoutPosition.Y)) && (X == actor2.LayoutPosition.X))
            {
                adj = true;
            }

            return adj;
        }

        private async Task<List<Actor>> AllAdjacentActors(Actor primaryActor, List<Actor> checkedActors)
        {
            List<Actor> AdjacentActors = null;

            foreach (var actor in checkedActors)
            {
                if (isAdjacent(primaryActor, actor))
                {
                    if (AdjacentActors == null)
                    {
                        AdjacentActors = new List<Actor>();
                    }

                    AdjacentActors.Add(actor);
                }
            }
            return AdjacentActors;
        }

        private void Fight(Player player, List<Actor> EnemiesFought)
        {
            if(EnemiesFought != null && EnemiesFought.Count != 0)
            {
                BattleUI.DrawBattleField(Processor.position.Layout);
                foreach (var enemy in EnemiesFought)
                {
                    attackLoop(player, (Enemy)enemy);
                }
            }
        }

        private async Task FightNearest(Player player, List<Actor> enemies)
        {
            Fight(player, await AllAdjacentActors(player, enemies));
        }
        
        private void Rescue(List<Actor> NPCsRescued)
        {
            if (NPCsRescued != null && NPCsRescued.Count != 0)
            {
                BattleUI.DrawBattleField(Processor.position.Layout);
                foreach (NPC NPC in NPCsRescued)
                {
                    NPC.Rescued($"{NPC.Name} Was rescued! They want to repay the favor");
                }
            }
        }
        private async Task RescueNearest(Player player, List<Actor> npcs)
        {
            Rescue(await AllAdjacentActors(player, npcs));
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

        public async Task Controller(IActor[][] layout)
        {
            RandomlyAssignActorPosition(Processor.Player, Processor.position.Layout);
            RandomlyAssignActorPosition(Processor.Enemies, Processor.position.Layout);
            RandomlyAssignActorPosition(Processor.NPCs, Processor.position.Layout);


            while (Processor.Enemies.Count > 0 && Processor.Player.CurrentHealth > 0)
            {
                BattleUI.DrawBattleField(layout);
                UILineManager.PrintLine("To move use your arrow keys");
                ConsoleKey key = UILineManager.waitForKeys(new ConsoleKey[] { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow, });

                int X = Processor.Player.LayoutPosition.X;
                int Y = Processor.Player.LayoutPosition.Y;
                Logger.logDebugInformation($"BattleFieldController(): ConsoleKey key = UILineManager.waitForKeys = {key}");
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        Processor.position.UpdatePosition(Processor.Player, (X, Y + 1));
                        break;
                    case ConsoleKey.DownArrow:
                        Processor.position.UpdatePosition(Processor.Player, (X, Y - 1));
                        break;
                    case ConsoleKey.LeftArrow:
                        Processor.position.UpdatePosition(Processor.Player, (X - 1, Y));
                        break;
                    case ConsoleKey.RightArrow:
                        Processor.position.UpdatePosition(Processor.Player, (X + 1, Y));
                        break;
                }
                KeyLogger.Key = ConsoleKey.F1;

                Task Rescuing = RescueNearest(Processor.Player, Processor.NPCs);
                Task Fighting = FightNearest(Processor.Player, Processor.Enemies);

                await Rescuing;
                await Fighting;
            }

            Processor.position.ResetLayout();
        }
    }
}
