using System;
using OpenTK.Graphics.OpenGL;

namespace shaders
{

	public class UniformSampler : Uniform
	{

		private int currentValue;
		private bool used = false;

		public UniformSampler (String name) : base (name)
		{
		}

		public void loadTexUnit (int texUnit)
		{
			if (!used || currentValue != texUnit) {
				GL.Uniform1 (base.getLocation (), texUnit);
				used = true;
				currentValue = texUnit;
			}
		}
	}
}
