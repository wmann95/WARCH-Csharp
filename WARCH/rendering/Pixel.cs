using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARCH.rendering
{
    public struct Color
    {
        public float red
        {
            get;
            private set;
        }

        public float green
        {
            get;
            private set;
        }

        public float blue
        {
            get;
            private set;
        }

        public float alpha
        {
            get;
            private set;
        }

        public Color(float r, float g, float b, float a)
        {
            red = r;
            green = g;
            blue = b;
            alpha = a;
        }

        public Color()
        {
            red = green = blue = 0;
            alpha = 1;
        }
    }

    internal class Pixel
    {
        int VAO;
        int VBO;
        int EBO;
        Shader shader;
        //Color color;
        float red;
        float green;
        float blue;
        float alpha;

        Vector2 position;

        static readonly uint[] indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        public Pixel(Vector2 position)
        {
            float[] verts =
            {
                 0.5f,  0.5f, 0.0f,
                 0.5f, -0.5f, 0.0f,
                -0.5f, -0.5f, 0.0f,
                -0.5f,  0.5f, 0.0f,
            };


            VAO = GL.GenVertexArray();
            VBO = GL.GenBuffer();
            EBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, verts.Length * sizeof(float), verts, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            shader = new Shader("shader.vert", "shader.frag");

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            //color = new Color();
            red = green = blue = 0;
            alpha = 1;
            this.position = position;
        }

        public void Render(FrameEventArgs args)
        {
            GL.BindVertexArray(VAO);
            shader.Use();
            shader.SetVec4("color", new Vector4(red, green, blue, alpha));

            Matrix4 view = Matrix4.CreateTranslation(position.X, position.Y, 0f);
            Matrix4 model = Matrix4.Identity;
            Matrix4 projection = Matrix4.CreateOrthographicOffCenter(0f, 79.0f, 59f, 0f, -1f, 100.0f);

            shader.SetMatrix4("view", view);
            shader.SetMatrix4("model", model);
            shader.SetMatrix4("projection", projection);

            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        double time = 0;

        public void Update(FrameEventArgs args)
        {
            time += args.Time;
            float c = (float)Math.Sin(time) / (2.5f);
            red = green = blue = c;
            alpha = 1;
        }
    }
}
