using System;

namespace lwjgl.vector
{
	[Serializable]
	public abstract class Matrix
	{
		public abstract Matrix setIdentity();

		public abstract Matrix invert();

		public abstract Matrix negate();

		public abstract Matrix transpose();

		public abstract Matrix setZero();

		public abstract float determinant();
	}
}

