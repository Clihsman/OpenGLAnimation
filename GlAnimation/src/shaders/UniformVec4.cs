using lwjgl.vector;
using OpenTK.Graphics.OpenGL;
using System;

namespace shaders
{
	public class UniformVec4 : Uniform
	{

		public UniformVec4 (String name) : base (name)
		{
		}

		public void loadVec4 (Vector4f vector)
		{
			loadVec4 (vector.x, vector.y, vector.z, vector.w);
		}

		public void loadVec4 (float x, float y, float z, float w)
		{
			GL.Uniform4 (base.getLocation (), x, y, z, w);
		}
	}
}
