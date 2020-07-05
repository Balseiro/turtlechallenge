using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TurtleChallenge.Models;

namespace TurtleChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var gsJson = string.Empty;
            var movesJson = string.Empty;

            using (StreamReader sr = new StreamReader(args[0]))
            {
                gsJson = sr.ReadToEnd();
            }

            using (StreamReader sr = new StreamReader(args[1]))
            {
                movesJson = sr.ReadToEnd();
            }

            var moves = JsonConvert.DeserializeObject<List<List<Move>>>(movesJson);

            foreach(var m in moves)
            {
                var gs = JsonConvert.DeserializeObject<GameSettings>(gsJson);
                var game = new Game(gs);
                var output = game.Start(m);
                Console.WriteLine(output);
            }

            Console.ReadLine();
        }
    }
}
