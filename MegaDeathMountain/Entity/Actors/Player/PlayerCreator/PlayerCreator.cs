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
        private static ConsoleKey ClassChoice;

        private static void RequestName(ILogger logger)
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

        private static void RequestClass()
        {
            UILineManager.ClearScreen();
            UILineManager.SkipLine(4);
            UILineManager.PrintLine("What Class Will You Choose: ");
            UILineManager.PrintLine("1 : Knight");
            UILineManager.PrintLine("2 : Beast");
            UILineManager.PrintLine("3 : Priest");

            PlayerCreator.ClassChoice =  UILineManager.waitForKeys(new ConsoleKey[]
            {
                ConsoleKey.D1,
                ConsoleKey.D2,
                ConsoleKey.D3
            });

            return;
        }

        public static Player BuildPlayer(ILogger logger)
        {

            PlayerCreator.RequestName(logger);
            PlayerCreator.RequestClass();

            switch(ClassChoice)
            {
                case ConsoleKey.D1:
                    return new Knight(PlayerName, logger);
                case ConsoleKey.D2:
                    return new Beast(PlayerName, logger);
                case ConsoleKey.D3:
                    return new Priest(PlayerName, logger);
                default:
                    logger.logException("Exception assigning player Class.", new ArgumentException());
                    throw new ArgumentException();
            }
        }
    }
}
