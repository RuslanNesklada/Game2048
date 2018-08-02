//This game was made by me during 3.5 hours
//Idea of the game was stolen from Wikipedia :))

using System;

namespace Game2048
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            State pointCommenced = new State();
            pointCommenced.DoGame();
        }
    }
}
