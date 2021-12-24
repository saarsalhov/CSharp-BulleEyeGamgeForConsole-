using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsEyeGame.Model
{
    public class BullsEyeValidator
    {
        public static bool ValidPin(string i_NewPin)
        {
            bool charactersAppearOnlyOnce = true;
            bool fourCharacters = i_NewPin.Length == 4;

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

            return charactersAppearOnlyOnce && fourCharacters;
        }

        public static bool ValidNumberOfLines(int i_NumberOfLines)
        {
            return i_NumberOfLines <= 10 && i_NumberOfLines >= 4;
        }
    }
}
