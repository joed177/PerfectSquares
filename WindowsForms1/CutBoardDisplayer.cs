using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace WindowsForms1
{
    public class CutBoardDisplayer
    {
        public CutBoardDisplayer() { }
        public CutBoardDisplayer(List<Board>aCutBoards, List<Board>aSourceBoards )
        {
            cutBoards = aCutBoards;
            sourceBoards = aSourceBoards;
        }

        public List<Board> cutBoards { get;  set; }
        public List<Board> sourceBoards { get; set; }

        private void Show(Board boardToShow, int startX, int startY)
        {
            Rectangle rect = new Rectangle(startX, startY, 
                (int)Math.Floor(boardToShow.Length), (int)Math.Floor(boardToShow.Width));

            SolidBrush b = new SolidBrush(Color.Black);
            Pen p = new Pen(b, 5);
            DrawRectangle(p, rect);
        }
    }
}
