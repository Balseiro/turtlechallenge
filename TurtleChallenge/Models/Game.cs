using System.Collections.Generic;

namespace TurtleChallenge.Models
{
    public class Game
    {
        public GameSettings Gs { get; }

        public Game(GameSettings gs)
        {
            Gs = gs;
        }

        public string Start(List<Move> moves)
        {
            foreach(var m in moves)
            {
                if(m.MoveType == "rotate")
                {
                    Rotate();
                }
                if(m.MoveType == "forward")
                {
                    if (CanMoveForward())
                    {
                        MoveForward();

                        if (MineHit()) return "Mine Hit !";
                        if (IsFinishTile()) return "Success";
                    }
                    else
                    {
                        return "Invalid move, can't move forward";
                    }
                }
            }

            return "Still in danger !";
        }

        public void Rotate()
        {
            switch(Gs.StartingDirection){
                case "north":
                    Gs.StartingDirection = "east";
                    break;
                case "east":
                    Gs.StartingDirection = "south";
                    break;
                case "south":
                    Gs.StartingDirection = "west";
                    break;
                case "west":
                    Gs.StartingDirection = "north";
                    break;
            }
        }

        public bool CanMoveForward()
        {
            switch (Gs.StartingDirection)
            {
                case "north":
                    return Gs.StartingY > 0;
                case "east":
                    return Gs.StartingX < (Gs.NumCols - 1);
                case "south":
                    return Gs.StartingY < (Gs.NumRows - 1);
                case "west":
                    return Gs.StartingX > 0;
            }

            return true;
        }

        public void MoveForward()
        {
            switch (Gs.StartingDirection)
            {
                case "north":
                    Gs.StartingY--;
                    break;
                case "east":
                    Gs.StartingX++;
                    break;
                case "south":
                    Gs.StartingY++;
                    break;
                case "west":
                    Gs.StartingX--;
                    break;
            }
        }

        public bool MineHit()
        {
            foreach(var b in Gs.Bombs)
            {
                if (b.X == Gs.StartingX && b.Y == Gs.StartingY) return true;
            }

            return false;
        }

        public bool IsFinishTile()
        {
            if (Gs.StartingX == Gs.ExitX && Gs.StartingY == Gs.ExitY) return true;
            
            return false;
        }
    }
}
