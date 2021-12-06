using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaDeathMountain;
using System.Windows.Forms;

namespace MegaDeathMountainShared
{
    public class FormsKeyLogger : IKeyLogger
    {
        private ConsoleKey key;
        public ConsoleKey Key { get { return key; } set { key = value; } }

        public void Game_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show($"in keydown: {e.KeyCode}");
            KeyEvents.ExitGameCheck(ConvertKey(e.KeyCode));
            UpdateKeyAsync(ConvertKey(e.KeyCode));
        }

        public ConsoleKey ConvertKey(Keys formKey)
        {
            switch (formKey)
            {
                case Keys.Enter:
                    return ConsoleKey.Enter;
                case Keys.Escape:
                    return ConsoleKey.Escape;
                case Keys.Up:
                    return ConsoleKey.UpArrow;
                case Keys.Down:
                    return ConsoleKey.DownArrow;
                case Keys.Left:
                    return ConsoleKey.LeftArrow;
                case Keys.Right:
                    return ConsoleKey.RightArrow;
                default:
                    return ConsoleKey.F19;
            }
        }

        public static ConsoleKey waitForKeys(ConsoleKey[] consoleKey)
        {
            Processor.keyLogger.ClearKey();
            while (true)
            {
                if (consoleKey.Contains(Processor.keyLogger.Key))
                {
                    return Processor.keyLogger.Key;
                }
            }
        }

        public void CheckForCriticalTasks()
        {
            throw new NotImplementedException();
        }

        public void UpdateKeyAsync(ConsoleKey key = ConsoleKey.F19)
        {
            this.Key = key;
        }
    }
}
