using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public static class GameMode
    {
        public enum Type
        {
            player,
            bot
        }

        public static Type? CurrentGame;
    }
}
