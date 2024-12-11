using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOGO_DA_VELHA
{
    public partial class Form1 : Form
    {
        int xplayer = 0, oplayer = 0, emapatepontos = 0, rodadas = 0;
        bool turn = true, final_game = false;
        string[] texto = new string[9];

        private void btnlim_Click(object sender, EventArgs e)
        {
            bnt.Text = "";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            rodadas = 0;
            final_game = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void bnt_Click(object sender, EventArgs e)
        {
            Button bnt = (Button)sender;
            int buttonIndex = bnt.TabIndex;
            
            if (bnt.Text == "" && final_game == false)
            {
                if (turn)
                {
                    bnt.Text = "X";
                    texto[buttonIndex] = bnt.Text;
                    rodadas++;
                    turn = !turn;
                    Checagem(1);
                }
                else
                {
                    bnt.Text = "O";
                    texto[buttonIndex] = bnt.Text;
                    rodadas++;
                    turn = !turn;
                    Checagem(2);
                }
            }

        }

        void Checagem(int ChecagemPlayer)
        {
            string suporte = "";

            if (ChecagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Winner(ChecagemPlayer);
                        return;
                    }
                }
            }

            for (int vertical = 0; vertical < 3; vertical ++)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Winner(ChecagemPlayer);
                        return;
                    }
                }
            }

            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    Winner(ChecagemPlayer);
                    return;
                }
            }

            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Winner(ChecagemPlayer);
                    return;
                }
            }

            if (rodadas == 9 && final_game == false)
            {
                emapatepontos++;
                empates.Text = Convert.ToString(emapatepontos);
                MessageBox.Show("Deu Véia!!!");
                final_game = true;
                return;
            }

        }

        void Winner (int PlayerWhoWins)
        {
            final_game = true;
            if (PlayerWhoWins == 1)
            {
                xplayer++;
                xpontos.Text = Convert.ToString(xplayer);
                MessageBox.Show("X ganhou!!");
                turn = true;
            }
            else
            {
                oplayer++;
                opontos.Text = Convert.ToString(oplayer);
                MessageBox.Show("O ganhou!!");
                turn = false;
            }
        }
    }
}
