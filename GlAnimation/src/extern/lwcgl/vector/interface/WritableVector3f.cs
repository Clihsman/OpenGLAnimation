using System;

namespace  lwjgl.vector
{
	public interface WritableVector3f : WritableVector2f
	{
		void setZ(float paramFloat);
		void set(float paramFloat1, float paramFloat2, float paramFloat3);
	}
}

