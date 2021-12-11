using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaDeathMountain;
using System.Windows.Forms;

namespace MegaDeathMountainShared
{
    class FormBattle
    {
        private static bool ContinueBattle = true;
        public static BattleOptions UserSelection;

        public void SetBattleOption(BattleOptions userSelection) => UserSelection = userSelection;

        private static bool ContinueBattleCheck(Actor enemy) =>  (Processor.Player.CurrentHealth > 0 && enemy.CurrentHealth > 0);

        private static void DrawBattleCanvas(Game game, Actor enemy)
        {
            UpdateBattleCanvas(game, enemy);
            game.BattleWindowEnemyPictureBox.ImageLocation = Game.ConvertConsoleSymbolToFormsGraphic(enemy.LayoutGraphic.Symbol).imageLocation;
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.BattlePanel, true });
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.BattleFieldCanvas, false });
        }

        private static void CloseBattleCanvas(Game game)
        {
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.BattleFieldCanvas, true });
            game.Invoke(Game.PanelVisibilityDelegate, new object[] { game.BattlePanel, false });
            
        }

        private static void UpdateBattleCanvas(Game game, Actor enemy)
        {
            game.Invoke(Game.SetLabelValueDelegate, new object[] { game.BattleWindowPlayerHealth, Processor.Player.CurrentHealth.ToString() });
            game.Invoke(Game.SetLabelValueDelegate, new object[] { game.BattleWindowPlayerEnergy, Processor.Player.CurrentEnergy.ToString() });
            game.Invoke(Game.SetLabelValueDelegate, new object[] { game.BattleWindowEnemyHealth, enemy.CurrentHealth.ToString() });
        }

        public static void Battle(Game game, Enemy enemy)
        {
            string EnemyAttackMessage;
            DrawBattleCanvas(game, enemy);
            while (ContinueBattle)
            {
                if (UserSelection != 0)
                {
                    switch (UserSelection)
                    {
                        case BattleOptions.Attack:
                            MessageBox.Show($"{Processor.Player.Name}{Dialogue.Instance.getRandomAttackMsg()}");
                            MessageBox.Show(Processor.Player.PlayerFormAttack(enemy));
                            break;
                        case BattleOptions.Defend:
                            Processor.Player.Defend();
                            MessageBox.Show(Processor.Player.Name + Dialogue.Instance.getRandomDefendMsg());
                            break;
                        case BattleOptions.Special:
                            MessageBox.Show(Processor.Player.specialAttack(enemy));
                            break;
                    }
                    UserSelection = 0;
                    UpdateBattleCanvas(game, enemy);

                    if (enemy.CurrentHealth > 0)
                    {
                        if (enemy.ChargingSpecialAttack == false)
                        {
                            EnemyAttackMessage = enemy.attack(Processor.Player, Dialogue.Instance.getRandomAttackMsg());
                            if (enemy.ChargingSpecialAttack == true)
                            {
                                MessageBox.Show($"{enemy.Name}{" Begins charging for a powerful attack"}");
                            }
                            else
                            {
                                MessageBox.Show(EnemyAttackMessage);
                            }
                        }
                        else
                        {
                            MessageBox.Show(enemy.specialAttack(Processor.Player));
                            enemy.ChargingSpecialAttack = false;
                        }
                        UpdateBattleCanvas(game, enemy);
                    }

                    ContinueBattle = ContinueBattleCheck(enemy);
                }
            }
            ContinueBattle = true;
            CloseBattleCanvas(game);
        }

        public enum BattleOptions
        {
            Undefined,
            Attack,
            Defend,
            Special
        }
    }
}
