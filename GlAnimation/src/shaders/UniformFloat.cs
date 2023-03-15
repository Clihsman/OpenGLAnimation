using System;
using OpenTK.Graphics.OpenGL;

namespace shaders
{
	public class UniformFloat : Uniform
	{
		private float currentValue;
		private bool used = false;

		public UniformFloat (String name) : base (name)
		{
		}

		public void loadFloat (float value)
		{
			if (!used || currentValue != value) {
				GL.Uniform1 (base.getLocation (), value);
				used = true;
				currentValue = value;
			}
		}
	}
}
