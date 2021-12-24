using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsEyeGame.Model
{
     public class BullsEyeLogic
    {
        private readonly string r_RandomKey;
        private readonly BullsEyeResultHandler r_ResultOfTheGame;
        private bool m_QuitGame;
        private string[] m_Pins;
        private string[] m_Result;
        private int m_NumOfLines;
        private int m_NumberOfCurrentAttempt;

        public BullsEyeLogic()
        {
            NumOfLines = 4;
            CurrentAttempt = -1;
            QuitGame = false;
            this.r_ResultOfTheGame = new BullsEyeResultHandler();
            this.r_RandomKey = chooseRandomKey();
            Pins = new string[NumOfLines];
            Result = new string[NumOfLines];
        }

        public BullsEyeLogic(int i_NumOfAttemptsInOneGame)
        {
            NumOfLines = i_NumOfAttemptsInOneGame;
            CurrentAttempt = -1;
            QuitGame = false;
            this.r_ResultOfTheGame = new BullsEyeResultHandler();
            this.r_RandomKey = chooseRandomKey();
            Pins = new string[i_NumOfAttemptsInOneGame];
            Result = new string[i_NumOfAttemptsInOneGame];
        }

        private static string chooseRandomKey()
        {
            Random rand = new Random();
            char[] chosenKey = new char[4];
            char[] bucketOfLetters = new char[8] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            for (int i = 0; i < 4; i++)
            {
                int currentRandomIndex = rand.Next(bucketOfLetters.Length);

                if (chosenKey.Contains(bucketOfLetters[currentRandomIndex]) == false)
                {
                    chosenKey[i] = bucketOfLetters[currentRandomIndex];
                }
                else
                {
                    i--;
                    continue;
                }
            }

            return new string(chosenKey);
        }

        private static void resultFixLeft(ref string io_Result)
        {
            int countCorrectV = 0;
            int countCorrectX = 0;
            StringBuilder fixedResult = new StringBuilder();

            foreach (char letter in io_Result)
            {
                if (letter == 'X')
                {
                    countCorrectX++;
                }
                else if (letter == 'V')
                {
                    countCorrectV++;
                }
            }

            for (int i = 0; i < countCorrectV; i++)
            {
                fixedResult.Append('V');
            }

            for (int i = 0; i < countCorrectX; i++)
            {
                fixedResult.Append('X');
            }

            io_Result = fixedResult.ToString();
        }

        public bool QuitGame
        {
            get
            {
                return this.m_QuitGame;
            }

            set
            {
                this.m_QuitGame = value;
            }
        }

        public string RandomKey
        {
            get
            {
                return r_RandomKey;
            }
        }

        public string[] Pins
        {
            get
            {
                return this.m_Pins;
            }

            set
            {
                this.m_Pins = value;
            }
        }

        public string[] Result
        {
            get
            {
                return this.m_Result;
            }

            set
            {
                this.m_Result = value;
            }
        }

        public int NumOfLines
        {
            get
            {
                return m_NumOfLines;
            }

            set
            {
                if(!BullsEyeValidator.ValidNumberOfLines(value))
                {
                    return;
                }

                m_NumOfLines = value;
                Pins = new string[NumOfLines];
                Result = new string[NumOfLines];
            }
        }

        public int CurrentAttempt
        {
            get
            {
                return m_NumberOfCurrentAttempt;
            }

            set
            {
                m_NumberOfCurrentAttempt = value;
            }
        }

        public BullsEyeResultHandler ResultOfTheGame
        {
            get
            {
                return r_ResultOfTheGame;
            }
        }

        private bool addNewPin(string i_NewPin)
        {
            bool initializationRight = true;

            if (!BullsEyeValidator.ValidPin(i_NewPin))
            {
                initializationRight = false;
            }

            CurrentAttempt++;
            Pins[CurrentAttempt] = i_NewPin;

            return initializationRight;
        }

        private void addNewResult(string i_NewPin)
        {
            Result[CurrentAttempt] = calculateResult(i_NewPin);
        }

        public void PlayMove(string i_NewPin)
        {
            if (addNewPin(i_NewPin))
            {
                addNewResult(this.m_Pins[CurrentAttempt]);
            }

            ResultOfTheGame.YouLose(Result[CurrentAttempt], CurrentAttempt, NumOfLines);
            ResultOfTheGame.YouWinner(Result[CurrentAttempt]);
        }

        private string calculateResult(string i_NewPin)
        {
            string feedBack = null;
            char[] result = new char[4];

            for (int i = 0; i < i_NewPin.Length; i++)
            {
                for (int j = 0; j < RandomKey.Length; j++)
                {
                    if(i_NewPin[i] == RandomKey[j])
                    {
                        if(i == j)
                        {
                            result[i] = 'V';
                        }
                        else
                        {
                            result[i] = 'X';
                        }
                    }
                }
            }

            feedBack = new string(result);
            resultFixLeft(ref feedBack);

            return feedBack;
        }
    }
}
