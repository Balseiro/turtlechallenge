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

            if (args.Length != 2)
            {
                Console.WriteLine("2 file names are required to run this: One for settings and another for moves");
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    gsJson = sr.ReadToEnd();
                }

                using (StreamReader sr = new StreamReader(args[1]))
                {
                    movesJson = sr.ReadToEnd();
                }

                var moves = JsonConvert.DeserializeObject<List<List<Move>>>(movesJson);

                foreach (var m in moves)
                {
                    var gs = JsonConvert.DeserializeObject<GameSettings>(gsJson);
                    var game = new Game(gs);
                    var output = game.Start(m);
                    Console.WriteLine(output);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
