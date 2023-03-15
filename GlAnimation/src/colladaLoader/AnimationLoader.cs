using lwjgl.vector;
using System.Collections.Generic;
using OpenTK;
using xmlParser;
using dataStructures;
using System;

namespace colladaLoader
{
	public class AnimationLoader
	{	
		private static readonly Matrix4f CORRECTION = new Matrix4f ().rotate ((float)MathHelper.DegreesToRadians (-90), new Vector3f (1, 0, 0));
	
		private XmlNode animationData;
		private XmlNode jointHierarchy;

		public AnimationLoader (XmlNode animationData, XmlNode jointHierarchy)
		{
			this.animationData = animationData;
			this.jointHierarchy = jointHierarchy;
		}

		public AnimationData extractAnimation ()
		{
			String rootNode = findRootJointName ();
			float[] times = getKeyTimes ();
			float duration = times [times.Length - 1];
			KeyFrameData[] keyFrames = initKeyFrames (times);
			List<XmlNode> animationNodes = animationData.getChildren ("animation");
			foreach (XmlNode jointNode in animationNodes) {
				loadJointTransforms (keyFrames, jointNode, rootNode);
			}
			return new AnimationData (duration, keyFrames);
		}

		private float[] getKeyTimes ()
		{
			XmlNode timeData = animationData.getChild ("animation").getChild ("source").getChild ("float_array");
			String[] rawTimes = timeData.getData ().Split (' ');
			float[] times = new float[rawTimes.Length];
			for (int i = 0; i < times.Length; i++) {
				times [i] = float.Parse (rawTimes [i]);
			}
			return times;
		}

		private KeyFrameData[] initKeyFrames (float[] times)
		{
			KeyFrameData[] frames = new KeyFrameData[times.Length];
			for (int i = 0; i < frames.Length; i++) {
				frames [i] = new KeyFrameData (times [i]);
			}
			return frames;
		}

		private void loadJointTransforms (KeyFrameData[] frames, XmlNode jointData, String rootNodeId)
		{
			String jointNameId = getJointName (jointData);
			String dataId = getDataId (jointData);
			XmlNode transformData = jointData.getChildWithAttribute ("source", "id", dataId);
			String[] rawData = transformData.getChild ("float_array").getData ().Split (' ');
			processTransforms (jointNameId, rawData, frames, jointNameId.Equals (rootNodeId));
		}

		private String getDataId (XmlNode jointData)
		{
			XmlNode node = jointData.getChild ("sampler").getChildWithAttribute ("input", "semantic", "OUTPUT");
			return node.getAttribute ("source").Substring (1);
		}

		private String getJointName (XmlNode jointData)
		{
			XmlNode channelNode = jointData.getChild ("channel");
			String data = channelNode.getAttribute ("target");
			return data.Split ('/') [0];
		}

		private void processTransforms (String jointName, String[] rawData, KeyFrameData[] keyFrames, bool root)
		{
			float[] matrixData = new float[16];
			for (int i = 0; i < keyFrames.Length; i++) {
				for (int j = 0; j < 16; j++) {
					matrixData [j] = float.Parse (rawData [i * 16 + j]);
				//	Console.WriteLine (matrixData[j]);
				}

				Matrix4f transform = new Matrix4f ();
				transform.load (matrixData);
				transform.transpose ();
				if (root) {
					//because up axis in Blender is different to up axis in game
					Matrix4f.mul (CORRECTION, transform, transform);
				}

				keyFrames [i].addJointTransform (new JointTransformData (jointName, transform));
			}
		}

		private String findRootJointName ()
		{
			XmlNode skeleton = jointHierarchy.getChild ("visual_scene").getChildWithAttribute ("node", "id", "Armature");
			return skeleton.getChild ("node").getAttribute ("id");
		}


	}

}