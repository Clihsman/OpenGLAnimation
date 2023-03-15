using System;
using lwjgl.vector;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace shaders
{
	public class UniformMatrix : Uniform
	{

		public UniformMatrix (String name) : base (name)
		{
		} 

		public void loadMatrix (Matrix4f matrix)
		{
			GL.UniformMatrix4 (base.getLocation (),1, false, matrix.toArray());
		}
	
	}

}
