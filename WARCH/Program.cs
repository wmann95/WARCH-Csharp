using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using WARCH.emulator;
using WARCH.rendering;

namespace WARCH
{
    public class WARCH : GameWindow
    {
        Screen screen;
        Machine machine;

        public WARCH(int width, int height, string title) : base(new GameWindowSettings() { RenderFrequency=60, UpdateFrequency=30 }, new NativeWindowSettings() { Size = (width, height), Title = title })
        {
            screen = new Screen();
            machine = new Machine();

            /*bool running = true;
            while (running)
            {
                if (machine.halt)
                {
                    break;
                }
                machine.update();
                screen.Render();
            }*/
        }

        protected override void OnLoad()
        {
            base.OnLoad();
        }
        protected override void OnUnload()
        {
            base.OnUnload();
        }

        int updates = 0;
        int frames = 0;
        double time = 0;

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            time += args.Time;

            if(time > 1)
            {
                Console.WriteLine(updates + " " + frames);
                time = frames = updates = 0;
            }

            screen.Update(args);

            updates++;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.ClearColor(1, 1, 1, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            screen.Render(args);

            Context.SwapBuffers();

            frames++;
        }
    }

    public class Program
    {
        public static void Main(String[] args)
        {
            using(WARCH warch = new WARCH(800,600, "WARCH"))
            {
                warch.Run();
            }
        }
    }
}