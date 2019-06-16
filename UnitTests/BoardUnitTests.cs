using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsForms1;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void SquareInchesTest()
        {
            Board b = new Board(5, 2);
            double expected = 10;
            Assert.AreEqual(b.SquareInches, expected);
        }


        [TestMethod]
        public void BoardTest3()
        {
            double expectedLength = .5;
            double expectedWidth = 1;
            Board b = new Board(.5, 1);
            Assert.IsTrue(b.Length - expectedWidth <= .01);
            Assert.IsTrue(b.Width - expectedLength <= .01);
        } 
        [TestMethod]
        public void OrderAscendingTest1()
        {
            List<Board> boards = new List<Board>();
            Board b1 = new Board(10, 5);
            Board b2 = new Board(5, 6);
            Board expected1 = new Board(10, 5);
            Board expected2 = new Board(5, 6);
            boards.Add(new Board(10, 5));
            boards.Add(new Board(5, 6));
            List<Board> Actual = Board.OrderBoardsAscending(boards);
            Assert.IsTrue(Actual[0].Equals(expected2));
            Assert.IsTrue(Actual[1].Equals(expected1));

        }
        [TestMethod]
        public void OrderAssendingTest2()
        {
            List<Board> boards = new List<Board>();
            Board b2 = new Board(10, 5);
            Board b1 = new Board(5, 6);
            Board expected1 = new Board(10, 5);
            Board expected2 = new Board(5, 6);
            boards.Add(new Board(5, 6));
            boards.Add(new Board(10, 5));
            List<Board> Actual = Board.OrderBoardsAscending(boards);
            Assert.IsTrue(Actual[0].Equals(expected2));
            Assert.IsTrue(Actual[1].Equals(expected1));

        }
        [TestMethod]
        public void OrderDescendingTest1()
        {
            List<Board> boards = new List<Board>();
            Board b2 = new Board(10, 5);
            Board b1 = new Board(5, 6);
            Board expected1 = new Board(10, 5);
            Board expected2 = new Board(5, 6);
            boards.Add(new Board(5, 6));
            boards.Add(new Board(10, 5));
            List<Board> Actual = Board.OrderBoardsDescending(boards);
            Assert.IsTrue(Actual[0].Equals(expected1));
            Assert.IsTrue(Actual[1].Equals(expected2));

        }
        [TestMethod]
        public void OrderDescendingTest2()
        {
            List<Board> boards = new List<Board>();
            Board b2 = new Board(10, 5);
            Board b1 = new Board(5, 6);
            Board expected1 = new Board(10, 5);
            Board expected2 = new Board(5, 6);
            boards.Add(new Board(10, 5));
            boards.Add(new Board(5, 6));
            List<Board> Actual = Board.OrderBoardsDescending(boards);
            Assert.IsTrue(Actual[0].Equals(expected1));
            Assert.IsTrue(Actual[1].Equals(expected2));

        }

        [TestMethod]
        public void RemoveBoardFromListTest1()
        {
            List<Board> boards = new List<Board>();
            boards.Add(new Board(10, 20));
            boards.Add(new Board(20, 30));
            Board b = new Board(10, 20);
            Board c = new Board(20, 30);
            bool e = Board.RemoveBoardFromList(boards, b, 0);
            Assert.IsTrue(c.Equals(boards[0]));
            Assert.IsTrue(boards.Count == 1);
            Assert.IsTrue(e);
        }

        [TestMethod]
        public void RemoveBoardFromListTest2()
        {
            List<Board> boards = new List<Board>();
            boards.Add(new Board(10, 20));
            boards.Add(new Board(20, 30));
            Board b = new Board(10, 20);
            Board c = new Board(20, 30);
            bool e = Board.RemoveBoardFromList(boards, b, 1);
            Assert.IsFalse(c.Equals(boards[0]));
            Assert.IsTrue(boards.Count == 2);
            Assert.IsFalse(e);

        }
    }
}
