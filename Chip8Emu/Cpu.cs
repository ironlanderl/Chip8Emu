using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chip8Emu
{
    class Cpu
    {
        Grafica schermo;
        byte[] memoria;
        UInt16 indirizzo = 0x0000;
        UInt16 PC;
        UInt16 I;
        byte[] registri = new byte[16];
        Timer delay;
        Timer audio;

        public byte[] Registri
        {
            get
            {
                return registri;
            }
        }




        public Cpu(Grafica schermo, byte[] memoria, Timer delay, Timer audio)
        {
            this.schermo = schermo;
            this.memoria = memoria;
            this.delay = delay;
            this.audio = audio;
        }



        public void Decodifica(string istruzione)
        {
            if (istruzione.ToString().StartsWith("0"))
            {
                if (istruzione == "00E0") PulisciSchermo();
            }
            else if (istruzione.ToString().StartsWith("1"))
            {
                indirizzo = UInt16.Parse(istruzione.Substring(1), System.Globalization.NumberStyles.HexNumber);
            }
            else if (istruzione.ToString().StartsWith("2"))
            {

            }
            else if (istruzione.ToString().StartsWith("3"))
            {

            }
            else if (istruzione.ToString().StartsWith("4"))
            {

            }
            else if (istruzione.ToString().StartsWith("5"))
            {

            }
            else if (istruzione.ToString().StartsWith("6"))
            {
                istruzione = istruzione.Substring(1);
                int x = Int32.Parse(istruzione.Substring(0,1), System.Globalization.NumberStyles.HexNumber);
                istruzione = istruzione.Substring(1);
                byte nn = Byte.Parse(istruzione, System.Globalization.NumberStyles.HexNumber);
                registri[x] = nn;
            }
            else if (istruzione.ToString().StartsWith("7"))
            {
                istruzione = istruzione.Substring(1);
                int x = Int32.Parse(istruzione.Substring(0, 1), System.Globalization.NumberStyles.HexNumber);
                istruzione = istruzione.Substring(1);
                byte nn = Byte.Parse(istruzione, System.Globalization.NumberStyles.HexNumber);
                registri[x] += nn;
            }
            else if (istruzione.ToString().StartsWith("8"))
            {

            }
            else if (istruzione.ToString().StartsWith("9"))
            {

            }
            else if (istruzione.ToString().StartsWith("A"))
            {

            }
            else if (istruzione.ToString().StartsWith("B"))
            {

            }
            else if (istruzione.ToString().StartsWith("C"))
            {

            }
            else if (istruzione.ToString().StartsWith("D"))
            {

            }
            else if (istruzione.ToString().StartsWith("E"))
            {

            }
            else if (istruzione.ToString().StartsWith("F"))
            {

            }
        }










        private void PulisciSchermo()
        {
            schermo.PulisciSchermo();
        }

    }
}
