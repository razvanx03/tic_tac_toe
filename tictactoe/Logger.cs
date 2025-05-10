using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public class Logger : ILogger
    {
        private List<string> movesLog = new List<string>();
        private const string LogFilePath = "game_history.txt";

        public void LogMove(PieceType player, Coordinate coordinate)
        {
            movesLog.Add($"{DateTime.Now}: Player {player} moved to ({coordinate.X}, {coordinate.Y})");
        }

        public void SaveLog()
        {
            File.WriteAllLines(LogFilePath, movesLog);
        }

        public void ClearLog()
        {
            movesLog.Clear();
            if (File.Exists(LogFilePath))
            {
                File.Delete(LogFilePath);
            }
        }
    }
}
