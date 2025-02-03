using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ride
{
    public partial class Form1 : Form
    {
        int vbots = 10;
        int pontos = 0;
        Random rnd = new Random();
        int posicao;
        bool perdeu = false;

        public Form1()
        {
            InitializeComponent();

            Reiniciar();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Misturar()
        {
            perdeu = false;
            txtpontos.Text = "Pontos: " + pontos;
            player.Image = Properties.Resources.player;

            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && (string)y.Tag == "bot")
                {
                    posicao = this.ClientSize.Height + rnd.Next(-900, -600) + (y.Height * 13);
                    y.Top = posicao;
                }
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "bot")
                {
                    posicao = this.ClientSize.Width + rnd.Next(500, 800) + (x.Width * 10);
                    x.Left = posicao;
                }
            }
        }

        private void Reiniciar()
        {
            motor();
            vbots = 10;
            pontos = 0;
            perdeu = false;
            txtpontos.Text = "Pontos: " + pontos;
            player.Image = Properties.Resources.player;
            player.Top = 107;


            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && (string)y.Tag == "bot")
                {
                    posicao = this.ClientSize.Height + rnd.Next(-900, -600) + (y.Height * 13);
                    y.Top = posicao;
                }
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "bot")
                {
                    posicao = this.ClientSize.Width + rnd.Next(500, 800) + (x.Width * 10);
                    x.Left = posicao;
                }
            }

            timer1.Start();
        }

        private void Timer(object sender, EventArgs e)
        {
            txtpontos.Text = "Pontos: " + pontos;

            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "bot")
                {
                    x.Left -= vbots;

                    if (x.Left < -250)
                    {
                        x.Left = this.ClientSize.Width + rnd.Next(200, 500) + (x.Width * 15);
                        Misturar();
                        pontos += 4;

                        if (pontos == 100)
                        {
                            timer1.Stop();
                            MessageBox.Show("Parabéns, você atingiu os 100 pontos!");
                            Reiniciar();
                        }
                    }
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer1.Stop();
                        txtpontos.Text += " Pressione R para reiniciar o jogo";
                        perdeu = true;
                    }
                }
            }

            if (pontos > 5)
            {
                vbots = 15;
            }
            if (pontos > 15)
            {
                vbots = 25;
            }
            if (pontos > 25)
            {
                vbots = 35;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                cima_Click(sender,e);
            }
            if (e.KeyCode == Keys.S)
            {
                baixo_Click(sender, e);
            }
        }

        private void cima_Click(object sender, EventArgs e)
        {
            if (player.Top > 0)
            {
                player.Top = player.Top - 17;
            }
        }

        private void baixo_Click(object sender, EventArgs e)
        {
            if (player.Top < 99999999999999999)
            {
                player.Top = player.Top + 17;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && perdeu == true)
            {
                Reiniciar();
            }
            if (e.KeyCode == Keys.H && perdeu == false)
            {
                motor();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
