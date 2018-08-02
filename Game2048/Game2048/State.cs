using System;

namespace Game2048
{
    partial class State
    {
        public int[,] Board;
        int columns = 4;
        int rows = 4;
        public State()
        {
            Board = new int[columns, rows];
        }
       
        public void DoGame()
        {
            bool continuingEmviroment = true;
            do
            {
                ShowBoard();
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.RightArrow) MoveRight();
                else if (key.Key == ConsoleKey.LeftArrow) MoveLeft();
                else if (key.Key == ConsoleKey.UpArrow) MoveUp();
                else if (key.Key == ConsoleKey.DownArrow) MoveDown();
                else if (key.Key == ConsoleKey.Q) break;
                else 
                {
                    Console.Clear();
                    Console.WriteLine(@"Please, press another key." + Environment.NewLine +
                                      @"The allowed keys are ←, →, ↑, ↓ and 'Q' for EXIT");
                    continue;
                }
                continuingEmviroment = AddNewNumberRandomy();
                
                Console.Clear();

            } while (continuingEmviroment);
        }

        private bool AddNewNumberRandomy()
        {
            try
            {
                int countOfFreePositions = 0;
                int[,] arrayOfPossiblePositions = new int[columns, rows];
                Random factory = new Random();
                int randomPositionFoaAdding;
                countOfFreePositions = SeekFreePositions(countOfFreePositions, arrayOfPossiblePositions);
                if (countOfFreePositions == 0)
                {
                    Console.WriteLine("The end. You lose! ha-ha-ha!");
                    Console.WriteLine("Your result is: {0}", FindResult());
                    Console.ReadKey();
                    return false;
                }
                else if (countOfFreePositions != 0)
                {
                    randomPositionFoaAdding = factory.Next(1, countOfFreePositions);
                    
                    AssignNewValue(arrayOfPossiblePositions, randomPositionFoaAdding);
                }
                return true;

            }
            catch (Exception exp)
            {

                //Console.WriteLine("Exception" + exp.Source);
                return false;
            }
        }

        private int FindResult()
        {
            int result = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result += Board[i, j];
                }

            }
            return result;
        }

        private void AssignNewValue(int[,] positionsInArray, int randomPositionFoaAdding)
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (positionsInArray[i, j] == randomPositionFoaAdding)
                    {
                        Board[i, j] = PutRandomNumber();
                        return;
                    }
                }
            }
        }

        private int SeekFreePositions(int freePositions, int[,] positionsInArray)
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j <rows; j++)
                {
                    if (Board[i, j] == 0)
                    {
                        freePositions++;
                        positionsInArray[i, j] = freePositions;
                    }
                }
            }

            return freePositions;
        }
    }
}
