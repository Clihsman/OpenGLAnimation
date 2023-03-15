using OpenTK.Graphics.OpenGL;
using System;

namespace shaders
{
	public abstract class Uniform
	{	
		private static int NOT_FOUND = -1;
	
		private String name;
		private int location;

		public Uniform (String name)
		{
			this.name = name;
		}

		public virtual void storeUniformLocation (int programID)
		{
			location = GL.GetUniformLocation (programID, name);
			if (location == NOT_FOUND) {
				Console.Error.WriteLine ("No uniform variable called " + name + " found!");
			}
		}

		public int getLocation ()
		{
			return location;
		}
	}
}
