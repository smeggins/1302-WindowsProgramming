using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public static class PlayerCreator
    {
        private static string PlayerName;
        private static PlayerClass ClassChoice;

        public static string GetValueString()
        {
            return $"PlayerName: {PlayerName}, ClassChoice: {ClassChoice}";
        }
        public static void RequestName(ILogger logger)
        {
            UILineManager.ClearScreen();
            UILineManager.SkipLine(4);
            UILineManager.PrintChars("What is your Name Brave Adventurer: ");
            string returnName;
            try
            {
                returnName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                logger.logException("Exception assigning player name.", ex);
                throw new ArgumentException();
            }

            PlayerCreator.PlayerName = returnName;
            return;
        }

        private static void ConsoleClassConversion(ConsoleKey key, ILogger logger)
        {
            switch (key)
            {
                case (ConsoleKey.D1):
                    ClassChoice = PlayerClass.Knight;
                    break;
                case (ConsoleKey.D2):
                    ClassChoice = PlayerClass.Beast;
                    break;
                case (ConsoleKey.D3):
                    ClassChoice = PlayerClass.Priest;
                    break;
                default:
                    logger.logException("Exception assigning player Class.", new ArgumentException());
                    throw new ArgumentException();
            }
        }

        public static void RequestClass(ILogger logger)
        {
            UILineManager.ClearScreen();
            UILineManager.SkipLine(4);
            UILineManager.PrintLine("What Class Will You Choose: ");
            UILineManager.PrintLine("1 : Knight");
            UILineManager.PrintLine("2 : Beast");
            UILineManager.PrintLine("3 : Priest");

            ConsoleClassConversion(UILineManager.waitForKeys(new ConsoleKey[]
            {
                ConsoleKey.D1,
                ConsoleKey.D2,
                ConsoleKey.D3
            }), logger);

            return;
        }

        public static void SetName(string name)
        {
            PlayerName = name;
        }

        public static void SetClass(PlayerClass playerClass)
        {
            ClassChoice = playerClass;
        }

        public static bool ReadyToBuild()
        {
            return (PlayerName != "" && ClassChoice != 0);
        }

        public static Player BuildPlayer(ILogger logger)
        {
            switch (ClassChoice)
            {
                case (PlayerClass.Knight):
                    return new Knight(PlayerName, logger);
                case (PlayerClass.Beast):
                    return new Beast(PlayerName, logger);
                case (PlayerClass.Priest):
                    return new Priest(PlayerName, logger);
                default:
                    logger.logException("Exception assigning player Class.", new ArgumentException());
                    throw new ArgumentException();
            }
        }
    }
}
