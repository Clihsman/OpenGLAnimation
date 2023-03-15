using System;
using lwjgl.vector;

namespace dataStructures
{
	public class JointTransformData
	{

		public String jointNameId;
		public Matrix4f jointLocalTransform;

		public JointTransformData (String jointNameId, Matrix4f jointLocalTransform)
		{
			this.jointNameId = jointNameId;
			this.jointLocalTransform = jointLocalTransform;
		}
	}
}
