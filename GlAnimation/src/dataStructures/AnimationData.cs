
namespace dataStructures
{
	public class AnimationData
	{
		public float lengthSeconds;
		public KeyFrameData[] keyFrames;

		public AnimationData (float lengthSeconds, KeyFrameData[] keyFrames)
		{
			this.lengthSeconds = lengthSeconds;
			this.keyFrames = keyFrames;
		}

	}
}
