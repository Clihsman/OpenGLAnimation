using System.Collections.Generic;
using lwjgl.vector;
using System;

namespace dataStructures
{
	public class JointData
	{
		public int index;
		public String nameId;
		public Matrix4f bindLocalTransform;

		public List<JointData> children = new List<JointData> ();

		public JointData (int index, String nameId, Matrix4f bindLocalTransform)
		{
			this.index = index;
			this.nameId = nameId;
			this.bindLocalTransform = bindLocalTransform;
		}

		public void addChild (JointData child)
		{
			children.Add (child);
		}
	}
}
