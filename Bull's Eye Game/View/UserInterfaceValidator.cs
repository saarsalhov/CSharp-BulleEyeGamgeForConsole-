using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsEyeGame.View
{
    public class UserInterfaceValidator
    {
        public static int IsNumberInRange()
        {
            int numberOfAttempts = 0;
            bool isNumber = int.TryParse(Console.ReadLine(), out numberOfAttempts);

            while (!isNumber || (numberOfAttempts > 10 || numberOfAttempts < 4))
            {
                if (!isNumber)
                {
                    Console.WriteLine("You didn't chose a number, please try again.");
                    isNumber = int.TryParse(Console.ReadLine(), out numberOfAttempts);
                }
                else if (numberOfAttempts > 10 || numberOfAttempts < 4)
                {
                    Console.WriteLine("You didn't chose a number between 4 to 10 , please try again.");
                    isNumber = int.TryParse(Console.ReadLine(), out numberOfAttempts);
                }
            }

            return numberOfAttempts;
        }

        private static bool checkValidUserGuess(string i_UserGuess)
        {
            if(i_UserGuess.Length < 4)
            {
                Console.WriteLine("You entered less then 4 characters.");
            }
            else if(i_UserGuess.Length > 4)
            {
                Console.WriteLine("You entered more then 4 characters.");
            }

            return (i_UserGuess.Length == 4) && isPinInRange(i_UserGuess);
        }

        private static bool allCharactersAppearOnlyOnce(string i_NewPin)
        {
            bool charactersAppearOnlyOnce = true;

            for (int i = 0; i < i_NewPin.Length; i++)
            {
                for (int j = i + 1; j < i_NewPin.Length; j++)
                {
                    if (i_NewPin[i] == i_NewPin[j])
                    {
                        charactersAppearOnlyOnce = false;
                        break;
                    }
                }
            }

            if(charactersAppearOnlyOnce == false)
            {
                Console.WriteLine("You entered duplicated letter...");
            }

            return charactersAppearOnlyOnce;
        }

        public static string PlayNewGameValidation(string i_UserChoose)
        {
            while (i_UserChoose != "Y" && i_UserChoose != "N")
            {
                Console.WriteLine("You insert wrong option!");
                Console.WriteLine("Would you like to start a new game? (Y/N)");

                i_UserChoose = Console.ReadLine();
            }

            return i_UserChoose;
        }

        public static string IsValidPin(string i_UserPin, ref bool io_QuitTheGame)
        {
            while (!checkValidUserGuess(i_UserPin) || !allCharactersAppearOnlyOnce(i_UserPin))
            {
                Console.WriteLine("You entered wrong pin, Please try again!");
                Console.WriteLine("Guess <A B C D E F G H> - 4 different characters with no spaces or 'Q' to quit");

                i_UserPin = Console.ReadLine();
                if(i_UserPin == "Q")
                {
                    io_QuitTheGame = true;
                    break;
                }
            }

            return i_UserPin;
        }

        private static bool isPinInRange(string i_UserPin)
        {
            bool isInRange = true;

            foreach(char letter in i_UserPin)
            {
                if(letter > 'H' || letter < 'A')
                {
                    isInRange = false;
                    break;
                }
            }

            if(isInRange == false)
            {
                Console.WriteLine("You entered out of the range letter...");
            }

            return isInRange;
        }
    }
}
