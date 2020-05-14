using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhamVanLeBao_2001170836_DevAppSmart_BT1
{
    public partial class Form1 : Form
    {
        Panel pnCaro = new Panel();

        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

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
            Matrix = new List<List<Button>>();
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
                Matrix.Add(new List<Button>());
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
                    this.pnCaro.Controls.Add(btnPoint);
                    //set up handler click event
                    btnPoint.Click += btn_Click;
                    //add matrix to do save location of button handle win and lost
                    Matrix[i].Add(btnPoint);
                     
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
            
            ChangePlayer(btn);
            HandleWinandLost(btn);
        }
        private void ChangePlayer(Button btn)
        {
            if (this.isDisablePlayer)
            {
                btn.Text = "X";
                isDisablePlayer = false;
            }
            else
            {
                btn.Text = "O";
                isDisablePlayer = true;
            }
            btn.Enabled = false;
        }
        private void HandleWinandLost(Button btn)
        {
            //call vertical location of  button click   hang doc X
            int vertical = Convert.ToInt32(btn.Tag);
            int vertical2 = vertical;
            //call horizontal location of  button click hang ngang Y
            int horizontal = Matrix[vertical].IndexOf(btn);
            int horizontal2 = horizontal;
            int tren = 0, duoi = 0, trai = 0, phai = 0, cheotraitren = 0, cheophaitren = 0, dem = 1, cheotraiduoi = 0,cheophaiduoi = 0;

        
            // hander win from vertical
            for (int i = horizontal; i > 0; i--)
                {
                    // check X from better to left
                    if (Matrix[vertical][i].Text == btn.Text.ToString())
                    {
                        trai++;
                    }
                    else
                        break;
                    
                }

            for (int i = horizontal; i < int.Parse(txtCapMT.Text.ToString()); i++)
                {
                    // check X from better to right
                    if (Matrix[vertical][i].Text == btn.Text.ToString())
                    {   
                        phai++;
                    }
                    else
                        break;
                }
            if (trai + phai >= 6)
                MessageBox.Show("Player " + btn.Text.ToString() + " win");
            // hander win from horizontal
            for (int i = vertical; i > 0; i--)
            {
                // check X from better to top
                if (Matrix[i][horizontal].Text == btn.Text.ToString())
                {
                    tren++;
                }
                else
                    break;

            }

            for (int i = vertical; i < int.Parse(txtCapMT.Text.ToString()); i++)
            {
                // check X from better to bottom
                if (Matrix[i][horizontal].Text == btn.Text.ToString())
                {
                    duoi++;
                }
                else
                    break;

            }
            if (tren + duoi >= 6)
            {
                MessageBox.Show("Player " + btn.Text.ToString() + " win");
                tren = duoi = 0;
            }
                
            // hander win from cheotrai

            for (int i = 0; i <= vertical; i++)
            {
                if (vertical - i < 0 || horizontal - i < 0)
                    break;
                if (Matrix[horizontal - i][vertical - i].Text == btn.Text.ToString())
                {
                    cheotraitren++;
                }
                else
                    break;
            }

            for (int i = 1; i <= int.Parse(txtCapMT.Text.ToString()) - vertical; i++)
            {
                if (horizontal + i >= int.Parse(txtCapMT.Text.ToString()) || vertical + i >= int.Parse(txtCapMT.Text.ToString()))
                    break;

                if (Matrix[horizontal + i][vertical + i].Text == btn.Text.ToString())
                {
                    cheophaiduoi++;
                }
                else
                    break;
            }

            if(cheophaiduoi + cheotraitren == 5)
            {
                MessageBox.Show("Player " + btn.Text.ToString() + " win");
                cheophaiduoi = cheotraitren = 0;
            }


          

            for (int i = 0; i <= vertical; i++)
            {
                if (vertical + i > int.Parse(txtCapMT.Text.ToString()) || horizontal - i < 0)
                    break;

                if (Matrix[horizontal - i][vertical + i].Text == btn.Text)
                {
                    cheophaitren++;
                }
                else
                    break;
            }

            for (int i = 1; i <= int.Parse(txtCapMT.Text.ToString()) - vertical; i++)
            {
                if (horizontal + i >= int.Parse(txtCapMT.Text.ToString()) || vertical - i < 0)
                    break;

                if (Matrix[horizontal + i][vertical - i].Text == btn.Text)
                {
                    cheotraiduoi++;
                }
                else
                    break;
            }

            if (cheophaitren + cheotraiduoi >= 5)
            {
                MessageBox.Show("Player " + btn.Text.ToString() + " win");
                cheophaitren = cheotraiduoi = 0;
            }

            //player1.Text = vertical.ToString();
            //player2.Text = horizontal.ToString();

            txttren.Text = "tren :" + tren.ToString();
            txtduoi.Text = "duoi :" + duoi.ToString();
            txtphai.Text = "phai :"+phai.ToString();
            txttrai.Text = "trai :"+trai.ToString();

            txtcheotraitren.Text = "ctt :" + cheotraitren.ToString();
            txtcheotraiduoi.Text = "ctd :" + cheotraiduoi.ToString();
            txtcheophaitren.Text = "cpt :" + cheophaitren.ToString();
            txtcheophaiduoi.Text = "cpd :" + cheophaiduoi.ToString();
            tren = 0;
            duoi = 0;
            trai = 0;
            phai = 0;
            cheotraitren = 0;
            cheophaitren = 0;
            dem = 1;
            cheotraiduoi = 0;
            cheophaiduoi = 0;


        }
    }
}
