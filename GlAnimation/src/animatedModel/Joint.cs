using lwjgl.vector;
using System.Collections.Generic;
using System;

namespace animatedModel
{
	public class Joint {

		public int index;// ID
		public String name;
		public List<Joint> children = new List<Joint>();

		private Matrix4f animatedTransform = new Matrix4f();

		private Matrix4f localBindTransform;
		private Matrix4f inverseBindTransform = new Matrix4f();

		public Joint(int index, String name, Matrix4f bindLocalTransform) {
			this.index = index;
			this.name = name;
			this.localBindTransform = bindLocalTransform;
		}

		public void addChild(Joint child) {
			this.children.Add(child);
		}
			
		public Matrix4f getAnimatedTransform() {
			return animatedTransform;
		}

		public void setAnimationTransform(Matrix4f animationTransform) {
			this.animatedTransform = animationTransform;
		}
			
		public Matrix4f getInverseBindTransform() {
			return inverseBindTransform;
		}
			
		public void calcInverseBindTransform(Matrix4f parentBindTransform) 
		{
			Matrix4f bindTransform = Matrix4f.mul(parentBindTransform, localBindTransform, null);
		    Matrix4f.invert(bindTransform, inverseBindTransform);
			foreach (Joint child in children) {
				child.calcInverseBindTransform(bindTransform);
			}
		}
	}
}

