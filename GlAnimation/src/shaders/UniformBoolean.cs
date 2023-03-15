using System;
using OpenTK.Graphics.OpenGL;

namespace shaders
{
	public class UniformBoolean : Uniform
	{
		private bool currentBool;
		private bool used = false;

		public UniformBoolean (String name) : base (name)
		{
		}

		public void loadBoolean (bool value)
		{
			if (!used || currentBool != value) {
				GL.Uniform1 (base.getLocation (), value ? 1f : 0f);
				used = true;
				currentBool = value;
			}
		}
	}
}
