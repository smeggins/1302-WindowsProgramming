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

            Thread.Sleep(2000);

            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel2, true });
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel1, false });

            Thread.Sleep(2000);

            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel3, true });
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel2, false });

            Thread.Sleep(3000);

            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.IntroPanel3, false });
        }

        private void DrawFormsBattleField(IActor[][] layout)
        {
            
        }

        private void ManageBattlefield(Processor processor, Game game)
        {
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.BattleFieldPanel, true });

            processor.BattleField.RandomlyAssignActorPosition(Processor.Player, Processor.Position.Layout);
            processor.BattleField.RandomlyAssignActorPosition(Processor.Enemies, Processor.Position.Layout);
            processor.BattleField.RandomlyAssignActorPosition(Processor.NPCs, Processor.Position.Layout);


            while (Processor.Enemies.Count > 0 && Processor.Player.CurrentHealth > 0)
            {
                    //BattleUI.DrawBattleField(layout);
                //    UILineManager.PrintLine("To move use your arrow keys");

                //    movePlayerOnBattleField();

                //    RescueAdjacent(Processor.Player, Processor.NPCs);
                //    FightAdjacent(Processor.Player, Processor.Enemies);


                //    EnemyMovementOnBattleField();
                //    NPCMovementOnBattleField();
            }

        //Processor.Position.ResetLayout();
    }

        public Task StartFormGame(Game game)
        {
            return Task.Run(async () =>
            {
                //MessageBox.Show("Started the FormGame");
                Processor GameProcessor = new Processor(new FormsKeyLogger(), new WriteLogger());
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
                        //GameProcessor.BattleField.Controller(Processor.Position.Layout);

                    //    if (Processor.Player.CurrentHealth > 0)
                    //    {
                    //        UILineManager.PrintLine($"Congrats {Processor.Player.Name}, You survived another level of MEGA DEATH MOUNTAIN!");
                    //        UILineManager.PrintLine($"\n{Processor.Player.Name} stats:");
                    //        UILineManager.PrintLine($"Health: {Processor.Player.CurrentHealth}");
                    //        UILineManager.PrintLine($"Energy: {Processor.Player.CurrentEnergy}");
                    //        Processor.Player.makeCamp();
                    //        UILineManager.waitForEnter();
                    //        Processor.Player.level();
                    //        UILineManager.waitForEnter();
                    //    }
                    //    else
                    //    {
                    //        UILineManager.PrintLine("You had a good run, maybe next time you'll conquer MEGA DEATH MOUNTAIN!");
                    //        UILineManager.waitForEnter();
                    //        break;
                    //    }
                    levels++;
                }

                //UILineManager.ClearScreen();
                //UILineManager.PrintLine("Thanks for playing");
            });
        }

        //public void CreateGrid(object sender, EventArgs e)
        //{
        //    Button newButton = new Button();
        //    this.Controls.Add(newButton);
        //    newButton.Text = "Created Button";
        //    newButton.Location = new Point(70, 70);
        //    newButton.Size = new Size(50, 100);
        //    newButton.Location = new Point(20, 50);
        //}
    }
}
