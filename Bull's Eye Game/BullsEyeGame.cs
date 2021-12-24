using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsEyeGame.View;

namespace BullsEyeGame
{
    public class BullsEyeGame
    {
        public static void Main()
        {
            startGame();
        }

        private static void startGame()
        {
            ConsoleUi newGame = new ConsoleUi();
            newGame.StartGame();
        }
    }
}
