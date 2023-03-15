using System;
using lwjgl.vector;
using OpenTK.Graphics.OpenGL;

namespace shaders
{
	public class UniformVec2 : Uniform
	{

		private float currentX;
		private float currentY;
		private bool used = false;

		public UniformVec2 (String name) : base (name)
		{

		}

		public void loadVec2 (Vector2f vector)
		{
			loadVec2 (vector.x, vector.y);
		}

		public void loadVec2 (float x, float y)
		{
			if (!used || x != currentX || y != currentY) {
				this.currentX = x;
				this.currentY = y;
				used = true;
				GL.Uniform2 (base.getLocation (), x, y);
			}
		}
	}
}
