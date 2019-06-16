using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsForms1
{
    public class BoardCutter
    {
        public BoardCutter()
        {

        }
        public BoardCutter(List<Board> sourceBoards, List<Board> boardsToBeCut)
        {
            boardsToCutFrom = Board.OrderBoardsAscending(sourceBoards);
            boardsToCut = Board.OrderBoardsDescending(boardsToBeCut);
        }

        public List<Board> boardsToCutFrom = new List<Board>();
        public List<Board> boardsToCut = new List<Board>();
        public List<Board> cutBoards = new List<Board>();

         public void CutSourceBoard()
         {
            foreach (Board b in boardsToCut)
            {
                int i = FindBoardToCutFrom(b);
                b.SourceBoardID = boardsToCutFrom[i].ID;
                Constants.DIRECTION direction = DetermineDirectionOfCut(b, i);
                b.Direction=direction;
                AdjustSourceBoardDimensions(b, i, direction);
                cutBoards.Add(b);
                ManageScrap(b, i, direction);
                Board.RemoveBoardFromList(boardsToCutFrom, b, i);
                boardsToCutFrom = Board.OrderBoardsAscending(boardsToCutFrom);

            }
         }

        private void AdjustSourceBoardDimensions(Board b, int i, Constants.DIRECTION direction)
        {
            if(direction == Constants.DIRECTION.LENGTH)
                boardsToCutFrom[i].Width = boardsToCutFrom[i].Width - b.Width; 
            else
                boardsToCutFrom[i].Length = boardsToCutFrom[i].Length - b.Width;
        }

        private Constants.DIRECTION DetermineDirectionOfCut(Board b, int i)
        {
            if (boardsToCutFrom[i].Width >= b.Length)
                return Constants.DIRECTION.WIDTH;
            else
                return Constants.DIRECTION.LENGTH;
        }

        private int FindBoardToCutFrom(Board b)
        {
            for (int i = 0; i < boardsToCutFrom.Count; i++)
            {
                if ((b.Length > boardsToCutFrom[i].Length) || (b.Width > boardsToCutFrom[i].Width))
                    continue;
                else return i;
            }
            throw new NoBoardBigEnoughException(string.Format(
                "No board big enough to cut board {0} x {1}", b.Length, b.Width));
        }

        private void ManageScrap(Board b, int i, Constants.DIRECTION direction)
        {
            TrimCutBoard(b, i, direction);
            boardsToCutFrom[i].RotateBoard();
        }

        private void TrimCutBoard(Board b, int i, Constants.DIRECTION direction)
        {
            // Add scrap from cutting cut board to final size to boards to be cut 
            // from
            Board savedboardToCutFrom = new Board();
            savedboardToCutFrom = boardsToCutFrom[i];
            if (direction == Constants.DIRECTION.LENGTH)
                TrimBoardWidthAndAdd(savedboardToCutFrom, b,i);
            else
                TrimBoardLengthAndAdd(savedboardToCutFrom, b,i);
        }

        private void TrimBoardWidthAndAdd(Board savedboardToCutFrom, Board b, int i)
        {
            if (b.Length < savedboardToCutFrom.Length)
            {
                boardsToCutFrom.Add(new Board(savedboardToCutFrom.Length - b.Length,
                    b.Width));
                boardsToCutFrom.Last().SourceBoardID = b.ID;
                boardsToCutFrom.Last().Direction = Constants.DIRECTION.WIDTH;
            }
        }

        private void TrimBoardLengthAndAdd(Board savedBoard, Board b, int i)
        {
            if (b.Length < savedBoard.Width)
            {
                boardsToCutFrom.Add(new Board(savedBoard.Width - b.Length, b.Width));
                boardsToCutFrom.Last().SourceBoardID = b.ID;
                boardsToCutFrom.Last().Direction = Constants.DIRECTION.LENGTH;
            }

        }
    }
}
