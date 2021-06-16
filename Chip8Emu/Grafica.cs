using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chip8Emu
{
    class Grafica
    {
        Brush brush = Brushes.Black;
        Graphics g;

        public Grafica(PictureBox picture)
        {
            g = picture.CreateGraphics();
        }



        public void PulisciSchermo()
        {
            g.Clear(Color.White);
        }

        public void DisegnaRandom()
        {
            Random rng = new Random(Guid.NewGuid().ToString().GetHashCode());
            int x = rng.Next(0, 100);
            int y = rng.Next(0, 100);         
            g.FillRectangle(brush, x, y, 1, 1);
        }


    }
}
