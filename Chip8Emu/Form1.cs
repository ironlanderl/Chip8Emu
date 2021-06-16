using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chip8Emu
{
    public partial class Form1 : Form
    {
        const int HZ = 60;
        Cpu cpu;
        Grafica schermo;
        byte[] memoria = new byte[4096];


        public Form1()
        {
            InitializeComponent();

            pcbSchermo.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbSchermo.Image = new Bitmap(100, 100);
            schermo = new Grafica(pcbSchermo);

            tmrDelay.Interval = 1000 / HZ;
            tmrAudio.Interval = 1000 / HZ;
            tmrDebug.Interval = 1000 / HZ;

            cpu = new Cpu(schermo, memoria, tmrDelay, tmrAudio);
        }

        private void btnPixel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                schermo.DisegnaRandom();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            schermo.PulisciSchermo();
        }

        private void TestopCode_Click(object sender, EventArgs e)
        {
            cpu.Decodifica(textBox1.Text);
        }

        private void tmrDebug_Tick(object sender, EventArgs e)
        {
            lblDebug.Text = "";
            byte[] registri = cpu.Registri;
            for(int i = 0; i < 16; i++)
            {
                lblDebug.Text += i + "=" + registri[i] + "\n";
            }
        }
    }
}
