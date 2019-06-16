using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsForms1;

namespace UnitTests
{
    [TestClass]
    public class BoardCutterUnitTests
    {
        [TestMethod]
        public void BoardCutterTest1()
        {
            List<Board> sourceBoards = new List<Board>();
            sourceBoards.Add(new Board(96, 48));
            List<Board> boardsToCut = new List<Board>();
            boardsToCut.Add(new Board(48, 36));
            boardsToCut.Add(new Board(.5, 1)); // 1/2 calculates as the integer 0
            Board expected1 = new Board(48, 36);
            Board expected2 = new Board(.5, 1);
            BoardCutter bc = new BoardCutter(sourceBoards, boardsToCut);
            Assert.IsTrue(expected1.Equals(bc.boardsToCut[0]));
            Assert.IsTrue(expected2.Equals(bc.boardsToCut[1]));
            Assert.IsTrue(sourceBoards[0].ID == bc.boardsToCut[0].SourceBoardID);
        }

        [TestMethod]
        public void CutSourceBoardTest1()
        {
            List<Board> sourceBoards = new List<Board>();
            sourceBoards.Add(new Board(96, 48));
            List<Board> boardsToCut = new List<Board>();
            boardsToCut.Add(new Board(48, 36));
            boardsToCut.Add(new Board(36, 12)); 
            Board expected1 = new Board(48, 36);
            Board expected2 = new Board(36, 12);
            Board expectedSource1 = new Board(48, 48);
            Board expectedSource2 = new Board(12, 12);

            BoardCutter bc = new BoardCutter(sourceBoards, boardsToCut);
            bc.CutSourceBoard();
            Assert.IsTrue(expected1.Equals(bc.cutBoards[0]));
            Assert.IsTrue(expected2.Equals(bc.cutBoards[1]));
            Assert.IsTrue(expectedSource2.Equals(bc.boardsToCutFrom[0]));
            Assert.IsTrue(expectedSource1.Equals(bc.boardsToCutFrom[1]));
            Assert.IsTrue(expectedSource1.ID.Equals(bc.boardsToCut[0].SourceBoardID));
        }

        [TestMethod]
        [ExpectedException(typeof(NoBoardBigEnoughException))]
        public void CutSourceBoardTest3()
        {
            List<Board> source = new List<Board>();
            List<Board> cuts = new List<Board>();
            source.Add(new Board(50, 50));
            cuts.Add(new Board(60, 10));
            cuts.Add(new Board(10, 60));
            BoardCutter bc = new BoardCutter(source, cuts);
            bc.CutSourceBoard();
        }
        [TestMethod]
        public void CutSourceBoardTest2()
        {
            List<Board> sourceBoards = new List<Board>();
            sourceBoards.Add(new Board(96, 48));
            List<Board> boardsToCut = new List<Board>();
            boardsToCut.Add(new Board(48, 36));
            boardsToCut.Add(new Board(50, 12)); 
            Board expected1 = new Board(48, 36);
            Board expected2 = new Board(50, 12);
            Board expectedSource1 = new Board(46, 12);
            Board expectedSource3 = new Board(48, 36);

            BoardCutter bc = new BoardCutter(sourceBoards, boardsToCut);
            bc.CutSourceBoard();
            Assert.IsTrue(expected1.Equals(bc.cutBoards[1]));
            Assert.IsTrue(expected2.Equals(bc.cutBoards[0]));
            Assert.IsTrue(expectedSource3.Equals(bc.boardsToCutFrom[1]));
            Assert.IsTrue(expectedSource1.Equals(bc.boardsToCutFrom[0]));
            Assert.IsTrue(bc.boardsToCutFrom.Count==2);
        }
    }
}
