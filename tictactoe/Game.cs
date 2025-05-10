using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tic_tac_toe;

namespace tic_tac_toe
{
    public abstract class Game
    {
        public abstract void Initialise(Board board);
        public abstract void Start();


    }
}
