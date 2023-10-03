using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARCH.rendering
{
    internal class Shader : IDisposable
    {
        int Handle;

        public Shader(string vertexPath, string fragmentPath)
        {
            int vert, frag;
            string vertSource = File.ReadAllText(vertexPath);
            string fragSource = File.ReadAllText(fragmentPath);

            vert = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vert, vertSource);

            frag = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(frag, fragSource);

            GL.CompileShader(vert);

            GL.GetShader(vert, ShaderParameter.CompileStatus, out int success);
            if(success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(vert);
                Console.WriteLine(infoLog);
            }

            GL.CompileShader(frag);

            GL.GetShader(frag, ShaderParameter.CompileStatus, out success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(frag);
                Console.WriteLine(infoLog);
            }

            Handle = GL.CreateProgram();

            GL.AttachShader(Handle, vert);
            GL.AttachShader(Handle, frag);

            GL.LinkProgram(Handle);

            GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out success);
            if(success == 0)
            {
                string infoLog = GL.GetProgramInfoLog(Handle);
                Console.WriteLine(infoLog);
            }

            GL.DetachShader(Handle, vert);
            GL.DetachShader(Handle, frag);
            GL.DeleteShader(vert);
            GL.DeleteShader(frag);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(Handle);
                disposedValue = true;
            }
        }

        ~Shader()
        {
            GL.DeleteProgram(Handle);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SetMatrix4(string name, Matrix4 mat)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            GL.UniformMatrix4(loc, true, ref mat);
        }

        public void SetVec4(string name, Vector4 vec)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            GL.Uniform4(loc, vec.X, vec.Y, vec.Z, vec.W);
        }
    }
}
