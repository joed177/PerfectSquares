using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsForms1
{
    public partial class WoodCutterStart : Form
    {
        public WoodCutterStart()
        {
            InitializeComponent();
        }

        public List<Board> Boards;
        public List<Board> sourceBoards;
 
        private void BtnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                Board board = new Board();
                board.Length = txtLength.Text.ConvertMixedNumberToDecimal();
                board.Width = txtWidth.Text.ConvertMixedNumberToDecimal();
                Boards.Add(board);
            }
            catch (DivideByZeroException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (NotAFractionException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (NotAMixedNumberException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (NotAnIntegerException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;

            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
                
        }

        private void WoodCutterStart_Load(object sender, EventArgs e)
        {

        }

          private void BtnShowCuts_Click(object sender, EventArgs e)
        {
            List<Board> OrderedBoards = new List<Board>();
            OrderedBoards = Boards.OrderBy(o => o.SquareInches).ToList();

            foreach (Board b in OrderedBoards)
            {
                if (b.SquareInches > sourceBoards[0].SquareInches)
                {
                    throw new ApplicationException(string.Format("Board of length {0}, width {1} is to big to be cut from source board", b.Length, b.Width));
                }
                else
                {
                }
            }
        }

        private void BtnSource_Click(object sender, EventArgs e)
        {
            Board sourceBoard = new Board();
            sourceBoard.Length = txtSourceLength.Text.ConvertFractionToDecimal();
            sourceBoard.Width = txtSourceWidth.Text.ConvertMixedNumberToDecimal();
            sourceBoards.Add(sourceBoard);

        }
    }
}
