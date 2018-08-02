using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    partial class State
    {

        #region MovingWithKeyBoard
        public void MoveDown()
        {
            for (int i = 0; i < columns; i++)
            {
                ArrangeBoard(i, rows, "down");

                for (int j = 0; j < rows - 1; j++)
                {
                    Summation(ref Board[i, j], ref Board[i, j + 1]);
                }
                ArrangeBoard(i, rows, "down");

            }
        }
        public void MoveUp()
        {
            for (int i = 0; i < columns; i++)
            {
                ArrangeBoard(i, rows, "up");

                for (int j = rows - 1; j > 0; j--)
                {
                    Summation(ref Board[i, j], ref Board[i, j - 1]);
                }
                ArrangeBoard(i, rows, "up");

            }
        }
        public void MoveLeft()
        {
            for (int j = 0; j < rows; j++)
            {
                ArrangeBoard(columns, j, "left");

                for (int i = columns - 1; i >0 ; i--)
                {
                    Summation(ref Board[i , j], ref Board[i-1, j]);
                }
                ArrangeBoard(columns, j, "left");

            }

        }
        public void MoveRight()
        {
            for (int j = 0; j < rows; j++)
            {
                ArrangeBoard(columns, j, "right");

                for (int i = columns - 1; i > 0; i--)
                {
                    Summation(ref Board[i - 1, j], ref Board[i, j]);
                }
                ArrangeBoard(columns, j, "right");

            }
        }
        private void Summation(ref int Entry1, ref int Entry2)
        {

            if (Entry1 == Entry2) { Entry2 += Entry1; Entry1 = 0; }
        }
        private void ArrangeBoard(int iColumn, int iRow, string direction)
        {
            bool temp;
            switch (direction)
            {
                case ("down"):
                    {
                        for (int j = iRow - 1; j > 0; j--)
                        {
                            temp = Change2Places(ref Board[iColumn, j - 1], ref Board[iColumn, j]);
                            if (temp)
                            {
                                bool situation = true;
                                for (int jTemp = j; situation & jTemp < iRow - 1; jTemp++)
                                {
                                    situation = Change2Places(ref Board[iColumn, jTemp], ref Board[iColumn, jTemp + 1]);
                                }
                            }
                        }
                        break;
                    }
                case ("up"):
                    {
                        for (int j = 0; j < rows - 1; j++)
                        {
                            temp = Change2Places(ref Board[iColumn, j + 1], ref Board[iColumn, j]);
                            if (temp)
                            {
                                bool situation = true;
                                for (int jTemp = j; situation & jTemp > 0; jTemp--)
                                {
                                    situation = Change2Places(ref Board[iColumn, jTemp], ref Board[iColumn, jTemp - 1]);
                                }
                            }
                        }
                        break;
                    }
                case ("right"):
                    {
                        for (int i = iColumn - 1; i > 0; i--)
                        {
                            temp = Change2Places(ref Board[i - 1, iRow], ref Board[i, iRow]);
                            if (temp)
                            {
                                bool situation = true;
                                for (int iTemp = i; situation & iTemp < iColumn - 1; iTemp++)
                                {
                                    situation = Change2Places(ref Board[iTemp, iRow], ref Board[iTemp + 1, iRow]);
                                }
                            }
                        }
                        break;
                    }
                case ("left"):
                    {
                        for (int i = 0; i < iColumn - 1; i++)
                        {
                            temp = Change2Places(ref Board[i + 1, iRow], ref Board[i, iRow]);
                            if (temp)
                            {
                                bool situation = true;
                                for (int iTemp = i; situation & iTemp > 0; iTemp--)
                                {
                                    situation = Change2Places(ref Board[iTemp, iRow], ref Board[iTemp -1 , iRow]);
                                }
                            }
                        }
                        break;
                    }
            }
        }
        private bool Change2Places(ref int Entry1, ref int Entry2)
        {
            if (Entry2 == 0 & Entry1 != 0)
            {
                Entry2 = Entry1;
                Entry1 = 0;
                return true;
            }
            return false;
        }
        #endregion

    }
}
