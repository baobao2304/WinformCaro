using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibraryOfBao;
namespace PhamVanLeBao_2001170836_DevAppSmart_BT1
{
    public partial class Form1 : Form
    {
        Panel pnCaro = new Panel();
        private int[,] matrix = new int[50,50];
        //private List<List<Button>> matrix;
        AlgorithmsHandle handlegame = new AlgorithmsHandle();
        //public List<List<Button>> Matrix
        //{
        //    get { return matrix; }
        //    set { matrix = value; }
        //}

        // isDisablePlayer use to do change player
        bool isDisablePlayer = true;
        public Form1()
        {
            InitializeComponent();
            btnCreateMatrix.Enabled = false;
        }

        private void InitializeMatrixCaroComponent()
        {



        }


        private void txtCapMT_KeyPress(object sender, KeyPressEventArgs e)
        {

            this.Controls.Remove(pnCaro);
          
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm  , bo di la khong co dau cham
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //btnCreateMatrix_Click  call matrix with textbox setup 
        private void btnCreateMatrix_Click(object sender, EventArgs e)
        {
            //create matrix add button to do control win and lost
            // set up panel caro
            pnCaro.Size = new Size(1000, 400);
            pnCaro.BackColor = Color.White;
            pnCaro.Top = 150;
            pnCaro.Left = 10;
            pnCaro.AutoScroll = true;

            int left = 3;
            int top = 10;
            this.Controls.Add(pnCaro);
            for (int i = 0; i < int.Parse(this.txtCapMT.Text.ToString()); i++)
            {
                
                for (int j = 0; j < int.Parse(this.txtCapMT.Text.ToString()); j++)
                {
                    Button btnPoint = new Button();
                    btnPoint.Size = new Size(30, 30);
                    btnPoint.Left = left + 33;
                    btnPoint.Top = top;
                    left += 33;
                    btnPoint.BackColor = Color.Gray;
                    btnPoint.Text = "";
                    //set up vertical for button;
                    btnPoint.Tag = i.ToString();
                    btnPoint.Name = j.ToString();
                    this.pnCaro.Controls.Add(btnPoint);
                    //set up handler click event
                    btnPoint.Click += btn_Click;
                    //add matrix to do save location of button handle win and lost
                    matrix[i, j] = -2;
                }
                top += 30;
                left = 3;
            }


        }
        private void txtCapMT_TextChanged(object sender, EventArgs e)
        {
            if (txtCapMT.Text == "")
            {
                txtCapMT.Text = "0";
            }
            int txtCapMTparse = int.Parse(txtCapMT.Text.ToString());
            
            if (txtCapMTparse > 6)
                btnCreateMatrix.Enabled = true;
            else
                btnCreateMatrix.Enabled = false;
            if (txtCapMTparse > 50)
                btnCreateMatrix.Enabled = false;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //btnPoint.Tag = i.ToString();
            //btnPoint.Name = j.ToString();
            int i = int.Parse(btn.Tag.ToString());
            int j = int.Parse(btn.Name.ToString());
            int button;
            int length = int.Parse(txtCapMT.Text.ToString());
            int tren = 0, duoi = 0, trai = 0, phai = 0, cheotraitren = 0, cheophaitren = 0, dem = 1, cheotraiduoi = 0, cheophaiduoi = 0;
            ChangePlayer(btn);
            if (btn.Text == "X")
                button = 1;
            else
                button = 0;
            //MessageBox.Show("point"+i+","+j);
            //HandleWinandLost(i,j, length, button);
            
            //if (HandleWinandLost(i, j, length, button) != -1)
            if (handlegame.HandleWinandLost(i, j, length, button, matrix) != -1)
                MessageBox.Show("Playerr" + btn + ": WIN");


            txttren.Text = "tren :" + tren.ToString();
            txtduoi.Text = "duoi :" + duoi.ToString();
            txtphai.Text = "phai :" + phai.ToString();
            txttrai.Text = "trai :" + trai.ToString();

            txtcheotraitren.Text = "ctt :" + cheotraitren.ToString();
            txtcheotraiduoi.Text = "ctd :" + cheotraiduoi.ToString();
            txtcheophaitren.Text = "cpt :" + cheophaitren.ToString();
            txtcheophaiduoi.Text = "cpd :" + cheophaiduoi.ToString();
            tren = 0;
            duoi = 0;
            trai = 0/*;*/
            phai = 0;
            cheotraitren = 0;
            cheophaitren = 0;
            dem = 1;
            cheotraiduoi = 0;
            cheophaiduoi = 0;

        }
        private void ChangePlayer(Button btn)
        {
            //btnPoint.Tag = i.ToString();
            //btnPoint.Name = j.ToString();
            int i =  int.Parse(btn.Tag.ToString());
            int j = int.Parse(btn.Name.ToString());
            if (this.isDisablePlayer)
            {
                
                btn.Text = "X";
                isDisablePlayer = false;
                matrix[i,j] = 1;
            }
            else
            {
                btn.Text = "O";
                isDisablePlayer = true;
                matrix[i, j] = 0;
            }
            btn.Enabled = false;
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {

        }
    }
}
