using System;

namespace  lwjgl.vector
{
	public interface WritableVector4f : WritableVector3f
	{
		void setW(float paramFloat);
		void set(float paramFloat1, float paramFloat2, float paramFloat3, float paramFloat4);
	}
}

