using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    partial class State
    {
        private int PutRandomNumber()
        {
            int numberForInserting = 2;
            Random randomFactory = new Random();
            int temp = randomFactory.Next(1000000000);
            if (temp > 909090909) numberForInserting = numberForInserting << 1;
            return numberForInserting;
        }
    }
}
