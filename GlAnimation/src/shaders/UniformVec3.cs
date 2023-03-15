using lwjgl.vector;
using System;
using OpenTK.Graphics.OpenGL;

namespace shaders
{
	public class UniformVec3 : Uniform
	{
		private float currentX;
		private float currentY;
		private float currentZ;
		private bool used = false;

		public UniformVec3 (String name) : base (name)
		{
		}

		public void loadVec3 (Vector3f vector)
		{
			loadVec3 (vector.x, vector.y, vector.z);
		}

		public void loadVec3 (float x, float y, float z)
		{
			if (!used || x != currentX || y != currentY || z != currentZ) {
				this.currentX = x;
				this.currentY = y;
				this.currentZ = z;
				used = true;
				GL.Uniform3 (base.getLocation (), x, y, z);
			}
		}
	}
}
