using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsEyeGame.Model
{
    public class BullsEyeResultHandler
    {
        private bool m_IsWin;
        private bool m_IsLose;

        public BullsEyeResultHandler()
        {
            IsWin = false;
            IsLose = false;
        }

        public bool IsWin
        {
            get
            {
                return this.m_IsWin;
            }

            set
            {
                this.m_IsWin = value;
            }
        }

        public bool IsLose
        {
            get
            {
                return this.m_IsLose;
            }

            set
            {
                this.m_IsLose = value;
            }
        }

        public void YouWinner(string i_CurrentResult)
        {
            IsWin = i_CurrentResult == "VVVV";
        }

        public void YouLose(string i_CurrentResult, int i_CurrentAttempt, int i_NumOfLines)
        {
            IsLose = i_CurrentResult != "VVVV" && (i_CurrentAttempt + 1) == i_NumOfLines;
        }
    }
}
