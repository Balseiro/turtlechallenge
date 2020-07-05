using System.Collections.Generic;

namespace TurtleChallenge.Models
{
    public class GameSettings
    {
        public GameSettings()
        {
            Bombs = new List<Bomb>();
        }

        public int NumRows { get; set; }

        public int NumCols { get; set; }

        public int StartingX { get; set; }

        public int StartingY { get; set; }

        public string StartingDirection { get; set; }

        public int ExitX { get; set; }

        public int ExitY { get; set; }

        public List<Bomb> Bombs { get; set; }
    }
}
