using OpenTK.Graphics.OpenGL;
using utils;
using System.Text;
using System;
using System.IO;

namespace shaders
{
	public class ShaderProgram
	{
		private int programID;

		public ShaderProgram (MyFile vertexFile, MyFile fragmentFile,params String[] inVariables)
		{
			int vertexShaderID = loadShader (vertexFile, ShaderType.VertexShader);
			int fragmentShaderID = loadShader (fragmentFile, ShaderType.FragmentShader);
			programID = GL.CreateProgram ();
			GL.AttachShader (programID, vertexShaderID);
			GL.AttachShader (programID, fragmentShaderID);
			bindAttributes (inVariables);
			GL.LinkProgram (programID);
			GL.DetachShader (programID, vertexShaderID);
			GL.DetachShader (programID, fragmentShaderID);
			GL.DeleteShader (vertexShaderID);
			GL.DeleteShader (fragmentShaderID);
		}

		protected void storeAllUniformLocations (params Uniform[] uniforms)
		{
			foreach (Uniform uniform in uniforms) {
				uniform.storeUniformLocation (programID);
			}
			GL.ValidateProgram (programID);
		}

		public void start ()
		{
			GL.UseProgram (programID);
		}

		public void stop ()
		{
			GL.UseProgram (0);
		}

		public void cleanUp ()
		{
			stop ();
			GL.DeleteProgram (programID);
		}

		private void bindAttributes (String[] inVariables)
		{
			for (int i = 0; i < inVariables.Length; i++) {
				GL.BindAttribLocation (programID, i, inVariables [i]);
			}
		}

		private int loadShader (MyFile file, ShaderType type)
		{
			StringBuilder shaderSource = new StringBuilder ();
			try {
				StreamReader reader = file.getReader ();
				String line;
				while ((line = reader.ReadLine ()) != null) {
					shaderSource.Append (line).Append ("\n");
				}
				reader.Close ();
			} catch (Exception e) {
				Console.Error.WriteLine ("Could not read file.");
				Console.WriteLine (e);
				Environment.Exit (-1);
			}
			int shaderID = GL.CreateShader (type);
			GL.ShaderSource (shaderID, shaderSource.ToString ());
			GL.CompileShader (shaderID);
			int status;
			GL.GetShader (shaderID, ShaderParameter.CompileStatus, out status);
			if (status == (int)All.False) {
				Console.WriteLine (GL.GetShaderInfoLog (shaderID));
				Console.Error.WriteLine ("Could not compile shader " + file);
				Environment.Exit (-1);
			}
			return shaderID;
		}
	}

}
