using xmlParser;
using dataStructures;
using System;
using System.Collections.Generic;
using GlAnimation;

namespace colladaLoader
{

	public class SkinLoader
	{

		private XmlNode skinningData;
		private int maxWeights;

		public SkinLoader (XmlNode controllersNode, int maxWeights)
		{
			this.skinningData = controllersNode.getChild ("controller").getChild ("skin");
			this.maxWeights = maxWeights;
		}

		public SkinningData extractSkinData ()
		{
			List<String> jointsList = loadJointsList ();
			float[] weights = loadWeights ();
			XmlNode weightsDataNode = skinningData.getChild ("vertex_weights");
			int[] effectorJointCounts = getEffectiveJointsCounts (weightsDataNode);
			List<VertexSkinData> vertexWeights = getSkinData (weightsDataNode, effectorJointCounts, weights);
			return new SkinningData (jointsList, vertexWeights);
		}

		private List<String> loadJointsList ()
		{
			XmlNode inputNode = skinningData.getChild ("vertex_weights");
			String jointDataId = inputNode.getChildWithAttribute ("input", "semantic", "JOINT").getAttribute ("source")
				.Substring (1);
			XmlNode jointsNode = skinningData.getChildWithAttribute ("source", "id", jointDataId).getChild ("Name_array");
			String[] names = jointsNode.getData ().Split (' ');
			List<String> jointsList = new List<String> ();
			foreach (String name in names) {
				jointsList.Add (name);
			}
			return jointsList;
		}

		private float[] loadWeights ()
		{
			XmlNode inputNode = skinningData.getChild ("vertex_weights");
			String weightsDataId = inputNode.getChildWithAttribute ("input", "semantic", "WEIGHT").getAttribute ("source")
				.Substring (1);
			XmlNode weightsNode = skinningData.getChildWithAttribute ("source", "id", weightsDataId).getChild ("float_array");
			String[] rawData = weightsNode.getData ().Split (' ');
			float[] weights = new float[rawData.Length];
			for (int i = 0; i < weights.Length; i++) {
				weights [i] = float.Parse (rawData [i]);
			}
			return weights;
		}

		private int[] getEffectiveJointsCounts (XmlNode weightsDataNode)
		{
			string[] rawData = weightsDataNode.getChild ("vcount").getData ().Split(' ');

			int[] counts = new int[rawData.Length];
			for (int i = 0; i < counts.Length; i++) {
				int.TryParse (rawData [i], out counts [i]);
			}

			return counts;
		}

		private List<VertexSkinData> getSkinData (XmlNode weightsDataNode, int[] counts, float[] weights)
		{
			String[] rawData = weightsDataNode.getChild ("v").getData ().Split (' ');
			List<VertexSkinData> skinningData = new List<VertexSkinData> ();
			int pointer = 0;

			foreach (int count in counts)
			{
				VertexSkinData skinData = new VertexSkinData ();
				for (int i = 0; i < count; i++) {
					int jointId = int.Parse (rawData [pointer++]);
					int weightId = int.Parse (rawData [pointer++]);

					skinData.addJointEffect (jointId, weights [weightId]);
				}
				skinData.limitJointNumber (maxWeights);
				skinningData.Add (skinData);
			}

			return skinningData;
		}
	}
}
