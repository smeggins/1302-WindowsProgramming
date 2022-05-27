using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public static class UILineManager
    {
        public readonly static int DisplayWidth = 87;

        public static void PrintChars(string msg)
        {
            Console.Write(msg);
        }

        public static void PrintLine(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void ChangeConsoleTextColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        public static void ChangeConsoleTextColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void clearConsoleBuffer()
        {
            Processor.keyLogger.ClearKey();
            while (Console.KeyAvailable)
                Console.ReadKey(false);
        }

        public static void waitForEnter(string message = "")
        {
            UILineManager.PrintLine($"{message}\nPress Enter To Continue:");
            Processor.keyLogger.ClearKey();
            while (true)
            {
                UILineManager.PrintChars("");

                if (Processor.keyLogger.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        public static void waitForKey(ConsoleKey consoleKey)
        {
            Processor.keyLogger.ClearKey();
            while (true)
            {
                if (Processor.keyLogger.Key == consoleKey)
                {
                    break;
                }
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

        public static void SkipLine(int numberOfLines = 1)
        {
            if (numberOfLines <= 1)
            {
                Console.Write("\n");
            }
            else
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    Console.Write("\n");
                }
            }

            return;
        }

        public static void ClearScreen()
        {
            Console.Clear();
            clearConsoleBuffer();
        }

        private static void AppendAstrix(StringBuilder builder, int numberOfTimesToAppend)
        {
        
            builder.Append(new String('*', numberOfTimesToAppend));
        }

        public static void DrawEmptyMenuLine()
        {
            UILineManager.PrintChars("*");

            for (int i = 0; i < (DisplayWidth - 2); i++)
            {
                UILineManager.PrintChars(" ");
            }
            UILineManager.PrintChars("*");

            UILineManager.SkipLine();

            return;
        }

        public static void DrawEmptyMenuLine((ConsoleColor color, string text) textWithColor)
        {
            int TextLength = textWithColor.text.Length;
            if (TextLength > 0)
            {
                StringBuilder Builder = new StringBuilder();
                int FillerSymbols = DisplayWidth;

                FillerSymbols = FillerSymbols - TextLength;

                UILineManager.PrintChars("*");

                for (int i = 0; i < (((DisplayWidth - TextLength) / 2) - 1 ); i++)
                {
                    Builder.Append(" ");
                }
                UILineManager.PrintChars(Builder.ToString());

                UILineManager.ChangeConsoleTextColor(textWithColor.color);
                UILineManager.PrintChars(textWithColor.text);
                UILineManager.ChangeConsoleTextColor();

                // if there would be a remainder one side needs to have an extra astrix
                if (FillerSymbols % 2 == 0)
                {
                    UILineManager.PrintChars(Builder.ToString());
                }
                else
                {
                    UILineManager.PrintChars(Builder.ToString());
                    UILineManager.PrintChars(" ");
                }
                UILineManager.PrintLine("*");
            }
            else
            {
                DrawEmptyMenuLine();
            }

            return;
        }

        public static void DrawMenuLine()
        {
            
            for (int i = 0; i < DisplayWidth; i++)
            {
                UILineManager.PrintChars("*");
            }

            UILineManager.SkipLine();

            return;
        }

        public static void DrawMenuLine(string text)
        {
            if (text.Length > 0)
            {
                StringBuilder Builder = new StringBuilder();
                int FillerSymbols = DisplayWidth;

                FillerSymbols = FillerSymbols - text.Length;

                AppendAstrix(Builder, ((FillerSymbols / 2)));

                Builder.Append(text);

                // if there would be a remainder one side needs to have an extra astrix
                if (FillerSymbols % 2 == 0)
                {
                    AppendAstrix(Builder, ((FillerSymbols / 2)));
                }
                else
                {
                    AppendAstrix(Builder, ((FillerSymbols / 2) + 1));
                }

                UILineManager.PrintLine($"{Builder.ToString()}");
            }
            else
            {
                for (int i = 0; i < DisplayWidth; i++)
                {
                    UILineManager.PrintChars("*");
                }

                UILineManager.SkipLine();
            }

            return;
        }

        public static void DrawMenuLine((ConsoleColor color, string text) textWithColor)
        {
            int TextLength = textWithColor.text.Length;
            if (TextLength > 0)
            {
                StringBuilder Builder = new StringBuilder();
                int FillerSymbols = DisplayWidth;

                FillerSymbols = FillerSymbols - TextLength;

                AppendAstrix(Builder, ((FillerSymbols / 2)));
                UILineManager.PrintChars(Builder.ToString());

                UILineManager.ChangeConsoleTextColor(textWithColor.color);
                UILineManager.PrintChars(textWithColor.text);
                UILineManager.ChangeConsoleTextColor();

                // if there would be a remainder one side needs to have an extra astrix
                if (FillerSymbols % 2 == 0)
                {
                    UILineManager.PrintLine(Builder.ToString());
                }
                else
                {
                    UILineManager.PrintChars(Builder.ToString());
                    UILineManager.PrintLine("*");
                }
            }
            else
            {
                for (int i = 0; i < DisplayWidth; i++)
                {
                    UILineManager.PrintChars("*");
                }
                UILineManager.SkipLine();
            }

            return;
        }

        public static void DrawMenuLine(List<string> text)
        {
            int AsterixGroups = text.Count + 1;
            if (AsterixGroups > 1)
            {
                StringBuilder Builder = new StringBuilder();
                int FillerSymbols = DisplayWidth;

                foreach (var t in text)
                {
                    FillerSymbols -= t.Length;
                }

                foreach (var t in text)
                {
                    AppendAstrix(Builder, (FillerSymbols / (AsterixGroups)));
                    Builder.Append(t);
                }
                AppendAstrix(Builder, (FillerSymbols / (AsterixGroups)));

                // if there would be a remainder one side needs to have an extra astrix
                int ExtraAsterix = FillerSymbols - (FillerSymbols / (AsterixGroups)) * (AsterixGroups);
                if (ExtraAsterix != 0)
                {
                    AppendAstrix(Builder, ExtraAsterix);
                }

                UILineManager.PrintLine($"{Builder.ToString()}");
            }
            else
            {
                for (int i = 0; i < DisplayWidth; i++)
                {
                    UILineManager.PrintChars("*");
                }

                UILineManager.SkipLine();
            }

            return;
        }

        public static void DrawMenuLine(List<(ConsoleColor color, string text)> textWithColor)
        {
            int AsterixGroups = textWithColor.Count + 1;
            if (AsterixGroups > 1)
            {
                StringBuilder Builder = new StringBuilder();
                int FillerSymbols = DisplayWidth;

                foreach (var t in textWithColor)
                {
                    FillerSymbols -= t.text.Length;
                }

                AppendAstrix(Builder, (FillerSymbols / AsterixGroups));

                foreach (var t in textWithColor)
                {
                    UILineManager.PrintChars(Builder.ToString());
                    UILineManager.ChangeConsoleTextColor(t.color);
                    UILineManager.PrintChars(t.text);
                    UILineManager.ChangeConsoleTextColor();
                }

                // if there would be a remainder one side needs to have an extra astrix
                int ExtraAsterix = FillerSymbols - (FillerSymbols / (AsterixGroups)) * (AsterixGroups);
                if (ExtraAsterix != 0)
                {
                    AppendAstrix(Builder, ExtraAsterix);
                    UILineManager.PrintChars(Builder.ToString());
                }
                else
                {
                    UILineManager.PrintChars(Builder.ToString());
                }
                UILineManager.SkipLine();

            }
            else
            {
                for (int i = 0; i < DisplayWidth; i++)
                {
                    UILineManager.PrintChars("*");
                }

                UILineManager.SkipLine();
            }

            return;
        }

        public static void DrawBattleFieldLine (int layoutRowLength)
        {
            UILineManager.PrintChars("|");
            for (int i = 0; i < ((layoutRowLength * 2) - 1); i++)
            {
                UILineManager.PrintChars("-");
            }
            UILineManager.PrintChars("|");
        }
        public static void DrawBattleFieldPosition(ConsoleColor color = ConsoleColor.White, string symbol = " ")
        {
            UILineManager.PrintChars("|");
            UILineManager.ChangeConsoleTextColor(color);
            UILineManager.PrintChars(symbol);
            UILineManager.ChangeConsoleTextColor();
        }
    }
}
