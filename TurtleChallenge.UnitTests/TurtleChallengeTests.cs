using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TurtleChallenge.Models;

namespace TurtleChallenge.UnitTests
{
    [TestClass]
    public class TurtleChallengeTests
    {

        [TestMethod]
        public void Success_MoveForward()
        {
            var board = new char[5][] {
                new char[]{ ' ', ' ', ' ', ' ', 'S' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ',  'B', 'X' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' }
            };

            var gs = GameSettingsGenerator.Generate(board);
            var game = new Game(gs);
            var moves = new List<Move>() { new Move() { MoveType = "forward" }, new Move() { MoveType = "forward" } };
            var res = game.Start(moves);

            Assert.AreEqual(res, "Success");
        }

        [TestMethod]
        public void Success_Rotate_MoveForward()
        {
            var board = new char[5][] {
                new char[]{ ' ', ' ', ' ', 'E', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ',  'B', 'X' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' }
            };

            var gs = GameSettingsGenerator.Generate(board);
            var game = new Game(gs);
            var moves = new List<Move>() { 
                new Move() { MoveType = "forward" }, 
                new Move() { MoveType = "rotate" }, 
                new Move() { MoveType = "forward" },
                new Move() { MoveType = "forward" }
            };
            var res = game.Start(moves);

            Assert.AreEqual(res, "Success");
        }

        [TestMethod]
        public void BombHit()
        {
            var board = new char[5][] {
                new char[]{ ' ', ' ', ' ', 'S', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ',  'B', 'X' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' }
            };

            var gs = GameSettingsGenerator.Generate(board);
            var game = new Game(gs);
            var moves = new List<Move>() {
                new Move() { MoveType = "forward" }
            };
            var res = game.Start(moves);

            Assert.AreEqual(res, "Mine Hit !");
        }

        [TestMethod]
        public void MoveOutside_NorthBoundary()
        {
            var board = new char[5][] {
                new char[]{ ' ', ' ', ' ', 'N', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ',  'B', 'X' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' }
            };

            var gs = GameSettingsGenerator.Generate(board);
            var game = new Game(gs);
            var moves = new List<Move>() {
                new Move() { MoveType = "forward" }
            };
            var res = game.Start(moves);

            Assert.AreEqual(res, "Invalid move, can't move forward");
        }

        [TestMethod]
        public void MoveOutside_EastBoundary()
        {
            var board = new char[5][] {
                new char[]{ ' ', ' ', ' ', 'E', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ',  'B', 'X' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' }
            };

            var gs = GameSettingsGenerator.Generate(board);
            var game = new Game(gs);
            var moves = new List<Move>() {
                new Move() { MoveType = "forward" },
                new Move() { MoveType = "forward" }
            };
            var res = game.Start(moves);

            Assert.AreEqual(res, "Invalid move, can't move forward");
        }

        [TestMethod]
        public void MoveOutside_WestBoundary()
        {
            var board = new char[5][] {
                new char[]{ ' ', ' ', ' ', 'W', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ',  'B', 'X' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' }
            };

            var gs = GameSettingsGenerator.Generate(board);
            var game = new Game(gs);
            var moves = new List<Move>() {
                new Move() { MoveType = "forward" },
                new Move() { MoveType = "forward" },
                 new Move() { MoveType = "forward" },
                  new Move() { MoveType = "forward" },
                   new Move() { MoveType = "forward" }
            };
            var res = game.Start(moves);

            Assert.AreEqual(res, "Invalid move, can't move forward");
        }

        [TestMethod]
        public void MoveOutside_SouthBoundary()
        {
            var board = new char[5][] {
                new char[]{ ' ', ' ', ' ', ' ', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ',  'B', 'X' },
                new char[]{ 'S', ' ', ' ', 'B', ' ' },
                new char[]{ ' ', ' ', ' ', 'B', ' ' }
            };

            var gs = GameSettingsGenerator.Generate(board);
            var game = new Game(gs);
            var moves = new List<Move>() {
                new Move() { MoveType = "forward" },
                new Move() { MoveType = "forward" }
            };
            var res = game.Start(moves);

            Assert.AreEqual(res, "Invalid move, can't move forward");
        }
    }
}
