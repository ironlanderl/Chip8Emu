using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace Chip8Emu
{
    class Cpu
    {
        const int lunghezza = 64;
        const int altezza = 32;

        bool[,] screen = new bool[altezza, lunghezza];
        byte[] RAM = new byte[4096];
        UInt16 PC;
        UInt16 I;
        byte[] registri = new byte[16];
        System.Windows.Forms.Timer clock = new System.Windows.Forms.Timer();
        Stack<UInt16> stack = new Stack<ushort>();
        string instruction;

        public byte[] Registri
        {
            get
            {
                return registri;
            }
        }

        public void LoadROM(byte[] ROM)
        {
            int j = 0x200;
            for (int i = 0; i < ROM.Length; i++)
            {
                RAM[j] = ROM[i];
                j++;
            }
            Start();
        }

        private void LoadFont()
        {

        }

        public void Start()
        {
            LoadFont();
            PC = 0x200;
            clock.Tick += MainLoop;
            clock.Interval = 1;
            clock.Enabled = true;
        }

        public void MainLoop(object sender, EventArgs e)
        {
            Fetch();
            Decodifica();
        }

        public Cpu()
        {

        }

        public void Fetch()
        {
            // divide the instruction in 4 parts
            byte[] opcode = new byte[4];
            // move left to right
            opcode[0] = (byte)(RAM[PC] >> 4);
            // move right to left and back
            opcode[1] = (byte)(RAM[PC] << 4);
            opcode[1] = (byte)(opcode[1] >> 4);
            // move left to right
            opcode[2] = (byte)(RAM[PC + 1] >> 4);
            // move right to left and back
            opcode[3] = (byte)(RAM[PC + 1] << 4);
            opcode[3] = (byte)(opcode[3] >> 4);

            instruction = "";
            foreach (var item in opcode)
            {
                instruction += Convert.ToString(item, 16);
            }
            PC += 2;
        }

        public void Decodifica()
        {
            UInt16 A = UInt16.Parse(instruction.Substring(0, 1), System.Globalization.NumberStyles.HexNumber);
            UInt16 X = UInt16.Parse(instruction.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);
            UInt16 Y = UInt16.Parse(instruction.Substring(2, 1), System.Globalization.NumberStyles.HexNumber);
            UInt16 N = UInt16.Parse(instruction.Substring(3), System.Globalization.NumberStyles.HexNumber);
            byte NN = byte.Parse(instruction.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            UInt16 NNN = UInt16.Parse(instruction.Substring(1, 3), System.Globalization.NumberStyles.HexNumber);

            switch (A)
            {
                case 0:
                    if (instruction.ToUpper() == "00E0") screen = new bool[altezza, lunghezza];
                    break;
                case 1:
                    PC = NNN;
                    break;
                case 2:
                    break;
                case 3:
                    if (registri[X] == NN)
                    {
                        PC += 2;
                    }
                    break;
                case 4:
                    if (registri[X] != NN)
                    {
                        PC += 2;
                    }
                    break;
                case 5:
                    if (registri[X] == registri[Y])
                    {
                        PC += 2;
                    }
                    break;
                case 6:
                    registri[X] = NN;
                    break;
                case 7:
                    registri[X] += NN;
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 0xA:
                    I = NNN;
                    break;
                case 0xB:
                    break;
                case 0xC:
                    break;
                case 0xD:
                    byte x = (byte)(registri[X] % lunghezza);
                    byte y = (byte)(registri[Y] % altezza);
                    registri[0xF] = 0;

                    // altezza
                    for (int i = 0; i < N; i++)
                    {
                        // prendo i dati per la riga 'i' dello sprite
                        bool[] data = ConvertByteToBoolArray(RAM[I + i]);
                        // scrivo allo schermo in base alla lunghezza
                        for (int j = 0; j < 8; j++)
                        {
                            // Controllo se esco dallo schermo
                            if (x + j < lunghezza)
                            {
                                // controllo se il bit è 1
                                if (data[j])
                                {
                                    if (screen[y + i, x + j] == false)
                                    {
                                        screen[y + i, x + j] = true;
                                    }
                                    else
                                    {
                                        screen[y + i, x + j] = false;
                                        registri[0xF] = 0x1;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 0xE:
                    break;
                case 0xF:
                    break;
            }
        }

        private static bool[] ConvertByteToBoolArray(byte b)
        {
            // prepare the return result
            bool[] result = new bool[8];

            // check each bit in the byte. if 1 set to true, if 0 set to false
            for (int i = 0; i < 8; i++)
                result[i] = (b & (1 << i)) == 0 ? false : true;

            // reverse the array
            Array.Reverse(result);

            return result;
        }


        public bool[,] GetScreen()
        {
            return screen;
        }
    }
}
