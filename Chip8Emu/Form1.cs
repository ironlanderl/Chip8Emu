using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Chip8Emu
{
    public partial class Form1 : Form
    {
        const int HZ = 60;
        Cpu cpu;
        int l = 0;
        Timer refresh = new Timer();

        public Form1()
        {
            InitializeComponent();

            //pcbSchermo.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbSchermo.Image = new Bitmap(64, 32);

            refresh.Tick += Refresh_Tick;
            refresh.Interval = 1000 / HZ;
            refresh.Enabled = false;
            chkRefresh.Checked = false;

            tmrDebug.Interval = 1000 / HZ;
            tmrDebug.Enabled = false;


            cpu = new Cpu();
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            if (Program.refr)
            {
                bool[,] schermo = cpu.GetScreen();
                for (int i = 0; i < 32; i++)
                {
                    for (int j = 0; j < 64; j++)
                    {
                        //rtbLog.Text += schermo[j, i] == true ? "." : " ";
                        ((Bitmap)(pcbSchermo.Image)).SetPixel(j, i, schermo[j, i] == true ? Color.Black : Color.White);
                    }
                    //rtbLog.Text += "\n";
                }
                //chkRefresh.Checked = false;
                /*if (l < 60)
                {
                    Bitmap bitmap = (Bitmap)pcbSchermo.Image;
                    bitmap.Save(String.Format("C:\\path\\frames\\{0}.png", l), ImageFormat.Png);
                    l++;
                }*/
                Program.refr = false;
            }
        }

        private void TestopCode_Click(object sender, EventArgs e)
        {

        }

        private void tmrDebug_Tick(object sender, EventArgs e)
        {
            lblDebug.Text = "";
            byte[] registri = cpu.Registri;
            for (int i = 0; i < 16; i++)
            {
                lblDebug.Text += i + "=" + registri[i] + "\n";
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            if (a.ShowDialog() == DialogResult.OK)
            {
                byte[] ROM;
                ROM = File.ReadAllBytes(a.FileName);
                cpu.LoadROM(ROM);
                refresh.Enabled = true;
                chkRefresh.Checked = true;
                tmrDebug.Enabled = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh_Tick(sender, e);
        }

        private void chkRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRefresh.Checked)
            {
                refresh.Enabled = true;
            }
            else
            {
                refresh.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            int x = rng.Next(0, 65);
            int y = rng.Next(0, 33);
            ((Bitmap)(pcbSchermo.Image)).SetPixel(x, y, rng.Next(0, 2) == 1 ? Color.Black : Color.White);
        }
    }
}
