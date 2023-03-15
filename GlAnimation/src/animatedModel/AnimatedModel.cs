using System;
using lwjgl.vector;
using animation;
using openglObjects;
using textures;

namespace animatedModel
{
	public class AnimatedModel {

		// skin
		private Vao model;
		private Texture texture;

		// skeleton
		private Joint rootJoint;
		private int jointCount;

		private Animator animator;

		public AnimatedModel(Vao model, Texture texture, Joint rootJoint, int jointCount) {
			this.model = model;
			this.texture = texture;
			this.rootJoint = rootJoint;
			this.jointCount = jointCount;
			this.animator = new Animator(this);
			rootJoint.calcInverseBindTransform(new Matrix4f());
		}
			
		public Vao getModel() {
			return model;
		}
			
		public Texture getTexture() {
			return texture;
		}
			
		public Joint getRootJoint() {
			return rootJoint;
		}
			
		public void delete() {
			model.delete();
			texture.delete();
		}
			
		public void doAnimation(Animation animation) {
			animator.doAnimation(animation);
		}

		public void update() {
			animator.update();
		}
			
		public Matrix4f[] getJointTransforms() {
			Matrix4f[] jointMatrices = new Matrix4f[jointCount];
			addJointsToArray(rootJoint, jointMatrices);
			return jointMatrices;
		}
			
		private void addJointsToArray(Joint headJoint, Matrix4f[] jointMatrices) {
			jointMatrices[headJoint.index] = headJoint.getAnimatedTransform();
			foreach (Joint childJoint in headJoint.children) {
				addJointsToArray(childJoint, jointMatrices);
			}
		}

	}
}

