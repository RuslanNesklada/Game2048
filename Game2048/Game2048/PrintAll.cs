using System;

namespace Game2048
{
    partial class State
    {
        private void ShowBoard()
        {
            Console.SetWindowSize(50, 30);
            Console.Title = @"Game 2048. Made by Ruslan.Nesklada";
            Console.SetBufferSize(50, 30);

            string str1 = new String('-', columns * 5);
            Console.WriteLine(str1);
            PrintGameBoard();
            Console.WriteLine(str1);
            Console.WriteLine("Press 'Q' for EXIT");
            Console.WriteLine(str1);
        }
        private void PrintGameBoard()
        {

            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    if (Board[i, j] == 0) ;//This number is the most popular obviously
                    else if (Board[i, j] == 2) Console.BackgroundColor = ConsoleColor.DarkBlue;
                    else if (Board[i, j] == 4) Console.BackgroundColor = ConsoleColor.DarkGreen;
                    else if (Board[i, j] == 8) Console.BackgroundColor = ConsoleColor.DarkRed;
                    else if (Board[i, j] == 16) Console.BackgroundColor = ConsoleColor.DarkYellow;
                    else if (Board[i, j] == 32) Console.BackgroundColor = ConsoleColor.DarkCyan;
                    else if (Board[i, j] == 64) Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    else if (Board[i, j] == 128) Console.BackgroundColor = ConsoleColor.DarkGreen;
                    else Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write("{0,5}", Board[i, j]);
                    Console.ResetColor();
                }
                Console.Write(Environment.NewLine);
            }
        }

    }
}
