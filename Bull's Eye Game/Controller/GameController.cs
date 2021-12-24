using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsEyeGame.Model;

namespace BullsEyeGame.Controller
{
    public class GameController
    {
        private readonly BullsEyeLogic r_Game;

        public GameController()
        {
            this.r_Game = new BullsEyeLogic();
        }

        public int NumOfAttempts
        {
            get
            {
                return this.r_Game.NumOfLines;
            }

            set
            {
                this.r_Game.NumOfLines = value;
            }
        }

        public string RandomKey
        {
            get
            {
                return this.r_Game.RandomKey;
            }
        }

        public int CurrentAttempt
        {
            get
            {
                return r_Game.CurrentAttempt;
            }
        }

        public string[] Pins
        {
            get
            {
                return this.r_Game.Pins;
            }
        }

        public string[] Result
        {
            get
            {
                return this.r_Game.Result;
            }
        }

        public void SendRequestToTheModel(string i_Pin)
        {
            r_Game.PlayMove(i_Pin);
        }

        public bool IsWin()
        {
            return r_Game.ResultOfTheGame.IsWin;
        }

        public bool IsLose()
        {
            return r_Game.ResultOfTheGame.IsLose;
        }
    }
}
