namespace dataStructures
{
	public class SkeletonData
	{	
		public readonly int jointCount;
		public readonly JointData headJoint;

		public SkeletonData (int jointCount, JointData headJoint)
		{
			this.jointCount = jointCount;
			this.headJoint = headJoint;
		}
	}
}
