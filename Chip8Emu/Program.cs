using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDL2;

namespace Chip8Emu
{
    static class Program
    {
        static Random rng = new Random();
        static Cpu cpu = new Cpu();

        // Create a new window given a title, size, and passes it a flag indicating it should be shown.
        static IntPtr window = SDL.SDL_CreateWindow("Chip8Emu.net",
                                              SDL.SDL_WINDOWPOS_UNDEFINED,
                                              SDL.SDL_WINDOWPOS_UNDEFINED,
                                              640,
                                              320,
                                              SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

        // Creates a new SDL hardware renderer using the default graphics device with VSYNC enabled.
        static IntPtr renderer = SDL.SDL_CreateRenderer(window,
                                              -1,
                                              SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED/* |
                                              SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC*/);

        static void Main()
        {
            // Initilizes SDL.
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine($"There was an issue initilizing SDL. {SDL.SDL_GetError()}");
            }


            // Initilizes SDL_image for use with png files.
            if (SDL_image.IMG_Init(SDL_image.IMG_InitFlags.IMG_INIT_PNG) == 0)
            {
                Console.WriteLine($"There was an issue initilizing SDL2_Image {SDL_image.IMG_GetError()}");
            }


            Menu();



            var running = true;

            SDL.SDL_RenderSetIntegerScale(renderer, SDL.SDL_bool.SDL_TRUE);
            SDL.SDL_RenderSetScale(renderer, 10, 10);

            // Main loop for the program
            while (running)
            {
                while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
                // Check to see if there are any events and continue to do so until the queue is empty.
                {
                    switch (e.type)
                    {
                        case SDL.SDL_EventType.SDL_QUIT:
                            running = false;
                            break;
                        case SDL.SDL_EventType.SDL_KEYDOWN:
                            SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);
                            SDL.SDL_RenderClear(renderer);
                            break;
                    }
                }

                // reset screen
                SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);
                SDL.SDL_RenderClear(renderer);

                // Change color to white
                SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);
                // Get the screen
                bool[,] screen = cpu.GetScreen();
                //Draw!
                for (int i = 0; i < 32; i++)
                {
                    for (int j = 0; j < 64; j++)
                    {
                        if (screen[i, j])
                            SDL.SDL_RenderDrawPoint(renderer, j, i);
                    }
                }

                // Switches out the currently presented render surface with the one we just did work on.
                SDL.SDL_RenderPresent(renderer);
            }

            // Clean up the resources that were created.
            SDL.SDL_DestroyRenderer(renderer);
            SDL.SDL_DestroyWindow(window);
            SDL.SDL_Quit();
        }

        static void Menu()
        {
            // Just load the rom
            byte[] ROM;
            ROM = File.ReadAllBytes(@"C:\path\chip8ufo.ch8");
            cpu.LoadROM(ROM);
        }
    }
}
