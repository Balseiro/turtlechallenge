using TurtleChallenge.Models;

namespace TurtleChallenge.UnitTests
{
    public static class GameSettingsGenerator
    {
        public static GameSettings Generate(char [][] board)
        {
            var gs = new GameSettings();
            gs.NumRows = board.Length;
            gs.NumCols = board[0].Length;

            for(var i = 0; i < board.Length; ++i)
            {
                for(var j = 0; j < board.Length; ++j)
                {
                    if(board[i][j] == 'B')
                    {
                        gs.Bombs.Add(new Bomb() { Y = i, X = j });
                    }
                    else if (board[i][j] == 'X')
                    {
                        gs.ExitY = i;
                        gs.ExitX = j;
                    }
                    else if (board[i][j] == 'S')
                    {
                        gs.StartingY = i;
                        gs.StartingX = j;
                        gs.StartingDirection = "south";
                    }
                    else if (board[i][j] == 'W')
                    {
                        gs.StartingY = i;
                        gs.StartingX = j;
                        gs.StartingDirection = "west";
                    }
                    else if (board[i][j] == 'N')
                    {
                        gs.StartingY = i;
                        gs.StartingX = j;
                        gs.StartingDirection = "north";
                    }
                    else if (board[i][j] == 'E')
                    {
                        gs.StartingY = i;
                        gs.StartingX = j;
                        gs.StartingDirection = "east";
                    }
                }
            }

            return gs;
        }
    }
}
