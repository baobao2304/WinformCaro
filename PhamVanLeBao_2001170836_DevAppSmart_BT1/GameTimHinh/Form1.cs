using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTimHinh
{
    struct item
    {
        public int id;
        public int checkDem;
    }
    struct buttoncheck
    {
        public int i, j;
    }
    public partial class Form1 : Form
    {
        private int check1,check2,checktaohinh= -1,checkwin = 0 ;
        Panel pnBanCo = new Panel();
        private item[] matrix = new item[50];
        private List<List<Button>> matrixbtn;
        private buttoncheck btncheck1, btncheck2;
        int nhapSo ;

        public Form1()
        {
            InitializeComponent();
            check1 = check2 = -1;
            
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            // MessageBox.Show(btn.TabIndex.ToString());

            if(checktaohinh == 1)
            {
                MessageBox.Show("chưa bấm nút start ");
                return;
            }
            btn.Text = btn.Name;
          
            if (check1 == -1)
            {
                check1 = int.Parse(btn.Name);
                btncheck1.i = int.Parse(btn.Tag.ToString());
                btncheck1.j = btn.TabIndex;
                //MessageBox.Show( "i :"+ btn.Tag.ToString() + "   j :  "+ btn.TabIndex.ToString());
            }

            else
            {
                if (check2 == -1)
                {
                    check2 = int.Parse(btn.Name);
                    btncheck2.i = int.Parse(btn.Tag.ToString());
                    btncheck2.j = btn.TabIndex;
                    //MessageBox.Show("i2 :" + btn.Tag.ToString() + "   j2 :  " + btn.TabIndex.ToString());
                }

            }

            if (btncheck1.i == btncheck2.i && btncheck1.j == btncheck2.j)
            {
                matrixbtn[btncheck1.i][btncheck1.j].Text = "";
                matrixbtn[btncheck2.i][btncheck2.j].Text = "";
                check1 = check2 = -1;
                return;
            }

            if (check1 == check2 && check1 != -1 && check2 != -1 )
            {
                matrixbtn[btncheck1.i][btncheck1.j].BackColor = Color.Red;
                matrixbtn[btncheck2.i][btncheck2.j].BackColor = Color.Red;
                matrixbtn[btncheck1.i][btncheck1.j].Enabled = true;
                matrixbtn[btncheck2.i][btncheck2.j].Enabled = true;
                checkwin++;
                check1 = check2 = -1;
            }
            else if(check1 != check2 && check1 != -1 && check2 != -1)
            {
                //MessageBox.Show("2 hinh không giống nhau ");
                matrixbtn[btncheck1.i][btncheck1.j].Text = "";
                matrixbtn[btncheck2.i][btncheck2.j].Text = "";
                check1 = check2 = -1;
            }

            if(checkwin == nhapSo * 2)
            {
                
                MessageBox.Show("Chuc mung ban da chien thang");
            }    
        }

        private void btnTaoHinh_Click(object sender, EventArgs e)
        {
            checktaohinh = 1;
            nhapSo = int.Parse(txtNhapSo.Text.ToString());
            if (nhapSo > 5)
            {
                MessageBox.Show("vui long nhap so duoi 4 ");
                txtNhapSo.Text = "";
                return ;
            }
            if (nhapSo % 2 == 1)
            {
                MessageBox.Show("vui long nhap so chan ");
                txtNhapSo.Text = "";
                return;
            }
            for (int o = 0; o < nhapSo*2; o++)
            {
                matrix[o].id = o;
                matrix[o].checkDem = 2;
            }
            pnBanCo.Size = new Size(1500, 600);
            pnBanCo.BackColor = Color.White;
            pnBanCo.Top = 150;
            pnBanCo.Left = 10;
            pnBanCo.AutoScroll = true;
            int left = 6;
            int top = 60;
            this.Controls.Add(pnBanCo);
            matrixbtn = new List<List<Button>>();
            for (int i = 0; i < nhapSo; i++)
            {
                matrixbtn.Add(new List<Button>());
                for (int j = 0; j < nhapSo; j++)
                {
                    Button btnPoint = new Button();
                    btnPoint.Size = new Size(60, 60);
                    btnPoint.Left = left + 66;
                    btnPoint.Top = top;
                    left += 66;
                    btnPoint.BackColor = Color.Gray;
                    btnPoint.Text = "";
                    btnPoint.Click += btn_Click;

                    btnPoint.Tag = i.ToString();
                    btnPoint.TabIndex = j;



                    
                    matrixbtn[i].Add(btnPoint);
                    this.pnBanCo.Controls.Add(btnPoint);

                }
                top += 70;
                left = 6;
            }


            btnTaoHinh.Enabled = true;
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            timer1.Start();
            checktaohinh = 0;
            Random rdm = new Random();
            int imgRdm = -1;
            int nhapSoRD = nhapSo;
            bool checkAddImg = false;
            bool checkExist = false;
            //kiểm tra mảng matrix có hình trùng
            for (int i = 0; i < nhapSo; i++)
            {
                for(int j = 0; j < nhapSo; j++)
                {
                    for (; ; )
                    {
                        //mỗi hình chỉ được random 2 lần  nếu random không thành công thì  random lại cho tới khi đúng .

                        imgRdm = rdm.Next(0, nhapSoRD * 2);
                        for (int u = 0; u < nhapSo * 2; u++)
                        {
                            if (imgRdm == matrix[u].id)
                            {
                                if (matrix[u].checkDem == 0)
                                {
                                    if (imgRdm == nhapSoRD * 2)
                                        nhapSoRD--;

                                    Console.WriteLine("so nay da het" + imgRdm);
                                    break;
                                }
                                else
                                {

                                    matrixbtn[i][j].Name = imgRdm.ToString();
                                    Console.WriteLine("Doc so random " + imgRdm);
                                    matrix[u].checkDem--;
                                    checkAddImg = true;
                                    break;

                                }
                            }
                        }
                        if (checkAddImg)
                        {
                            checkAddImg = false;
                            break;
                        }

                    }
                }
            }
           
        }

        private void txtNhapSo_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }
    }
}
