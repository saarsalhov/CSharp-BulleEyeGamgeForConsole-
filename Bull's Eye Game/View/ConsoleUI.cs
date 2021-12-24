using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsEyeGame.Controller;
using Ex02.ConsoleUtils;

namespace BullsEyeGame.View
{
    public class ConsoleUi
    {
        private GameController m_Manager;

        public ConsoleUi()
        {
            this.m_Manager = new GameController();
        }

        private GameController manager
        {
            get
            {
                return this.m_Manager;
            }

            set
            {
                this.m_Manager = value;
            }
        }

        private void buildGameBoard(bool i_YouLose, string i_RandomKey)
        {
            string randomKeyView = null;

            if (!i_YouLose)
            {
                randomKeyView = " # # # # ";
            }
            else
            {
                randomKeyView = pinWithSpacesReadyToPrint(i_RandomKey);
            }

            Console.WriteLine("|Pins:    |Result:|");
            Console.WriteLine("|=========|=======|");
            Console.WriteLine("|{0}|       |", randomKeyView);
            Console.WriteLine("|=========|=======|");
            for (int i = 0; i < this.manager.NumOfAttempts; i++)
            {
                Console.WriteLine("|" + pinWithSpacesReadyToPrint(this.manager.Pins[i]) + "|" + resultWithSpacesReadyToPrint(this.manager.Result[i]) + "|");
                Console.WriteLine("|=========|=======|");
            }
        }

        private string pinWithSpacesReadyToPrint(string i_Pin)
        {
            int indexOfPinsChars = 0;
            char[] pinReadyForPrint = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            string finalString = null;

            if (i_Pin != null)
            {
                for (int i = 1; i < 9; i += 2)
                {
                    pinReadyForPrint[i] = i_Pin[indexOfPinsChars++];
                }
            }

            finalString = new string(pinReadyForPrint);

            return finalString;
        }

        private string resultWithSpacesReadyToPrint(string i_Result)
        {
            int indexOfResultChars = 0;
            char[] resultReadyForPrint = new char[7] { ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            string finalString = null;

            if (i_Result != null)
            {
                for (int i = 0; i < 7; i += 2)
                {
                    if(indexOfResultChars < i_Result.Length)
                    {
                        resultReadyForPrint[i] = i_Result[indexOfResultChars++];
                    }
                }
            }

            finalString = new string(resultReadyForPrint);

            return finalString;
        }

        public void StartGame()
        {
            bool quitTheGame = false;
            string startNewGame = null;
            int numberOfAttempts = 0;

            Console.WriteLine("Hello player, welcome to Bull's Eye Game.");
            Console.WriteLine("Please choose your number attempts (between 4 to 10):");
            numberOfAttempts = UserInterfaceValidator.IsNumberInRange();
            this.manager.NumOfAttempts = numberOfAttempts;
            this.buildGameBoard(this.manager.IsLose(), this.manager.RandomKey);
            bodyOfTheGame(ref quitTheGame);
            if (quitTheGame)
            {
                Console.WriteLine("Good Bye!");
            }
            else
            {
                if (this.manager.IsWin())
                {
                    Console.WriteLine("You guessed after {0} steps!", this.manager.CurrentAttempt + 1);
                }
                else if (this.manager.IsLose())
                {
                    Console.WriteLine("No more guesses allowed. You Lost.");
                }

                Console.WriteLine("Would you like to start a new game? (Y/N)");
                startNewGame = UserInterfaceValidator.PlayNewGameValidation(Console.ReadLine());
                if (startNewGame == "Y")
                {
                    Screen.Clear();
                    this.manager = new GameController();
                    StartGame();
                }
                else if (startNewGame == "N")
                {
                    Console.WriteLine("Good Bye!");
                }
            }
        }

        private void bodyOfTheGame(ref bool io_QuitTheGame)
        {
            string lastUserInput = null;

            while (!this.manager.IsLose() && io_QuitTheGame != true && !this.manager.IsWin())
            {
                Console.WriteLine("Please type your next guess <A B C D E F G H> - 4 different characters with no spaces or 'Q' to quit");
                lastUserInput = Console.ReadLine();
                io_QuitTheGame = lastUserInput == "Q";
                if (io_QuitTheGame)
                {
                    break;
                }

                lastUserInput = UserInterfaceValidator.IsValidPin(lastUserInput, ref io_QuitTheGame);
                if (io_QuitTheGame)
                {
                    break;
                }

                this.manager.SendRequestToTheModel(lastUserInput);
                Screen.Clear();
                this.buildGameBoard(manager.IsLose(), manager.RandomKey);
            }
        }
    }
}
