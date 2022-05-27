using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public static class BattleUI
    {
        private static void drawEnemy(List<string> enemyImage)
        {
            if (enemyImage.Count > 0)
            {
                UILineManager.DrawEmptyMenuLine();

                for (int i = 0; i < enemyImage.Count; i++)
                {
                    UILineManager.DrawEmptyMenuLine((ConsoleColor.Red, enemyImage[i]));
                }

                UILineManager.DrawEmptyMenuLine();
            }
            
            return;
        }
        public static void drawBattle(int round, Player player, Enemy enemy)
        {
            UILineManager.DrawMenuLine();
            UILineManager.DrawMenuLine($" Round {round} ");
            UILineManager.DrawMenuLine();
            string playerhealthstring = $" {player.Name}s Health: {player.CurrentHealth} ";
            UILineManager.DrawMenuLine(new List<(ConsoleColor, string)>() { (ConsoleColor.Blue, playerhealthstring), (ConsoleColor.Red, $" {enemy.Name}s Health: {enemy.CurrentHealth} ")});
            UILineManager.DrawMenuLine(new List<(ConsoleColor, string)>() { (ConsoleColor.Blue, $" {player.Name}s Energy: {player.CurrentEnergy} "), (ConsoleColor.White, new string('*', playerhealthstring.Length)) });
            UILineManager.DrawMenuLine();                                                                                                                                  
            drawEnemy(enemy.Image());
            UILineManager.DrawMenuLine();
            UILineManager.DrawEmptyMenuLine();
            UILineManager.DrawMenuLine();
            UILineManager.DrawMenuLine(new List<(ConsoleColor, string)>() { 
                                                (ConsoleColor.White, " 1:Attack "), 
                                                (ConsoleColor.White, " 2:Defend "),
                                                ((player.CurrentEnergy == 10) ? ConsoleColor.White : ConsoleColor.DarkGray, " 3:Special ")});
            UILineManager.DrawMenuLine();

            return;
        }

        public static void DrawBattleField(IActor[][] layout)
        {
            //TODO player is registering in the opposite x and y position
            UILineManager.ClearScreen();
            UILineManager.DrawBattleFieldLine(layout.Length);
            UILineManager.SkipLine();

            for (int y = layout[0].Length - 1; y >= 0; y--)
            {
                for (int x = 0; x < layout.Length; x++)
                {
                    if (layout[x][y] == null)
                    {
                        UILineManager.DrawBattleFieldPosition();
                    }
                    else
                    {
                        UILineManager.DrawBattleFieldPosition(layout[x][y].LayoutGraphic().color, $"{layout[x][y].LayoutGraphic().symbol}");
                    }
                }
                UILineManager.PrintChars("|");
                UILineManager.SkipLine();
            }

            UILineManager.DrawBattleFieldLine(layout.Length);
            UILineManager.SkipLine(2);

            return;
        }
    }
}
