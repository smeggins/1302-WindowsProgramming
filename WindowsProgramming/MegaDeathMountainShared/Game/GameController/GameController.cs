using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaDeathMountain;
using System.Windows.Forms;
using System.Threading;

namespace MegaDeathMountainShared
{
    public class GameController
    {
        private static Game GameCanvas;
        public GameController (Game game)
        {
            GameCanvas = game;
        }

        private void TitleScreen(Game game)
        {
            KeyEvents.WaitForEnter();
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.CharacterSelectorPanel, true });
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.TitleScreenInitialPanel, false });
        }

        public void CharacterCreationScreen(Game game, ILogger logger)
        {
            while (true)
            {
                KeyEvents.WaitForEnter(); // about to get the values from the form to make the character[]/
                PlayerCreator.SetName(game.CC_NameBox.Text);
                if (PlayerCreator.ReadyToBuild())
                {
                    Processor.Player = PlayerCreator.BuildPlayer(logger);
                    break;
                }
            }
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.CharacterSelectorPanel, false });
        }

        private void Intro(Game game)
        {
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel1, true });

            Thread.Sleep(500);

            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel2, true });
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel1, false });

            Thread.Sleep(500);

            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel3, true });
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel2, false });

            Thread.Sleep(500);

            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel3, false });
        }

        private void DrawFormsBattleField(Game game, IActor[][] layout)
        {
            for (int y = 0; y < layout.Length; y++) 
            {
                for (int x = 0; x < layout.Length; x++)
                {
                    game.Invoke(Game.GridSquareDelegate, new object[] { game.BattleFieldCanvas, layout, (x, y) });
                }
            }
        }

        public static bool DrawShowBoxIfMessageExists(string? message)
        {
            bool Exists = false;
            if (message is not null && message != "")
            {
                MessageBox.Show(message);
                Exists = true;
            }

            return Exists;
        }

        

        public static BattleField.Fight FormFightDelegate = new BattleField.Fight(FightTheFormEnemies);
        private static void FightTheFormEnemies(Player player, List<Actor> EnemiesFought)
        {
            if (EnemiesFought != null && EnemiesFought.Count != 0)
            {
                foreach (Enemy enemy in EnemiesFought)
                {
                    FormBattle.Battle(GameCanvas, enemy);
                }
            }
        }

        private void ManageBattlefield(Processor processor, Game game)
        {
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.BattleFieldPanel, true });

            processor.BattleField.RandomlyAssignActorPosition(Processor.Player, Processor.Position.Layout);
            processor.BattleField.RandomlyAssignActorPosition(Processor.Enemies, Processor.Position.Layout);
            processor.BattleField.RandomlyAssignActorPosition(Processor.NPCs, Processor.Position.Layout);

            DrawFormsBattleField(game, Processor.Position.Layout);

            string RescueMessage;
            bool FoughtEnemies = false;

            while (Processor.Enemies.Count > 0 && Processor.Player.CurrentHealth > 0)
            {
                processor.BattleField.movePlayerOnBattleField(FormsKeyLogger.waitForKeys(new ConsoleKey[] { (ConsoleKey.UpArrow), (ConsoleKey.DownArrow), (ConsoleKey.LeftArrow), (ConsoleKey.RightArrow) }));
                game.Invoke(Game.GridSquareUpdateDelegate);

                // Rescue NPCS
                RescueMessage = processor.BattleField.RescueAdjacent(Processor.Player, Processor.NPCs);
                DrawShowBoxIfMessageExists(RescueMessage);

                // Fight Enemies
                FoughtEnemies = processor.BattleField.FightAdjacent(FormFightDelegate, Processor.Player, Processor.Enemies);
                
                
                if (FoughtEnemies || RescueMessage != "")
                {
                    game.Invoke(Game.GridSquareUpdateDelegate);
                }


                List<string> CivDeathMessages = processor.BattleField.EnemyMovementOnBattleField();
                bool fought = processor.BattleField.FightAdjacent(FormFightDelegate, Processor.Player, Processor.Enemies);
                game.Invoke(Game.GridSquareUpdateDelegate);

                foreach (string deathMessage in CivDeathMessages)
                {
                    MessageBox.Show(deathMessage);
                }
                RescueMessage = "";
            }

            Processor.Position.ResetLayout();
        }

        private void LevelUp()
        {

        }

        public Task StartFormGame(Game game, Processor GameProcessor)
        {
            return Task.Run(async () =>
            {
                //MessageBox.Show("Started the FormGame");
                TitleScreen(game);
                CharacterCreationScreen(game, GameProcessor.Logger);
                Intro(game);
                GameProcessor.cheat(Processor.Player, "p");

                int levels = 0;

                while (levels < 9)
                {
                    Task entitygen = GameProcessor.GenerateEntities();

                    await entitygen;
                    ManageBattlefield(GameProcessor, game);

                    if (Processor.Player.CurrentHealth > 0)
                    {
                        //UILineManager.PrintLine($"Congrats {Processor.Player.Name}, You survived another level of MEGA DEATH MOUNTAIN!");
                        //UILineManager.PrintLine($"\n{Processor.Player.Name} stats:");
                        //UILineManager.PrintLine($"Health: {Processor.Player.CurrentHealth}");
                        //UILineManager.PrintLine($"Energy: {Processor.Player.CurrentEnergy}");
                        //Processor.Player.makeCamp();
                        //UILineManager.waitForEnter();
                        //Processor.Player.level();
                        //UILineManager.waitForEnter();
                    }
                    else
                    {
                        game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.DiedPane, true });
                        game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.BattleFieldPanel, false });
                        UILineManager.waitForEnter();
                        break;
                    }
                    levels++;
                }

                //UILineManager.ClearScreen();
                //UILineManager.PrintLine("Thanks for playing");
            });
        }

        
    }
}
