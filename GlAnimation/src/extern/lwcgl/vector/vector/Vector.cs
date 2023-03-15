using System;

namespace lwjgl.vector
{
	[Serializable]
	public abstract class Vector : ReadableVector
	{
		public float length ()
		{ 
			return (float)Math.Sqrt (lengthSquared ());
		}

		public abstract float lengthSquared ();

		public abstract Vector negate ();

		public Vector normalise ()
		{
			float len = length ();
			if (len != 0.0F) {
				float l = 1.0F / len;
				return scale (l);
			}
			throw new Exception();
		}

		public abstract Vector scale (float paramFloat);
	}
}
