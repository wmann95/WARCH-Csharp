
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARCH.rendering
{
    internal class Screen
    {
        Pixel[] pixels;

        public Screen()
        {
            pixels = new Pixel[80 * 60];

            for(int y = 0; y < 60; y++)
            {
                for(int x = 0; x < 80; x++)
                {
                    pixels[y * 80 + x] = new Pixel(new Vector2(x, y));
                }
            }
        }
        ~Screen()
        {

        }

        public void Render(FrameEventArgs args)
        {
            for(int i = 0; i < pixels.Length; i++)
            {
                //pixels[i].Render(args);
            }

            /*foreach(Pixel pixel in pixels) {
                pixel.Render(args);
            }*/
        }

        internal void Update(FrameEventArgs args)
        {
            for (int i = 0; i < pixels.Length; i++)
            {
                //pixels[i].Update(args);
            }

            /*foreach (Pixel pixel in pixels)
            {
                pixel.Update(args);
            }*/
        }
    }
}
