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

        public void RandomlyAssignActorPosition(Actor actor, IActor[][] layout)
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

        public void RandomlyAssignActorPosition(List<Actor> actors, IActor[][] layout)
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

        private List<Actor> AllAdjacentActors(Actor primaryActor, List<Actor> checkedActors)
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
            if (EnemiesFought != null && EnemiesFought.Count != 0)
            {
                BattleUI.DrawBattleField(Processor.Position.Layout);
                foreach (var enemy in EnemiesFought)
                {
                    attackLoop(player, (Enemy)enemy);
                }
            }
        }


        private void Murder(Enemy enemy, List<Actor> AdjacentNPCs)
        {
            if (AdjacentNPCs != null && AdjacentNPCs.Count != 0)
            {
                BattleUI.DrawBattleField(Processor.Position.Layout);
                foreach (NPC npc in AdjacentNPCs)
                {
                    npc.die($"{npc.Name} has been brutally murdered by a terrifying {enemy.Name}!");
                }
                BattleUI.DrawBattleField(Processor.Position.Layout);
            }
        }

        private void FightAdjacent(Player player, List<Actor> enemies)
        {
            if (enemies.Count > 0)
                Fight(player, AllAdjacentActors(player, enemies));
        }

        private void KillAdjacent(Enemy enemy, List<Actor> npcs)
        {
            if (npcs.Count > 0)
                Murder(enemy, AllAdjacentActors(enemy, npcs));
        }

        private void Rescue(List<Actor> NPCsRescued)
        {
            if (NPCsRescued != null && NPCsRescued.Count != 0)
            {
                BattleUI.DrawBattleField(Processor.Position.Layout);
                foreach (NPC NPC in NPCsRescued)
                {
                    NPC.Rescued($"{NPC.Name} Was rescued! They want to repay the favor");
                }
            }
        }
        private void RescueAdjacent(Player player, List<Actor> npcs)
        {
            if (npcs.Count > 0)
                Rescue(AllAdjacentActors(player, npcs));
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

        public void movePlayerOnBattleField()
        {
            ConsoleKey key = UILineManager.waitForKeys(new ConsoleKey[] { (ConsoleKey.UpArrow), (ConsoleKey.DownArrow), (ConsoleKey.LeftArrow), (ConsoleKey.RightArrow) });
            int X = Processor.Player.LayoutPosition.X;
            int Y = Processor.Player.LayoutPosition.Y;
            Logger.logDebugInformation($"BattleFieldController(): ConsoleKey key = UILineManager.waitForKeys = {key}");
            switch (key)
            {
                case (ConsoleKey.UpArrow):
                    Processor.Position.UpdatePosition(Processor.Player, (X, Y + 1));
                    break;
                case (ConsoleKey.DownArrow):
                    Processor.Position.UpdatePosition(Processor.Player, (X, Y - 1));
                    break;
                case (ConsoleKey.LeftArrow):
                    Processor.Position.UpdatePosition(Processor.Player, (X - 1, Y));
                    break;
                case (ConsoleKey.RightArrow):
                    Processor.Position.UpdatePosition(Processor.Player, (X + 1, Y));
                    break;
            }
            Processor.keyLogger.ClearKey();
        }

        private int Square(int num) => num * num;

        private int GetDistanceSquared((int X, int Y) position1, (int X, int Y) position2) =>
            Square(position1.X - position2.X) + Square(position1.Y - position2.Y);

        public Actor findNearestActorToActor(Actor primaryActor, List<Actor> searchActors)
        {
            (int X, int Y) CurrentPosition = primaryActor.LayoutPosition;
            Actor ClosestActor = searchActors[0];
            int ClosestPositionDistanceSquared = GetDistanceSquared(CurrentPosition, searchActors.First().LayoutPosition);

            foreach (Actor actor in searchActors.Skip(1))
            {
                int DistanceSquared = GetDistanceSquared(CurrentPosition, actor.LayoutPosition);
                if (DistanceSquared < ClosestPositionDistanceSquared)
                {
                    ClosestPositionDistanceSquared = DistanceSquared;
                    ClosestActor = actor;
                }
            }

            return ClosestActor;
        }

        private void MoveActorTowardsClosestActor(Actor primary, Actor target, int spacesToMove = 1)
        {
            int EXAbs = (int)MathF.Abs(primary.LayoutPosition.X);
            int EYAbs = (int)MathF.Abs(primary.LayoutPosition.Y);
            int NXAbs = (int)MathF.Abs(target.LayoutPosition.X);
            int NYAbs = (int)MathF.Abs(target.LayoutPosition.Y);
            
            if (MathF.Abs(EXAbs - NXAbs) > MathF.Abs(EYAbs - NYAbs))
            {
                if (target.LayoutPosition.X > primary.LayoutPosition.X)
                {
                    Processor.Position.move(primary, spacesToMove, 0);
                }
                else
                {
                    Processor.Position.move(primary, -spacesToMove, 0);
                }
            }
            else
            {
                if (target.LayoutPosition.Y > primary.LayoutPosition.Y)
                {
                    Processor.Position.move(primary, 0, spacesToMove);
                }
                else
                {
                    Processor.Position.move(primary, 0, -spacesToMove);
                }
            }
        }

        private void MoveActorRandomly(Actor actor, int spacesToMove = 1)
        {
            bool moveOnXAxis = (Randomizer.Instance.RandomNumber(0, 1) == 0);
            int modifyer = (Randomizer.Instance.RandomNumber(0, 1) == 0) ? (1 * spacesToMove) : (-1 * spacesToMove);

            if (moveOnXAxis)
            {
                Processor.Position.move(actor, modifyer, 0);
            }
            else
            {
                Processor.Position.move(actor, 0, modifyer);
            }
        }

        private void EnemyMovementOnBattleField()
        {   
            foreach (Enemy enemy in Processor.Enemies)
            {
                if (Processor.NPCs.Count > 0) 
                {
                    Actor ClosestNPC = findNearestActorToActor(enemy, Processor.NPCs);
                    MoveActorTowardsClosestActor(enemy, ClosestNPC);
                    KillAdjacent(enemy, new List<Actor>() { ClosestNPC });
                }
                else
                {
                    MoveActorTowardsClosestActor(enemy, Processor.Player);
                }
            }

            FightAdjacent(Processor.Player, Processor.Enemies);
        }

        private void NPCMovementOnBattleField()
        {
            List<Actor> npcsToKill = new List<Actor>();

            foreach (NPC npc in Processor.NPCs)
            {
                MoveActorRandomly(npc);

                //if (Processor.Enemies.Count > 0)
                //{
                //    List<Actor> adjacentEnemies = AllAdjacentActors(npc, Processor.Enemies);

                //    if (adjacentEnemies.Count > 0)
                //    {
                //        npcsToKill.Add(npc);
                //        continue;
                //    }
                //}

                //if (isAdjacent(Processor.Player, npc))
                //{
                //    npc.Rescued($"The civilian {npc.Name} is has made it to you and thus saftey. They'd like to repay the favor");
                //}
            }

            foreach (NPC npc in npcsToKill)
            {
                npc.die();
            }
        }

        public void Controller(IActor[][] layout)
        {
            RandomlyAssignActorPosition(Processor.Player, Processor.Position.Layout);
            RandomlyAssignActorPosition(Processor.Enemies, Processor.Position.Layout);
            RandomlyAssignActorPosition(Processor.NPCs, Processor.Position.Layout);


            while (Processor.Enemies.Count > 0 && Processor.Player.CurrentHealth > 0)
            {
                BattleUI.DrawBattleField(layout);
                UILineManager.PrintLine("To move use your arrow keys");

                movePlayerOnBattleField();

                RescueAdjacent(Processor.Player, Processor.NPCs);
                FightAdjacent(Processor.Player, Processor.Enemies);

                
                EnemyMovementOnBattleField();
                NPCMovementOnBattleField();
            }

            Processor.Position.ResetLayout();
        }
    }
}
