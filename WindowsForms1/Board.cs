using System;
using System.Collections.Generic;
using System.Linq;


namespace WindowsForms1
{
// By definition, the length of a board is always its longest side
    public class Board
    {
        public Board()
        {
            DateTime t = new DateTime();
            ID = t.Ticks;
        }

        public Board(double aLength, double aWidth)
        {
            // always make the length the longest side of the board
            if (aWidth > aLength)
            {
                Length = aWidth;
                Width = aLength;
            } else
            {
                Length = aLength;
                Width = aWidth;
            }
        /* ID is intended to be unique.  The method here may not
         * necessarily be unique, but for the few number of boards
         * it should be */
            DateTime t = new DateTime();
            ID = t.Ticks;
        }
        public long ID { get; set; }

        public Board(List<Board> aBoards)
        {
            _boards = aBoards;
        }

        private List<Board> _boards = new List<Board>();

        public double Length { get; set; }

        public double Width { get; set; }

        public long SourceBoardID { get; set; }

        public Constants.DIRECTION Direction { get; set; }

        public double SquareInches
        {
            get { return Length * Width; }
        }

        public void RotateBoard()
        {
            if (this.Length < Width)
            {
                double Length = this.Length;
                this.Length = Width;
                Width = Length;
            }
        }
        public static List<Board> OrderBoardsAscending(List<Board> boards)
        {
            if (boards.Count > Constants.MINBOARDS)
            {
                List<Board> OrderedBoards = new List<Board>();
                IEnumerable<Board> OrderedBoardQuery = from board in
                                                       boards
                                                       orderby board.Length, board.Width
                                                       select board;
                foreach (Board b in OrderedBoardQuery)
                    OrderedBoards.Add(b); 
                return OrderedBoards;
            }
            else
                return boards;

        }
        public static List<Board> OrderBoardsDescending(List<Board> boards)
        {
            if (boards.Count > 1)
            {
                List<Board> OrderedBoards = new List<Board>();
                IEnumerable<Board> OrderedBoardQuery = from board in
                                                       boards
                                                       orderby board.Length descending, board.Width
                                                       select board;
                foreach (Board b in OrderedBoardQuery)
                    OrderedBoards.Add(b);
                return OrderedBoards;
            }
            else
                return boards;
        }

        public override bool Equals(object obj)
        {
           if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
           else
            {
                Board b = (Board)obj;
                return (((Length - b.Length) < Constants.ERRORMARGIN) &&
                    ((Width - b.Width) < Constants.ERRORMARGIN));
                    
            }
        }
        public override int GetHashCode()
        {
            return ((int)Math.Floor(Length)<<2) ^ (int)Math.Floor(Width);
        }

        public override string ToString()
        {
            return String.Format("Board ({0} x {1})", Length, Width);
        }

        public static bool RemoveBoardFromList(List<Board> Boards, Board b, int i)
        {
            if (Boards[i].Equals(b) || (Boards[i].Length < Constants.ERRORMARGIN)
                || (Boards[i].Width < Constants.ERRORMARGIN))
            {
                Boards.Remove(Boards[i]);
                return true;
            }
            return false;
        }

    }
}
